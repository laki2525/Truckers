using MetroFramework.Forms;
using Neo4j.Driver;

namespace Truckers.Forms
{
    public partial class AddDeleteForm : MetroForm
    {
        private IDriver? _driver;

        public AddDeleteForm(IDriver driver)
        {
            InitializeComponent();
            _driver = driver;
        }

        #region ADD        
        public void AddCity(string name, int population, double longitude, double latitude)
        {
            using var session = _driver?.AsyncSession();
            session?.RunAsync($"CREATE (n:City {{name: '{name}', population: {population},  latitude: {latitude}, longitude: {longitude}}})");
        }

        public void AddHighway(string cityAName, string cityBName, string name, int distance)
        {
            using var session = _driver?.AsyncSession();
            session?.RunAsync($"MATCH (a:City),(b:City) WHERE a.name = '{cityAName}' AND b.name = '{cityBName}' " +
                              $"CREATE (a)-[r:CONNECTED_BY {{name: '{name}', distance: {distance}}}]->(b)");
        }

        public async void AddTruck(string truckName, string cityName)
        {
            using var session = _driver?.AsyncSession();
            var result = await (session ?? throw new Exception("session is null")).RunAsync($"MATCH (t:Truck) WHERE t.name = '{truckName}' RETURN COUNT(t) ").Result.SingleAsync();

            if (result[0].As<long>() == 0)
            {
                Random random = new();
                double minRadius = 0.03;
                double maxRadius = 0.06;
                double radius = minRadius + (random.NextDouble() * (maxRadius - minRadius));
                double angle = random.NextDouble() * 2 * Math.PI;
                double x = radius * Math.Cos(angle);
                double y = radius * Math.Sin(angle);

                session?.RunAsync($"MATCH (a:City) WHERE a.name = '{cityName}' " +
                                  $"CREATE (n:Truck {{name: '{truckName}', GotDelivery: 'No', latitude: a.latitude + {x}, longitude: a.longitude + {y}}}) " +
                                  $"CREATE (n)-[r:AVAILABLE_AT]->(a)");
            }
            else
                MessageBox.Show($"Kamion {truckName} vec postoji!");
        }

        public async void CreateDelivery(string deliveryName, string goods, string cityName)
        {
            using var session = _driver?.AsyncSession();
            var result = await(session ?? throw new Exception("session is null")).RunAsync($"MATCH (d:Delivery) WHERE d.name = '{deliveryName}' RETURN COUNT(d) ").Result.SingleAsync();

            if (result[0].As<long>() == 0)
            {
                Random random = new();
                double minRadius = 0.03;
                double maxRadius = 0.06;
                double radius = minRadius + (random.NextDouble() * (maxRadius - minRadius));
                double angle = random.NextDouble() * 2 * Math.PI;
                double x = radius * Math.Cos(angle);
                double y = radius * Math.Sin(angle);

                session?.RunAsync($"MATCH (a:City) WHERE a.name = '{cityName}' " +
                                  $"CREATE (n:Delivery {{name: '{deliveryName}', Status: 'Not delivering', Goods: '{goods}', latitude: a.latitude + {x}, longitude: a.longitude + {y}}}) " +
                                  $"CREATE (n)-[r:STORED_AT]->(a)");
                cmbDeliveryNameForTruck.Items.Add(deliveryName);
            }
            else
                MessageBox.Show($"Posiljka {deliveryName} vec postoji!");
        }

        public async Task<string> MoveDeliveryToTruck(string deliveryName, string truckName, string destinationCity)
        {
            var stringResult = "";
            using var session = _driver?.AsyncSession();
            session?.RunAsync($"MATCH (d:Delivery) WHERE d.name = '{deliveryName}' " +
                              $"SET d.Status = 'Delivering' " +
                              $"WITH d " +
                              $"MATCH (t:Truck) WHERE t.name = '{truckName}' " +
                              $"SET t.GotDelivery = 'Yes' " +
                              $"WITH t, d " +
                              $"MATCH (d)-[r:STORED_AT]->(c:City) DETACH DELETE r " +
                              $"CREATE (d)-[r1:LOADED_ONTO]->(t) " +
                              $"WITH t " +
                              $"MATCH (dc:City) WHERE dc.name = '{destinationCity}' " +
                              $"CREATE (t)-[r2:HEADING_TO]->(dc)");

            session?.RunAsync($"MATCH (t:Truck)-[r:AVAILABLE_AT]->(c:City) WHERE t.name = '{truckName}' " +
                              $"DELETE r CREATE(t) -[r1: CURRENTLY_AT]->(c) ");
            session?.RunAsync($"MATCH (t:Truck {{name: '{truckName}'}}) SET t.destination = '{destinationCity}'");
        
            var result = await (session ?? throw new Exception("session is null")).RunAsync($"MATCH (t:Truck) WHERE t.name = '{truckName}' " +
                                                                                            $"MATCH(city1: City) WHERE(t) -[:CURRENTLY_AT]->(city1) " +
                                                                                            $"MATCH(city2: City) WHERE city2.name = t.destination " +
                                                                                            $"CALL apoc.algo.dijkstra(city1, city2, 'CONNECTED_BY', 'distance', 0, 1) " +
                                                                                            $"YIELD path, weight " +
                                                                                            $"RETURN path as path, weight as weight");
            var record = await result.SingleAsync();
            var weight = record["weight"].As<int>();

            var temp = record[0].As<IPath>().Nodes.ToList();
            var t = temp.ToList();

            for (var i = 0; i < t.Count; i++)
            {
                var s = t[i].Properties.ElementAt(0).Value;

                if (i < t.Count - 1)
                    stringResult += (string)s + "->";
                else
                    stringResult += (string)s;
            }
            stringResult += ";" + weight;

            return stringResult;
        }
        #endregion

        #region DELETE
        public void DeleteEmptyTruck(string truckName)
        {
            using var session = _driver?.AsyncSession();
            session?.RunAsync($"MATCH (t:Truck) WHERE t.name = '{truckName}' MATCH (t) WHERE t.GotDelivery = 'No' DETACH DELETE t");
            cmbDeleteTruckName.Items.Remove(truckName);
        }

        public void DeleteNotDelivering(string deliveryName)
        {
            using var session = _driver?.AsyncSession();
            session?.RunAsync($"MATCH (d:Delivery) WHERE d.name = '{deliveryName}' MATCH (d) WHERE d.Status = 'Not delivering' DETACH DELETE d");
            cmbDeleteDeliveryName.Items.Remove(deliveryName);
        }
        #endregion

        #region HANDLERS
        private async void AddDeleteForm_Load(object sender, EventArgs e)
        {
            using var session = _driver?.AsyncSession();
            var resultCity = await (session ?? throw new Exception("session is null")).RunAsync("MATCH (c:City) RETURN c.name");
            var recordCity = await resultCity.ToListAsync();

            foreach (var r in recordCity)
            {
                var rr = r.Values.First();
                if (!cmbCityA.Items.Contains(rr.Value.ToString()))
                    cmbCityA.Items.Add(rr.Value.ToString());
                if (!cmbCityB.Items.Contains(rr.Value.ToString()))
                    cmbCityB.Items.Add(rr.Value.ToString());
                if (!cmbDeliveryDestination.Items.Contains(rr.Value.ToString()))
                    cmbDeliveryDestination.Items.Add(rr.Value.ToString());
                if (!cmbDeliveryCity.Items.Contains(rr.Value.ToString()))
                    cmbDeliveryCity.Items.Add(rr.Value.ToString());
                if (!cmbTruckCity.Items.Contains(rr.Value.ToString()))
                    cmbTruckCity.Items.Add(rr.Value.ToString());
            }

            var resultDelivery = await session.RunAsync("MATCH (d:Delivery) WHERE d.Status = 'Not delivering' RETURN d.name");
            var recordDelivery = await resultDelivery.ToListAsync();

            foreach (var r in recordDelivery)
            {
                var rr = r.Values.First();
                if (!cmbDeliveryNameForTruck.Items.Contains(rr.Value.ToString()))
                    cmbDeliveryNameForTruck.Items.Add(rr.Value.ToString());
                if (!cmbDeleteDeliveryName.Items.Contains(rr.Value.ToString()))
                    cmbDeleteDeliveryName.Items.Add(rr.Value.ToString());
            }

            var resultTruck = await session.RunAsync("MATCH (t:Truck) WHERE t.GotDelivery = 'No' RETURN t.name");
            var recordTruck = await resultTruck.ToListAsync();

            foreach (var r in recordTruck)
            {
                var rr = r.Values.First();
                if (!cmbDeleteTruckName.Items.Contains(rr.Value.ToString()))
                    cmbDeleteTruckName.Items.Add(rr.Value.ToString());
            }
        }

        private async void cmbDeliveryNameForTruck_SelectedValueChanged(object sender, EventArgs e)
        {
            cmbTruckNameForDelivery.Items.Clear();
            var deliveryName = cmbDeliveryNameForTruck.Text;
            using var session = _driver?.AsyncSession();

            var resultTruck = await (session ?? throw new Exception("session is null")).RunAsync($"MATCH (d:Delivery) WHERE d.name = '{deliveryName}'" +
                                                                                                 $" MATCH (d)-[:STORED_AT]-(c1:City)" +
                                                                                                 $" MATCH (t:Truck) WHERE t.GotDelivery = 'No' " +
                                                                                                 $" MATCH (t) WHERE (t)-[:AVAILABLE_AT]-(c1) RETURN t.name");

            var recordTruck = await resultTruck.ToListAsync();

            foreach (var r in recordTruck)
            {
                var rr = r.Values.First();
                if (!cmbTruckNameForDelivery.Items.Contains(rr.Value.ToString()))
                    cmbTruckNameForDelivery.Items.Add(rr.Value.ToString());
            }

        }

        private void btnAddCity_Click(object sender, EventArgs e)
        {
            if (cmbCityA.Items.Contains(txbCityName.Text))
                MessageBox.Show($"{txbCityName.Text} vec postoji!");
            else
            {
                try
                {
                    if (txbCityName.Text == "")
                        throw new Exception("Ime grada ne sme biti prazno!");
                    if (!Int32.TryParse(txbPopulation.Text, out int a))
                        throw new Exception("Populacija mora biti celobrojan broj!");
                    if(!double.TryParse(txbLongitude.Text, out double b))
                        throw new Exception("Longitude mora biti decimalan broj!");
                    if(!double.TryParse(txbLatitude.Text, out double c))
                            throw new Exception("Latitude mora biti decimalan broj!");

                    AddCity(txbCityName.Text, Int32.Parse(txbPopulation.Text), double.Parse(txbLongitude.Text), double.Parse(txbLatitude.Text));
                    AddDeleteForm_Load(sender, e);
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void btnAddHighway_Click(object sender, EventArgs e)
        {
            try
            {
                if (cmbCityA.SelectedIndex == -1)
                    throw new Exception("Grad A mora biti izabran!");
                if (cmbCityB.SelectedIndex == -1)
                    throw new Exception("Grad B mora biti izabran!");
                if (cmbCityA.Text == cmbCityB.Text)
                    throw new Exception("Gradovi ne mogu biti isti!");
                if (txbHighwayName.Text == "")
                    throw new Exception("Polje naziv puta ne sme biti prazno!");
                if (!Int32.TryParse(txbDistance.Text, out int a))
                    throw new Exception("Duzina puta mora biti celobrojan broj!");

                AddHighway(cmbCityA.Text, cmbCityB.Text, txbHighwayName.Text, Int32.Parse(txbDistance.Text));
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }   
        }

        private void btnAddTruck_Click(object sender, EventArgs e)
        {
            try
            {
                if (txbTruckName.Text == "")
                    throw new Exception("Ime kamiona ne sme biti prazno!");
                if (cmbTruckCity.SelectedIndex == -1)
                    throw new Exception("Mora biti izabran grad!");

                AddTruck(txbTruckName.Text, cmbTruckCity.Text);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void btnCreateDelivery_Click(object sender, EventArgs e)
        {
            try
            {
                if (txbDeliveryName.Text == "")
                    throw new Exception("Naziv posliljke ne sme biti prazno!");
                if(txbDeliveryGoods.Text == "" )
                    throw new Exception("Polje sadrzaj ne sme biti prazno!");
                if (cmbDeliveryCity.SelectedIndex == -1)
                    throw new Exception("Mora biti izabran grad!");

                CreateDelivery(txbDeliveryName.Text, txbDeliveryGoods.Text, cmbDeliveryCity.Text);
                AddDeleteForm_Load(sender, e);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private async void btnAddDeliveryToTruck_Click(object sender, EventArgs e)
        {
            try
            {
                if (cmbDeliveryNameForTruck.SelectedIndex == -1)
                    throw new Exception("Mora biti izabrana posiljka!");
                if (cmbTruckNameForDelivery.SelectedIndex == -1)
                    throw new Exception("Mora biti izabran kamion!");
                if(cmbDeliveryDestination.SelectedIndex == -1)
                    throw new Exception("Mora biti izabrana destinacija!");

                using var session = _driver?.AsyncSession();
                var resultDestination = await (session ?? throw new Exception("session is null")).RunAsync($"MATCH (d:Delivery) WHERE d.name = '{cmbDeliveryNameForTruck.Text}'" +
                                                                                                           $" MATCH (d)-[:STORED_AT]-(c1:City)" +
                                                                                                           $" RETURN c1.name");
                var recordDestination = await resultDestination.SingleAsync();
                if (recordDestination.Values.First().Value.ToString() == cmbDeliveryDestination.Text)
                    throw new Exception("Posiljka je vec u tom gradu");

                string s = await MoveDeliveryToTruck(cmbDeliveryNameForTruck.Text, cmbTruckNameForDelivery.Text, cmbDeliveryDestination.Text);
                var a = s.Split(";");
                var o = double.Parse(a[1]) / 100.00;
                Random random = new Random();
                int randomNumber = random.Next(10000, 15001);

                MessageBox.Show($"Izabrana najkraca ruta: {a[0]}\nUkupno kilometra: {a[1]}km\nProcena troskova:\nGorivo: {Math.Round(o * 40 * 195, 2)} rsd\nUtovar/Istovar: {randomNumber} rsd");
                AddDeleteForm_Load(sender, e);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnDeleteEmptyTruck_Click(object sender, EventArgs e)
        {
            DeleteEmptyTruck(cmbDeleteTruckName.Text);
        }

        private void btnDeleteNotDelivering_Click(object sender, EventArgs e)
        {
            DeleteNotDelivering(cmbDeleteDeliveryName.Text);
        }
        #endregion
    }
}

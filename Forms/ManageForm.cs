using MetroFramework.Forms;
using Neo4j.Driver;
using Truckers.Models;

namespace Truckers.Forms
{
    public partial class ManageForm : MetroForm
    {
        private IDriver? _driver;

        public ManageForm(IDriver driver)
        {
            InitializeComponent();
            _driver = driver;
        }

        #region MANAGE
        public async Task<City?> CalculateShortestPath(string truckName)
        {
            City city;
            
            using (var session = _driver?.AsyncSession())
            {
                var result = await (session ?? throw new Exception("session is null")).RunAsync($"MATCH (t:Truck) WHERE t.name = '{truckName}' " +
                                              $"MATCH(city1: City) WHERE(t) -[:CURRENTLY_AT]->(city1) " +
                                              $"MATCH(city2: City) WHERE city2.name = t.destination " +
                                              $"CALL apoc.algo.dijkstra(city1, city2, 'CONNECTED_BY', 'distance', 0, 1) " +
                                              $"YIELD path, weight " +
                                              $"RETURN path as path, weight as weight");
                
                var record = await result.SingleAsync();
                var weight = record["weight"].As<int>();
                var temp = record[0].As<IPath>().Nodes.ToList();

                if (temp.Count == 1)
                    return null;
                else
                {
                    var t = temp[1].Properties.ToList();
                    city = new City((string)t[0].Value, Convert.ToInt32(t[1].Value));
                }
            }

            return city;
        }

        public void UpdateTruckPosition(string truckName, City city)
        {
            using var session = _driver?.AsyncSession();
            session?.RunAsync($"MATCH (t:Truck), (c2:City) " +
                            $"WHERE t.name = '{truckName}' AND c2.name = '{city.Name}' " +
                            $"MATCH(c1: City) WHERE(t) -[:CURRENTLY_AT]->(c1) " +
                            $"MATCH (t)-[r:CURRENTLY_AT]->(c1) " +
                            $"DELETE r " +
                            $"CREATE (t) -[:CURRENTLY_AT]->(c2) ");

            Random random = new();
            double minRadius = 0.03;
            double maxRadius = 0.06;
            double radius = minRadius + (random.NextDouble() * (maxRadius - minRadius));
            double angle = random.NextDouble() * 2 * Math.PI;
            double x = radius * Math.Cos(angle);
            double y = radius * Math.Sin(angle);

            session?.RunAsync($"MATCH (t:Truck), (c2:City) " +
                                $"WHERE t.name = '{truckName}' AND c2.name = '{city.Name}' " +
                                $"SET t.longitude = c2.longitude + {Math.Abs(y)} " +
                                $"WITH t, c2 " +
                                $"SET t.latitude = c2.latitude + {Math.Abs(x)} ");

            radius = minRadius + (random.NextDouble() * (maxRadius - minRadius));
            angle = random.NextDouble() * 2 * Math.PI;
            x = radius * Math.Cos(angle);
            y = radius * Math.Sin(angle);

            session?.RunAsync($"MATCH (d:Delivery), (t:Truck), (c2:City) " +
                                $"WHERE t.name = '{truckName}' AND c2.name = '{city.Name}' " +
                                $"MATCH (d) -[:LOADED_ONTO]-(t) " +
                                $"SET d.longitude = c2.longitude + {Math.Abs(y)} " +
                                $"WITH t, c2, d " +
                                $"SET d.latitude = c2.latitude + {Math.Abs(x)} ");
        }

        private async void TruckArrivedAtDestination(string truckName)
        {
            using var session = _driver?.AsyncSession();
            await (session ?? throw new Exception("session is null")).RunAsync($"MATCH (t:Truck {{name: '{truckName}'}})  SET t.GotDelivery = 'No' " +
                                                                              $"WITH t " +
                                                                              $"MATCH (t)-[r:HEADING_TO]-() DELETE r " +
                                                                              $"With t " +
                                                                              $"MATCH (t)-[r:CURRENTLY_AT]-() DELETE r " +
                                                                              $"With t " +
                                                                              $"MATCH (c1:City) WHERE c1.name = t.destination " +
                                                                              $"CREATE (t) -[:AVAILABLE_AT]->(c1) " +
                                                                              $"WITH t, c1 " +
                                                                              $"MATCH (d:Delivery)-[r:LOADED_ONTO]-(t) DELETE r " +
                                                                              $"SET d.Status = 'Not delivering' " +
                                                                              $"With d, t, c1 " +
                                                                              $"CREATE (d) -[:STORED_AT]->(c1) " +
                                                                              $"REMOVE t.destination ");
            cmbTruck.Items.Remove(truckName);
            cmbTruck.SelectedIndex = -1;
            btnUpdateTruck.Enabled = false;
        }
        #endregion

        #region HANDLERS
        private void cmbTruck_SelectedValueChanged(object sender, EventArgs e)
        {
            if (cmbTruck.SelectedIndex != -1)
                btnUpdateTruck.Enabled = true;
        }

        private async void btnUpdateTruck_Click(object sender, EventArgs e)
        {
            City? city = await CalculateShortestPath(cmbTruck.Text);
            if (city == null)
                TruckArrivedAtDestination(cmbTruck.Text);
            else
                UpdateTruckPosition(cmbTruck.Text, city);
        }

        private async void ManageForm_Load(object sender, EventArgs e)
        {
            using var session = _driver?.AsyncSession();
            var resultTruck = await (session ?? throw new Exception("session is null")).RunAsync("MATCH (t:Truck) WHERE t.GotDelivery = 'Yes' RETURN t.name");
            var recordTruck = await resultTruck.ToListAsync();

            foreach (var r in recordTruck)
            {
                var rr = r.Values.First();
                if (!cmbTruck.Items.Contains(rr.Value.ToString()))
                    cmbTruck.Items.Add(rr.Value.ToString());
            }

            if (cmbTruck.SelectedIndex == -1)
                btnUpdateTruck.Enabled = false;
        }

        private void btnCopy_Click(object sender, EventArgs e)
        {
            string textToCopy = "{\r\n  \"title\": \"TRUCKERS\",\r\n  \"version\": \"2.2\",\r\n  \"settings\": {\r\n    \"pagenumber\": 0,\r\n    \"editable\": true,\r\n    \"fullscreenEnabled\": false,\r\n    \"parameters\": {}\r\n  },\r\n  \"pages\": [\r\n    {\r\n      \"title\": \"Main Page\",\r\n      \"reports\": [\r\n        {\r\n          \"title\": \"MAPA\",\r\n          \"query\": \"MATCH (n)-[r]->(m)\\nWHERE NOT type(r) = \\\"CONNECTED_BY\\\"\\nMATCH (s)\\nRETURN r, s;\",\r\n          \"width\": 6,\r\n          \"height\": 4,\r\n          \"x\": 0,\r\n          \"y\": 0,\r\n          \"type\": \"map\",\r\n          \"selection\": {\r\n            \"Delivery\": \"(no label)\",\r\n            \"City\": \"(no label)\",\r\n            \"Truck\": \"(no label)\"\r\n          },\r\n          \"settings\": {\r\n            \"nodeColorScheme\": \"set1\"\r\n          },\r\n          \"refreshRate\": 5\r\n        },\r\n        {\r\n          \"title\": \"GRAF\",\r\n          \"query\": \"MATCH (n)-[e]->(m) RETURN n,e,m LIMIT 20\\n\\n\\n\",\r\n          \"width\": 6,\r\n          \"height\": 4,\r\n          \"x\": 6,\r\n          \"y\": 0,\r\n          \"type\": \"graph\",\r\n          \"selection\": {\r\n            \"City\": \"name\",\r\n            \"Truck\": \"name\"\r\n          },\r\n          \"settings\": {\r\n            \"nodePositions\": {}\r\n          }\r\n        }\r\n      ]\r\n    }\r\n  ],\r\n  \"parameters\": {},\r\n  \"extensions\": {}\r\n} ";
            Clipboard.SetText(textToCopy);
        }
        #endregion
    }
}

using MetroFramework.Forms;
using Neo4j.Driver;
using Truckers.Models;

namespace Truckers.Forms
{
    public partial class SearchForm : MetroForm
    {
        private IDriver? _driver;

        public SearchForm(IDriver driver)
        {
            InitializeComponent();
            _driver = driver;
        }

        #region SEARCH
        public async Task<List<Truck>> SearchTruckByName(string name)
        {
            List<Truck> truckList = new();
            using (var session = _driver?.AsyncSession())
            {
                var result = await (session ?? throw new Exception("session is null")).RunAsync($"MATCH (t:Truck)-[:CURRENTLY_AT|AVAILABLE_AT]->(c:City) " +
                                                                                                $"WHERE t.name =~ '.*{name}.*' " +
                                                                                                $"RETURN t.name, t.GotDelivery, c.name ");
                while (await result.FetchAsync())
                {
                    var record = result.Current;
                    var truck = new Truck
                    {
                        Name = record[0].As<string>(),
                        GotDelivery = record[1].As<string>(),
                        CityCurrent = record[2].As<string>()
                    };
                    truckList.Add(truck);
                }
            }

            return truckList;
        }

        public async Task<List<Delivery>> SearchDeliveryByName(string name)
        {
            List<Delivery> deliveryList = new();
            using (var session = _driver?.AsyncSession())
            {
                var result = await (session ?? throw new Exception("session is null")).RunAsync($"MATCH (d:Delivery)-[:STORED_AT]->(c:City) " +
                                                                                                $"WHERE d.name =~ '.*{name}.*' " +
                                                                                                $"RETURN d.name, d.Goods, c.name, d.Status " +
                                                                                                $"UNION " +
                                                                                                $"MATCH (d:Delivery)-[:LOADED_ONTO]->(t:Truck)-[:CURRENTLY_AT]->(c:City) " +
                                                                                                $"WHERE d.name =~ '.*{name}.*' " +
                                                                                                $"RETURN d.name, d.Goods, c.name, d.Status ");
                while (await result.FetchAsync())
                {
                    var record = result.Current;
                    var delivery = new Delivery
                    {
                        Name = record[0].As<string>(),
                        Goods = record[1].As<string>(),
                        CityCurrent = record[2].As<string>(),
                        Status = record[3].As<string>()
                    };
                    deliveryList.Add(delivery);
                }
            }

            return deliveryList;
        }
        #endregion

        #region HANDLERS
        private async void btnSearchTruck_Click(object sender, EventArgs e)
        {
            string name = tbxSearchTruck.Text;
            List<Truck> truckList = await SearchTruckByName(name);
            lbxSearchTruckResult.Items.Clear();

            foreach (Truck truck in truckList)
            {
                ListViewItem item = new(truck.Name);
                item.SubItems.Add(truck.CityCurrent);
                item.SubItems.Add(truck.GotDelivery);
                lbxSearchTruckResult.Items.Add(item);
            }
        }

        private async void btnSearchDelivery_Click(object sender, EventArgs e)
        {
            string name = tbxSearchDelivery.Text;
            List<Delivery> deliveryList = await SearchDeliveryByName(name);
            lbxSearchDeliveryResult.Items.Clear();

            foreach (Delivery delivery in deliveryList)
            {
                ListViewItem item = new(delivery.Name);
                item.SubItems.Add(delivery.Goods);
                item.SubItems.Add(delivery.CityCurrent);
                item.SubItems.Add(delivery.Status);
                lbxSearchDeliveryResult.Items.Add(item);
            }
        }
        #endregion
    }
}

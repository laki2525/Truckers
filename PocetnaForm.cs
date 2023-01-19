using MetroFramework.Forms;
using Neo4j.Driver;
using Truckers.Forms;

namespace Truckers
{
    public partial class PocetnaForm : MetroForm
    {
        private IDriver _driver;

        public PocetnaForm()
        {
            InitializeComponent();
            _driver = GraphDatabase.Driver("bolt://localhost:7687", AuthTokens.Basic("neo4j", "stella"));
        }

        private void btnAddDelete_Click(object sender, EventArgs e)
        {
            AddDeleteForm form = new(_driver);
            form.ShowDialog();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            SearchForm form = new(_driver);
            form.ShowDialog();
        }

        private void btnManage_Click(object sender, EventArgs e)
        {
            ManageForm form = new(_driver);
            form.ShowDialog();
        }
    }
}
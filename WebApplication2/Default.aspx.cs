using System;
using System.Data.SqlClient;
using System.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace WebApplication2
{
    public partial class _Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Populate the dropdowns at the beginning of the page
                PopolaDropDownAuto();
                PopolaDropDownOptional();
                PopolaDropDownGaranzia();
            }
        }

        private void PopolaDropDownAuto()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["YourConnectionString"].ConnectionString))
                {
                    connection.Open();
                    string query = "SELECT ID_Macchina, Modello FROM Macchine";
                    SqlCommand cmd = new SqlCommand(query, connection);
                    SqlDataReader reader = cmd.ExecuteReader();

                    DropDownList1.DataSource = reader;
                    DropDownList1.DataTextField = "Modello";
                    DropDownList1.DataValueField = "ID_Macchina";
                    DropDownList1.DataBind();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Si è verificato un errore: {ex.Message}");
            }
        }

        private void PopolaDropDownOptional()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["YourConnectionString"].ConnectionString))
                {
                    connection.Open();
                    string query = "SELECT ID_Optional, Nome, Prezzo FROM OptionalMacchine";
                    SqlCommand cmd = new SqlCommand(query, connection);
                    SqlDataReader reader = cmd.ExecuteReader();

                    DropDownList2.DataSource = reader;
                    DropDownList2.DataTextField = "Nome";
                    DropDownList2.DataValueField = "ID_Optional";
                    DropDownList2.DataBind();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Si è verificato un errore: {ex.Message}");
            }
        }

        private void PopolaDropDownGaranzia()
        {
            for (int i = 1; i <= 10; i++)
            {
                ListItem item = new ListItem($"{i} Anno{(i > 1 ? "i" : "")} di Garanzia - Costo: {i * 120} EUR", i.ToString());
                DropDownList3.Items.Add(item);
            }
        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Implement logic for the DropDownList1 selected index change event
            // Example: UpdateImageAndPrice();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string selectedCarId = DropDownList1.SelectedValue;
            string selectedOptionalId = DropDownList2.SelectedValue;
            string selectedWarranty = DropDownList3.SelectedValue;

            // Add your logic here based on the selected values
        }
    }
}

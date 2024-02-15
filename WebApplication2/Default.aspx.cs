using System;
using System.Data.SqlClient;
using System.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections.Generic;
using System.Data;

namespace WebApplication2
{
    public partial class _Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Popola i dropdown all'inizio della pagina
                PopolaDropDownAuto();
                PopolaDropDownOptional();
                PopolaDropDownGaranzia();
            }
        }

        private void PopolaDropDownAuto()
        {
            SqlConnection connection = null;
            try
            {
                // Utilizzo di using per garantire la chiusura automatica della connessione
                string connection = new SqlConnection=)
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
                // Gestisci l'eccezione come preferisci, ad esempio, puoi registrare l'errore o mostrare un messaggio all'utente
                Console.WriteLine($"Si è verificato un errore: {ex.Message}");
            }
            finally
            {
                // Assicurati di chiudere la connessione anche se si verificano eccezioni
                if (connection != null && connection.State == ConnectionState.Open)
                {
                    connection.Close();
                }
            }
        }


        private void PopolaDropDownOptional()
        {
            SqlConnection connection = null;
            try
            {
                // Utilizzo di using per garantire la chiusura automatica della connessione
                using (connection = new SqlConnection("Macchine"))
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
                // Gestisci l'eccezione come preferisci, ad esempio, puoi registrare l'errore o mostrare un messaggio all'utente
                Console.WriteLine($"Si è verificato un errore: {ex.Message}");
            }
            finally
            {
                // Assicurati di chiudere la connessione anche se si verificano eccezioni
                if (connection != null && connection.State == ConnectionState.Open)
                {
                    connection.Close();
                }
            }
        }


        private void PopolaDropDownGaranzia()
        {
            // Aggiungi anni di garanzia al dropdown
            for (int i = 1; i <= 10; i++)
            {
                ListItem item = new ListItem($"{i} Anno{(i > 1 ? "i" : "")} di Garanzia - Costo: {i * 120} EUR", i.ToString());
                DropDownList3.Items.Add(item);
            }
        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Implementa la logica per l'evento di selezione del DropDownList1
            // Esempio: AggiornaImmagineEPrezzo();
        }
        protected void Button1_Click(object sender, EventArgs e)
        { 
        }
        }
}

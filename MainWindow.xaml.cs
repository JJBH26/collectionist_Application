using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

using MySql.Data.MySqlClient;

namespace Collectionist_application
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        MySqlConnection con = new MySqlConnection("SERVER=LOCALHOST;DATABASE=Collectionist;USER=root;PASSWORD=AMPH0611.Moise;");

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                con.Open();  // Open the connection
                MySqlDataAdapter da = new MySqlDataAdapter("SELECT * FROM cardtype", con);
                DataSet ds = new DataSet();
                da.Fill(ds);  // Fill the DataSet with data from the database

                // Check if the DataSet contains data
                if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    DataGrid.ItemsSource = ds.Tables[0].DefaultView;  // Bind data to the DataGrid
                }
                else
                {
                    MessageBox.Show("No data found in the table.");  // Show a message if no data is found
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);  // Handle any exceptions
            }
            finally
            {
                con.Close();  // Ensure the connection is closed after the operation
            }
        }


        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}

using System;
using System.Collections.Generic;
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
using System.Data.SqlClient;
using System.Data.Entity;
using System.Data;
using System.Diagnostics;
using System.Collections.ObjectModel;

namespace EntityExample
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
                        
        }

        static private string GetConnectionString()
        {
            return @"Data Source=(localdb)\mssqllocaldb; Initial Catalog = Peoples; Integrated Security=true;";
        }

        private void ButtonBaseConnect(object sender, RoutedEventArgs e)
        {
            string connectionString = GetConnectionString();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                //connection.ConnectionString = connectionString;
                connection.Open();

                String sql1 = "SELECT * FROM dbo.Names";

                //String sql2 = "SELECT SecName FROM dbo.Names";

                //String sql3 = "SELECT Age FROM dbo.Names";

                using (SqlCommand command = new SqlCommand(sql1, connection))
                {
                    
                    command.ExecuteNonQuery();

                    SqlDataAdapter dataAdp = new SqlDataAdapter(command);
                    DataTable dt = new DataTable("dbo.Names");
                    dataAdp.Fill(dt);
                    Grid1.ItemsSource = dt.DefaultView;                    
                }


            }
        }
    } 
        
}

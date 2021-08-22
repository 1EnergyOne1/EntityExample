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

        /// <summary>
        /// Метод, возвращающий строку подключения к БД Peoples
        /// </summary>
        /// <returns></returns>
        static private string GetConnectionString()
        {
            return @"Data Source=(localdb)\mssqllocaldb; Initial Catalog = Peoples; Integrated Security=true;";
        }


        /// <summary>
        /// Вывод данных из базы данных в таблицу DataGrid
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void ButtonBaseConnect(object sender, RoutedEventArgs e)
        {
            string connectionString = GetConnectionString(); // строка подключения

            using (SqlConnection connection = new SqlConnection(connectionString)) //using означает, что при закрытии последней фигурной скобки соединение закроется
            {
                
                connection.Open(); // открыть соединение

                String sql1 = "SELECT * FROM dbo.Names"; //LINQ запрос в БД
                               

                using (SqlCommand command = new SqlCommand(sql1, connection)) // инструкция T-SQL над базой данных (запрос, строка подключения)
                {
                    
                    command.ExecuteNonQuery();                            // возвращает строки из бд

                    SqlDataAdapter dataAdp = new SqlDataAdapter(command); //мост между DataSet и SQL Server для получения и сохранения данных
                    DataTable dt = new DataTable("dbo.Names");            // создается элемент таблицы для DataGrid
                    dataAdp.Fill(dt);                                     // добавление данных в таблиу DataGrid
                    Grid1.ItemsSource = dt.DefaultView;                    
                }
            }
        }


        /// <summary>
        /// Сортировка по имени. Описание инструкций см. метод ButtonBaseConnect
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void buttonSortName(object sender, RoutedEventArgs e)
        {
            string connectionString = GetConnectionString();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {

                connection.Open();

                String sql1 = "SELECT * FROM dbo.Names ORDER BY Name";


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

        /// <summary>
        /// Сортировка по фамилии. Описание инструкций см. метод ButtonBaseConnect
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonSortSecName(object sender, RoutedEventArgs e)
        {
            string connectionString = GetConnectionString();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {

                connection.Open();

                String sql1 = "SELECT * FROM dbo.Names ORDER BY SecName";


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

        /// <summary>
        /// Сортировка по возрасту. Описание инструкций см. метод ButtonBaseConnect
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void buttonSortAge(object sender, RoutedEventArgs e)
        {
            string connectionString = GetConnectionString();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {

                connection.Open();

                String sql1 = "SELECT * FROM dbo.Names ORDER BY Age";


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

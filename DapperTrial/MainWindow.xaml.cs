using Dapper;
using Npgsql;
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

namespace DapperTrial
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

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string server = "mydb.ctmbums33jwn.ap-south-1.rds.amazonaws.com";
            string port = "5432";
            string user = "postgres";
            string password = "postgres";
            string database = "accounting";

            string connectionString = String.Format("Server={0};Port={1};" +
                    "User Id={2};Password={3};Database={4};",
                    server, port, user, password, database);

            using (IDbConnection connection = new NpgsqlConnection(connectionString))
            {
                List<LoginModel> res = connection.Query<LoginModel>("select * from login").ToList();
                MessageBox.Show(res[0].Email);                
            }
        }
    }
}

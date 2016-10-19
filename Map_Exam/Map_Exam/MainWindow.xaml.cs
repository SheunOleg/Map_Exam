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
using Oracle.ManagedDataAccess.Client;
using Oracle.ManagedDataAccess.Types;

namespace Map_Exam
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        OracleConnection oracleConn { get; set; }
        public MainWindow()
        {
            InitializeComponent();
            oracleConn = new OracleConnection("Data Source=10.3.0.227;User Id=Sheun;Password=1111;");
            try
            {
                oracleConn.Open();
            }
            catch (Exception e)
            {
                oracleConn.Close();
                Close();
            }
        }

        private void Button_Click_Login(object sender, RoutedEventArgs e)
        {
            OracleCommand com = new OracleCommand();
            com.Connection = oracleConn;
            com.CommandText = "BEGIN PROVER('" + Login.Text + "','" + Password.Text + "') END";
            var res = com.ExecuteScalar();

            if ((bool)res == true)
            {
            }
            else
            {
            }

        }

        private void Button_Click_Registr(object sender, RoutedEventArgs e)
        {
            if (Login.Text != null && Password.Text != null)
                try
                {
                    OracleCommand com = new OracleCommand("INSERT INTO OPERATOR_(NAME,PSWD) VALUES('" + Login.Text + "','"
                        + Password.Text + "')", oracleConn);
                    var res = com.ExecuteReader();
                    //while (res.Read())
                    //{
                    //    Console.WriteLine(res[1].ToString());
                    //}
                }
                catch { }

        }
    }
}

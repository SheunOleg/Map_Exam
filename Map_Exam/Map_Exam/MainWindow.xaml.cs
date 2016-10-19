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

            com.CommandText = "BEGIN PROVER(':login',':password')";
            com.Parameters.Add("login", OracleDbType.NVarchar2, 10).Value = Login.Text;
            com.Parameters.Add("password", OracleDbType.NVarchar2, 10).Value = Password.Text;
            OracleDataReader res = com.ExecuteReader();
            while (res.Read())
            {
                if ((bool)res[0] == true)
                { 
                }
                else 
                { 
                }
            }
        }

        private void Button_Click_Registr(object sender, RoutedEventArgs e)
        {
            try
            {

                OracleCommand com = new OracleCommand("Select * From OPERATOR_;", oracleConn);
                //OracleCommand com = new OracleCommand("SELECT * FROM ALL_TABLES", oracleConn);
                //com.CommandText = "INSERT INTO OPERATOR_(ID,NAME,PSWD) VALUES(2,':login',':password');";
                //com.Parameters.Add("login", OracleDbType.NVarchar2, 10).Value = Login.Text;
                //com.Parameters.Add("password", OracleDbType.NVarchar2, 10).Value = Password.Text;
                OracleDataReader reader = com.ExecuteReader();
                while (reader.Read())
                {

                    Console.WriteLine("\t{0}\t{1}\t{2}",
                    reader[0], reader[1], reader[2]);
                }
                reader.Close();
                
            }
            catch { }

        }
    }
}

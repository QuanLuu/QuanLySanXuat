using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
//using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;

namespace Chuong_Trinh_Quan_Ly_San_Xuat.ADO
{
    public class DataProvider
    {
        private static DataProvider instance;

        public static DataProvider Instance
        {
            get
            {
                if (instance == null) instance = new DataProvider();
                return DataProvider.instance;
            }

            set
            {
                DataProvider.instance = value;
            }
        }

        private DataProvider() { }

        string connectstring =Properties.Settings.Default.QLSX;



        //Properties.Settings.Default.QLSX;//ConfigurationManager.ConnectionStrings["QLSX"].ToString();

        public DataTable ExecuteQuery(string query, object[] parameter = null)
        {

            DataTable data = new DataTable();
            try
            {
               
                using (SqlConnection connection = new SqlConnection(connectstring))
                {

               
                    connection.Open();
                
                    SqlCommand command = new SqlCommand(query, connection);
                    command.CommandTimeout = 0;
                    if (parameter != null)
                    {
                        string[] listParam = query.Split(' ');
                        int i = 0;
                        foreach (string item in listParam)
                        {
                            if (item.Contains('@'))
                            {
                                command.Parameters.AddWithValue(item, parameter[i]);
                                i++;
                            }
                        }

                    }
                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    adapter.Fill(data);
                    connection.Close();
               
                }   
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return data;
        }
        public int ExecuteNonQuery(string query, object[] parameter = null)
        {
            int data = 0;

            using (SqlConnection connection = new SqlConnection(connectstring))
            {
                connection.Open();

                SqlCommand command = new SqlCommand(query, connection);
                command.CommandTimeout = 0;
                if (parameter != null)
                {
                    string[] listPara = query.Split(' ');
                    int i = 0;
                    foreach (string item in listPara)
                    {
                        if (item.Contains('@'))
                        {
                            command.Parameters.AddWithValue(item, parameter[i]);
                            i++;
                        }
                    }
                }

                data = command.ExecuteNonQuery();

                connection.Close();
            }

            return data;
        }

        public object ExecuteScalar(string query, object[] parameter = null)
        {
            object data = 0;

            using (SqlConnection connection = new SqlConnection(connectstring))
            {
                connection.Open();

                SqlCommand command = new SqlCommand(query, connection);
                command.CommandTimeout = 0;
                if (parameter != null)
                {
                    string[] listPara = query.Split(' ');
                    int i = 0;
                    foreach (string item in listPara)
                    {
                        if (item.Contains('@'))
                        {
                            command.Parameters.AddWithValue(item, parameter[i]);
                            i++;
                        }
                    }
                }

                data = command.ExecuteScalar();

                connection.Close();
            }

            return data;
        }
    }
}
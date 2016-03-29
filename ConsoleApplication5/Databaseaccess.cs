using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication5
{
    class Databaseaccess
    {


       public void dbaction(List<string> list_pn, List<string> list_npn, List<string> list_cdm, List<string> list_cdm_term2,List<string> list_cdm_term3,List<string> list_cdm_term4)
        {
            string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["Test"].ConnectionString.ToString();
            string sql, sql1, sql2, sql3;     
            SqlCommand command, command1, command2, command3;
            SqlDataReader dataReader, dataReader1, dataReader3;
            SqlConnection connection = new SqlConnection(connectionString);

            connection.Open();
            sql = "Select * from table_npn";
            command = new SqlCommand(sql, connection);
            // sql1 = "select * from cdm_new";
            sql1 = "select * from splitups";
            command1 = new SqlCommand(sql1, connection);
            string temp_str, temp_str1;
            dataReader = command.ExecuteReader();

            while (dataReader.Read())
            {
                temp_str = dataReader["pn"].ToString();
                list_pn.Add(temp_str.ToLower());
                list_npn.Add(dataReader["npn"].ToString().ToLower());

            }

            dataReader.Close();
            command.Dispose();
            dataReader1 = command1.ExecuteReader();

            while (dataReader1.Read())
            {

                list_cdm.Add(dataReader1["column1"].ToString().ToLower());
                list_cdm_term2.Add(dataReader1["column2"].ToString().ToLower());
                list_cdm_term3.Add(dataReader1["column3"].ToString().ToLower());
                list_cdm_term4.Add(dataReader1["column4"].ToString().ToLower());

            }
            dataReader1.Close();
            command1.Dispose();
            connection.Close();
        }

       public List<string> dbactionweight(List<string> list_cdm_desc)
        {
            string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["Test"].ConnectionString.ToString();
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            string sql = "Select * from cdm_new";
            SqlCommand command = new SqlCommand(sql, connection);
            SqlDataReader dataReader=command.ExecuteReader();
            string temp_str;

            while (dataReader.Read())
            {
                temp_str = dataReader["cdmdes"].ToString();
                list_cdm_desc.Add(temp_str.ToString().ToLower());
            }

            dataReader.Close();
            command.Dispose();
            connection.Close();
            return list_cdm_desc;
        }

        
    }
}

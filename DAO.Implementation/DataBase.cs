using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace DAO.Implementation
{
    public class DataBase
    {
        static string connectionString = @"data source = DESKTOP-F3Q3GMI\SA; initial catalog = BDFriedCrab; user id = sa; password= univalle";

        public static SqlCommand CreateBasicCommand()
        {
            SqlConnection connection = new SqlConnection(connectionString);
            SqlCommand command = new SqlCommand();
            command.Connection = connection;
            return command;
        }

        public static SqlCommand CreateBasicCommand(string query)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            SqlCommand command = new SqlCommand(query);
            command.Connection = connection;
            return command;
        }

        /// <summary>
        /// Insert , Update, Delete
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        public static int ExecuteBasicCommand(SqlCommand command)
        {
            try
            {
                command.Connection.Open();
                return command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                command.Connection.Close();
            }
        }

        /// <summary>
        /// Select
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        public static DataTable ExecuteDataTableCommand(SqlCommand command)
        {
            DataTable dt = new DataTable();
            try
            {
                command.Connection.Open();
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                adapter.Fill(dt);
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                command.Connection.Close();
            }
            return dt;
        }

        public static SqlDataReader ExecuteDataReaderCommand(SqlCommand command)
        {
            SqlDataReader dr = null;
            try
            {
                command.Connection.Open();
                dr = command.ExecuteReader();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dr;
        }
    }
}

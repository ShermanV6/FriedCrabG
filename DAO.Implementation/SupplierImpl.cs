using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAO.Model;
using DAO.Interfaces;
using System.Data;
using System.Data.SqlClient;

namespace DAO.Implementation
{
    public class SupplierImpl : ISupplier
    {
        public int Delete(Suppliers t)
        {
            string query = @"UPDATE Supplier SET status=0,lastUpdate=CURRENT_TIMESTAMP,idUser=@idUser
                            WHERE idSupplier=@idSupplier";
            try
            {
                SqlCommand command = DataBase.CreateBasicCommand(query);
                command.Parameters.AddWithValue("@idUser", t.IdUser);
                command.Parameters.AddWithValue("@idSupplier", t.IdSupplier);
                return DataBase.ExecuteBasicCommand(command);
            }
            catch (Exception ex)
            {
                //Logs de errores
                throw ex;
            }
        }

        public Suppliers Get(byte id)
        {
            Suppliers t = null;
            string query = @"SELECT idSupplier,supplierName,numberPhone,status,registerDate,lastUpdate,idUser
                            FROM Supplier
                            WHERE idSupplier=@idSupplier";
            SqlCommand command = null;
            SqlDataReader dr = null;
            try
            {
                command = DataBase.CreateBasicCommand(query);
                command.Parameters.AddWithValue("@idSupplier", id);
                dr = DataBase.ExecuteDataReaderCommand(command);
                while (dr.Read())
                {
                    t = new Suppliers(byte.Parse(dr[0].ToString()), dr[1].ToString(),dr[2].ToString(), byte.Parse(dr[3].ToString()), DateTime.Parse(dr[4].ToString()), DateTime.Parse(dr[5].ToString()), short.Parse(dr[6].ToString()));
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                command.Connection.Close();
                dr.Close();
            }
            return t;
        }

        public int Insert(Suppliers t)
        {
            string query = @"INSERT INTO Supplier (supplierName,numberPhone,lastUpdate,idUser)
                            VALUES (@supplierName,@numberPhone,CURRENT_TIMESTAMP,@idUser)";
            try
            {
                SqlCommand command = DataBase.CreateBasicCommand(query);
                command.Parameters.AddWithValue("@supplierName", t.SupplierName);
                command.Parameters.AddWithValue("@numberPhone", t.NumberPhone);
                command.Parameters.AddWithValue("@idUser", t.IdUser);
                return DataBase.ExecuteBasicCommand(command);

            }
            catch (Exception ex)
            {
                //Logs de errores
                throw ex;
            }
        }

        public DataTable Select()
        {
            string query = @"SELECT *
                              FROM vwSupplier
                              ORDER BY 2";
            try
            {
                SqlCommand command = DataBase.CreateBasicCommand(query);
                return DataBase.ExecuteDataTableCommand(command);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public int Update(Suppliers t)
        {
            string query = @"UPDATE Supplier SET supplierName=@supplierName,numberPhone=@numberPhone,lastUpdate=CURRENT_TIMESTAMP,idUser=@idUser
                            WHERE idSupplier=@idSupplier";
            try
            {
                SqlCommand command = DataBase.CreateBasicCommand(query);
                command.Parameters.AddWithValue("@supplierName", t.SupplierName);
                command.Parameters.AddWithValue("@numberPhone", t.NumberPhone);
                command.Parameters.AddWithValue("@idUser", t.IdUser);
                command.Parameters.AddWithValue("@idSupplier", t.IdSupplier);
                return DataBase.ExecuteBasicCommand(command);

            }
            catch (Exception ex)
            {
                //Logs de errores
                throw ex;
            }
        }
    }
}

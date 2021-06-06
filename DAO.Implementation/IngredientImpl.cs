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
    public class IngredientImpl : IIngredient
    {
        public int Delete(Ingredients t)
        {
            string query = @"UPDATE Ingredient SET status=0,lastUpdate=CURRENT_TIMESTAMP,idUser=@idUser
                            WHERE idIngredient=@idIngredient";
            try
            {
                SqlCommand command = DataBase.CreateBasicCommand(query);
                command.Parameters.AddWithValue("@idUser", t.IdUser);
                command.Parameters.AddWithValue("@idIngredient", t.IdIngredient);
                return DataBase.ExecuteBasicCommand(command);
            }
            catch (Exception ex)
            {
                //Logs de errores
                throw ex;
            }
        }

        public Ingredients Get(byte id)
        {
            Ingredients t = null;
            string query = @"SELECT idIngredient,ingredientName,status,registerDate,lastUpdate,idUser
                            FROM Ingredient
                            WHERE idIngredient=@idIngredient";
            SqlCommand command = null;
            SqlDataReader dr = null;
            try
            {
                command = DataBase.CreateBasicCommand(query);
                command.Parameters.AddWithValue("@idIngredient", id);
                dr = DataBase.ExecuteDataReaderCommand(command);
                while (dr.Read())
                {
                    t = new Ingredients(byte.Parse(dr[0].ToString()), dr[1].ToString(), byte.Parse(dr[2].ToString()), DateTime.Parse(dr[3].ToString()), DateTime.Parse(dr[4].ToString()), short.Parse(dr[5].ToString()));
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

        public int Insert(Ingredients t)
        {
            string query = @"INSERT INTO Ingredient(ingredientName,lastUpdate,idUser)
                            VALUES (@ingredientName,CURRENT_TIMESTAMP,@idUser)";
            try
            {
                SqlCommand command = DataBase.CreateBasicCommand(query);
                command.Parameters.AddWithValue("@ingredientName", t.IngredientName);
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
                              FROM vwIngredient
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

        public int Update(Ingredients t)
        {
            string query = @"UPDATE Ingredient SET ingredientName=@ingredientName,lastUpdate=CURRENT_TIMESTAMP,idUser=@idUser
                            WHERE idIngredient=@idIngredient";
            try
            {
                SqlCommand command = DataBase.CreateBasicCommand(query);
                command.Parameters.AddWithValue("@ingredientName", t.IngredientName);
                command.Parameters.AddWithValue("@idUser", t.IdUser);
                command.Parameters.AddWithValue("@idIngredient", t.IdIngredient);
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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO.Model
{
    public class Ingredients : BaseModel
    {
        #region Properties
        public byte IdIngredient { get; set; }
        public string IngredientName { get; set; }
        #endregion
        #region Constructors
        public Ingredients()
        {

        }

        /// <summary>
        /// GET
        /// </summary>
        /// <param name="idIngredient"></param>
        /// <param name="ingredientName"></param>
        /// <param name="status"></param>
        /// <param name="registerDate"></param>
        /// <param name="lastUpdate"></param>
        /// <param name="idUser"></param>
        public Ingredients(byte idIngredient, string ingredientName, byte status, DateTime registerDate, DateTime lastUpdate, short idUser)
             : base(status, registerDate, lastUpdate, idUser)
        {
            IdIngredient = idIngredient;
            IngredientName = ingredientName;
        }

        /// <summary>
        /// Insert
        /// </summary>
        /// <param name="idIngredient"></param>
        /// <param name="ingredientName"></param>
        /// <param name="idUser"></param>
        public Ingredients(string ingredientName, short idUser)
        {
            IngredientName = ingredientName;
            IdUser = idUser;
        }
        #endregion
        #region Methods

        #endregion
    }
}

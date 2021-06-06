using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO.Model
{
    public class Suppliers:BaseModel
    {
        #region Properties
        public byte IdSupplier { get; set; }
        public string SupplierName { get; set; }
        public string NumberPhone { get; set; }
        #endregion

        #region Constructors
        public Suppliers()
        {

        }

        /// <summary>
        /// GET
        /// </summary>
        /// <param name="idSupplier"></param>
        /// <param name="supplierName"></param>
        /// <param name="numberPhone"></param>
        /// <param name="status"></param>
        /// <param name="registerDate"></param>
        /// <param name="lastUpdate"></param>
        /// <param name="idUser"></param>
        public Suppliers(byte idSupplier, string supplierName, string numberPhone, byte status, DateTime registerDate, DateTime lastUpdate, short idUser)
            :base(status,registerDate,lastUpdate,idUser)
        {
            IdSupplier = idSupplier;
            SupplierName = supplierName;
            NumberPhone = numberPhone;
        }

        /// <summary>
        /// Insert
        /// </summary>
        /// <param name="supplierName"></param>
        /// <param name="idUser"></param>
        public Suppliers(string supplierName, string numberPhone, short idUser)
        {
            SupplierName = supplierName;
            NumberPhone = numberPhone; 
            IdUser = idUser;
        }
        #endregion

        #region Methods

        #endregion
    }
}

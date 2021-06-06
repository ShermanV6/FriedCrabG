using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO.Model
{
    public class BaseModel
    {
        #region Properties
        public byte Status { get; set; }
        public DateTime RegisterDate { get; set; }
        public DateTime LastUpdate { get; set; }
        public short IdUser { get; set; }
        #endregion

        #region Constructors
        public BaseModel()
        {

        }

        public BaseModel(byte status, DateTime registerDate, DateTime lastUpdate, short idUser)
        {
            Status = status;
            RegisterDate = registerDate;
            LastUpdate = lastUpdate;
            IdUser = idUser;
        }
        #endregion
    }
}

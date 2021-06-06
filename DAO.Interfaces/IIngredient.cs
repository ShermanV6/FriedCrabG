﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAO.Model;
using System.Data;

namespace DAO.Interfaces
{
    public interface IIngredient:IDao<Ingredients>
    {
        Ingredients Get(byte id);
    }
}

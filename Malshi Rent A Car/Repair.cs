﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace Malshi_Rent_A_Car
{
    abstract class Repair
    {
        protected string RepairID;
        protected string repairDate;
        protected string repairLocation;
        protected int repairCost;
        protected string repairDetails;

        abstract public int addRepair(string vehicle);
        abstract public DataTable viewRepair();
        abstract public DataTable viewRepair(string id);
        abstract public int updateRepair(string vid);

    }
}

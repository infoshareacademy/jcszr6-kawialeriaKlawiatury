﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodTrakker.BusinessLogic
{
    public interface Iindexable
    {
        int Id { get; }

        void UpdateIndex(int i);
    }
}

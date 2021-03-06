﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flower_Shop_Project.Flowers
{
    [Serializable]
    public class Rose : Flower
    {
        public Rose() { }
        public Rose(string sort, Color color, int price)
            : base(sort, color, price){}
        
        public override string ToString()
        {
            return string.Format("{0} - {1}", "Rose", base.ToString());
        }

    }
}

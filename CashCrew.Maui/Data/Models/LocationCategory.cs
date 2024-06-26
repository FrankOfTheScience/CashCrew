﻿using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CashCrew.Data.Models
{
    public class LocationCategory
    {
        [PrimaryKey]
        public string Name { get; set; }
        public string Image { get; set; }

        public LocationCategory(string name, string image)
        {
            Name = name;
            Image = image;
        }

        public LocationCategory() { }
    }
}

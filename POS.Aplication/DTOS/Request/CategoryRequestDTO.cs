﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.Aplication.DTOS.Request
{
    public class CategoryRequestDTO
    {
        public string? Name { get; set; }
        public string? Description { get; set; } 
        public int State { get; set; }
    }
}

﻿using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class InstructorType :BaseEntity
    {
        public InstructorType()
        {
             
        }
        public string Name { get; set; }
    } 
}


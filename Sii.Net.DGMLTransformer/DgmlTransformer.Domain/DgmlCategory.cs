﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DGMLTransformer.Domain
{
    public class DgmlCategory
    {
        public string Id { get; set; }
        public string Label { get; set; }

        public override string ToString()
        {
            return Label;
        }
    }
}

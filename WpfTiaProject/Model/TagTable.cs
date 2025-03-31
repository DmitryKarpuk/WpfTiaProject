﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Siemens.Engineering;
using Siemens.Engineering.SW;
using Siemens.Engineering.SW.Tags;

namespace WpfTiaProject.Model
{
    public class TagTable
    {
        public bool IsSelected {  get; set; }
        public PlcTagTable PlcTagTable { get; set; }
        public TagTable() { }
        public TagTable(PlcTagTable plcTagTable, bool isSelected=false)
        {
            IsSelected = isSelected;
            PlcTagTable = plcTagTable;
        }
    }
}

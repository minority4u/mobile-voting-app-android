﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MSO.StimmApp.Elements
{
    public class BottomlinelessExpandableEditor : Editor
    {
        public BottomlinelessExpandableEditor()
        {
            this.TextChanged += (sender, e) => { this.InvalidateMeasure(); };
        }
    }
}

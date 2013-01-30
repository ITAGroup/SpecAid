using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpecAid.Base
{
    public class CompareRowResult
    {
        public List<CompareColumnResult> columnResults = new List<CompareColumnResult>();
        
        public int totalErrors
        {
            get { return columnResults.Where(n => n.IsError == true).Count(); }
        }
    }
}

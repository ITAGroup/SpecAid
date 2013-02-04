using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpecAid.Base
{
    public class CompareColumnResult
    {
        public string ExpectedPrint = string.Empty;
        public string ActualPrint = string.Empty;

        public bool IsError = false;
        public string ErrorMessage = string.Empty;
    }
}

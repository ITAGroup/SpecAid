using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;

namespace SpecAid.Helper
{
    public static class AssemblyEntryFinderInUnitTests
    {
        // Because Assembly.GetEntryAssembly() doesn't work in UnitTests...
        public static Assembly Go()
        {
            var specAidAssembly = Assembly.GetExecutingAssembly();

            StackTrace stackTrace = new StackTrace();           // get call stack
            StackFrame[] stackFrames = stackTrace.GetFrames();  // get method calls (frames)

            Assembly assembly = null;
            foreach (var stackFrame in stackFrames)
            {
                try
                {
                    var dType = stackFrame.GetMethod().DeclaringType;

                    if (dType == null)
                        continue;

                    assembly = dType.Assembly;

                    if (specAidAssembly.FullName != assembly.FullName)
                    {
                        return assembly;
                    }
                }
// ReSharper disable EmptyGeneralCatchClause
                catch
// ReSharper restore EmptyGeneralCatchClause
                {
                    // Throw away the exception... 
                    // Either we have the assembly in the Stack or we don't...
                }
            }

            return assembly;
        }
    }
}

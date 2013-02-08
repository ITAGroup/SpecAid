using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SpecAid;

namespace SpecAidGitHubSamples.Common
{
    public static class RecallAidHelper
    {
        public static TReal GetReal<TReal>() where TReal : new()
        {
            var lookup = typeof(TReal).FullName;

            if (RecallAid.It.ContainsKey(lookup))
                return (TReal)RecallAid.It[lookup];

            var saveThis = new TReal();
            RecallAid.It[lookup] = saveThis;

            return saveThis;
        }
    }
}

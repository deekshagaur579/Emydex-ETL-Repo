using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FarmSystem.Test1.Utilities
{
    public static class Utility
    {
        public static string GenerateId()
        {
            return Guid.NewGuid().ToString();
        }
    }
}


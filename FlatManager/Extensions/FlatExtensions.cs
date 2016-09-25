using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlatManager.Models.FlatModels;

namespace FlatManager.Extensions
{
    public static class FlatExtensions
    {
        public static string ToGridView(this Flat flat)
        {
            return flat.Address.ToString();
        }
    }
}

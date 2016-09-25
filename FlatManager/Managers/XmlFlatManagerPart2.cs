using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlatManager.Models.FlatModels;

namespace FlatManager.Managers
{
    public partial class XmlFlatManager
    {
        private string filePath;
        private IEnumerable<Owner> owners;

        public string FilePath
        {
            get { return filePath; }
        }
    }
}

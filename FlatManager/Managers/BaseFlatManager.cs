using System.Collections.Generic;
using System.Linq;
using FlatManager.Extensions;
using FlatManager.Models.FlatModels;
using System;

namespace FlatManager.Managers
{
    public abstract class BaseFlatManager
    {
        public delegate bool FlatFilter(Flat flat);

        protected List<Flat> flats;

        public abstract void ReadFlats();
        public abstract void WriteFlats();

        public IEnumerable<KeyValuePair<int, string>> GetFlatList()
        {
            return flats.Select(f => f.ToGridView());
        }

        public IEnumerable<KeyValuePair<int, string>> GetFlatList(string region, FlatFilter filter)
        {
            Func<Flat, bool> regionFilter;
            if (string.Equals(region, "Минск", StringComparison.InvariantCultureIgnoreCase))
            {
                regionFilter = f => string.Equals(f.Address.City, region, StringComparison.InvariantCultureIgnoreCase);
            }
            else
            {
                regionFilter = f => string.Equals(f.Address.Region, region, StringComparison.InvariantCultureIgnoreCase);
            }
            return flats.Where(flat => regionFilter(flat) && filter(flat)).Select(f => f.ToGridView());
        }

        public Flat GetFlat(int id)
        {
            var result = flats.Single(f => f.Id == id);
            OnGetFlat(result);
            return result;
        }

        protected virtual void OnGetFlat(Flat flat) { }

        public IEnumerable<string> GetRegionList()
        {
            return flats.Select(f => f.Address.Region)
                        .Distinct(StringComparer.OrdinalIgnoreCase)
                        .OrderBy(s => s, StringComparer.OrdinalIgnoreCase);
        }
    }
}

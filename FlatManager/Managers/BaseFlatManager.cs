using System.Collections.Generic;
using System.Linq;
using FlatManager.Extensions;
using FlatManager.Models.FlatModels;

namespace FlatManager.Managers
{
    public abstract class BaseFlatManager
    {
        public delegate bool FlatFilter(Flat flat);

        protected IEnumerable<Flat> flats;

        public abstract void ReadFlats();
        public abstract void WriteFlats();

        public IEnumerable<string> GetFlatList()
        {
            return flats.Select(f => f.ToGridView());
        }

        public IEnumerable<string> GetFlatList(FlatFilter filter)
        {
            return flats.Where(flat => filter(flat)).Select(f => f.ToGridView());
        }

        public Flat GetFlat(int id)
        {
            var result = flats.Single(f => f.Id == id);
            OnGetFlat(result);
            return result;
        }

        protected virtual void OnGetFlat(Flat flat) { }
    }
}

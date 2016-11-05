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

        public IEnumerable<KeyValuePair<int, string>> GetFlatList(int ownerId)
        {
            return flats.Where(flat => flat.Owner.Id == ownerId).Select(f => f.ToGridView());
        }

        public Flat GetFlat(int id, bool executeEvent = true)
        {
            var result = flats.Single(f => f.Id == id);
            if (executeEvent)
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

        public void CreateFlat(Flat flat)
        {
            if (flat == null) throw new ArgumentNullException(nameof(flat));
            flat.Id = flats.Any() ? flats.Max(f => f.Id) + 1 : 0;
            flats.Add(flat);
        }

        public void UpdateFlat(Flat flat)
        {
            var toUpdate = flats.Single(f => f.Id == flat.Id);
            toUpdate.Address = flat.Address;
            toUpdate.RentCostPerMonth = flat.RentCostPerMonth;
            toUpdate.RoomCount = flat.RoomCount;
            toUpdate.Square = flat.Square;
            toUpdate.Views = 0;
        }

        public void DeleteFlat(int flatId)
        {
            flats.RemoveAll(f => f.Id == flatId);
        }

        public abstract List<Owner> Owners { get; }

        public abstract void CreateOwner(Owner owner);

        public bool IsUniqueOwner(Owner owner)
        {
            return
                !Owners.Any(
                    ow => string.Equals(ow.PhoneNumber, owner.PhoneNumber, StringComparison.InvariantCultureIgnoreCase));
        }
    }
}

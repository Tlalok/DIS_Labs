using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using FlatManager.Models.FlatModels;

namespace FlatManager.Managers
{
    public partial class XmlFlatManager: BaseFlatManager
    {
        public static readonly string SupportedFormat = ".xml";
    
        public XmlFlatManager(string filePath)
        {
            if (!File.Exists(filePath))
            {
                throw new FileNotFoundException("File not found", filePath);
            }
            if (
                !string.Equals(Path.GetExtension(filePath), SupportedFormat, StringComparison.InvariantCultureIgnoreCase))
            {
                throw new NotSupportedException("File has not supported format.");
            }
            this.filePath = filePath;
        }

        public override void ReadFlats()
        {
            var document = XDocument.Load(filePath);
            

            var ownerData = from el in document.Root.Elements()
                            where string.Equals(el.Name.LocalName, "owners", StringComparison.InvariantCultureIgnoreCase)
                            select el;

            this.owners = from el in ownerData.First().Elements()
                         select new Owner
                         {
                             Id = int.Parse(el.Attribute("id").Value),
                             Name = el.Attribute("name").Value,
                             Secondname = el.Attribute("secondname").Value,
                             PhoneNumber = el.Attribute("phoneNumber").Value,
                         };

            var ownerDictionary = owners.ToDictionary(o => o.Id);

            var flatData = from el in document.Root.Elements()
                           where string.Equals(el.Name.LocalName, "flats", StringComparison.InvariantCultureIgnoreCase)
                           select el;

            this.flats = from el in flatData.First().Elements()
                               select new Flat
                               {
                                   Id = int.Parse(el.Attribute("id").Value),
                                   RentCostPerMonth = double.Parse(el.Attribute("rentCostPerMonth").Value),
                                   RoomCount = int.Parse(el.Attribute("roomCount").Value),
                                   Square = int.Parse(el.Attribute("square").Value),
                                   Views = int.Parse(el.Attribute("views").Value),
                                   Owner = ownerDictionary[int.Parse(el.Attribute("owner").Value)],
                                   Address = new Address
                                   {
                                       Region = el.Element("address").Attributes().Count(a => string.Equals(a.Name.LocalName, "region", StringComparison.InvariantCultureIgnoreCase)) != 0 
                                       ? el.Element("address").Attribute("region").Value 
                                       : null,
                                       City = el.Element("address").Attribute("city").Value,
                                       Street = el.Element("address").Attribute("street").Value,
                                       HouseNumber = int.Parse(el.Element("address").Attribute("houseNumber").Value),
                                       FlatNumber = int.Parse(el.Element("address").Attribute("flatNumber").Value),
                                   }
                               };



        }

        public override void WriteFlats()
        {
            var document = new XDocument(new XElement("root"));

            var ownersElement = new XElement("owners");
            foreach (var owner in owners)
            {
                var ownerElement = new XElement("owner");
                ownerElement.Add(new XAttribute("id", owner.Id));
                ownerElement.Add(new XAttribute("name", owner.Name));
                ownerElement.Add(new XAttribute("secondname", owner.Secondname));
                ownerElement.Add(new XAttribute("phoneNumber", owner.PhoneNumber));
                ownersElement.Add(ownerElement);
            }
            document.Root.Add(ownersElement);

            var flatsElement = new XElement("flats");
            foreach (var flat in flats)
            {
                var flatElement = new XElement("flat");
                flatElement.Add(new XAttribute("id", flat.Id));
                flatElement.Add(new XAttribute("rentCostPerMonth", flat.RentCostPerMonth));
                flatElement.Add(new XAttribute("roomCount", flat.RoomCount));
                flatElement.Add(new XAttribute("views", flat.Views));
                flatElement.Add(new XAttribute("owner", flat.Owner.Id));
                var addressElement = new XElement("address");
                if (flat.Address.Region != null)
                    addressElement.Add(new XAttribute("region", flat.Address.Region));
                addressElement.Add(new XAttribute("city", flat.Address.City));
                addressElement.Add(new XAttribute("street", flat.Address.Street));
                addressElement.Add(new XAttribute("houseNumber", flat.Address.HouseNumber));
                addressElement.Add(new XAttribute("flatNumber", flat.Address.FlatNumber));
                flatElement.Add(addressElement);
                flatsElement.Add(flatElement);
            }
            document.Root.Add(flatsElement);

            document.Save(filePath);
        }

        protected override void OnGetFlat(Flat flat)
        {
            flat.Views++;
        }
    }
}

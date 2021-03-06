﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using FlatManager.Managers;
using FlatManager.Models.FlatModels;
using FlatManager.UserUI;
using FlatManager.UserUI.Menu;

namespace FlatManager
{
    class Program
    {
        private static string filePath = "test.xml";

        private static List<Flat> flats;
        private static List<Owner> owners;

        static void Main(string[] args)
        {
            var menu = new MenuWrapper(
                new MainMenu(),
                new List<Action>
                {
                    () => new OwnerUI(new XmlFlatManager(filePath)).Run(),
                    () => new ClientUI(new XmlFlatManager(filePath)).Run()
                });
            menu.Run();

            return;
            GenerateTestData();
            return;
        }

        private static void GenerateTestData()
        {
            owners = new List<Owner>();
            var owner = new Owner
            {
                Id = 0,
                Name = "Иван",
                Secondname = "Иванов",
                PhoneNumber = "123456789"
            };
            owners.Add(owner);
            owner = new Owner
            {
                Id = 1,
                Name = "Игорь",
                Secondname = "Сидоров",
                PhoneNumber = "987654321"
            };
            owners.Add(owner);


            flats = new List<Flat>();
            flats.Add(new Flat
            {
                Id = 0,
                Owner = owner,
                Address = new Address
                {
                    Region = "Гомельская",
                    Street = "Ленина",
                    FlatNumber = 116,
                    City = "Гомель",
                    HouseNumber = 11
                },
                RentCostPerMonth = 300,
                RoomCount = 3,
                Square = 60,
                Views = 0
            });

            flats.Add(new Flat
            {
                Id = 1,
                Owner = owner,
                Address = new Address
                {
                    Street = "Орловская",
                    FlatNumber = 85,
                    City = "Минск",
                    HouseNumber = 3
                },
                RentCostPerMonth = 270,
                RoomCount = 3,
                Square = 54,
                Views = 0
            });

            flats.Add(new Flat
            {
                Id = 2,
                Owner = owner,
                Address = new Address
                {
                    Street = "Гикало",
                    FlatNumber = 4,
                    City = "Минск",
                    HouseNumber = 13
                },
                RentCostPerMonth = 200,
                RoomCount = 2,
                Square = 41,
                Views = 0
            });

            flats.Add(new Flat
            {
                Id = 3,
                Owner = owner,
                Address = new Address
                {
                    Street = "Козлова",
                    FlatNumber = 25,
                    City = "Минск",
                    HouseNumber = 4
                },
                RentCostPerMonth = 190,
                RoomCount = 2,
                Square = 37,
                Views = 0
            });

            WriteFlats();
        }

        public static void WriteFlats()
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
                flatElement.Add(new XAttribute("square", flat.Square));
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
    }
}

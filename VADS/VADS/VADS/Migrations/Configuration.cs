using System.Data.Entity.ModelConfiguration.Conventions;
using VADS.Models;

namespace VADS.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<VADS.Models.UsersContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(VADS.Models.UsersContext context)
        {
            //TODO: Poner Marcas y Modelos con sus IDs respondientes
            context.VehicleBrandses.AddOrUpdate(x => x.Brand,
                                                new VehicleBrands() { Brand = "Toyota", BrandId = 1 },
                                                new VehicleBrands() { Brand = "Honda", BrandId = 2 },
                                                new VehicleBrands() { Brand = "Mitsubishi", BrandId = 3 },
                                                new VehicleBrands() { Brand = "Peugeot", BrandId = 4 },
                                                new VehicleBrands() { Brand = "Renault", BrandId = 5 },
                                                new VehicleBrands() { Brand = "Nissan", BrandId = 6 },
                                                new VehicleBrands() { Brand = "Subaru", BrandId = 7 },
                                                new VehicleBrands() { Brand = "Mazda", BrandId = 8 },
                                                new VehicleBrands() { Brand = "Suzuki", BrandId = 9 },
                                                new VehicleBrands() { Brand = "Chevrolet", BrandId = 10 },
                                                new VehicleBrands() { Brand = "Volvo", BrandId = 11 },
                                                new VehicleBrands() { Brand = "Dodge", BrandId = 12 },
                                                new VehicleBrands() { Brand = "Infinity", BrandId = 13 },
                                                new VehicleBrands() { Brand = "Seat", BrandId = 14 },
                                                new VehicleBrands() { Brand = "Chrystler", BrandId = 15 },
                                                new VehicleBrands() { Brand = "Opel", BrandId = 16 },
                                                new VehicleBrands() { Brand = "Jaguar", BrandId = 17 },
                                                new VehicleBrands() { Brand = "Citroen", BrandId = 18 },
                                                new VehicleBrands() { Brand = "Buik", BrandId = 19 },
                                                new VehicleBrands() { Brand = "Fiat", BrandId = 20 }
                                                );
            context.VehicleModelses.AddOrUpdate(x => x.Model,
                                                new VehicleModels() { Model = "Corolla", BrandId = 1 },
                                                new VehicleModels() { Model = "Camry", BrandId = 1 },
                                                new VehicleModels() { Model = "Yaris", BrandId = 1 },
                                                new VehicleModels() { Model = "Civic", BrandId = 2 },
                                                new VehicleModels() { Model = "Accord", BrandId = 2 },
                                                new VehicleModels() { Model = "Fit", BrandId = 2 },
                                                new VehicleModels() { Model = "Lancer", BrandId = 3 },
                                                new VehicleModels() { Model = "Galant", BrandId = 3 },
                                                new VehicleModels() { Model = "Mirage", BrandId = 3 },
                                                new VehicleModels() { Model = "407", BrandId = 4 },
                                                new VehicleModels() { Model = "307", BrandId = 4 },
                                                new VehicleModels() { Model = "206", BrandId = 4 },
                                                new VehicleModels() { Model = "Cleo", BrandId = 5 },
                                                new VehicleModels() { Model = "Megane", BrandId = 5 },
                                                new VehicleModels() { Model = "Stepway", BrandId = 5 },
                                                new VehicleModels() { Model = "Sentra", BrandId = 6 },
                                                new VehicleModels() { Model = "Tidda", BrandId = 6 },
                                                new VehicleModels() { Model = "Versa", BrandId = 6 },
                                                new VehicleModels() { Model = "Impreza", BrandId = 7 },
                                                new VehicleModels() { Model = "Forester", BrandId = 7 },
                                                new VehicleModels() { Model = "Outback", BrandId = 7 },
                                                new VehicleModels() { Model = "2", BrandId = 8 },
                                                new VehicleModels() { Model = "3", BrandId = 8 },
                                                new VehicleModels() { Model = "5", BrandId = 8 },
                                                new VehicleModels() { Model = "Aerio", BrandId = 9 },
                                                new VehicleModels() { Model = "Samurai", BrandId = 9 },
                                                new VehicleModels() { Model = "Grand Vitara", BrandId = 9 },
                                                new VehicleModels() { Model = "Suburban", BrandId = 10 },
                                                new VehicleModels() { Model = "Tahoe", BrandId = 10 },
                                                new VehicleModels() { Model = "Camaro", BrandId = 10 },
                                                new VehicleModels() { Model = "S80", BrandId = 11 },
                                                new VehicleModels() { Model = "V70", BrandId = 11 },
                                                new VehicleModels() { Model = "V60", BrandId = 11 },
                                                new VehicleModels() { Model = "Durango", BrandId = 12 },
                                                new VehicleModels() { Model = "Journey", BrandId = 12 },
                                                new VehicleModels() { Model = "Viper", BrandId = 12 },
                                                new VehicleModels() { Model = "Q50", BrandId = 13 },
                                                new VehicleModels() { Model = "Q60", BrandId = 13 },
                                                new VehicleModels() { Model = "QX50", BrandId = 13 },
                                                new VehicleModels() { Model = "Toledo", BrandId = 14 },
                                                new VehicleModels() { Model = "Leon", BrandId = 14 },
                                                new VehicleModels() { Model = "Altea", BrandId = 14 },
                                                new VehicleModels() { Model = "300", BrandId = 15 },
                                                new VehicleModels() { Model = "Delta", BrandId = 15 },
                                                new VehicleModels() { Model = "Grand Voyager", BrandId = 15 },
                                                new VehicleModels() { Model = "Adam", BrandId = 16 },
                                                new VehicleModels() { Model = "Corsa", BrandId = 16 },
                                                new VehicleModels() { Model = "Astra", BrandId = 16 },
                                                new VehicleModels() { Model = "XJ", BrandId = 17 },
                                                new VehicleModels() { Model = "XK", BrandId = 17 },
                                                new VehicleModels() { Model = "XF", BrandId = 17 },
                                                new VehicleModels() { Model = "C3", BrandId = 18 },
                                                new VehicleModels() { Model = "C4", BrandId = 18 },
                                                new VehicleModels() { Model = "Metropolis", BrandId = 18 },
                                                new VehicleModels() { Model = "Enclave", BrandId = 19 },
                                                new VehicleModels() { Model = "Riviera", BrandId = 19 },
                                                new VehicleModels() { Model = "LaCrosse", BrandId = 19 },
                                                new VehicleModels() { Model = "Punto", BrandId = 20 },
                                                new VehicleModels() { Model = "Stilo", BrandId = 20 },
                                                new VehicleModels() { Model = "Panda", BrandId = 20 }
                );
        }
    }
}

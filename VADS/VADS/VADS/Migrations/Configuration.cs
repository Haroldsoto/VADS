using VADS.Models;

namespace VADS.Migrations
{
    using System.Data.Entity.Migrations;

    internal sealed class Configuration : DbMigrationsConfiguration<UsersContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(UsersContext context)
        {
            //TODO: Poner Marcas y Modelos con sus IDs respondientes
            context.VehicleBrands.AddOrUpdate(x => x.Brand,
                                                new VehicleBrand() { Brand = "Toyota", BrandId = 1 },
                                                new VehicleBrand() { Brand = "Honda", BrandId = 2 },
                                                new VehicleBrand() { Brand = "Mitsubishi", BrandId = 3 },
                                                new VehicleBrand() { Brand = "Peugeot", BrandId = 4 },
                                                new VehicleBrand() { Brand = "Renault", BrandId = 5 },
                                                new VehicleBrand() { Brand = "Nissan", BrandId = 6 },
                                                new VehicleBrand() { Brand = "Subaru", BrandId = 7 },
                                                new VehicleBrand() { Brand = "Mazda", BrandId = 8 },
                                                new VehicleBrand() { Brand = "Suzuki", BrandId = 9 },
                                                new VehicleBrand() { Brand = "Chevrolet", BrandId = 10 },
                                                new VehicleBrand() { Brand = "Volvo", BrandId = 11 },
                                                new VehicleBrand() { Brand = "Dodge", BrandId = 12 },
                                                new VehicleBrand() { Brand = "Infinity", BrandId = 13 },
                                                new VehicleBrand() { Brand = "Seat", BrandId = 14 },
                                                new VehicleBrand() { Brand = "Chrystler", BrandId = 15 },
                                                new VehicleBrand() { Brand = "Opel", BrandId = 16 },
                                                new VehicleBrand() { Brand = "Jaguar", BrandId = 17 },
                                                new VehicleBrand() { Brand = "Citroen", BrandId = 18 },
                                                new VehicleBrand() { Brand = "Buik", BrandId = 19 },
                                                new VehicleBrand() { Brand = "Fiat", BrandId = 20 }
                                                );
            context.VehicleModels.AddOrUpdate(x => x.Model,
                                                new VehicleModel() { Model = "Corolla", BrandId = 1 },
                                                new VehicleModel() { Model = "Camry", BrandId = 1 },
                                                new VehicleModel() { Model = "Yaris", BrandId = 1 },
                                                new VehicleModel() { Model = "Civic", BrandId = 2 },
                                                new VehicleModel() { Model = "Accord", BrandId = 2 },
                                                new VehicleModel() { Model = "Fit", BrandId = 2 },
                                                new VehicleModel() { Model = "Lancer", BrandId = 3 },
                                                new VehicleModel() { Model = "Galant", BrandId = 3 },
                                                new VehicleModel() { Model = "Mirage", BrandId = 3 },
                                                new VehicleModel() { Model = "407", BrandId = 4 },
                                                new VehicleModel() { Model = "307", BrandId = 4 },
                                                new VehicleModel() { Model = "206", BrandId = 4 },
                                                new VehicleModel() { Model = "Cleo", BrandId = 5 },
                                                new VehicleModel() { Model = "Megane", BrandId = 5 },
                                                new VehicleModel() { Model = "Stepway", BrandId = 5 },
                                                new VehicleModel() { Model = "Sentra", BrandId = 6 },
                                                new VehicleModel() { Model = "Tidda", BrandId = 6 },
                                                new VehicleModel() { Model = "Versa", BrandId = 6 },
                                                new VehicleModel() { Model = "Impreza", BrandId = 7 },
                                                new VehicleModel() { Model = "Forester", BrandId = 7 },
                                                new VehicleModel() { Model = "Outback", BrandId = 7 },
                                                new VehicleModel() { Model = "2", BrandId = 8 },
                                                new VehicleModel() { Model = "3", BrandId = 8 },
                                                new VehicleModel() { Model = "5", BrandId = 8 },
                                                new VehicleModel() { Model = "Aerio", BrandId = 9 },
                                                new VehicleModel() { Model = "Samurai", BrandId = 9 },
                                                new VehicleModel() { Model = "Grand Vitara", BrandId = 9 },
                                                new VehicleModel() { Model = "Suburban", BrandId = 10 },
                                                new VehicleModel() { Model = "Tahoe", BrandId = 10 },
                                                new VehicleModel() { Model = "Camaro", BrandId = 10 },
                                                new VehicleModel() { Model = "S80", BrandId = 11 },
                                                new VehicleModel() { Model = "V70", BrandId = 11 },
                                                new VehicleModel() { Model = "V60", BrandId = 11 },
                                                new VehicleModel() { Model = "Durango", BrandId = 12 },
                                                new VehicleModel() { Model = "Journey", BrandId = 12 },
                                                new VehicleModel() { Model = "Viper", BrandId = 12 },
                                                new VehicleModel() { Model = "Q50", BrandId = 13 },
                                                new VehicleModel() { Model = "Q60", BrandId = 13 },
                                                new VehicleModel() { Model = "QX50", BrandId = 13 },
                                                new VehicleModel() { Model = "Toledo", BrandId = 14 },
                                                new VehicleModel() { Model = "Leon", BrandId = 14 },
                                                new VehicleModel() { Model = "Altea", BrandId = 14 },
                                                new VehicleModel() { Model = "300", BrandId = 15 },
                                                new VehicleModel() { Model = "Delta", BrandId = 15 },
                                                new VehicleModel() { Model = "Grand Voyager", BrandId = 15 },
                                                new VehicleModel() { Model = "Adam", BrandId = 16 },
                                                new VehicleModel() { Model = "Corsa", BrandId = 16 },
                                                new VehicleModel() { Model = "Astra", BrandId = 16 },
                                                new VehicleModel() { Model = "XJ", BrandId = 17 },
                                                new VehicleModel() { Model = "XK", BrandId = 17 },
                                                new VehicleModel() { Model = "XF", BrandId = 17 },
                                                new VehicleModel() { Model = "C3", BrandId = 18 },
                                                new VehicleModel() { Model = "C4", BrandId = 18 },
                                                new VehicleModel() { Model = "Metropolis", BrandId = 18 },
                                                new VehicleModel() { Model = "Enclave", BrandId = 19 },
                                                new VehicleModel() { Model = "Riviera", BrandId = 19 },
                                                new VehicleModel() { Model = "LaCrosse", BrandId = 19 },
                                                new VehicleModel() { Model = "Punto", BrandId = 20 },
                                                new VehicleModel() { Model = "Stilo", BrandId = 20 },
                                                new VehicleModel() { Model = "Panda", BrandId = 20 }
                );
        }
    }
}

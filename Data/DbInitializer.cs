using Auto.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Auto.Data
{
    public static class DbInitializer
    {
        public static void Initialize(AutoContext context)
        {
            context.Database.EnsureCreated();

            if(context.Piesa.Any())
            {
                // db has been already populated
                return;
            }

            var cars = new List<Car>
            {
            new Car{Brand="Mazda",Model="Mps",FullName="Mazda Mps"},
            new Car{Brand="Mazda",Model="3",FullName="Mazda 3"},
            new Car{Brand="Mazda",Model="CHR",FullName="Mazda CHR"},
            new Car{Brand="Audi",Model="A2",FullName="Audi A2"},
            new Car{Brand="Audi",Model="A4",FullName="Audi A4"},
            new Car{Brand="Audi",Model="Q3",FullName="Audi Q3"},
            new Car{Brand="Tesla",Model="S",FullName="tesla S"},
            new Car{Brand="Tesla",Model="X",FullName="Tesla X"},
            new Car{Brand="Tesla",Model="3",FullName="Tesla 3"}
            };

            cars.ForEach(s => context.Masina.Add(s));
            context.SaveChanges();

            var garages = new List<Garage>
            {
            new Garage{Name="Joe's Garage",Address="511 E Park St Sylacauga"},
            new Garage{Name="Hot  Wheels",Address="630 D St Alexander City"},
            new Garage{Name="Lego",Address="524 Prairie Ave Paris"},
            new Garage{Name="Cars Xpert",Address="402 Sherwood Green Ct Mason"},
            new Garage{Name="Smart Parts",Address="27169 Holiday Rd Battle Lake,"},
            new Garage{Name="Sky",Address="480 Mountain Laurel Dr Columbus"}
            };
            garages.ForEach(s => context.Service.Add(s));
            context.SaveChanges();

            var appointments = new List<Appointment>
            {
            new Appointment{Date=DateTime.Now,CarID=1,GarageID=2},
            new Appointment{Date=DateTime.Now.AddDays(1),CarID=2,GarageID=6},
            new Appointment{Date=DateTime.Now.AddDays(2),CarID=3,GarageID=1},
            new Appointment{Date=DateTime.Now.AddDays(3),CarID=4,GarageID=5},
            new Appointment{Date=DateTime.Now.AddDays(4),CarID=5,GarageID=4},
            new Appointment{Date=DateTime.Now.AddDays(5),CarID=6,GarageID=3},
            };
            appointments.ForEach(s => context.Programare.Add(s));
            context.SaveChanges();

            var parts = new List<Part>
            {
            new Part{Name="Engine",Price=3000,AppointmentID=1},
            new Part{Name="Transmission",Price=2500,AppointmentID=1},
            new Part{Name="Battery",Price=1800,AppointmentID=1},
            new Part{Name="Alternator",Price=1000,AppointmentID=2},
            new Part{Name="Brakes",Price=2000,AppointmentID=2},
            new Part{Name="Muffler",Price=500,AppointmentID=2},
            new Part{Name="Fuel Tank",Price=700,AppointmentID=3},
            new Part{Name="Radiator",Price=400,AppointmentID=3},
            new Part{Name="Headlight",Price=200,AppointmentID=3},
            new Part{Name="Rear Light",Price=200,AppointmentID=4}
            };
            parts.ForEach(s => context.Piesa.Add(s));
            context.SaveChanges();
        }
    }
}

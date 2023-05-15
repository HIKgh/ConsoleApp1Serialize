using System;
using System.Collections.Generic;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace ConsoleApp1
{
    public class BaseAddress
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public class Region : BaseAddress
    {
    }

    public class Place : BaseAddress
    {
        public BaseAddress PlaceType { get; set; }
    }

    public class Street : BaseAddress
    {
        public BaseAddress StreetType { get; set; }
    }

    public class House : BaseAddress
    {
    }

    public class Address : BaseAddress
    {
    }

    public class Point
    {
        public Region Region { get; set; }
        public Place Place { get; set; }
        public Address? Address { get; set; }
        public Street? Street { get; set; }
        public House? House { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
    }

    public class RoutePath
    {
        public List<Point> Points { get; set; }
    }

    public class Program
    {
        static void Main(string[] args)
        {
            var Kladbishe = new Point()
            {
                Region = new()
                {
                    Id = 2,
                    Name = "Курганская область"
                },
                Place = new()
                {
                    Id = 1,
                    Name = "Курган",
                    PlaceType = new()
                    {
                        Id = 4,
                        Name = "город"
                    }
                },
                Address = new()
                {
                    Id = 10,
                    Name = "Кладбище"
                },
                Latitude = 50.0,
                Longitude = 60.0
            };
            var Lenina13 = new Point()
            {
                Region = new()
                {
                    Id = 2,
                    Name = "Курганская область"
                },
                Place = new()
                {
                    Id = 1,
                    Name = "Курган",
                    PlaceType = new()
                    {
                        Id = 4,
                        Name = "город"
                    }
                },
                Street = new()
                {
                    Id = 12,
                    Name = "Ленина",
                    StreetType = new()
                    {
                        Id = 13,
                        Name = "улица"
                    }
                },
                House = new()
                {
                    Id = 22,
                    Name = "13",
                },
                Latitude = 51.0,
                Longitude = 61.0
            };
            var Kurgan = new Point()
            {
                Region = new()
                {
                    Id = 2,
                    Name = "Курганская область"
                },
                Place = new()
                {
                    Id = 1,
                    Name = "Курган",
                    PlaceType = new()
                    {
                        Id = 4,
                        Name = "город"
                    }
                },
                Latitude = 52.0,
                Longitude = 62.0
            };
            var routePath = new RoutePath()
            {
                Points = new List<Point>() { Kladbishe, Lenina13, Kurgan }
            };
            JsonSerializerOptions option = new()
            {
                IgnoreNullValues = true,
                Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping,
            };
            var json = JsonSerializer.Serialize<RoutePath>(routePath, option);
            Console.WriteLine(json);
            Console.ReadKey();
        }
    }
}
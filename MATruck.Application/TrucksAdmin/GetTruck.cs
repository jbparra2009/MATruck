﻿using MATruck.Database;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MATruck.Application.TrucksAdmin
{
    public class GetTruck
    {
        private readonly ApplicationDbContext _ctx;

        public GetTruck(ApplicationDbContext ctx)
        {
            _ctx = ctx;
        }

        public TruckViewModel Do(int id) =>
            _ctx.Trucks.Where(x => x.Id == id).Select(x => new TruckViewModel
            {
                Id = x.Id,
                VIN = x.VIN,
                Year = x.Year,
                Make = x.Make,
                Type = x.Type,
                Class = x.Class,
                BodyType = x.BodyType,
                Lenght = x.Lenght,
                Description = x.Description,
                TruckPlate = x.TruckPlate,
                TruckNumber = x.TruckNumber,
                RegistrantName = x.RegistrantName,
                TitleState = x.TitleState,
                OwnerLessorName = x.OwnerLessorName,
                ExpiresDate = x.ExpiresDate,
                EfectiveDate = x.EfectiveDate,
                IssueDate = x.IssueDate,
                PurchasePrice = x.PurchasePrice,
                PurchaseDate = x.PurchaseDate,
                Status = x.Status,
            })
            .FirstOrDefault();

        public class TruckViewModel
        {
            public int Id { get; set; }
            public string VIN { get; set; }
            public string Year { get; set; }
            public string Make { get; set; }
            public string Type { get; set; }
            public string Class { get; set; }
            public string BodyType { get; set; }
            public string Lenght { get; set; }
            public string Description { get; set; }

            public string TruckPlate { get; set; }
            public string TruckNumber { get; set; }

            public string RegistrantName { get; set; }
            public string TitleState { get; set; }
            public string OwnerLessorName { get; set; }
            public DateTime ExpiresDate { get; set; }
            public DateTime EfectiveDate { get; set; }
            public DateTime IssueDate { get; set; }
            public int PurchasePrice { get; set; }
            public DateTime PurchaseDate { get; set; }

            public string Status { get; set; } // Active, Standby, Sold, Deleted.

        }
    }
}

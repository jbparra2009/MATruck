﻿using MATruck.Database;
using MATruck.Domain.Models;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace MATruck.Application.TrailersAdmin
{
    public class UpdateTrailer
    {
        private readonly ApplicationDbContext _ctx;

        public UpdateTrailer(ApplicationDbContext ctx)
        {
            _ctx = ctx;
        }

        public async Task<Response> Do(Request request)
        {
            var trailer = _ctx.Trailers.FirstOrDefault(x => x.Id == request.Id);

            trailer.Id = request.Id;
            trailer.VIN = request.VIN;
            trailer.Year = request.Year;
            trailer.Make = request.Make;
            trailer.Model = request.Model;
            trailer.Class = request.Class;
            trailer.BodyType = request.BodyType;
            trailer.Lenght = request.Lenght;
            trailer.Description = request.Description;
            trailer.TrailerPlate = request.TrailerPlate;
            trailer.TrailerNumber = request.TrailerNumber;
            trailer.TitleNumber = request.TitleNumber;
            trailer.TitleState = request.TitleState;
            trailer.TitleIssueDate = request.TitleIssueDate;
            trailer.PurchasePrice = request.PurchasePrice;
            trailer.PurchaseDate = request.PurchaseDate;
            trailer.Status = request.Status;

            await _ctx.SaveChangesAsync();

            return new Response
            {
                Id = trailer.Id,
                VIN = trailer.VIN,
                Year = trailer.Year,
                Make = trailer.Make,
                Model = trailer.Model,
                Class = trailer.Class,
                BodyType = trailer.BodyType,
                Lenght = trailer.Lenght,
                Description = trailer.Description,
                TrailerPlate = trailer.TrailerPlate,
                TrailerNumber = trailer.TrailerNumber,
                TitleNumber = trailer.TitleNumber,
                TitleState = trailer.TitleState,
                TitleIssueDate = trailer.TitleIssueDate,
                PurchasePrice = trailer.PurchasePrice,
                PurchaseDate = trailer.PurchaseDate,
                Status = trailer.Status,
            };
        }

        public class Request
        {
            public int Id { get; set; }
            public string VIN { get; set; }
            public string Year { get; set; }
            public string Make { get; set; }
            public string Model { get; set; }
            public string Class { get; set; }
            public string BodyType { get; set; }
            public string Lenght { get; set; }
            public string Description { get; set; }

            public string TrailerPlate { get; set; }
            public string TrailerNumber { get; set; }

            public string TitleNumber { get; set; }
            public string TitleState { get; set; }
            public DateTime TitleIssueDate { get; set; }
            public int PurchasePrice { get; set; }
            public DateTime PurchaseDate { get; set; }

            public string Status { get; set; } // Active, Standby, Deleted.

        }

        public class Response
        {
            public int Id { get; set; }
            public string VIN { get; set; }
            public string Year { get; set; }
            public string Make { get; set; }
            public string Model { get; set; }
            public string Class { get; set; }
            public string BodyType { get; set; }
            public string Lenght { get; set; }
            public string Description { get; set; }

            public string TrailerPlate { get; set; }
            public string TrailerNumber { get; set; }

            public string TitleNumber { get; set; }
            public string TitleState { get; set; }
            public DateTime TitleIssueDate { get; set; }
            public int PurchasePrice { get; set; }
            public DateTime PurchaseDate { get; set; }

            public string Status { get; set; } // Active, Standby, Deleted.

        }
    }
}

﻿using MATruck.Database;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace MATruck.Application.FactoriesAdmin
{
    public class GetFactory
    {
        private readonly ApplicationDbContext _ctx;

        public GetFactory(ApplicationDbContext ctx)
        {
            _ctx = ctx;
        }

        public FactoryViewModel Do(int id) =>
            _ctx.Factories.Where(x => x.Id == id).Select(x => new FactoryViewModel
            {
                Id = x.Id,
                Name = x.Name,
                Description = x.Description,
                Email = x.Email,
                Phone1 = x.Phone1,
                Phone2 = x.Phone2,
                Rate = x.Rate,
                Address1 = x.Address1,
                Address2 = x.Address2,
                City = x.City,
                State = x.State,
                ZipCode = x.ZipCode,
                Created = x.Created,
                Status = x.Status,
            })
            .FirstOrDefault();

        public class FactoryViewModel
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public string Description { get; set; }
            public string Email { get; set; }
            public string Phone1 { get; set; }
            public string Phone2 { get; set; }

            [Column(TypeName = "decimal(18,2)")]
            public decimal Rate { get; set; }

            public string Address1 { get; set; }
            public string Address2 { get; set; }
            public string City { get; set; }
            public string State { get; set; }
            public string ZipCode { get; set; }

            public DateTime Created { get; set; }
            public string Status { get; set; } // Active, Standby, Deleted.

        }
    } 
}

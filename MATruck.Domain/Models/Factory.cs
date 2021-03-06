﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace MATruck.Domain.Models
{
    public class Factory
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

        public DateTime Created { get; set; } = DateTime.Now;
        public string Status { get; set; } // Active, Standby, Deleted.

        public ICollection<FactoryStaff> FactoryStaff { get; set; }

        public ICollection<LoadDataRelationship> LoadDataRelationships { get; set; }
    }
}

﻿using System;

namespace MATruck.Domain.Models
{
    public class BrokerStaff
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Description { get; set; }
        public string Email { get; set; }
        public string Phone1 { get; set; }
        public string Fax1 { get; set; }
        public DateTime Created { get; set; } = DateTime.Now;

        public int BrokerId { get; set; }
        public Broker Broker { get; set; }
    }
}

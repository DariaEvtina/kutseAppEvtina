using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace kutseAppEvtina.Models
{
    public class GuestContext : DbContext
    {
        public DbSet<Guest> Guests { get; set; }
        public DbSet<Holidays> Holidays { get; set; }
    }
}
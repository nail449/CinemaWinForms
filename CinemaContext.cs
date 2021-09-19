using System;
using System.Collections.Generic;
using System.Text;
using System.Data.Entity;

namespace Kino
{
    class CinemaContext : DbContext
    {
        public DbSet<Tickets1> Tickets1 { get; set; }
    }
}

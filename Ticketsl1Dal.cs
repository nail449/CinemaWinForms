using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Data.Entity;

namespace Kino
{
    class Ticketsl1Dal
    {
        public List<Tickets1> GetAll()
        {
            using (CinemaContext context = new CinemaContext())
            {
                return context.Tickets1.ToList();
            }
        }

         public List<Tickets1> GetByName(string key)
        {
            using (CinemaContext context = new CinemaContext())
            {
                return context.Tickets1.Where(a=>a.Name.Contains(key)).ToList();
            }
        }

        public void Add(Tickets1 tickets1)
        {
            using (CinemaContext context = new CinemaContext())
            {
                //context.Tickets.Add(tickets);
                var entity = context.Entry(tickets1);
                entity.State = EntityState.Added;
                context.SaveChanges();
            }
        }

        public void Update(Tickets1 tickets1)
        {
            using (CinemaContext context = new CinemaContext())
            {
                var entity = context.Entry(tickets1);
                entity.State = EntityState.Modified;
                context.SaveChanges();
            }
        }
        public void Delete(Tickets1 tickets1)
        {
            using (CinemaContext context = new CinemaContext())
            {
                var entity = context.Entry(tickets1);
                entity.State = EntityState.Deleted;
                context.SaveChanges();
            }
        }
    }
}

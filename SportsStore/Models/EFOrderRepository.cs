using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportsStore.Models
{
    public class EFOrderRepository : IOrderRepository
    {
        private SportDbContext _db;

        public EFOrderRepository(SportDbContext db)
        {
            _db = db;
        }

        public IQueryable<Order> Orders => _db.Orders.Include(x => x.Lines)
            .ThenInclude(l => l.Product);

        public void SaveOrder(Order order)
        {
            _db.AttachRange(order.Lines.Select(l => l.Product));
            if(order.OrderID == 0)
            {
                _db.Orders.Add(order);
            }
            _db.SaveChanges();
        }
    }
}

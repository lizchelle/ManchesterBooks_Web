using ManchesterBooksWeb2.DataAccess.Repository.IRepository;
using ManchesterBooksWeb2.Models;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ManchesterBooksWeb2.DataAccess.Repository
{
    public class OrderDetailRepository : Repository<OrderDetail>, IOrderDetailRepository
    {
        private ApplicationDbContext _db;
                
        public OrderDetailRepository(ApplicationDbContext db) : base(db)
            {
                _db = db;

            }

       
        public void Update(OrderDetail obj)
        {
            _db.OrderDetail.Update(obj);
        }

    }
}

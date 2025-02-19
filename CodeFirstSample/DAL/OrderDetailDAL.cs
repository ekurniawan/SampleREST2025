using CodeFirstSample.Models;
using Microsoft.EntityFrameworkCore;

namespace CodeFirstSample.DAL
{
    public class OrderDetailDAL : IOrderDetail
    {
        private readonly AppDbContext _appDbContext;
        public OrderDetailDAL(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public Task<OrderDetail> Add(OrderDetail entity)
        {
            throw new NotImplementedException();
        }

        public Task<OrderDetail> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<OrderDetail>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<OrderDetail> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<OrderDetail>> GetByOrderHeaderId(int orderHeaderId)
        {
            var results = await _appDbContext.OrderDetails
                .Include(x => x.Product).ThenInclude(x => x.Category)
                .Include(x => x.OrderHeader).ThenInclude(x => x.Customer)
                .Where(x => x.OrderHeaderId == orderHeaderId).ToListAsync();
            return results;
        }

        public Task<OrderDetail> Update(OrderDetail entity)
        {
            throw new NotImplementedException();
        }
    }
}

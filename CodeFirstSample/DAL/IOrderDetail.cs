using CodeFirstSample.Models;

namespace CodeFirstSample.DAL
{
    public interface IOrderDetail : ICrud<OrderDetail>
    {
        Task<IEnumerable<OrderDetail>> GetByOrderHeaderId(int orderHeaderId);
    }
}

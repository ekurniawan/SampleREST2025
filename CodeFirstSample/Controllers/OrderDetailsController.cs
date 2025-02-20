using AutoMapper;
using CodeFirstSample.DAL;
using CodeFirstSample.DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CodeFirstSample.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderDetailsController : ControllerBase
    {
        private readonly IOrderDetail _orderDetail;
        private readonly IMapper _mapper;

        public OrderDetailsController(IOrderDetail orderDetail, IMapper mapper)
        {
            _orderDetail = orderDetail;
            _mapper = mapper;
        }

        [HttpGet("{id}")]
        public async Task<IEnumerable<OrderDetailDTO>> GetByOrderHeaderId(int id)
        {
            var results = await _orderDetail.GetByOrderHeaderId(id);
            var orderDetailDTOs = _mapper.Map<IEnumerable<OrderDetailDTO>>(results);
            return orderDetailDTOs;
        }

    }
}

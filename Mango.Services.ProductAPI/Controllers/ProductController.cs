using AutoMapper;
using Mango.Services.CouponAPI.Models.Dto;
using Mango.Services.ProductAPI.Data;
using Mango.Services.ProductAPI.Models;
using Mango.Services.ProductAPI.Models.Dto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace Mango.Services.ProductAPI.Controllers
{
    [Route("api/product")]
    [ApiController]
    [Authorize]
    [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.Unauthorized)]
    public class ProductController : ControllerBase
    {
        private readonly AppDbContext _db;
        private readonly IMapper _mapper;
        private ResponseDto _response;
        
        public ProductController(AppDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
            _response = new ResponseDto();
        }

        [HttpGet]
        public async Task<ResponseDto> Get()
        {
            try
            {
                IEnumerable<Product> objList = await _db.Products.ToListAsync();
                _response.Result =  _mapper.Map<IEnumerable<ProductDto>>(objList);

            }
            catch (Exception ex)
            {
                _response.isSuccess = false;
                _response.Message = ex.Message;
            }
            return _response;
        }

        [HttpGet("{id}")]
        public async Task<ResponseDto> GetAsync(int id)
        {
            try
            {
                Product obj = await _db.Products.FirstOrDefaultAsync(u => u.ProductId == id);
                _response.Result = _mapper.Map<ProductDto>(obj);

            }
            catch (Exception ex)
            {
                _response.isSuccess = false;
                _response.Message = ex.Message;
            }
            return _response;
        }

        [HttpPost]
        [Authorize(Roles ="ADMIN")]
        public async Task<ResponseDto> Post([FromBody] ProductDto productDto)
        {
            try
            {
                Product obj = _mapper.Map<Product>(productDto);
                await _db.Products.AddAsync(obj);
                await _db.SaveChangesAsync();
                _response.Result = _mapper.Map<ProductDto>(obj);
            }
            catch (Exception ex)
            {
                _response.isSuccess = false;
                _response.Message = ex.Message;
            }
            return _response;
        }


        [HttpPut]
        [Authorize(Roles = "ADMIN")]
        public async Task<ResponseDto> PutAsync([FromBody] ProductDto productDto)
        {
            try
            {
                Product obj = _mapper.Map<Product>(productDto);
                _db.Products.Update(obj);
               await _db.SaveChangesAsync();

                _response.Result = _mapper.Map<ProductDto>(obj);
            }
            catch (Exception ex)
            {
                _response.isSuccess = false;
                _response.Message = ex.Message;
            }
            return _response;
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "ADMIN")]
        public async Task<ResponseDto> DeleteAsync(int id)
        {
            try
            {
                Product obj = await _db.Products.FirstAsync(u => u.ProductId == id);
                _db.Products.Remove(obj);
                await _db.SaveChangesAsync();

                
                return new ResponseDto { isSuccess = true, Message = "Product successfully deleted." };
            }
            catch (Exception ex)
            {
                
                return new ResponseDto { isSuccess = false, Message = ex.Message };
            }
        }

    }
}

using Mango.Web.Models;
using Mango.Web.Service;
using Mango.Web.Service.IService;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;

namespace Mango.Web.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService _pr;
        public ProductController(IProductService pr)
        {
            _pr = pr;
        }

        public async Task<IActionResult> ProductIndex()
        {
            List<ProductDto?> list = new();
            ResponseDto? response = await _pr.GetAllProductsAsync();

            if (response != null && response.isSuccess)
            {
                list = JsonConvert.DeserializeObject<List<ProductDto>>(Convert.ToString(response.Result));
            }
            else
            {
                TempData["error"] = response?.Message;
            }
            return View(list);
        }

        public async Task<IActionResult> ProductCreate()
        {

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> ProductCreate(ProductDto model)
        {

            if (ModelState.IsValid)
            {
                ResponseDto? response = await _pr.CreateProductAsync(model);

                if (response != null && response.isSuccess)
                {
                    TempData["success"] = "product Created Successfully !";
                    return RedirectToAction(nameof(ProductIndex));
                }
                else
                {
                    TempData["error"] = response?.Message;
                }
            }
            return View(model);
        }

        public async Task<IActionResult> ProductDelete(int productId)
        {
            ResponseDto? response = await _pr.GetProductByIdAsync(productId);

            if (response != null && response.isSuccess)
            {
                ProductDto? model = JsonConvert.DeserializeObject<ProductDto>(Convert.ToString(response.Result));
                return View(model);
            }
            else
            {
                TempData["error"] = response?.Message;
            }
            return NotFound();
        }
        [HttpPost]
        public async Task<IActionResult> ProductDelete(ProductDto productDto)
        {
            ResponseDto? response = await _pr.DeleteProductAsync(productDto.ProductId);

            if (response != null && response.isSuccess)
            {
                TempData["success"] = "Coupon Deleted Successfully !";
                return RedirectToAction(nameof(ProductIndex));
            }
            else
            {
                TempData["error"] = response?.Message;
            }
            return View(productDto);
        }

        public async Task<IActionResult> ProductEdit(int productId)
        {
            ResponseDto? response = await _pr.GetProductByIdAsync(productId);

            if (response != null && response.isSuccess)
            {
                ProductDto? model = JsonConvert.DeserializeObject<ProductDto>(Convert.ToString(response.Result));
                return View(model);
            }
            else
            {
                TempData["error"] = response?.Message;
            }
            return NotFound();
        }
        [HttpPost]
        public async Task<IActionResult> ProductEdit(ProductDto productDto)
        {
            ResponseDto? response = await _pr.UpdateProductAsync(productDto);

            if (response != null && response.isSuccess)
            {
                TempData["success"] = "Coupon Updated Successfully !";
                return RedirectToAction(nameof(ProductIndex));
            }
            else
            {
                TempData["error"] = response?.Message;
            }
            return View(productDto);
        }

    }
}

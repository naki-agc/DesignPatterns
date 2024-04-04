using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using RepositoryDesignPattern.BusinessLayer.Abstract;
using RepositoryDesignPattern.EntityLayer.Concrete;
using System.Collections.Generic;
using System.Linq;

namespace RepositoryDesignPattern.PresentationLayer.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService _productService;
        private readonly ICategoryService _categoryService;

        public ProductController(IProductService productService, ICategoryService categoryService)
        {
            _productService = productService;
            _categoryService = categoryService;
        }

        public IActionResult Index()
        {
            var values = _productService.TGetList().OrderBy(x=> x.ProductID).ToList();
            return View(values);
        }

        public IActionResult Index2()
        {
            var values = _productService.TProductListWithCategory().OrderBy(x => x.ProductID).ToList();
            return View(values);
        }

        [HttpGet]
        public IActionResult AddProduct() // burada amacımız kullanıcıya dropdown üzerinden bir veri seçtirmek
        {
            List<SelectListItem> values = (from x in _categoryService.TGetList()
                                           select new SelectListItem
                                           {
                                               Text = x.CategoryName,
                                               Value = x.CategoryID.ToString()
                                           }).ToList();
            ViewBag.v = values;
            return View();
        }



        [HttpPost]
        public IActionResult AddProduct(Product product)
        {
            _productService.TInsert(product);
            return RedirectToAction("Index");
        }


        public IActionResult DeleteProduct(int id)
        {
            var value = _productService.TGetById(id); //silinecek ıdyi product türünde bul valueya ata
            _productService.TDelete(value);           // value değerini sil
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult UpdateProduct(int id)
        {
            List<SelectListItem> values = (from x in _categoryService.TGetList()
                                           select new SelectListItem
                                           {
                                               Text = x.CategoryName,
                                               Value = x.CategoryID.ToString()
                                           }).ToList();
            ViewBag.v = values;
            var value = _productService.TGetById(id); //update olacak ıdyi product türünde bul valueya ata
            return View(value);
        }

        [HttpPost]
        public IActionResult UpdateProduct(Product product)
        {
            _productService.TUpdate(product);
            return RedirectToAction("Index");
        }
    }
}

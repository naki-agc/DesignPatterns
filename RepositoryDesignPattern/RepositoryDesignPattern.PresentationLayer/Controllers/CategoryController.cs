using Microsoft.AspNetCore.Mvc;
using RepositoryDesignPattern.BusinessLayer.Abstract;
using RepositoryDesignPattern.EntityLayer.Concrete;
using System.Linq;

namespace RepositoryDesignPattern.PresentationLayer.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        public IActionResult Index()
        {
            var values = _categoryService.TGetList().OrderBy(category=> category.CategoryID).ToList();
            return View(values);
        }

        [HttpGet]
        public IActionResult AddCategory()
        {
            return View();
        }



        [HttpPost]
        public IActionResult AddCategory(Category category)
        {
            _categoryService.TInsert(category);
            return RedirectToAction("Index");
        }


        public IActionResult DeleteCategory(int id)
        {
            var value = _categoryService.TGetById(id); //silinecek ıdyi category türünde bul valueya ata
            _categoryService.TDelete(value);           // value değerini sil
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult UpdateCategory(int id) 
        {
            var value = _categoryService.TGetById(id); //update olacak ıdyi category türünde bul valueya ata
            return View(value);
        }

        [HttpPost]
        public IActionResult UpdateCategory(Category category)
        {
            _categoryService.TUpdate(category);
            return RedirectToAction("Index");
        }
    }
}

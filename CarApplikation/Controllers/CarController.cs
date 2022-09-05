using CarApplikation.Data;
using CarApplikation.Models;
using Microsoft.AspNetCore.Mvc;

namespace CarApplikation.Controllers
{
    public class CarController : Controller
    {

        public readonly CarDbContext _dbContext;


        public CarController(CarDbContext db)
        {
            _dbContext = db;
        }
        public IActionResult Index()
        {
            return View();
        }


        public IActionResult Edit(int? id)
        {
            if(id == null || id ==0)
            {
                return NotFound();
            }

            var car = _dbContext.cars.Find(id);
            if(car == null)
            {
                return NotFound();
            }
            return View(car);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Car obj)
        {

            if (ModelState.IsValid)
            {
                _dbContext.cars.Update(obj);
                _dbContext.SaveChanges();
                return RedirectToAction("CarList", "Car");
            }
            return View(obj);

        }

        public IActionResult Create()
        {


            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Car obj)
        {

            if (ModelState.IsValid)
            {
                _dbContext.cars.Add(obj);
                _dbContext.SaveChanges();
                return RedirectToAction("index", "Home");
            }
            return View();

        }




        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            var car = _dbContext.cars.Find(id);
            if (car == null)
            {
                return NotFound();
            }
            return View(car);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePost(int? id)
        {

            var car = _dbContext.cars.Find(id);
            if(car == null)
            {
                return NotFound();
            }

            _dbContext.Remove(id);
            _dbContext.SaveChanges();
            RedirectToAction("CarList");
            return View();

        }

        public IActionResult CarList()
        {

            IEnumerable<Car> carList = _dbContext.cars;
            return View(carList);
        }


        public IActionResult CarDetail()
        {
            return View();
        }
    }
}

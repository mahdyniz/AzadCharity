using AzadCharity.DAL.Repositories;
using AzadCharity.Models.Models;
using Microsoft.AspNetCore.Mvc;

namespace AzadCharity.Admin.Controllers
{
    public class CharityCaseController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public CharityCaseController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IActionResult Index()
        {
            var allCharityCases = _unitOfWork.CharityCase.GetAll();
            return View(allCharityCases);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(CharityCase charityCase)
        {
            if (ModelState.IsValid == true)
            {
                charityCase.CreatedDate = DateTime.Now;
                _unitOfWork.CharityCase.Add(charityCase);
                _unitOfWork.Save();
                return RedirectToAction(nameof(Index));
            }

            return View(charityCase);
        }
        public IActionResult Edit(int id)
        {
            var charityCase = _unitOfWork.CharityCase.GetById(id);
            if (charityCase == null)
            {
                return NotFound();
            }
            return View(charityCase);
        }

        [HttpPost]
        public IActionResult Edit(int id, CharityCase charityCase)
        {
            if (id != charityCase.Id)
            {
                return BadRequest();
            }

            if (ModelState.IsValid)
            {
                _unitOfWork.CharityCase.Update(charityCase);
                _unitOfWork.Save();
                return RedirectToAction(nameof(Index));
            }
            return View(charityCase);
        }
        public IActionResult Delete(int id)
        {
            var charityCase = _unitOfWork.CharityCase.GetById(id);
            if (charityCase == null)
            {
                return NotFound();
            }

            return View(charityCase);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            var charityCase = _unitOfWork.CharityCase.GetById(id);
            if (charityCase != null)
            {
                _unitOfWork.CharityCase.Delete(id);
                _unitOfWork.Save();
            }
            return RedirectToAction(nameof(Index));
        }

    }
}

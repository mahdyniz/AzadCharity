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
    }
}

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
        public async Task<IActionResult> Index()
        {
            var allCharityCases = await _unitOfWork.CharityCase.GetAllAsync();
            return View(allCharityCases);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(CharityCase charityCase)
        {
            if (ModelState.IsValid == true)
            {
                charityCase.CreatedDate = DateTime.Now;
                await _unitOfWork.CharityCase.AddAsync(charityCase);
                await _unitOfWork.SaveAsync();
                return RedirectToAction(nameof(Index));
            }

            return View(charityCase);
        }
    }
}

using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TrashHandling.Models;
using TrashHandling.Models.Entities;
using TrashHandling.Models.Repositories;

namespace TrashHandling.Controllers
{
    [Authorize]
    public class FacilitiesController : Controller
    {
        private readonly IFacilityRepo repo;
        private readonly IMapper mapper;
        public FacilitiesController(IFacilityRepo repo, IMapper mapper)
        {
            this.repo = repo;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> List()
        {
            return View(mapper.Map<List<FacilityViewModel>>(await repo.GetListAsync()));
        }

        public IActionResult Add()
        {
            return View(new FacilityViewModel());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Add(FacilityViewModel viewModel)
        {
            if (ModelState.IsValid == true)
            {
                await repo.AddAsync(mapper.Map<Facility>(viewModel));

                return RedirectToAction("List", "Facilities");
            }
            else
            {
                return View(viewModel);
            }

        }

        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return RedirectToAction("List", "Facilities");
            FacilityViewModel facility = mapper.Map<FacilityViewModel>(await repo.GetIdAsync((int)id));

            return View(facility);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(FacilityViewModel viewModel)
        {
            if (ModelState.IsValid == true)
            {
                await repo.UpdateAsync(mapper.Map<Facility>(viewModel));

                return RedirectToAction("List", "Facilities");
            }
            else
            {
                return View(viewModel);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            await repo.DeleteAsync(id);

            return RedirectToAction("List", "Facilities");

        }
    }
}

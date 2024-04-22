using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TrashHandling.Models;
using TrashHandling.Models.Entities;
using TrashHandling.Models.Repositories;

namespace TrashHandling.Controllers
{
    [Authorize]
    public class TrashCollectionsController : Controller
    {
        private readonly ITrashCollectionRepo repo;
        private readonly IMapper mapper;
        public TrashCollectionsController(ITrashCollectionRepo repo, IMapper mapper)
        {
            this.repo = repo;
            this.mapper = mapper;
        }
        [HttpGet]
        public async Task<IActionResult> List()
        {
            return View(mapper.Map<List<TrashCollectionViewModel>>(await repo.GetListAsync()));
        }
        public IActionResult Add()
        {
            return View(new TrashCollectionViewModel());
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Add(TrashCollectionViewModel viewModel)
        {
            if (ModelState.IsValid == true)
            {
                await repo.AddAsync(mapper.Map<TrashCollection>(viewModel));

                return RedirectToAction("List", "TrashCollections");
            }
            else
            {
                return View(viewModel);
            }

        }
        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return RedirectToAction("List", "TrashCollections");
            TrashCollectionViewModel instructor = mapper.Map<TrashCollectionViewModel>(await repo.GetIdAsync((int)id));

            return View(instructor);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(TrashCollectionViewModel viewModel)
        {
            if (ModelState.IsValid == true)
            {
                await repo.UpdateAsync(mapper.Map<TrashCollection>(viewModel));

                return RedirectToAction("List", "TrashCollections");
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

            return RedirectToAction("List", "TrashCollections");

        }
    }
}

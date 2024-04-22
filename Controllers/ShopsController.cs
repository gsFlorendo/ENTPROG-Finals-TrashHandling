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
    public class ShopsController : Controller
    {
        private readonly IShopRepo repo;
        private readonly IMapper mapper;
        public ShopsController(IShopRepo repo, IMapper mapper)
        {
            this.repo = repo;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> List()
        {
            return View(mapper.Map<List<ShopViewModel>>(await repo.GetListAsync()));
        }

        public IActionResult Add()
        {
            return View(new ShopViewModel());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Add(ShopViewModel viewModel)
        {
            if (ModelState.IsValid == true)
            {
                await repo.AddAsync(mapper.Map<Shop>(viewModel));

                return RedirectToAction("List", "Shops");
            }
            else
            {
                return View(viewModel);
            }

        }

        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return RedirectToAction("List", "Shops");
            ShopViewModel shop = mapper.Map<ShopViewModel>(await repo.GetIdAsync((int)id));

            return View(shop);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(ShopViewModel viewModel)
        {
            if (ModelState.IsValid == true)
            {
                await repo.UpdateAsync(mapper.Map<Shop>(viewModel));

                return RedirectToAction("List", "Shops");
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

            return RedirectToAction("List", "Shops");

        }
    }
}

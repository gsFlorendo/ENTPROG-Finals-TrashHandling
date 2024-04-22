using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TrashHandling.Data;
using TrashHandling.Models;
using TrashHandling.Models.Entities;

namespace TrashHandling.Controllers
{
    [Authorize]
    public class TrashBookingsController : Controller
    {
        private readonly PatientConsultAuthDBContext dbContext;
        private readonly IMapper mapper;

        public TrashBookingsController(PatientConsultAuthDBContext dbContext, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Add(TrashBookingViewModel viewModel)
        {
            if (ModelState.IsValid == true)
            {
                TrashBooking model = mapper.Map<TrashBooking>(viewModel);
                await dbContext.TrashBookings.AddAsync(model);
                await dbContext.SaveChangesAsync();
                return RedirectToAction("List", "TrashBookings");
            }
            else
            {
                return View(viewModel);
            }
        }

        [HttpGet]
        public async Task<IActionResult> List()
        {
            List<TrashBookingViewModel> trashbookingList = mapper.Map<List<TrashBookingViewModel>>(await dbContext.TrashBookings.ToListAsync());

            return View(trashbookingList);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            TrashBookingViewModel trashbooking = mapper.Map<TrashBookingViewModel>(await dbContext.TrashBookings.FindAsync(id));

            return View(trashbooking);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(TrashBooking viewModel)
        {
            if (ModelState.IsValid == true)
            {
                dbContext.Set<TrashBooking>().Update(mapper.Map<TrashBooking>(viewModel));
                await dbContext.SaveChangesAsync();

                return RedirectToAction("List", "TrashBookings");
            }

            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            dbContext.Set<TrashBooking>().Remove(mapper.Map<TrashBooking>(await dbContext.TrashBookings.FindAsync(id)));
            await dbContext.SaveChangesAsync();

            return RedirectToAction("List", "TrashBookings");
        }
    }
}

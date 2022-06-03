using Hungryless.Domain.Contracts.Services;
using Hungryless.Domain.Entities;
using Hungryless.Infrastructure.Context;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Hungryless.Web.Controllers
{
    public class SuppliesController : Controller
    {
        private readonly ISuppliesService _service;

        public SuppliesController(ISuppliesService service)
        {
            _service = service;
        }

        // GET: Supplies
        public async Task<IActionResult> Index()
        {
            var supplies = await _service.GetAll();
            
            return supplies != null ?
                        View(supplies) :
                        Problem("Supplies are null.");
        }

        // GET: Supplies/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            var supplies = await _service.GetAll();

            if (id == null || supplies == null)
            {
                return NotFound();
            }

            var supply = await _service.Get(id.Value);

            if (supply == null)
            {
                return NotFound();
            }

            return View(supply);
        }

        // GET: Supplies/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Supplies/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Name,Category,Cost,Quantity,Id")] Supplies supply)
        {
            if (ModelState.IsValid)
            {
                await _service.Add(supply);

                return RedirectToAction(nameof(Index));
            }
            return View(supply);
        }

        // GET: Supplies/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            var supplies = await _service.GetAll();

            if (id == null || supplies == null)
            {
                return NotFound();
            }

            var supply = await _service.Get(id.Value);

            if (supply == null)
            {
                return NotFound();
            }
            return View(supply);
        }

        // POST: Supplies/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Name,Category,Cost,Quantity,Id")] Supplies supply)
        {
            if (id != supply.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _service.Update(supply);
                }
                catch (DbUpdateConcurrencyException)
                {
                    var supplyExists = await SuppliesExists(supply.Id);

                    if (!supplyExists)
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(supply);
        }

        // GET: Supplies/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            var supplies = await _service.GetAll();

            if (id == null || supplies == null)
            {
                return NotFound();
            }

            var supply = await _service.Get(id.Value);

            if (supply == null)
            {
                return NotFound();
            }

            return View(supply);
        }

        // POST: Supplies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var supplies = await _service.GetAll();

            if (supplies == null)
            {
                return Problem("Supplies are null.");
            }
            var supply = await _service.Get(id);
            if (supply != null)
            {
                await _service.Delete(supply.Id);
            }

            return RedirectToAction(nameof(Index));
        }

        private async Task<bool> SuppliesExists(Guid id)
        {
            var supplies = await _service.GetAll();
            return supplies.Any(e => e.Id == id);
        }
    }
}

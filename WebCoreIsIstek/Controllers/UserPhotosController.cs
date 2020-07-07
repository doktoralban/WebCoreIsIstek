using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebCoreIsIstek.Models;
using System.Web;
using Microsoft.AspNetCore.Http;

namespace WebCoreIsIstek.Controllers
{
    public class UserPhotosController : Controller
    {
        private readonly TestDbContext _context;

        public UserPhotosController(TestDbContext context)
        {
            _context = context;
        }

        // GET: UserPhotos
        public async Task<IActionResult> Index()
        {
            return View(await _context.TbUserPhoto.ToListAsync());
        }

        // GET: UserPhotos/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbUserPhoto = await _context.TbUserPhoto
                .FirstOrDefaultAsync(m => m.UserName == id);
            if (tbUserPhoto == null)
            {
                return NotFound();
            }

            return View(tbUserPhoto);
        }

        // GET: UserPhotos/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: UserPhotos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("UserName")] TbUserPhoto tbUserPhoto, IFormFile Fotografi)
        {
            if (ModelState.IsValid)
            {
                //.......................................................
                byte[] imageData = null;
                if (Fotografi != null)
                {
                    using (var binary = new BinaryReader(Fotografi.OpenReadStream()))
                    {
                        imageData = binary.ReadBytes((Int32)Fotografi.Length);
                    }
                }
                //.......................................................
                tbUserPhoto.UserPhoto = imageData;
                //.......................................................
                _context.Add(tbUserPhoto);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tbUserPhoto);
        }

        // GET: UserPhotos/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbUserPhoto = await _context.TbUserPhoto.FindAsync(id);
            if (tbUserPhoto == null)
            {
                return NotFound();
            }
            return View(tbUserPhoto);
        }

        // POST: UserPhotos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("UserName")] TbUserPhoto tbUserPhoto, IFormFile Fotografi)
        {
            if (id != tbUserPhoto.UserName)
            {
                return NotFound();
            }
            //.......................................................
            byte[] imageData = null;
            if (Fotografi != null)
            {
                using (var binary = new BinaryReader(Fotografi.OpenReadStream()))
                {
                    imageData = binary.ReadBytes((Int32)Fotografi.Length);
                }
            }
                //.......................................................
                if (ModelState.IsValid)
            {
                try
                {
                    //.......................................................
                    tbUserPhoto.UserPhoto = imageData;
                    //.......................................................
                    _context.Update(tbUserPhoto);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TbUserPhotoExists(tbUserPhoto.UserName))
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
            return View(tbUserPhoto);
        }

        // GET: UserPhotos/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbUserPhoto = await _context.TbUserPhoto
                .FirstOrDefaultAsync(m => m.UserName == id);
            if (tbUserPhoto == null)
            {
                return NotFound();
            }

            return View(tbUserPhoto);
        }

        // POST: UserPhotos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var tbUserPhoto = await _context.TbUserPhoto.FindAsync(id);
            _context.TbUserPhoto.Remove(tbUserPhoto);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TbUserPhotoExists(string id)
        {
            return _context.TbUserPhoto.Any(e => e.UserName == id);
        }
    }
}

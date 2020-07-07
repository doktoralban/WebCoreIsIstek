using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebCoreIsIstek.Models;

namespace WebCoreIsIstek.Controllers
{
    public class KullanicilarController : Controller
    {
        private readonly MakinaBakimDbContext _context;

        public KullanicilarController(MakinaBakimDbContext context)
        {
            _context = context;
        }

        // GET: Kullanicilar
        public async Task<IActionResult> Index()
        {
            return View(await _context.tbKullanicilar.ToListAsync());
        }

        // GET: Kullanicilar/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbKullanicilar = await _context.tbKullanicilar
                .FirstOrDefaultAsync(m => m.KullaniciID == id);
            if (tbKullanicilar == null)
            {
                return NotFound();
            }

            return View(tbKullanicilar);
        }

        // GET: Kullanicilar/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Kullanicilar/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("KullaniciID,KullanıcıAdı,Şifresi,AdıSoyadı,Grubu,Tipi,Adminmi,Ünvanı,LokasyonID,FaaliyetAlaniID,Emaili,CepTelefonu,DahiliTelefonu,Fotografi,UstAmiriID,SuanSistemde,DahiliMesajlaşmadaGörünür,BakımOnarımYapabilir,YerelIPAdresi,SonGirişZamanı,SonÇikişZamanı,Aktif")] tbKullanicilar tbKullanicilar)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tbKullanicilar);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tbKullanicilar);
        }

        // GET: Kullanicilar/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbKullanicilar = await _context.tbKullanicilar.FindAsync(id);
            if (tbKullanicilar == null)
            {
                return NotFound();
            }
            return View(tbKullanicilar);
        }

        // POST: Kullanicilar/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("KullaniciID,KullanıcıAdı,Şifresi,AdıSoyadı,Grubu,Tipi,Adminmi,Ünvanı,LokasyonID,FaaliyetAlaniID,Emaili,CepTelefonu,DahiliTelefonu,Fotografi,UstAmiriID,SuanSistemde,DahiliMesajlaşmadaGörünür,BakımOnarımYapabilir,YerelIPAdresi,SonGirişZamanı,SonÇikişZamanı,Aktif")] tbKullanicilar tbKullanicilar)
        {
            if (id != tbKullanicilar.KullaniciID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tbKullanicilar);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!tbKullanicilarExists(tbKullanicilar.KullaniciID))
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
            return View(tbKullanicilar);
        }

        // GET: Kullanicilar/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbKullanicilar = await _context.tbKullanicilar
                .FirstOrDefaultAsync(m => m.KullaniciID == id);
            if (tbKullanicilar == null)
            {
                return NotFound();
            }

            return View(tbKullanicilar);
        }

        // POST: Kullanicilar/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tbKullanicilar = await _context.tbKullanicilar.FindAsync(id);
            _context.tbKullanicilar.Remove(tbKullanicilar);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool tbKullanicilarExists(int id)
        {
            return _context.tbKullanicilar.Any(e => e.KullaniciID == id);
        }
    }
}

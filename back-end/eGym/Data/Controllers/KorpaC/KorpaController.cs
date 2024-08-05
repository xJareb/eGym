﻿using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using eGym.Data.Models;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using eGym.Data.Endpoints.KategorijaEndpoints.GetById;
using eGym.Data.ViewModels.NarudzbaVMs;
using eGym.Data.ViewModels.KorpaVMs;

namespace eGym.Data.Controllers.KorpaC
{
    [ApiController]
    [Route("api/[controller]")]
    public class KorpaController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public KorpaController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpPost("DodajProizvodUKorpu")]
        public async Task<IActionResult> DodajProizvodUKorpu([FromQuery] DodajUKorpuVM dodajukorpuvm)
        {
            var korpa = await _context.Korpa
                .Include(k => k.Proizvodi)
                .ThenInclude(kp => kp.Proizvod)
                .FirstOrDefaultAsync(k => k.KorisnikID == dodajukorpuvm.KorisnikID);

            if (korpa == null)
            {
                korpa = new Korpa { KorisnikID = dodajukorpuvm.KorisnikID };
                _context.Korpa.Add(korpa);
            }

            var proizvod = await _context.Proizvod.FindAsync(dodajukorpuvm.ProizvodID);

            if (proizvod == null)
            {
                return NotFound("Proizvod not found");
            }

            var existingKorpaProizvod = korpa.Proizvodi
                .FirstOrDefault(kp => kp.ProizvodID == dodajukorpuvm.ProizvodID);

            if (existingKorpaProizvod != null)
            {
                existingKorpaProizvod.Kolicina += dodajukorpuvm.Kolicina;
            }
            else
            {
                var korpaProizvod = new KorpaProizvod
                {
                    Korpa = korpa,
                    Proizvod = proizvod,
                    Kolicina = dodajukorpuvm.Kolicina
                };

                _context.KorpaProizvod.Add(korpaProizvod);
            }

            await _context.SaveChangesAsync();

            return Ok(korpa);
        }


        [HttpGet("GetKorpaByKorisnikID/{korisnikID}")]
        public async Task<IActionResult> GetKorpaByKorisnikID(int korisnikID)
        {
            var korpa = await _context.Korpa
                .Include(k => k.Proizvodi)
                .ThenInclude(kp => kp.Proizvod)
                .ThenInclude(p => p.Slike)
                .FirstOrDefaultAsync(k => k.KorisnikID == korisnikID);

            if (korpa == null)
            {   
                //vracam praznu korpu da izbjegnem error u konzoli
                return Ok(new Korpa
                {
                    KorpaID = 0,
                    Proizvodi = new List<KorpaProizvod>(),
                    Vrijednost = 0
                });
            }

            var korpaDto = new
            {
                KorpaID = korpa.KorpaID,
                //Vrijednost = korpa.Vrijednost,
                Proizvodi = korpa.Proizvodi.Select(kp => new
                {
                    ProizvodID = kp.ProizvodID,
                    Naziv = kp.Proizvod.Naziv,
                    Popust = kp.Proizvod.popust,
                    Cijena = kp.Proizvod.Cijena,
                    Kolicina = kp.Kolicina,
                    SlikaProizvoda = kp.Proizvod.Slike.FirstOrDefault().Putanja
                }),
                Vrijednost = korpa.Proizvodi.Sum(kp => kp.Proizvod.Cijena * kp.Kolicina)
            };

            return Ok(korpaDto);
        }
        [HttpDelete("RemoveProizvodFromKorpa/{korpaID}/{proizvodID}")]
        public async Task<IActionResult> RemoveProizvodFromKorpa(int korpaID, int proizvodID)
        {
            var korpa = await _context.Korpa
                .Include(k => k.Proizvodi)
                .FirstOrDefaultAsync(k => k.KorpaID == korpaID);

            if (korpa == null)
            {
                return NotFound("Korpa not found");
            }

            var korpaProizvod = korpa.Proizvodi.FirstOrDefault(kp => kp.ProizvodID == proizvodID);

            if (korpaProizvod == null)
            {
                return NotFound("Proizvod not found in the Korpa");
            }

            _context.KorpaProizvod.Remove(korpaProizvod);
            await _context.SaveChangesAsync();

            return Ok("Proizvod removed from Korpa");
        }
    }
}

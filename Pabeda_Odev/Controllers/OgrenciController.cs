using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Pabeda_Odev.Model;
using Pabeda_Odev.Repositories.Abstract;

namespace Pabeda_Odev.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OgrenciController : ControllerBase
    {
        private readonly IRepository<Ogrenci> ogr_repository;
        private readonly IRepository<OgrenciOgretmen> oo_repository;
        public OgrenciController(IRepository<Ogrenci> ogr_repository, IRepository<OgrenciOgretmen> oo_repository)
        {
            this.ogr_repository = ogr_repository;
            this.oo_repository = oo_repository;
        }
        [HttpPost("OgretmenEkle")]
        public ActionResult<OgrenciOgretmen> OOEkle([FromBody]OgrenciOgretmen OgrenciOgretmen)
        {
            if (!ModelState.IsValid || OgrenciOgretmen == null) return BadRequest();

            if (oo_repository.Add(OgrenciOgretmen))
                return Ok(OgrenciOgretmen);

            return BadRequest();
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(ogr_repository.GetAll());
        }
        [HttpPost]
        public IActionResult Post([FromBody]Ogrenci ogrenci)
        {
            if (!ModelState.IsValid || ogrenci == null) return BadRequest();

            if (ogr_repository.Add(ogrenci))
                return Ok(ogrenci);

            return BadRequest();
        }
    }
}
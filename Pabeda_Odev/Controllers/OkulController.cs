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
    public class OkulController : ControllerBase
    {
        private readonly IRepository<Okul> okul_repository;
        private readonly IRepository<OgretmenOkul> oo_repository;
        private readonly IOkulRepository okl_repository;
        public OkulController(IRepository<Okul> okul_repository, IRepository<OgretmenOkul> oo_repository, IOkulRepository okl_repository)
        {
            this.okul_repository = okul_repository;
            this.okl_repository = okl_repository;
            this.oo_repository = oo_repository;
        }
        [HttpPost("OOEkle")]
        public ActionResult<OgretmenOkul> OOEkle([FromBody]OgretmenOkul OgretmenOkul)
        {
            if (!ModelState.IsValid || OgretmenOkul == null) return BadRequest();

            if (oo_repository.Add(OgretmenOkul))
                return Ok(OgretmenOkul);

            return BadRequest();
        }
        [HttpGet("OkulOgr")]
        public IActionResult OkulOgr(int id)
        {

            return Ok(okl_repository.GetOkulOgrencileri(id));
        }
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(okl_repository.GetAll());
        }
        [HttpPost]
        public IActionResult Post([FromBody]Okul okul)
        {
            if (!ModelState.IsValid || okul == null) return BadRequest();

            if (okul_repository.Add(okul))
                return Ok(okul);

            return BadRequest();
        }
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]Okul okul)
        {
            if (!ModelState.IsValid || okul == null) return BadRequest();

            var okulbilgi = okul_repository.GetById(id);
            if (okulbilgi == null) return NotFound();

            okul.ID = okulbilgi.ID;
            if (okl_repository.Update2(okul))
                return Ok(okul);
            return BadRequest();
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var okul = okul_repository.GetById(id);
            if (okul == null) return NotFound();

            if (okul_repository.Remove(id))
                return Ok(okul);
            return BadRequest();
        }
    }
}
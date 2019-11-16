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
    public class OgretmenController : ControllerBase
    {
        private readonly IOgretmenRepository ogr_repository;

        public OgretmenController(IOgretmenRepository ogr_repository)
        {
            this.ogr_repository = ogr_repository;
        }

        [HttpGet("OgretmenOgrencileri/{id}")]
        public IActionResult Ogrt_ogr(int id)
        {

            return Ok(ogr_repository.GetOgrenciler(id));
        }
        [HttpPost]
        public IActionResult Post([FromBody]Ogretmen ogretmen)
        {
            if (!ModelState.IsValid || ogretmen == null) return BadRequest();

            if (ogr_repository.Add(ogretmen))
                return Ok(ogretmen);

            return BadRequest();
        }
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            return Ok(ogr_repository.GetOgrtOkul(id));
        }

    }
}
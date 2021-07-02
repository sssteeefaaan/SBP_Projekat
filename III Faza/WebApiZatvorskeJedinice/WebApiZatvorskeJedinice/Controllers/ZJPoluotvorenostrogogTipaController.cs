using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Zatvor.DTO;
using Zatvor.DTO.Basic;

namespace WebApiZatvorskaJedinica.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ZJPoluotvorenoStrogogTipaController : ControllerBase
    {
        [HttpGet]
        [Route("PreuzmiZatvorskeJediniceFULL")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult GetAllZJFULL()
        {
            try
            {
                return new JsonResult(DTOManager.ReadAllZJPoluotvorenoStrogogTipaFULL());
            }
            catch (Exception exc)
            {
                return BadRequest(exc.ToString());
            }
        }

        [HttpGet]
        [Route("PreuzmiZatvorskeJedinice")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult GetAllZJ()
        {
            try
            {
                return new JsonResult(DTOManager.ReadAllZJPoluotvorenoStrogogTipa());
            }
            catch (Exception exc)
            {
                return BadRequest(exc.ToString());
            }
        }

        [HttpGet]
        [Route("PreuzmiZatvorskuJedinicuFULL/{Sifra}")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult GetZJFULL(string Sifra)
        {
            try
            {
                return new JsonResult(DTOManager.ReadZJPoluotvorenoStrogogTipaFULL(Sifra));
            }
            catch (Exception exc)
            {
                return BadRequest(exc.ToString());
            }
        }

        [HttpGet]
        [Route("PreuzmiZatvorskuJedinicu/{Sifra}")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult GetZJ(string Sifra)
        {
            try
            {
                return new JsonResult(DTOManager.ReadZJPoluotvorenoStrogogTipa(Sifra));
            }
            catch (Exception exc)
            {
                return BadRequest(exc.ToString());
            }
        }

        [HttpPost]
        [Route("DodajZatvorskuJedinicu")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult CreateZJ([FromBody] ZJPoluotvorenoStrogogTipaBasic zj)
        {
            try
            {
                DTOManager.CreateZJPoluotvorenoStrogogTipa(zj);
                return new JsonResult(zj);
            }
            catch (Exception exc)
            {
                return BadRequest(exc.ToString());
            }
        }

        [HttpPut]
        [Route("IzmeniZatvorskuJedinicu")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult UpdateZJ([FromBody] ZJPoluotvorenoStrogogTipaBasic zj)
        {
            try
            {
                DTOManager.UpdateZJPoluotvorenoStrogogTipa(zj);
                return new JsonResult(zj);
            }
            catch (Exception exc)
            {
                return BadRequest(exc.ToString());
            }
        }


        [HttpDelete]
        [Route("ObrisiZatvorskuJedinicu/{Sifra}")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult DeleteZJ(string Sifra)
        {
            try
            {
                DTOManager.DeleteZJPoluotvorenoStrogogTipa(Sifra);
                return Ok();
            }
            catch (Exception exc)
            {
                return BadRequest(exc.ToString());
            }
        }
    }
}

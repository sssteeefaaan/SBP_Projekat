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
    public class ZJStrogogTipaController : ControllerBase
    {
        [HttpGet]
        [Route("PreuzmiZatvorskeJediniceFULL")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult GetAllZJFULL()
        {
            try
            {
                return new JsonResult(DTOManager.ReadAllZJStrogogTipaFULL());
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
                return new JsonResult(DTOManager.ReadAllZJStrogogTipa());
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
                return new JsonResult(DTOManager.ReadZJStrogogTipaFULL(Sifra));
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
                return new JsonResult(DTOManager.ReadZJStrogogTipa(Sifra));
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
        public IActionResult CreateZJ([FromBody] ZJStrogogTipaBasic zj)
        {
            try
            {
                DTOManager.CreateZJStrogogTipa(zj);
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
        public IActionResult UpdateZJ([FromBody] ZJStrogogTipaBasic zj)
        {
            try
            {
                DTOManager.UpdateZJStrogogTipa(zj);
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
                DTOManager.DeleteZJStrogogTipa(Sifra);
                return Ok();
            }
            catch (Exception exc)
            {
                return BadRequest(exc.ToString());
            }
        }
    }
}

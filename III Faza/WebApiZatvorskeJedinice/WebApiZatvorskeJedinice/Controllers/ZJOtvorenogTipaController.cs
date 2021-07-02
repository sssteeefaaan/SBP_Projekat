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
    public class ZJOtvorenogTipaController : ControllerBase
    {
        [HttpGet]
        [Route("PreuzmiZatvorskeJediniceFULL")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult GetAllZJFULL()
        {
            try
            {
                return new JsonResult(DTOManager.ReadAllZJOtvorenogTipaFULL());
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
                return new JsonResult(DTOManager.ReadAllZJOtvorenogTipa());
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
                return new JsonResult(DTOManager.ReadZJOtvorenogTipaFULL(Sifra));
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
                return new JsonResult(DTOManager.ReadZJOtvorenogTipa(Sifra));
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
        public IActionResult CreateZJ([FromBody] ZJOtvorenogTipaBasic zj)
        {
            try
            {
                DTOManager.CreateZJOtvorenogTipa(zj);
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
        public IActionResult UpdateZJ([FromBody] ZJOtvorenogTipaBasic zj)
        {
            try
            {
                DTOManager.UpdateZJOtvorenogTipa(zj);
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
                DTOManager.DeleteZJOtvorenogTipa(Sifra);
                return Ok();
            }
            catch (Exception exc)
            {
                return BadRequest(exc.ToString());
            }
        }

        [HttpPost]
        [Route("DodajRadSaFirmom/{Sifra}/{PIB}")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult CreateMozeDaAngazuje(string Sifra, string PIB)
        {
            try
            {
                DTOManager.CreateMozeDaAngazuje(Sifra, PIB);
                return Ok();
            }
            catch (Exception exc)
            {
                return BadRequest(exc.ToString());
            }
        }

        [HttpDelete]
        [Route("RaskiniRadSaFirmom/{Sifra}/{PIB}")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult DeleteMozeDaAngazuje(string Sifra, string PIB)
        {
            try
            {
                DTOManager.DeleteMozeDaAngazuje(Sifra, PIB);
                return Ok();
            }
            catch (Exception exc)
            {
                return BadRequest(exc.ToString());
            }
        }
    }
}

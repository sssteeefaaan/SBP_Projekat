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
    public class ZJOtvorenoPoluotvorenogTipaController : ControllerBase
    {
        [HttpGet]
        [Route("PreuzmiZatvorskeJediniceFULL")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult GetAllZJFULL()
        {
            try
            {
                return new JsonResult(DTOManager.ReadAllZJOtvorenoPoluotvorenogTipaFULL());
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
                return new JsonResult(DTOManager.ReadAllZJOtvorenoPoluotvorenogTipa());
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
                return new JsonResult(DTOManager.ReadZJOtvorenoPoluotvorenogTipaFULL(Sifra));
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
                return new JsonResult(DTOManager.ReadZJOtvorenoPoluotvorenogTipa(Sifra));
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
        public IActionResult CreateZJ([FromBody] ZJOtvorenoPoluotvorenogTipaBasic zj)
        {
            try
            {
                DTOManager.CreateZJOtvorenoPoluotvorenogTipa(zj);
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
        public IActionResult UpdateZJ([FromBody] ZJOtvorenoPoluotvorenogTipaBasic zj)
        {
            try
            {
                DTOManager.UpdateZJOtvorenoPoluotvorenogTipa(zj);
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
                DTOManager.DeleteZJOtvorenoPoluotvorenogTipa(Sifra);
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

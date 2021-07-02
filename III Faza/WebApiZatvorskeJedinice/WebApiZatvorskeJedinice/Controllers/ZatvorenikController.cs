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
    public class ZatvorenikController : ControllerBase
    {
        [HttpGet]
        [Route("PreuzmiZatvorenike")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult GetAllZatvorenik()
        {
            try
            {
                return new JsonResult(DTOManager.ReadAllZatvorenik());
            }
            catch (Exception exc)
            {
                return BadRequest(exc.ToString());
            }
        }

        [HttpGet]
        [Route("PreuzmiZatvorenika/{JMBG}")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult GetZatvorenik(string JMBG)
        {
            try
            {
                return new JsonResult(DTOManager.ReadZatvorenik(JMBG));
            }
            catch (Exception exc)
            {
                return BadRequest(exc.ToString());
            }
        }

        [HttpPost]
        [Route("DodajZatvorenika")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult CreateZatvorenik([FromBody] ZatvorenikBasic z)
        {
            try
            {
                DTOManager.CreateZatvorenik(z);
                return new JsonResult(z);
            }
            catch (Exception exc)
            {
                return BadRequest(exc.ToString());
            }
        }

        [HttpPut]
        [Route("IzmeniZatvorenika")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult UpdateZatvorenik([FromBody] ZatvorenikBasic z)
        {
            try
            {
                DTOManager.UpdateZatvorenik(z);
                return new JsonResult(z);
            }
            catch (Exception exc)
            {
                return BadRequest(exc.ToString());
            }
        }


        [HttpDelete]
        [Route("ObrisiZatvorenika/{JMBG}")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult DeleteZatvorenik(string JMBG)
        {
            try
            {
                DTOManager.DeleteZatvorenik(JMBG);
                return Ok();
            }
            catch (Exception exc)
            {
                return BadRequest(exc.ToString());
            }
        }
    }
}

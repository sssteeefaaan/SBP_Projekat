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
    public class ZaposleniController : ControllerBase
    {
        [HttpGet]
        [Route("PreuzmiZaposlene")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult GetAllZaposleni()
        {
            try
            {
                return new JsonResult(DTOManager.ReadAllZaposleni());
            }
            catch (Exception exc)
            {
                return BadRequest(exc.ToString());
            }
        }

        [HttpGet]
        [Route("PreuzmiZaposlenog/{JMBG}")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult GetZaposleni(string JMBG)
        {
            try
            {
                return new JsonResult(DTOManager.ReadZaposleni(JMBG));
            }
            catch (Exception exc)
            {
                return BadRequest(exc.ToString());
            }
        }

        [HttpPost]
        [Route("DodajZaposlenog")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult CreateZaposleni([FromBody] ZaposleniBasic zap)
        {
            try
            {
                DTOManager.CreateZaposleni(zap);

                return new JsonResult(zap);
            }
            catch (Exception exc)
            {
                return BadRequest(exc.ToString());
            }
        }

        [HttpPut]
        [Route("IzmeniZaposlenog")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult UpdateZaposleni([FromBody] ZaposleniBasic zap)
        {
            try
            {
                DTOManager.UpdateZaposleni(zap);
                return new JsonResult(zap);
            }
            catch (Exception exc)
            {
                return BadRequest(exc.ToString());
            }
        }

        [HttpDelete]
        [Route("ObrisiZaposlenog/{JMBG}")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult DeleteZaposleni(string JMBG)
        {
            try
            {
                DTOManager.DeleteZaposleni(JMBG);

                return Ok();
            }
            catch (Exception exc)
            {
                return BadRequest(exc.ToString());
            }
        }
    }
}

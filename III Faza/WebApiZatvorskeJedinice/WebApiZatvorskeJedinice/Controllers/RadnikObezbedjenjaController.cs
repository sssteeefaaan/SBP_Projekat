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
    public class ObezbedjenjeController : ControllerBase
    {
        [HttpGet]
        [Route("PreuzmiObezbedjenje")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult GetAllObezbedjenje()
        {
            try
            {
                return new JsonResult(DTOManager.ReadAllRadnikObezbedjenja());
            }
            catch (Exception exc)
            {
                return BadRequest(exc.ToString());
            }
        }

        [HttpGet]
        [Route("PreuzmiObezbedjenje/{JMBG}")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult GetObezbedjenje(string JMBG)
        {
            try
            {
                return new JsonResult(DTOManager.ReadRadnikObezbedjenja(JMBG));
            }
            catch (Exception exc)
            {
                return BadRequest(exc.ToString());
            }
        }

        [HttpPost]
        [Route("DodajObezbedjenje")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult CreateObezbedjenje([FromBody] RadnikObezbedjenjaBasic a)
        {
            try
            {
                DTOManager.CreateRadnikObezbedjenja(a);
                return new JsonResult(a);
            }
            catch (Exception exc)
            {
                return BadRequest(exc.ToString());
            }
        }

        [HttpPut]
        [Route("IzmeniObezbedjenje")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult UpdateObezbedjenje([FromBody] RadnikObezbedjenjaBasic a)
        {
            try
            {
                DTOManager.UpdateRadnikObezbedjenja(a);
                return new JsonResult(a);
            }
            catch (Exception exc)
            {
                return BadRequest(exc.ToString());
            }
        }

        [HttpDelete]
        [Route("ObrisiObezbedjenje/{JMBG}")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult DeleteObezbedjenje(string JMBG)
        {
            try
            {
                DTOManager.DeleteRadnikObezbedjenja(JMBG);
                return Ok();
            }
            catch (Exception exc)
            {
                return BadRequest(exc.ToString());
            }
        }
    }
}

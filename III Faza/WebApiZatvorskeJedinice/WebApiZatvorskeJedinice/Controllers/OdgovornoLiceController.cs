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
    public class OdgovornoLiceController : ControllerBase
    {
        [HttpGet]
        [Route("PreuzmiOdgovornaLica")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult GetAllOdgovornoLice()
        {
            try
            {
                return new JsonResult(DTOManager.ReadAllOdgovornoLice());
            }
            catch (Exception exc)
            {
                return BadRequest(exc.ToString());
            }
        }

        [HttpGet]
        [Route("PreuzmiOdgovornoLice/{JMBG}")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult GetOdgovornoLice(string JMBG)
        {
            try
            {
                return new JsonResult(DTOManager.ReadOdgovornoLice(JMBG));
            }
            catch (Exception exc)
            {
                return BadRequest(exc.ToString());
            }
        }

        [HttpPost]
        [Route("DodajOdgovornoLice")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult CreateOdgovornoLice([FromBody] OdgovornoLiceBasic olb)
        {
            try
            {
                DTOManager.CreateOdgovornoLice(olb);
                return new JsonResult(olb);
            }
            catch (Exception exc)
            {
                return BadRequest(exc.ToString());
            }
        }

        [HttpPut]
        [Route("IzmeniOdgovornoLice")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult UpdateOdgovornoLice([FromBody] OdgovornoLiceBasic olb)
        {
            try
            {
                DTOManager.UpdateOdgovornoLice(olb);
                return new JsonResult(olb);
            }
            catch (Exception exc)
            {
                return BadRequest(exc.ToString());
            }
        }

        [HttpDelete]
        [Route("ObrisiOdgovornoLice/{ID}")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult DeleteOdgovornoLice(int ID)
        {
            try
            {
                DTOManager.DeleteOdgovornoLice(ID);
                return Ok();
            }
            catch (Exception exc)
            {
                return BadRequest(exc.ToString());
            }
        }
    }
}

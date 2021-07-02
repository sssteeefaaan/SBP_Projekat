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
    public class TerminSetnjeController : ControllerBase
    {
        [HttpGet]
        [Route("PreuzmiTerminSetnje")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult GetAllTerminiSetnje()
        {
            try
            {
                return new JsonResult(DTOManager.ReadAllTerminSetnje());
            }
            catch (Exception exc)
            {
                return BadRequest(exc.ToString());
            }
        }

        [HttpGet]
        [Route("PreuzmiTerminSetnje/{ID}")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult GetTerminSetnje(int ID)
        {
            try
            {
                return new JsonResult(DTOManager.ReadTerminSetnje(ID));
            }
            catch (Exception exc)
            {
                return BadRequest(exc.ToString());
            }
        }

        [HttpPost]
        [Route("DodajTerminSetnje")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult CreateTerminSetnje([FromBody] TerminSetnjeBasic tsb)
        {
            try
            {
                DTOManager.CreateTerminSetnje(tsb);
                return new JsonResult(tsb);
            }
            catch (Exception exc)
            {
                return BadRequest(exc.ToString());
            }
        }

        [HttpPut]
        [Route("IzmeniTerminSetnje")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult UpdateTerminSetnje([FromBody] TerminSetnjeBasic tsb)
        {
            try
            {
                DTOManager.UpdateTerminSetnje(tsb);
                return new JsonResult(tsb);
            }
            catch (Exception exc)
            {
                return BadRequest(exc.ToString());
            }
        }


        [HttpDelete]
        [Route("ObrisiTerminSetnje/{ID}")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult DeleteTerminSetnje(int ID)
        {
            try
            {
                DTOManager.DeleteTerminSetnje(ID);
                return Ok();
            }
            catch (Exception exc)
            {
                return BadRequest(exc.ToString());
            }
        }
    }
}

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
    public class TerminPoseteController : ControllerBase
    {
        [HttpGet]
        [Route("PreuzmiTerminePosete")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult GetAllTerminPosete()
        {
            try
            {
                return new JsonResult(DTOManager.ReadAllTerminPosete());
            }
            catch (Exception exc)
            {
                return BadRequest(exc.ToString());
            }
        }

        [HttpGet]
        [Route("PreuzmiTerminPosete/{ID}")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult GetTerminPosete(int ID)
        {
            try
            {
                return new JsonResult(DTOManager.ReadTerminPosete(ID));
            }
            catch (Exception exc)
            {
                return BadRequest(exc.ToString());
            }
        }

        [HttpPost]
        [Route("DodajTerminPosete")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult CreateTerminPosete([FromBody] TerminPoseteBasic tpb)
        {
            try
            {
                DTOManager.CreateTerminPosete(tpb);
                return new JsonResult(tpb);
            }
            catch (Exception exc)
            {
                return BadRequest(exc.ToString());
            }
        }

        [HttpPut]
        [Route("IzmeniTerminPosete")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult UpdateTerminPosete([FromBody] TerminPoseteBasic tpb)
        {
            try
            {
                DTOManager.UpdateTerminPosete(tpb);
                return new JsonResult(tpb);
            }
            catch (Exception exc)
            {
                return BadRequest(exc.ToString());
            }
        }

        [HttpDelete]
        [Route("ObrisiTerminPosete/{ID}")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult DeleteTerminPosete(int ID)
        {
            try
            {
                DTOManager.DeleteTerminPosete(ID);
                return Ok();
            }
            catch (Exception exc)
            {
                return BadRequest(exc.ToString());
            }
        }
    }
}

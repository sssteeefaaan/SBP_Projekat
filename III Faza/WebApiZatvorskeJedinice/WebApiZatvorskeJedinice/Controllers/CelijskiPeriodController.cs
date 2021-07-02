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
    public class CelijskiPeriodController : ControllerBase
    {
        [HttpGet]
        [Route("PreuzmiCelijskePeriode")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult GetAllCelijskiPeriod()
        {
            try
            {
                return new JsonResult(DTOManager.ReadAllCelijskiPeriod());
            }
            catch (Exception exc)
            {
                return BadRequest(exc.ToString());
            }
        }

        [HttpGet]
        [Route("PreuzmiCelijskiPeriod/{ID}")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult GetCelijskiPeriod(int ID)
        {
            try
            {
                return new JsonResult(DTOManager.ReadCelijskiPeriod(ID));
            }
            catch (Exception exc)
            {
                return BadRequest(exc.ToString());
            }
        }

        [HttpPost]
        [Route("DodajCelijskiPeriod")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult CreateCelijskiPeriod([FromBody] CelijskiPeriodBasic cpb)
        {
            try
            {
                DTOManager.CreateCelijskiPeriod(cpb);
                return new JsonResult(cpb);
            }
            catch (Exception exc)
            {
                return BadRequest(exc.ToString());
            }
        }

        [HttpPut]
        [Route("IzmeniCelijskiPeriod")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult UpdateCelijskiPeriod([FromBody] CelijskiPeriodBasic cpb)
        {
            try
            {
                DTOManager.UpdateCelijskiPeriod(cpb);
                return new JsonResult(cpb);
            }
            catch (Exception exc)
            {
                return BadRequest(exc.ToString());
            }
        }

        [HttpDelete]
        [Route("ObrisiCelijskiPeriod/{ID}")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult DeleteCelijskiPeriod(int ID)
        {
            try
            {
                DTOManager.DeleteCelijskiPeriod(ID);
                return Ok();
            }
            catch (Exception exc)
            {
                return BadRequest(exc.ToString());
            }
        }
    }
}

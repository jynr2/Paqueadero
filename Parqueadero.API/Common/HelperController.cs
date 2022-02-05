using Microsoft.AspNetCore.Mvc;
using Parqueadero.Service.Models;

namespace Parqueadero.API.Common
{
    public class HelperController : Controller
    {
        public IActionResult ValidOperationStatus(BaseResponse baseResponse)
        {
            if (baseResponse.OperationStatus == 0)
                return BadRequest(baseResponse.Message);
            else if (baseResponse.OperationStatus == 1) return Ok(baseResponse);
            else return StatusCode(500, baseResponse.Message);
        }
    }
}

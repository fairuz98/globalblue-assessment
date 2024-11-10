using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace gb_assessment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CalculatorController : ControllerBase
    {
        [HttpPost] 
        [Authorize]
        public ActionResult<double> Calculate([FromBody] CalculationRequest request)
        {
            var result = EvaluateOperation(request.Operation);
            return Ok(result);
        }

        private double EvaluateOperation(string operation)
        {
            var dataTable = new System.Data.DataTable();
            return Convert.ToDouble(dataTable.Compute(operation, string.Empty));
        }
    }

    public class CalculationRequest
    {
        public string Operation { get; set; }
    }

}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Project_API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CalculatorController : ControllerBase
    {

        private readonly ILogger<CalculatorController> _logger;

        public CalculatorController(ILogger<CalculatorController> logger)
        {
            _logger = logger;
        }

        [HttpGet("sum/{firstNumber}/{secondNumber}")]
        public IActionResult Get(string firstNumber, string secondNumber )
        {
            
            if (IsNumeric(firstNumber) && IsNumeric(secondNumber))
            {
                var sum = ConvertToDecimal(firstNumber) + ConvertToDecimal(secondNumber);
                return Ok(sum.ToString());
            }

            return BadRequest("Invalid Input");
        }

        private bool IsNumeric(string param)
        {
            var isNumber = false;
            double numeroConvertido;

           isNumber = double.TryParse(param, System.Globalization.NumberStyles.Any,
                                System.Globalization.NumberFormatInfo.InvariantInfo,
                                out numeroConvertido);

            return isNumber;
        }

        private decimal ConvertToDecimal(string param)
        {
            decimal decimalValue;
            
            if (decimal.TryParse(param,out decimalValue))
            {
                return decimalValue;
            }

            return 0;
        }

    }
}

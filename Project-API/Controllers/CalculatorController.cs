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
                var calcuo = ConvertToDecimal(firstNumber) + ConvertToDecimal(secondNumber);
                return Ok(calcuo.ToString());
            }

            return BadRequest("Invalid Input");
        }

        [HttpGet("subtraction/{firstNumber}/{secondNumber}")]
        public IActionResult Subtraction(string firstNumber,string secondNumber)
        {
            if(IsNumeric(firstNumber) && IsNumeric(secondNumber))
            {
                var calculo = ConvertToDecimal(firstNumber) - ConvertToDecimal(secondNumber);
                return Ok(calculo.ToString());
            }

            return BadRequest("Invalid Input");
        }

        [HttpGet("multiplication/{firstNumber}/{secondNumber}")]
        public IActionResult Multiplication(string firstNumber, string secondNumber)
        {
            if(IsNumeric(firstNumber) && IsNumeric(secondNumber))
            {
                var calculo = ConvertToDecimal(firstNumber) * ConvertToDecimal(secondNumber);
                return Ok(calculo.ToString());
            }

            return BadRequest("Invalid Output");
        }

        [HttpGet("division/{firstNumber}/{secondNumber}")]
        public IActionResult Division(string firstNumber, string secondNumber)
        {
            if (IsNumeric(firstNumber) && IsNumeric(secondNumber))
            {
                if (ConvertToDecimal(secondNumber) == 0)
                {
                    return BadRequest("Division by zero not allowed");
                }

                var calculo = ConvertToDecimal(firstNumber) / ConvertToDecimal(secondNumber);

                return Ok(calculo.ToString());
            }

            return BadRequest("Invalid input");
        }

        [HttpGet("average/{firstNumber}/{secondNumber}")]
        public IActionResult Average(string firstNumber,string secondNumber)
        {
            if (IsNumeric(firstNumber) && IsNumeric(secondNumber))
            {
                var calculo = (ConvertToDecimal(firstNumber) + ConvertToDecimal(secondNumber)) / 2;

                return Ok(calculo.ToString());
            }

            return BadRequest("Invalid input");
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

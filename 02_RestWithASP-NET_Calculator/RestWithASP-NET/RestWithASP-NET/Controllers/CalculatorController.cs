using Microsoft.AspNetCore.Mvc;

namespace RestWithASP_NET.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CalculatorController : ControllerBase
    {

        private readonly ILogger<CalculatorController> _logger;


        //[HttpGet("sum/{firstNumber}/{secondNumber}")]
        //[HttpGet("sub/{firstNumber}/{secondNumber}")]
        //[HttpGet("div/{firstNumber}/{secondNumber}")]
        //[HttpGet("mult/{firstNumber}/{secondNumber}")]
        //[HttpGet("med/{firstNumber}/{secondNumber}")]
        [HttpGet("sqrt/{firstNumber}")]

        /*public IActionResult Get(string firstNumber, string secondNumber)
        {
            if (IsNumeric(firstNumber) && IsNumeric(secondNumber))
            {
                var sum = ConvertToDecimal(firstNumber) + ConvertToDecimal(secondNumber);
                return Ok(sum.ToString());
            }
            return BadRequest("Invalid Input");       
        }*/

        /*public IActionResult Get(string firstNumber, string secondNumber)
        {
            if (IsNumeric(firstNumber) && IsNumeric(secondNumber))
            {
                var sub = ConvertToDecimal(firstNumber) - ConvertToDecimal(secondNumber);
                return Ok(sub.ToString());
            }
            return BadRequest("Invalid Input");
        }*/

        /*public IActionResult Get(string firstNumber, string secondNumber)
        {
            if (IsNumeric(firstNumber) && IsNumeric(secondNumber))
            {
                var sub = ConvertToDecimal(firstNumber) / ConvertToDecimal(secondNumber);
                return Ok(sub.ToString());
            }
            return BadRequest("Invalid Input");
        }*/

        /*public IActionResult Get(string firstNumber, string secondNumber)
        {
            if (IsNumeric(firstNumber) && IsNumeric(secondNumber))
            {
                var sub = ConvertToDecimal(firstNumber) * ConvertToDecimal(secondNumber);
                return Ok(sub.ToString());
            }
            return BadRequest("Invalid Input");
        }*/

        /*public IActionResult Get(string firstNumber, string secondNumber)
        {
            if (IsNumeric(firstNumber) && IsNumeric(secondNumber))
            {
                var med = (ConvertToDecimal(firstNumber) + ConvertToDecimal(secondNumber))/2;
                return Ok(med.ToString());
            }
            return BadRequest("Invalid Input");
        }*/

        public IActionResult Get(string firstNumber)
        {
            if (IsNumeric(firstNumber))
            {
                var sqrt = Math.Sqrt((ConvertToDouble(firstNumber)));
                return Ok(sqrt.ToString());
            }
            return BadRequest("Invalid Input");
        }

        private bool IsNumeric(string strNumber)
        {
            double number;
            bool isNumber = double.TryParse(strNumber, System.Globalization.NumberStyles.Any, System.Globalization.NumberFormatInfo.InvariantInfo,out number);
            return isNumber;
        }

        private decimal ConvertToDecimal(string strNumber)
        {
            decimal decimalValue;
            if (decimal.TryParse(strNumber, out decimalValue))
            {
                return decimalValue;
            }
            return 0;
        }

        private double ConvertToDouble(string strNumber)
        {
            double doubleValue;
            if (double.TryParse(strNumber, out doubleValue))
            {
                return doubleValue;
            }
            return 0;
        }


    }
}
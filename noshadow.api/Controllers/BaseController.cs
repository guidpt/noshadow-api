using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using noshadow.api.Exceptions;
using noshadow.api.Model.Proxy;
using Newtonsoft.Json;

namespace noshadow.api.Controllers
{
    public class BaseController : Microsoft.AspNetCore.Mvc.Controller
    {

        public T GetProxy<T>(string json)
        {
            return JsonConvert.DeserializeObject<T>(json);
        }

        /// <summary>
        ///     Run <paramref name="predicate" /> under default statement.
        /// </summary>
        /// <param name="predicate">Function to be ran.</param>
        /// <returns><paramref name="predicate" /> return or default return in case of an error has been thrown.</returns>
        protected async Task<IActionResult> RunDefaultAsync(Func<Task<IActionResult>> predicate)
        {
            try
            {
                return await predicate();
            }
            catch (InvalidArgumentException invalidArgumentException)
            {
                return BadRequest(new ErrorProxy
                {
                    Code = 3,
                    Message = invalidArgumentException.Message
                });
            }
            catch (System.Exception exception)
            {
                return StatusCode(500, new ErrorProxy
                {
                    Code = 0,
                    Message = exception.Message
                });
            }
        }

        /// <summary>
        ///     Run <paramref name="predicate" /> under default statement.
        /// </summary>
        /// <param name="predicate">Function to be ran.</param>
        /// <returns><paramref name="predicate" /> return or default return in case of an error has been thrown.</returns>
        protected IActionResult RunDefault(Func<IActionResult> predicate)
        {
            try
            {
                return predicate();
            }
            catch (InvalidArgumentException invalidArgumentException)
            {
                return BadRequest(new ErrorProxy
                {
                    Code = 3,
                    Message = invalidArgumentException.Message
                });
            }
            catch (System.Exception exception)
            {
                return StatusCode(500, new ErrorProxy
                {
                    Code = 0,
                    Message = exception.Message
                });
            }
        }

    }
}
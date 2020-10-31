using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;

namespace Camones.Shop.Api.Controllers
{
    public class BaseController : ControllerBase
    {
        protected ActionResult<IEnumerable<T>> Collection<T>(IEnumerable<T> data)
        {
            if (data == null)
                return NotFound();
            
            return Ok(data);
        }

        protected ActionResult<T> Single<T>(T data)
        {
            if (data == null)
                return NotFound();

            return Ok(data);
        }
    }
}

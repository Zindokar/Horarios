﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HorariosBack.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class CustomersController : ControllerBase
  {
    [HttpGet]
    [Authorize]
    public IEnumerable<string> Get()
    {
      return new string[] { "yolandita", "sam0", "alejandro" };
    }
  }
}

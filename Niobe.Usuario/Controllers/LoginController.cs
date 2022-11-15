﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Niobe.Data;
using Niobe.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentResults;
using Niobe.Service;

namespace Niobe.Usuario.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private LoginService _loginService;

        public LoginController(LoginService loginService)
        {
            _loginService = loginService;
        }

        [HttpPost]
        public IActionResult LoginUsuario(LoginRequest request)
        {
            Token token = _loginService.LoginUsuario(request);
            if (token == null) return Unauthorized();
            return Ok(token);
        }
    }
}

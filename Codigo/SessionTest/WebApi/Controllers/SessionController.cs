using System;
using Microsoft.AspNetCore.Mvc;
using SessionLogicInterface;
using SessionLogicInterface.Entities;
using WebApi.Models;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("sessions")]
    public class SessionController : ControllerBase
    {
        private readonly ISessionService _sessionService;

        public SessionController(ISessionService sessionService)
        {
            this._sessionService = sessionService;
        }

        [HttpPost]
        public IActionResult Login(UserCredentials credentials)
        {
            string token = this._sessionService.Login(credentials);

            return Ok(new { data = token });
        }
    }
}


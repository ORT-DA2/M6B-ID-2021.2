using System;
using Microsoft.AspNetCore.Mvc;
using WebApi.Interfaces;
using WebApi.Services;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("movies")]
    public class MovieController : ControllerBase
    {
        private readonly IScoped _movieServiceScoped;
        private readonly IScoped _movieServiceScopedTwo;
        private readonly ITransient _movieServiceTransient;
        private readonly ITransient _movieServiceTransientTwo;
        private readonly ISingleton _movieServiceSingleton;

        public MovieController(IScoped movieServiceScoped, IScoped movieServiceScopedTwo, ITransient movieServiceTransient, ITransient movieServiceTransientTwo, ISingleton movieServiceSingleton)
        {
            this._movieServiceScoped = movieServiceScoped;
            this._movieServiceScopedTwo = movieServiceScopedTwo;
            this._movieServiceTransient = movieServiceTransient;
            this._movieServiceTransientTwo = movieServiceTransientTwo;
            this._movieServiceSingleton = movieServiceSingleton;
        }
        
        [HttpGet]
        public IActionResult Get()
        {
            Guid scopedId = this._movieServiceScoped.GetId();
            Guid scopedTwoId = this._movieServiceScopedTwo.GetId();

            Guid transientId = this._movieServiceTransient.GetId();
            Guid transientTwoId = this._movieServiceTransientTwo.GetId();

            return Ok(new
            {
                scoped = $"first movie service: {scopedId} & second movie service: {scopedTwoId} are equal: {scopedId == scopedTwoId}",
                transient = $"first movie service: {transientId} & second movie service: {transientTwoId} are equal: {transientId == transientTwoId}",
                singleton = $"first movie service: {this._movieServiceSingleton.GetId()}"
            });
        }
    }
}
using System;
using WebApi.Interfaces;

namespace WebApi.Services
{
    public class MovieService : IScoped, ITransient, ISingleton
    {
        private readonly Guid _id;

        public MovieService()
        {
            this._id = Guid.NewGuid();
        }

        public Guid GetId()
        {
            return this._id;
        }
    }
}
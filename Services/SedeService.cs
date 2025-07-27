using Proy_back_QBD.Models;
using Microsoft.AspNetCore.Mvc;
using Proy_back_QBD.Repository;

namespace Proy_back_QBD.Services
{
    public class SedeService : ISedeService
    {
        private readonly ISedeRepository _sedeRepository;
        public SedeService(ISedeRepository sedeRepository)
        {
            _sedeRepository = sedeRepository;
        }
        public async Task<int?> RegistrarSedeAsync(Sede sede)
        {
            if (sede == null)
            {
                return null;
            }
            await _sedeRepository.RegistrarAsync(sede);
            return sede.Id;
        }
    }
}
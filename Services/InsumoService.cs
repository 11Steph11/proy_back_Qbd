using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Proy_back_QBD.Data;
using Proy_back_QBD.Dto.Insumo;
using Proy_back_QBD.Models;


namespace Proy_back_QBD.Services
{
    public class InsumoService : IInsumoService
    {
        private readonly ApiContext _context;
        private readonly IMapper _mapper;
        public InsumoService(ApiContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public Task<Insumo?> Actualizar(int id, InsumoUpdateReq request)
        {
            throw new NotImplementedException();
        }

        public Task<Insumo?> Crear(InsumoCreateReq request)
        {
            throw new NotImplementedException();
        }

        public Task<Insumo?> Eliminar(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<InsumoLabRes>?> ListaFormulaR(int FormulaRId)
        {
            List<InsumoLabRes> response = await _context.InsumosR
                                                        .Where(w => w.FormulaRId == FormulaRId)
                                                        .Select(s => new InsumoLabRes
                                                        {
                                                            Id = s.InsumoId,
                                                            Descripcion = s.Insumo.Descripcion,
                                                            FactorCorreccion = s.Insumo.FactorCorreccion,
                                                            Dilucion = s.Insumo.Dilucion,
                                                            UnidadMedida = s.Insumo.UnidadMedida
                                                        })
                                                        .ToListAsync();
            return response;
        }

        public Task<List<InsumoFindAllRes?>> Obtener()
        {
            throw new NotImplementedException();
        }

        public Task<InsumoFindIdRes?> ObtenerById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
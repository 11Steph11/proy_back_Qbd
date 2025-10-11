using AutoMapper;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.EntityFrameworkCore;
using Proy_back_QBD.Data;
using Proy_back_QBD.Dto.Auxiliares;
using Proy_back_QBD.Dto.Request;
using Proy_back_QBD.Dto.Response;
using Proy_back_QBD.Models;
using Proy_back_QBD.Request;

namespace Proy_back_QBD.Services
{
    public class FormulaRService : IFormulaRService
    {
        private readonly ApiContext _context;
        private readonly IMapper _mapper;
        public FormulaRService(ApiContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<string> Crear(FormulaRCreReq request)
        {
            try
            {
                int result;
                // Mapeamos la formulaR
                FormulaR formulaR = _mapper.Map<FormulaR>(request);

                await _context.FormulasR.AddAsync(formulaR);
                result = await _context.SaveChangesAsync();
                foreach (var item in request.InsumosR)
                {
                    InsumoR insumoR = _mapper.Map<InsumoR>(item);
                    insumoR.FormulaRId = formulaR.Id;
                    await _context.InsumosR.AddAsync(insumoR);
                }

                // Intentamos guardar los cambios en la base de datos
                result = await _context.SaveChangesAsync();

                if (result > 0)
                {
                    return "Registro Exitoso";
                }
                else
                {
                    return "No se pudo guardar el registro. Intente nuevamente.";
                }
            }
            catch (Exception ex)
            {
                // Registro de error y manejo de excepciones
                // Aquí podrías usar un logger para registrar el error
                return $"Error: {ex.Message}";
            }
        }
        public async Task<string> Actualizar(int id, FormulaRUpdReq request)
        {
            try
            {
                // Buscar la formulaR existente
                var formulaR = await _context.FormulasR
                    .FirstOrDefaultAsync(f => f.Id == id); // Suponiendo que el Id está en la solicitud

                if (formulaR == null)
                {
                    return "La fórmula no existe.";
                }

                // Actualizamos las propiedades de FormulaR
                _mapper.Map(request, formulaR);  // Esto actualiza las propiedades de formulaR con los datos de request            

                // Guardamos los cambios
                var result = await _context.SaveChangesAsync();

                if (result > 0)
                {
                    return "Actualización exitosa";
                }
                else
                {
                    return "No se pudo actualizar la fórmula. Intente nuevamente.";
                }
            }
            catch (Exception ex)
            {
                // Log de error
                // Aquí podrías usar un logger para registrar el error
                return $"Error: {ex.Message}";
            }
        }

        public async Task<string> Eliminar(int formulaRId)
        {
            try
            {
                // Buscar la fórmula y sus insumos asociados
                var formulaR = await _context.FormulasR
                    .Include(f => f.InsumoR) // Cargar los insumos relacionados
                    .FirstOrDefaultAsync(f => f.Id == formulaRId);

                if (formulaR == null)
                {
                    return "La fórmula no existe.";
                }

                // Eliminar insumos relacionados (si no hay eliminación en cascada)
                if (formulaR.InsumoR != null && formulaR.InsumoR.Any())
                {
                    _context.InsumosR.RemoveRange(formulaR.InsumoR);
                }

                // Eliminar la fórmula
                _context.FormulasR.Remove(formulaR);

                // Guardar cambios
                var result = await _context.SaveChangesAsync();

                return result > 0
                    ? "Eliminación exitosa"
                    : "No se pudo eliminar la fórmula. Intente nuevamente.";
            }
            catch (Exception ex)
            {
                // Aquí podrías usar un logger para registrar el error
                return $"Error: {ex.Message}";
            }
        }


        public async Task<List<FormulaRRes>?> Listar(int sedeId)
        {
            List<FormulaRRes> response = await _context.FormulasR
                                                        .Where(w => w.SedeId == sedeId)
                                                        .Select(s => new FormulaRRes
                                                        {
                                                            Id = s.Id,
                                                            Descripcion = s.Descripcion,
                                                            Empaque = s.Empaque,
                                                            Procedimiento = s.Procedimiento,
                                                            Aspecto = s.Aspecto,
                                                            Color = s.Color,
                                                            Olor = s.Olor,
                                                            Ph = s.Ph
                                                        })
                                                        .ToListAsync();
            return response;
        }

    }
}
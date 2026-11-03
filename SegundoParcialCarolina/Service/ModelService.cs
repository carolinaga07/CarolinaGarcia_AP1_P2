using Aplicada1.Core;
using Microsoft.EntityFrameworkCore;
using SegundoParcialCarolina.Context;
using SegundoParcialCarolina.Models;
using System.Linq.Expressions;

namespace SegundoParcialCarolina.Service;

public class ModelService(IDbContextFactory<Contexto> contextFactory) : Aplicada1.Core.IServiceResult<Model1, int>
{
    public Task<Result<Model1?>> Buscar(int id)
    {
        throw new NotImplementedException();
    }

    public Task<Result> Eliminar(int id)
    {
        throw new NotImplementedException();
    }

    public Task<Result<List<Model1>>> GetList(Expression<Func<Model1, bool>> criterio)
    {
        throw new NotImplementedException();
    }

    public Task<Result> Guardar(Model1 entidad)
    {
        throw new NotImplementedException();
    }
}

using Aplicada1.Core;
using Microsoft.EntityFrameworkCore;
using SegundoParcialCarolina.Context;
using SegundoParcialCarolina.Models;
using System.Linq.Expressions;

namespace SegundoParcialCarolina.Service;

public class ModelService(IDbContextFactory<Contexto> contextFactory) : Aplicada1.Core.IServiceResult<Productos, int>
{
     public Task<Result> Guardar(Productos entidad)
    {
        throw new NotImplementedException();
    }

    //private async Task<bool> Existe (int id)
    // {

    // }

    // private async Task<bool> Insertar(Model1 model1)
    //{

    //}

    //private async Task<bool> Modificar(Model1 model1)
    //{

   
    public Task<Result<Productos?>> Buscar(int id)
    {
        throw new NotImplementedException();
    }
    public Task<Result<List<Productos>>> GetList(Expression<Func<Productos, bool>> criterio)
    {
        throw new NotImplementedException();
    }
    public Task<Result> Eliminar(int id)
    {
        throw new NotImplementedException();
    }

    /*private async Task<bool> Calcular(Model1 model, Contexto contexto)
    * {
    * }*/


    /*private async Task Ajustar(Contexto contexto, int modelId, int puntos)
      * {
      * }*/

    /*public async Task<List<model>> Listarmodel()
    * {
    * }*/


    /*public async Task<List<modelpuntaje>> Listarmodelpuntaje()
    * {
    * }*/


}

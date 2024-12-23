﻿
using webapi.Models;

namespace webapi.Services;

public class CategoriaService : ICategoriaService
{
 TareasContext context;
 
    public CategoriaService(TareasContext dbcontext)
    {
        context= dbcontext;
    }
    //Obtener
     public IEnumerable<Categoria> Get()
     {
         return context.Categorias;
     }
     
     //Guardar
     public async Task Save(Categoria categoria)
     {
         context.Categorias.Add(categoria);
        await context.SaveChangesAsync();
         
     }
     
     //actualizar
        public async  Task Update(Guid id, Categoria categoria)
        {
            var categoriaActual = context.Categorias.Find(id);

            if (categoriaActual != null)
            {
                categoriaActual.Nombre= categoria.Nombre;
                categoria.Descripcion= categoria.Descripcion;
                categoria.Peso= categoria.Peso;

               await context.SaveChangesAsync();
            }
         
        }
        //Eliminar 
        public async  Task Delete(Guid id)
        {
            var categoriaActual = context.Categorias.Find(id);

            if (categoriaActual != null)
            {
                context.Categorias.Remove(categoriaActual);
                await context.SaveChangesAsync();
            }
         
        }
}

public interface ICategoriaService
{
     IEnumerable<Categoria> Get();
     Task Save(Categoria categoria);
     Task Update(Guid id, Categoria categoria);
     Task Delete(Guid id);
}
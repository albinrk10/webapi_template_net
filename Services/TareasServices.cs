using webapi.Models;

namespace webapi.Services;

public class TareasService : ITareasService
{
    TareasContext context;
 
    public TareasService(TareasContext dbcontext)
    {
        context= dbcontext;
    }
    //Obtener
        public IEnumerable<Tarea> Get()
        {
            return context.Tareas;
        }
        //Guardar
        public async Task Save(Tarea tarea)
        {
            context.Tareas.Add(tarea);
            await context.SaveChangesAsync();
        }
        //actualizar
        public async Task Update(Guid id, Tarea tarea)
        {
            var tareaActual = context.Tareas.Find(id);

            if (tareaActual != null)
            {
                tareaActual.Titulo = tarea.Titulo;
                tarea.Descripcion = tarea.Descripcion;
                tarea.PrioridadTarea = tarea.PrioridadTarea;
                tarea.FechaCreacion = tarea.FechaCreacion;
                tarea.CategoriaId = tarea.CategoriaId;
                tarea.Resumen = tarea.Resumen;

                await context.SaveChangesAsync();
            }
        }
        //Eliminar
        public async Task Delete(Guid id)
        {
            var tareaActual = context.Tareas.Find(id);

            if (tareaActual != null)
            {
                context.Tareas.Remove(tareaActual);
                await context.SaveChangesAsync();
            }
        }
}

public interface ITareasService
{
    IEnumerable<Tarea> Get();
    Task Save(Tarea tarea);
    Task Update(Guid id, Tarea tarea);
    Task Delete(Guid id);
}
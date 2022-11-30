using Indimin.EastView.Domain.Entities;
using Indimin.EastView.Domain.Helpers;
using Indimin.EastView.Domain.Models;

namespace Indimin.EastView.Domain
{
    public static class CuidadanoMapper
    {
        public static Cuidadano ToEntity(this CuidadanoRequest request)
        {
            var entity = new Cuidadano();
            if (request != null)
            {
                entity.Nombre = request.Nombre;
                entity.Apellido = request.Apellido;
            }

            return entity;
        }

        public static IList<CuidadanoModel> ToModels(this ICollection<Cuidadano> entities)
        {
            List<CuidadanoModel> models = new();
            if (entities != null && entities.Any())
            {
                foreach (var entity in entities)
                {
                    models.Add(entity.ToModel());
                }
            }

            return models;
        }

        public static CuidadanoModel ToModel(this Cuidadano entity)
        {
            var model = new CuidadanoModel();
            if (entity != null)
            {
                model.CuidadanoId = entity.CuidadanoId;
                model.Nombre = entity.Nombre;
                model.Apellido = entity.Apellido;

                if (entity.Tareas != null && entity.Tareas.Any())
                {
                    model.Tareas = entity.Tareas.ToModels();
                }
            }

            return model;
        }

        public static Cuidadano ToUpdate(this CuidadanoRequest request, Cuidadano entity) 
        {
            if (request != null && entity != null)
            {
                entity.Nombre = request.Nombre;
                entity.Apellido = request.Apellido;
            }

            return entity;
        }
    }
}

using Indimin.EastView.Domain.Entities;
using Indimin.EastView.Domain.Models;

namespace Indimin.EastView.Domain.Helpers
{
    public static class TareaHelpers
    {
        public static Tarea ToEntity(this TareaRequest request, int cuidadanoId)
        {
            var entity = new Tarea();
            if (request != null)
            {
                entity.Descripcion = request.Descripcion;
                entity.Fecha = request.Fecha;
                entity.CuidadanoId = cuidadanoId;
            }

            return entity;
        }

        public static IList<TareaModel> ToModels(this ICollection<Tarea> entities)
        {
            List<TareaModel> models = new();
            if (entities != null && entities.Any())
            {
                foreach (var entity in entities)
                {
                    models.Add(entity.ToModel());
                }
            }

            return models;
        }

        public static TareaModel ToModel(this Tarea entity)
        {
            TareaModel model = new();
            if (entity != null)
            {
                model.Descripcion = entity.Descripcion;
                model.TareaId = entity.TareaId;
                model.Fecha = entity.Fecha;
            }

            return model;
        }

        public static Tarea ToUpdate(this TareaRequest request, Tarea entity)
        {
            if (request != null && entity != null)
            {
                entity.Descripcion = request.Descripcion;
                entity.Fecha = request.Fecha;
            }

            return entity;
        }
    }
}

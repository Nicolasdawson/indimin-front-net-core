using Indimin.EastView.Domain;
using Indimin.EastView.Domain.Entities;
using Indimin.EastView.Domain.Helpers;
using Indimin.EastView.Domain.Models;
using Indimin.EastView.Infrastructure.Repository;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Indimin.EastView.Api.Controllers
{
    [Route("api/")]
    [ApiController]
    public class TareaController : ControllerBase
    {
        private readonly IRepository<Tarea> _tareaRepository;
        private readonly IRepository<Cuidadano> _cuidadanoRepository;

        public TareaController(IRepository<Tarea> tareaRepository,
            IRepository<Cuidadano> cuidadanoRepository)
        {
            _tareaRepository = tareaRepository;
            _cuidadanoRepository = cuidadanoRepository;
        }

        [HttpGet]
        [Route("cuidadanos/tareas/{fecha}")]
        public virtual IActionResult GetTareas(
            [FromRoute] DateTime fecha)
        {
            var tareas = _tareaRepository.Get(x => x.Fecha.Date == fecha.Date, "Cuidadano").ToList();

            return Ok(tareas.ToModels());
        }

        [HttpPost]
        [Route("cuidadanos/{cuidadanoId}/tareas")]
        public virtual IActionResult CreateTarea(
            [FromRoute][Range(1, int.MaxValue)] int cuidadanoId,
            [FromBody] TareaRequest request)
        {
            var cuidadano = _cuidadanoRepository.Get(x => x.CuidadanoId == cuidadanoId).FirstOrDefault();

            if (cuidadano == null)
            {
                return NotFound("El cuidadano no existe");
            }

            var entity = request.ToEntity(cuidadanoId);

            entity = _tareaRepository.Create(entity);

            return Created(Request.GetDisplayUrl(), entity.ToModel());
        }

        [HttpPut]
        [Route("cuidadanos/{cuidadanoId}/tareas/{tareaId}")]
        public virtual IActionResult UpdateTarea(
            [FromBody] TareaRequest request,
            [FromRoute][Range(1, int.MaxValue)] int cuidadanoId,
            [FromRoute][Range(1, int.MaxValue)] int tareaId)
        {
            var tarea = _tareaRepository.Get(x => x.CuidadanoId == cuidadanoId && x.TareaId == tareaId).FirstOrDefault();

            if (tarea == null)
            {
                return NotFound("La tarea no existe");
            }

            request.ToUpdate(tarea);

            tarea = _tareaRepository.Update(tarea);

            return Ok(tarea.ToModel());
        }

        [HttpDelete]
        [Route("cuidadanos/{cuidadanoId}/tareas/{tareaId}")]
        public virtual IActionResult DeleteTarea(
            [FromRoute][Range(1, int.MaxValue)] int cuidadanoId,
            [FromRoute][Range(1, int.MaxValue)] int tareaId)
        {
            var tarea = _tareaRepository.Get(x => x.CuidadanoId == cuidadanoId && x.TareaId == tareaId).FirstOrDefault();

            if (tarea == null)
            {
                return NotFound("La tarea no existe");
            }

            _tareaRepository.Remove(tarea);

            return NoContent();
        }
    }
}

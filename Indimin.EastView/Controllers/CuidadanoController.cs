using Indimin.EastView.Domain;
using Indimin.EastView.Domain.Entities;
using Indimin.EastView.Domain.Models;
using Indimin.EastView.Infrastructure.Repository;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Indimin.EastView.Api.Controllers
{
    [Route("api/")]
    [ApiController]
    public class CuidadanoController : ControllerBase
    {
        private readonly IRepository<Cuidadano> _cuidadanoRepository;

        public CuidadanoController(IRepository<Cuidadano> cuidadanoRepository)
        {
            _cuidadanoRepository = cuidadanoRepository;
        }

        [HttpGet]
        [Route("cuidadanos")]
        public virtual IActionResult GetCuidadanos()
        {
            var cuidadanos = _cuidadanoRepository.Get(null, "Tareas").ToList().ToModels();

            return Ok(cuidadanos);
        }

        [HttpGet]
        [Route("cuidadanos/{id}")]
        public virtual IActionResult GetCuidadano(
            [FromRoute][Range(1, int.MaxValue)] int id)
        {
            var cuidadano = _cuidadanoRepository.Get(x => x.CuidadanoId == id, "Tareas").FirstOrDefault();

            if (cuidadano == null)
            {
                return NotFound("El cuidadano no existe");
            }

            return Ok(cuidadano.ToModel());
        }

        [HttpPost]
        [Route("cuidadanos")]
        public virtual IActionResult CreateCuidadano(
            [FromBody] CuidadanoRequest request)
        {
            var entity = request.ToEntity();

            var cuidadano = _cuidadanoRepository.Create(entity);

            return Created(Request.GetDisplayUrl(), cuidadano.ToModel());
        }

        [HttpPut]
        [Route("cuidadanos/{id}")]
        public virtual IActionResult UpdateCuidadano(
            [FromBody] CuidadanoRequest request,
            [FromRoute][Range(1, int.MaxValue)] int id)
        {
            var cuidadano = _cuidadanoRepository.Get(x => x.CuidadanoId == id).FirstOrDefault();

            if (cuidadano == null)
            {
                return NotFound("El cuidadano no existe");
            }

            request.ToUpdate(cuidadano);

            cuidadano = _cuidadanoRepository.Update(cuidadano);

            return Ok(cuidadano.ToModel());
        }

        [HttpDelete]
        [Route("cuidadanos/{id}")]
        public virtual IActionResult DeleteCuidadano(
            [FromRoute][Range(1, int.MaxValue)] int id)
        {
            var cuidadano = _cuidadanoRepository.Get(x => x.CuidadanoId == id).FirstOrDefault();

            if (cuidadano == null)
            {
                return NotFound("El cuidadano no existe");
            }

            _cuidadanoRepository.Remove(cuidadano);

            return NoContent();
        }
    }
}

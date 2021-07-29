using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Domain.Entities;
using WebApi.Domain.Interface;
using WebApi.Service.Validators;

namespace WebApiDDD.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : Controller
    {

        private IBaseService<Usuario> _baseService;

        public UsuarioController(IBaseService<Usuario> baseService)
        {
            _baseService = baseService;
        }

        [HttpPost]
        public IActionResult Create([FromBody] Usuario usuario)
        {
            if (usuario == null)
            {
                return NotFound();
            }
            return Execute(() => _baseService.Add<UsuarioValidator>(usuario).Id);
        }


        [HttpPut]
        public IActionResult Update([FromBody] Usuario usuario)
        {
            if (usuario == null)
            {
                return NotFound();
            }
            return Execute(() => _baseService.Update<UsuarioValidator>(usuario).Id);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if (id == 0)
                return NotFound();

            Execute(() =>
            {
                _baseService.Delete(id);
                return true;
            });

            return new NoContentResult();
        }


        [HttpGet]
        public IActionResult Get()
        {
            return Execute(() => _baseService.Get()
            );

        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            if(id == 0)
            {
                return NotFound();
            }

            return Execute(() => _baseService.GetById(id)
                );
        }

        private IActionResult Execute(Func<object> func)
        {
            try
            {
                var result = func();
                return Ok(result);

            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

    }
}

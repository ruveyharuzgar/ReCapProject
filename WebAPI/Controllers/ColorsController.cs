using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ColorsController : Controller
    {
        IColorService _colorService;

        public ColorsController(IColorService colorService)
        {
            _colorService = colorService;
        }

        [HttpPost("add")]
        public IActionResult Add(Color color)
        {
            var result = _colorService.Add(color);
            if (result.Succes)
            {
                return Ok(result);
            }
            return BadRequest(result.Succes);
        }

        [HttpPost("delete")]
        public IActionResult Delete(Color color)
        {
            var result = _colorService.Delete(color);
            if (result.Succes)
            {
                return Ok(result);
            }
            return BadRequest(result.Succes);
        }

        [HttpPost("update")]
        public IActionResult Update(Color color)
        {
            var result = _colorService.Update(color);
            if (result.Succes)
            {
                return Ok(result);
            }
            return BadRequest(result.Succes);
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _colorService.GetAll();
            if (result.Succes)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }

        [HttpGet("getcarsbycolorsid")]
        public IActionResult GetCarsByColorsId(int id)
        {
            var result = _colorService.GetCarsByColorId(id);
            if (result.Succes)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);

        }
    }
}

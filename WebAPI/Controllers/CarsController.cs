using Business.Abstract;
using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarsController : ControllerBase
    {
        ICarService _carService;

        public CarsController(ICarService carService)
        {
            _carService = carService;
        }
       
        [HttpPost("add")]
        public IActionResult Add(Car car)
        {
            var result = _carService.Add(car);
            if (result.Succes)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }

        [HttpPost("delete")]
        public IActionResult Delete(Car car)
        {
            var result = _carService.Delete(car);
            if (result.Succes)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }

        [HttpPost("update")]
        public IActionResult Update(Car car)
        {
            var result = _carService.Update(car);
            if (result.Succes)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            Thread.Sleep(1000);
            var result = _carService.GetAll();
            if (result.Succes)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }

        [HttpGet("getcarsbybrandid")]
        public IActionResult GetCarsByBrandId(int brandId)
        {
            var result = _carService.GetCarsByBrandId(brandId);
            if (result.Succes)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }

        [HttpGet("getcarsbycolorid")]
        public IActionResult GetCarsByColorsId(int colorId)
        {
            var result = _carService.GetCarsByColorsId(colorId);
            if (result.Succes)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }


        [HttpGet("getcardetailsbybrandname")]
        public IActionResult GetCarDetailsByBrandName(string name)
        {
            var result = _carService.GetCarDetailsByBrandName(name);
            if (result.Succes) return Ok(result);

            return BadRequest(result);
        }

        [HttpGet("getcardetailsbycolorname")]
        public IActionResult GetCarDetailsByColorName(string name)
        {
            var result = _carService.GetCarDetailsByColorName(name);
            if (result.Succes) return Ok(result);

            return BadRequest(result);
        }

        [HttpGet("getcardetails")]
        public IActionResult GetCarDetails()
        {
            var result = _carService.GetCarDetails();
            if (result.Succes)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }

        [HttpGet("getcardetailsbyid")]
        public IActionResult GetCarDetailsById(int carId)
        {
            var result = _carService.GetCarDetailsById(carId);
            if (result.Succes)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getcarsbydailyprice")]
        public IActionResult GetCarsByDailyPrice(decimal min, decimal max)
        {
            var result = _carService.GetCarsByDailyPrice(min, max);
            if (result.Succes)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getallcardetailsbyfiltersid")]
        public IActionResult GetAllCarDetailsByFilter(int brandId, int colorId)
        {
            var result = _carService.GetAllCarDetailsByFilter(brandId, colorId);
            if (result.Succes)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getallcardetailsbyfiltername")]
        public IActionResult GetCarDetailsByBrandNameAndColorName(string brandName, string colorName)
        {
            var result = _carService.GetCarDetailsByBrandNameAndColorName(brandName,colorName);
            if (result.Succes)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}

using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarsController : ControllerBase
    {
        ICarService _carManager;

        public CarsController(ICarService carManager)
        {
            _carManager = carManager;
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _carManager.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpGet("getbyid")]
        public IActionResult GetById(int id)
        {
            var result = _carManager.GetCarById(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
       /* [HttpGet("getbycolorid")]
        public IActionResult GetByColorId(int colorId)
        {
            var result = _carManager.GetCarsByColorId(colorId);

            return StatusCode(result.Success ? 200 : 400, result);
        }*/
       [HttpPost("add")]
       public IActionResult Add(Car car)
        {
            var result = _carManager.Add(car);
            if(result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpPost("delete")]
        public IActionResult Delete(Car car)
        {
            var result = _carManager.delete(car);
            if(result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpPost("update")]

        public IActionResult Update(Car car)
        {
            var result = _carManager.update(car);
            if(result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpGet("getcardetails")]
                public IActionResult GetCarDetails(int id)
        {
            var result = _carManager.GetCarDetails(c=>c.CarId==id);
            if(result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }
    }
}

using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using AudioService.Models;
using System.Reflection;
using AudioService.Repositories;
using AudioService.DTO.Gravadoras;

namespace AudioService.Controllers
{
    [Route("api/gravadora")]
    [ApiController]
    public class GravadoraController : ControllerBase
    {
        private readonly GravadoraRepository gravadoraRepository;
        public GravadoraController(DataContext context)
        {
            this.gravadoraRepository = new GravadoraRepository(context);
        }

        [HttpGet]
        public async Task<ActionResult<List<Gravadora>>> GetAll()
        {
            return Ok(await gravadoraRepository.GetAll());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Gravadora>> GetOne(int id)
        {
            return Ok(await this.gravadoraRepository.GetOne(id));
        }

        [HttpPost]
        public async Task<ActionResult<Gravadora>> Insert(InsertGravadoraDTO newInsertObj)
        {
            return Ok(await gravadoraRepository.Insert(newInsertObj));
        }

        [HttpPut]
        public async Task<ActionResult<Gravadora>> Update(UpdateGravadoraDTO? newUpdateObj)
        {
            var result = await gravadoraRepository.Update(newUpdateObj);
            if (result == default(Gravadora))
            {
                return NotFound();
            }
            return Ok(newUpdateObj);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<int>> Delete(int id)
        {
            var result = await gravadoraRepository.Delete(id);
            if (result == 0)
            {
                return NotFound();
            }
            return id;
        }
    }

}
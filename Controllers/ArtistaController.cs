using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using AudioService.Models;
using System.Reflection;
using AudioService.Repositories;
using AudioService.DTO.Artistas;

namespace AudioService.Controllers
{
    [Route("api/artista")]
    [ApiController]
    public class ArtistaController : ControllerBase
    {
        private readonly ArtistaRepository artistaRepository;

        public ArtistaController(DataContext context)
        {
            this.artistaRepository = new ArtistaRepository(context);
        }

        [HttpGet]
        public async Task<ActionResult<List<Artista>>> GetAll()
        {
            return Ok(await artistaRepository.GetAll());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Artista>> GetOne(int id)
        {
            return Ok(await artistaRepository.GetOne(id));
        }

        [HttpPost]
        public async Task<ActionResult<Artista>> Insert(InsertArtistaDTO newInsertObj)
        {
            await artistaRepository.Insert(newInsertObj);
            return Ok(newInsertObj);
        }

        [HttpPut]
        public async Task<ActionResult<Artista>> Update(UpdateArtistaDTO? newUpdateObj)
        {
            var result = await artistaRepository.Update(newUpdateObj);

            if (default(Artista) == result)
            {
                return NotFound();
            }
            return Ok(newUpdateObj);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<int>> Delete(int id)
        {
            var result = await artistaRepository.Delete(id);

            if (result == 0)
            {
                return NotFound();
            }
            return Ok(id);
        }
    }
}
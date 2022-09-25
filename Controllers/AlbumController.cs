using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using AudioService.Models;
using System.Reflection;
using AudioService.Repositories;
using AudioService.DTO.Albums;

namespace AudioService.Controllers
{
    [Route("api/album")]
    [ApiController]
    public class AlbumController : ControllerBase
    {
        private readonly AlbumRepository albumRepository;

        public AlbumController(DataContext context)
        {
            this.albumRepository = new AlbumRepository(context);
        }

        [HttpGet]
        public async Task<ActionResult<List<Album>>> GetAll()
        {
            return Ok(await this.albumRepository.GetAll());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Album>> GetOne(int id)
        {
            return Ok(await this.albumRepository.GetOne(id));
        }

        [HttpPost]
        public async Task<ActionResult<Album>> Insert(InsertAlbumDTO newInsertObj)
        {
            return Ok(await this.albumRepository.Insert(newInsertObj));
        }

        [HttpPut]
        public async Task<ActionResult<Album>> Update(UpdateAlbumDTO? newUpdateObj)
        {
            var result = await this.albumRepository.Update(newUpdateObj);
            if (result == default(Album))
            {
                return NotFound();
            }
            return Ok(newUpdateObj);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<int>> Delete(int id)
        {
            var result = await this.albumRepository.Delete(id);
            if (result == 0)
            {
                return NotFound();
            }
            return Ok(id);
        }
    }
}
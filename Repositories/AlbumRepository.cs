using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using AudioService.Models;
using AudioService.Repositories.Interfaces;
using AudioService.Repositories;
using System.Reflection;
using AudioService.DTO.Albums;

namespace AudioService.Repositories
{
    public class AlbumRepository : IGeneric<Album>
    {
        private readonly DataContext _context;

        public AlbumRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<List<Album>> GetAll()
        {
            return await _context.Album.ToListAsync();
        }

        public async Task<Album> GetOne(int id)
        {
            return await this._context.Album.FindAsync(id);
        }

        public async Task<Album> Insert(InsertAlbumDTO newInsertObj)
        {
            var gravadoraFound = await _context.Gravadora.FindAsync(newInsertObj.codGrav);
            var artistaFound = await _context.Artista.FindAsync(newInsertObj.codArt);
            if (gravadoraFound == null || artistaFound == null)
            {
                return default(Album);
            }
            List<Artista> artistasToSet = new List<Artista> { artistaFound };
            Album albumData = new Album
            {
                dataLancamento = newInsertObj.dataLancamento,
                genero = newInsertObj.genero,
                titulo = newInsertObj.titulo,
                gravadora = gravadoraFound,
                artistas = artistasToSet
            };
            var newAlbum = this._context.Album.Add(albumData);
            gravadoraFound.Albums.Add(albumData);
            artistaFound.albums.Add(albumData);
            await _context.SaveChangesAsync();
            return albumData;
        }

        public async Task<Album> Update(UpdateAlbumDTO? newUpdateObj)
        {
            var oldRegister = await this._context.Album.FindAsync(newUpdateObj.codAlb);
            if (oldRegister == null)
            {
                return default(Album);
            }
            foreach (PropertyInfo prop in newUpdateObj.GetType().GetProperties())
            {
                if (prop.GetValue(oldRegister) != null)
                {
                    prop.SetValue(oldRegister, prop.Name, null);
                }
            }
            await _context.SaveChangesAsync();
            return new Album
            {
                artistas = newUpdateObj.artistas,
                codAlb = newUpdateObj.codAlb,
                dataLancamento = newUpdateObj.dataLancamento,
                genero = newUpdateObj.genero,
                gravadora = newUpdateObj.gravadora,
                titulo = newUpdateObj.titulo
            };
        }

        public async Task<int> Delete(int id)
        {
            var oldRegister = await this._context.Album.FindAsync(id);
            if (oldRegister == null)
            {
                return 0;
            }
            this._context.Album.Remove(oldRegister);
            await _context.SaveChangesAsync();
            return id;
        }
    }
}
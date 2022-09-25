using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using AudioService.Repositories.Interfaces;
using AudioService.Models;
using System.Reflection;
using AudioService.DTO.Artistas;

namespace AudioService.Repositories
{
    public class ArtistaRepository : IGeneric<Artista>
    {
        private readonly DataContext _context;

        public ArtistaRepository(DataContext context)
        {
            this._context = context;
        }

        public async Task<List<Artista>> GetAll()
        {
            return await _context.Artista.ToListAsync();
        }

        public async Task<Artista> GetOne(int id)
        {
            return await this._context.Artista.FindAsync(id);
        }

        public async Task<Artista> Insert(InsertArtistaDTO newInsertObj)
        {
            Artista artistaData = new Artista {
                nomeArt = newInsertObj.nomeArt
            };
            this._context.Artista.Add(artistaData);
            await _context.SaveChangesAsync();
            return artistaData;
        }

        public async Task<Artista> Update(UpdateArtistaDTO? newUpdateObj)
        {
            var oldRegister = await this._context.Artista.FindAsync(newUpdateObj.codArt);
            if (oldRegister == null)
            {
                return default(Artista);
            }
            foreach (PropertyInfo prop in newUpdateObj.GetType().GetProperties())
            {
                if (prop.GetValue(oldRegister) != null)
                {
                    prop.SetValue(oldRegister, prop.Name, null);
                }
            }
            await _context.SaveChangesAsync();
            return new Artista { albums = newUpdateObj.albums, nomeArt = newUpdateObj.nomeArt, codArt = newUpdateObj.codArt };
        }

        public async Task<int> Delete(int id)
        {
            var oldRegister = await this._context.Artista.FindAsync(id);
            if (oldRegister == null)
            {
                return 0;
            }
            this._context.Artista.Remove(oldRegister);
            await _context.SaveChangesAsync();
            return id;
        }
    }
}
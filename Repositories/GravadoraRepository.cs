using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using AudioService.Repositories.Interfaces;
using AudioService.Models;
using System.Reflection;
using AudioService.DTO.Gravadoras;

namespace AudioService.Repositories
{
    public class GravadoraRepository : IGeneric<Gravadora>
    {
        private readonly DataContext _context;

        public GravadoraRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<List<Gravadora>> GetAll()
        {
            return await _context.Gravadora.ToListAsync();
        }

        public async Task<Gravadora> GetOne(int id)
        {
            return await this._context.Gravadora.FindAsync(id);
        }

        public async Task<Gravadora> Insert(InsertGravadoraDTO newInsertObj)
        {
            Gravadora gravadoraData = new Gravadora { nomeGrav = newInsertObj.nomeGrav };
            this._context.Gravadora.Add(gravadoraData);
            await _context.SaveChangesAsync();
            return gravadoraData;
        }

        public async Task<Gravadora> Update(UpdateGravadoraDTO? newUpdateObj)
        {
            var oldRegister = await this._context.Gravadora.FindAsync(newUpdateObj.codGrav);
            if (oldRegister == null)
            {
                return default(Gravadora);
            }
            foreach (PropertyInfo prop in newUpdateObj.GetType().GetProperties())
            {
                if (prop.GetValue(oldRegister) != null)
                {
                    prop.SetValue(oldRegister, prop.Name, null);
                }
            }
            await _context.SaveChangesAsync();
            return new Gravadora { nomeGrav = newUpdateObj.nomeGrav, Albums = newUpdateObj.Albums, codGrav = newUpdateObj.codGrav };
        }

        public async Task<int> Delete(int id)
        {
            var oldRegister = await this._context.Gravadora.FindAsync(id);
            if (oldRegister == null)
            {
                return 0;
            }
            this._context.Gravadora.Remove(oldRegister);
            await _context.SaveChangesAsync();
            return id;
        }
    }
}
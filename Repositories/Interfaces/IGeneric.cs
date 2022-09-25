using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace AudioService.Repositories.Interfaces
{
    public interface IGeneric<T>
    {
        public Task<List<T>> GetAll();
        public Task<T> GetOne(int id);
        public Task<int> Delete(int id);
    }
}
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vehicle.DAL;
using Vehicle.Repository.Common;

namespace Vehicle.Repository
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
    {
        private readonly VehicleContext _db;
        private readonly DbSet<TEntity> dbSet;

        public GenericRepository(VehicleContext context)
        {
            _db = context;
            dbSet = _db.Set<TEntity>();

        }

        public async Task<TEntity> GetById(int id)
        {
           return await dbSet.FindAsync(id);
        }

        public async void Add(TEntity entity)
        {
            await dbSet.AddAsync(entity);
            await _db.SaveChangesAsync();
        }

        public async void Update(TEntity entity)
        {
            _db.Entry(entity).State = EntityState.Modified;
            await _db.SaveChangesAsync();
        }
        public async void Delete(int id)
        {
            var entity = await GetById(id);
            dbSet.Remove(entity);
            await _db.SaveChangesAsync();
        }
    }
}

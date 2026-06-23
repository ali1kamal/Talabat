
//using Microsoft.EntityFrameworkCore;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using Talabat.BLL.Interfaces;
//using Talabat.BLL.Spacifications;
//using Talabat.BLL.Specifications;
//using Talabat.DAL.Data;
//using Talabat.DAL.Entities;

//namespace Talabat.BLL.Repositories
//{
//    public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
//    {
//        public GenericRepository(StoreContext context)
//        {
//            this.context = context;
//        }

//        public StoreContext context { get; }

//        public async Task<int> CountAsync(ISpecification<T> spec)
//        => await ApplySpecification(spec).CountAsync();

//        public async Task<IReadOnlyList<T>> GetAllAsync()
//            => await context.Set<T>().ToListAsync();

//        public async Task<IReadOnlyList<T>> GetAllWithSpecAsync(ISpecification<T> spec)
//        {
//            return await ApplySpecification(spec).ToListAsync();
//        }

//        public async Task<T> GetByIdAsync(int id)
//        => await context.Set<T>().FindAsync(id);

//        public async Task<T> GetByIdWithSpecAsync(ISpecification<T> spec)
//        {
//            return await ApplySpecification(spec).FirstOrDefaultAsync();
//        }

//        private IQueryable<T> ApplySpecification(ISpecification<T> spec)
//        {
//            return SpecificationEvalautor<T>.GetQuery(context.Set<T>().AsQueryable(), spec);
//        }
//    }
//}

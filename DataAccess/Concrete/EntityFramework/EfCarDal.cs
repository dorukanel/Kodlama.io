using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarDal : ICarDal
    {
        public void Add(Car entity)
        {
            //IDisposable pattern implementation of c#
                using (DorukanAracContext context = new DorukanAracContext())
                {
                    var addedEntity = context.Entry(entity);
                    addedEntity.State = EntityState.Added;
                    context.SaveChanges();
                }
            
        }

        public void Delete(Car entity)
        {
            using (DorukanAracContext context = new DorukanAracContext())
            {
                context.Cars.Remove(context.Cars.SingleOrDefault(c => c.CarId == entity.CarId));
                context.SaveChanges();
            }
        }

        public Car Get(Expression<Func<Car, bool>> filter)
        {
            using (DorukanAracContext context = new DorukanAracContext())
            {
                return context.Set<Car>().SingleOrDefault(filter);
            }
        }

        public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
        {
            using (DorukanAracContext context = new DorukanAracContext())
            {
                return filter == null
                    ? context.Set<Car>().ToList()
                    : context.Set<Car>().Where(filter).ToList();
            }
        }

        public void Update(Car entity)
        {
            using (DorukanAracContext context = new DorukanAracContext())
            {
                var carToUpdate = context.Cars.SingleOrDefault(c => c.CarId == entity.CarId);
                carToUpdate.BrandId = entity.BrandId;
                carToUpdate.ColorId = entity.ColorId;
                carToUpdate.DailyPrice = entity.DailyPrice;
                carToUpdate.Description = entity.Description;
                carToUpdate.ModelYear = entity.ModelYear;
                context.SaveChanges();
            }
        }
    }
}
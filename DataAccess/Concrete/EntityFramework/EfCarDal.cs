using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarDal : EfEntityRepositoryBase<Car, DorukanAracContext> , ICarDal
    {
        public List<CarDetailDto> GetCarDetails(Expression<Func<Car,bool>> filter =null)
        {
            using (DorukanAracContext context = new DorukanAracContext())
            {
                var result = from c in context.Cars
                             join co in context.Colors
                             on c.ColorId equals co.ColorId
                             join b in context.Brands
                             on c.BrandId equals b.BrandId

            select new CarDetailDto {   CarName = c.CarName,
                                        ColorName = co.ColorName,
                                        BrandName = b.BrandName, 
                                        DailyPrice=c.DailyPrice};

                return result.ToList();
            }
            
        }
	

	}
    }

//var result = from p in context.Products
//                             join c in context.Categories
//                             on p.CategoryId equals c.CategoryId
//                             select new ProductDetailDto {ProductId = p.ProductId, ProductName=p.ProductName,
//                                 CategoryName=c.CategoryName,UnitsInStock=p.UnitsInStock };
//             return result.ToList();
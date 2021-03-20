using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfRentalDal : EfEntityRepositoryBase<Rental, DorukanAracContext>, IRentalDal
    {
        public List<RentDetailDto> GetRentDetails()
        {
            using (DorukanAracContext context = new DorukanAracContext())
            {
                var result = from r in context.Rentals
                             join cu in context.Customers
                             on r.CustomerId equals cu.CustomerId
                             join c in context.Cars
                             on r.CarId equals c.CarId
                             join co in context.Colors
                             on c.ColorId equals co.ColorId
                             join b in context.Brands
                             on c.BrandId equals b.BrandId
                             select new RentDetailDto

                             {  ModelYear = c.ModelYear,
                                 BrandName = b.BrandName,
                                 ColorName = co.ColorName,
                                 CompanyName=cu.CompanyName,
                                  RentDate = r.RentDate,
                                  ReturnDate = r.ReturnDate};

              return result.ToList();
            };
                
            }
        }
    }


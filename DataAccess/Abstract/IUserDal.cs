using Core.DataAccess.EntityFramework;
using Core.Entity.Concrete;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using Core.DataAccess;

namespace DataAccess.Abstract
{
    public interface IUserDal : IEntityRepository<User>
    {
        List<OperationClaim> GetClaims(User user);
    }
}

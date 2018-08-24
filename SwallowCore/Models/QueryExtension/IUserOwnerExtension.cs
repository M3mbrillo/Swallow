using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore;
using SwallowCore.Models.Base;

namespace SwallowCore.Models.QueryExtension
{
    public static class IUserOwnerExtension
    {
        public static IQueryable<TEntity> GetByCurrentUser<TEntity>(this IEnumerable<TEntity> userOwner) 
            where TEntity : IUserOwner
        {
            return userOwner.Where(x => x.UserId == Core.User.Id).AsQueryable();
        }        
    }
}

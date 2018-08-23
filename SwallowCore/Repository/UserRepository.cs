using SwallowCore.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;


namespace SwallowCore.Repository
{
    public class UserRepository
    {
        public SwallowContext Context { get; }

        internal UserRepository(SwallowContext context)
        {
            this.Context = context;
        }

        internal User GetByLogin(string userOrEmail, string password)
        {
            if (string.IsNullOrWhiteSpace(userOrEmail))
            {
                throw new SwallowCoreException("User or Email is Empty");
            }

            if (string.IsNullOrWhiteSpace(password))
            {
                throw new SwallowCoreException("Password is Empty");
            }

            var qryUser = from u in this.Context.User
                          where
                               u.Password == password &&
                               (
                                   u.UserName == userOrEmail ||
                                   u.Email == userOrEmail
                               )
                          select u;

            return qryUser.FirstOrDefault();            
        }        
    }
}

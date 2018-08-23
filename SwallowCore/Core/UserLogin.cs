using System;
using System.Collections.Generic;
using System.Text;

namespace SwallowCore.Core
{
    public class UserLogin
    {
        public Models.User User { get; set; }

        public bool IsLogged => this.User != null;

        public bool Login(string userOrEmail, string password)
        {
            using (var repoBuilder = new Repository.RepositoryBuilder())
            {
                var userRepo = repoBuilder.BuildUserRepository();

                this.User = userRepo.GetByLogin(userOrEmail, password);
            }

            return this.IsLogged;
        }

    }
}

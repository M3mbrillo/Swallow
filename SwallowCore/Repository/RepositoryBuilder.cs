using SwallowCore.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SwallowCore.Repository
{
    public class RepositoryBuilder : IDisposable
    {
        public SwallowContext Context { get; }

        public RepositoryBuilder()
        {
            this.Context = new SwallowContext();
        }

        public UserRepository BuildUserRepository() => new UserRepository(this.Context);

        public void Dispose()
        {
            this.Context.Dispose();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace SwallowCore.Models
{
    public partial class SwallowContext
    {
        public override int SaveChanges()
        {
            this.ChangeTracker.Entries();

            // TODO if implent a interface custom save/change

            return base.SaveChanges();
        }
    }
}

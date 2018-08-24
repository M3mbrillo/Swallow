using System;
using System.Collections.Generic;
using System.Text;

using SwallowCore.Models.QueryExtension;

namespace SwallowCore.Repository
{
    public class TravelRepository
    {
        SwallowCore.Models.SwallowContext context { get; }

        public TravelRepository(SwallowCore.Models.SwallowContext context)
        {
            this.context = context;

            this.context.Travel.GetByCurrentUser();
        }
    }
}

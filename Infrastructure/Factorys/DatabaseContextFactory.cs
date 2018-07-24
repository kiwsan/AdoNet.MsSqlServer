using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Infrastructure.Factorys
{
    public class DatabaseContextFactory : IDatabaseContextFactory
    {
        private IDatabaseContext dataContext;

        public IDatabaseContext Context()
        {
            return dataContext ?? (dataContext = new DatabaseContext());
        }

        public void Dispose()
        {
            if (dataContext != null)
                dataContext.Dispose();
        }
    }
}

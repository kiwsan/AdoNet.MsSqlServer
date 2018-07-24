using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace Infrastructure.Uow
{
    public interface IUnitOfWork
    {

        IDatabaseContext DataContext { get; }
        SqlTransaction BeginTransaction();

        void Commit();

    }
}

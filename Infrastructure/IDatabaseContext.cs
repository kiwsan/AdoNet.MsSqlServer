using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace Infrastructure
{
    public interface IDatabaseContext
    {

        SqlConnection Connection { get; }
        void Dispose();

    }
}

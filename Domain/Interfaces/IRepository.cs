using Domain.Core.Domain;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace Domain.Interfaces
{
    public interface IRepository<T> where T : Entity, IAggregateRoot
    {
        int Insert(T entity, string insertSql, SqlTransaction sqlTransaction);
        int Update(T entity, string updateSql, SqlTransaction sqlTransaction);
        int Delete(int id, string deleteSql, SqlTransaction sqlTransaction);
        T GetById(int id, string getByIdSql);
        IEnumerable<T> GetAll(string getAllSql);
    }
}

using Domain;
using Domain.Core.Domain;
using Domain.Interfaces;
using Infrastructure.Uow;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace Infrastructure.Repositorys
{
    public abstract class BaseRepository<T> : IRepository<T> where T : Entity, IAggregateRoot, new()
    {
        private SqlConnection _conn;
        protected readonly IUnitOfWork _uow;

        public BaseRepository(IUnitOfWork uow)
        {
            if (uow == null) throw new ArgumentNullException("unitOfWork");
            _uow = uow;
            _conn = _uow.DataContext.Connection;
        }

        public int Insert(T entity, string insertSql, SqlTransaction sqlTransaction)
        {
            int i = 0;
            try
            {
                using (var cmd = _conn.CreateCommand())
                {
                    cmd.CommandText = insertSql;
                    cmd.CommandType = CommandType.Text;
                    cmd.Transaction = sqlTransaction;
                    InsertCommandParameters(entity, cmd);
                    i = cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return i;
        }

        public int Update(T entity, string updateSql, SqlTransaction sqlTransaction)
        {
            int i = 0;
            using (var cmd = _conn.CreateCommand())
            {
                cmd.CommandText = updateSql;
                cmd.CommandType = CommandType.Text;
                cmd.Transaction = sqlTransaction;
                UpdateCommandParameters(entity, cmd);
                i = cmd.ExecuteNonQuery();
            }
            return i;
        }

        public int Delete(int id, string deleteSql, SqlTransaction sqlTransaction)
        {
            int i = 0;
            using (var cmd = _conn.CreateCommand())
            {
                cmd.CommandText = deleteSql;
                cmd.CommandType = CommandType.Text;
                cmd.Transaction = sqlTransaction;
                DeleteCommandParameters(id, cmd);
                i = cmd.ExecuteNonQuery();
            }
            return i;
        }

        public T GetById(int id, string getByIdSql)
        {
            using (var cmd = _conn.CreateCommand())
            {
                cmd.CommandText = getByIdSql;
                cmd.CommandType = CommandType.Text;
                GetByIdCommandParameters(id, cmd);
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    return Map(reader);
                }

            }
        }

        public IEnumerable<T> GetAll(string getAllSql)
        {
            using (var cmd = _conn.CreateCommand())
            {
                cmd.CommandText = getAllSql;
                cmd.CommandType = CommandType.Text;
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    return Maps(reader);
                }
            }
        }

        protected abstract void InsertCommandParameters(T entity, SqlCommand cmd);
        protected abstract void UpdateCommandParameters(T entity, SqlCommand cmd);
        protected abstract void DeleteCommandParameters(int id, SqlCommand cmd);
        protected abstract void GetByIdCommandParameters(int id, SqlCommand cmd);
        protected abstract T Map(SqlDataReader reader);
        protected abstract List<T> Maps(SqlDataReader reader);

    }
}

using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using Npgsql;
using Otus.Crud.Options;

namespace Otus.Crud.Infrastructure
{
    public interface IQueryService<TEntity>
    {
        Task<TEntity> Get(string sql, object queryParams);

        Task<IEnumerable<TEntity>> GetAll(string sql);
        
        Task<IEnumerable<TEntity>> GetAll(string sql, object queryParams);
    }
    
    public class QueryService<TEntity> : IQueryService<TEntity>
    {
        private readonly DbOptions _dbOptions;

        public QueryService(DbOptions dbOptions)
        {
            _dbOptions = dbOptions;
        }

        public async Task<TEntity> Get(string sql, object queryParams)
        {
            await using var db = new NpgsqlConnection(_dbOptions.ConnectionString);
            
            return db.Query<TEntity>(sql, queryParams).FirstOrDefault();
        }
        
        public async Task<IEnumerable<TEntity>> GetAll(string sql)
        {
            return await GetAll(sql, null);
        }        
        
        public async Task<IEnumerable<TEntity>> GetAll(string sql, object queryParams)
        {
            await using var db = new NpgsqlConnection(_dbOptions.ConnectionString);
            
            return db.Query<TEntity>(sql, queryParams);
        }
    }
}
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using Npgsql;
using Otus.Crud.Options;

namespace Otus.Crud.Infrastructure
{
    public interface IDeleteService<TEntity>
    {
        Task Delete(string sql, object queryParams);
    }
    
    public class DeleteService<TEntity> : IDeleteService<TEntity>
    {
        private readonly DbOptions _dbOptions;

        public DeleteService(DbOptions dbOptions)
        {
            _dbOptions = dbOptions;
        }
        
        public async Task Delete(string sql, object queryParams)
        {
            await using var db = new NpgsqlConnection(_dbOptions.ConnectionString);
            
            await db.ExecuteAsync(sql, queryParams);
        }
    }
}
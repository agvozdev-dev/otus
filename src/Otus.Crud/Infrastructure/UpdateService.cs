using System.Threading.Tasks;
using Dapper;
using Npgsql;
using Otus.Crud.Options;

namespace Otus.Crud.Infrastructure
{
    public interface IUpdateService<TEntity>
    {
        Task Update(string sql, TEntity entity);
    }
    
    public class UpdateService<TEntity> : IUpdateService<TEntity>
    {
        private readonly DbOptions _dbOptions;

        public UpdateService(DbOptions dbOptions)
        {
            _dbOptions = dbOptions;
        }
        
        public async Task Update(string sql, TEntity entity)
        {
            await using var db = new NpgsqlConnection(_dbOptions.ConnectionString);

            await db.ExecuteAsync(sql, entity);
        }
    }
}
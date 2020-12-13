using System.Threading.Tasks;
using Dapper;
using Npgsql;
using Otus.Crud.Options;

namespace Otus.Crud.Infrastructure
{
    public interface ICreateService<TEntity>
    {
        Task Create(string sql, TEntity entity);
    }
    
    public class CreateService<TEntity> : ICreateService<TEntity>
    {
        private readonly DbOptions _dbOptions;

        public CreateService(DbOptions dbOptions)
        {
            _dbOptions = dbOptions;
        }

        public async Task Create(string sql, TEntity entity)
        {
            await using var db = new NpgsqlConnection(_dbOptions.ConnectionString);

            await db.ExecuteAsync(sql, entity);
        }
    }
}
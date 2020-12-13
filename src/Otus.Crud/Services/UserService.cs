using System;
using System.Threading.Tasks;
using Otus.Crud.Entities;
using Otus.Crud.Infrastructure;
#pragma warning disable 414

namespace Otus.Crud.Services
{
    public interface IUserService
    {
        Task<User> Get(Guid userId);

        Task Create(User user);

        Task Update(User user);

        Task Delete(Guid userId);
    }

    public class UserService : IUserService
    {
        private static readonly string _tableName = nameof(User);
        
        private readonly IQueryService<User>  _userQueryService;
        private readonly ICreateService<User> _userCreateService;
        private readonly IUpdateService<User> _userUpdateService;
        private readonly IDeleteService<User> _userDeleteService;

        public UserService(
            IQueryService<User>  userQueryService,
            ICreateService<User> userCreateService,
            IUpdateService<User> userUpdateService,
            IDeleteService<User> userDeleteService)
        {
            _userQueryService  = userQueryService;
            _userCreateService = userCreateService;
            _userUpdateService = userUpdateService;
            _userDeleteService = userDeleteService;
        }

        public Task<User> Get(Guid userId)
        {
            var sql = $"SELECT * FROM \"{_tableName}\" where \"Id\"=@userId";

            return _userQueryService.Get(sql, new { userId });
        }

        public Task Create(User user)
        {
            user.Id         = Guid.NewGuid();
            user.CreateDate = DateTime.UtcNow;

            var sql = $"INSERT INTO \"{_tableName}\" " +
                      "(\"Id\", \"FirstName\", \"LastName\", \"Patronymic\", \"CreateDate\") " +
                      "VALUES(@Id, @FirstName, @LastName, @Patronymic, @CreateDate)";

            return _userCreateService.Create(sql, user);
        }

        public Task Update(User user)
        {
            var sql = $"UPDATE \"{_tableName}\" " +
                      $"SET \"FirstName\"=@FirstName, \"LastName\"=@LastName, \"Patronymic\"=@Patronymic " +
                      $"WHERE \"Id\" = @Id";

            return _userUpdateService.Update(sql, user);
        }

        public Task Delete(Guid userId)
        {
            var sql = $"DELETE FROM \"{_tableName}\" WHERE \"Id\" = @userId";

            return _userDeleteService.Delete(sql, new { userId });
        }
    }
}
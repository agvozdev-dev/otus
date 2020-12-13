using System;

namespace Otus.Crud.Entities
{
    /// <summary>Пользователь</summary>
    public class User
    {
        /// <summary>Идентификатор</summary>
        public Guid Id { get; set; }

        /// <summary>Имя</summary>
        public string FirstName { get; set; }

        /// <summary>Фамилия</summary>
        public string LastName { get; set; }
        
        /// <summary>Отчество</summary>
        public string Patronymic { get; set; }

        /// <summary>Дата создания</summary>
        public DateTime CreateDate { get; set; }
    }
}
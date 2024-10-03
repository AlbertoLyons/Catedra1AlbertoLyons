using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Catedra1AlbertoLyons.src.models;

namespace Catedra1AlbertoLyons.src.interfaces
{
    public interface IUserRepository
    {
        Task<bool> ExistsByRut(string rut);
        Task<bool> ExistsById(int id);
        Task<bool> AddUserAsync(User user);
        Task<IEnumerable<User>> GetAllAsync();
        Task<User> GetById(int id);
        Task<IEnumerable<User>> GetAscSorted();
        Task<IEnumerable<User>> GetDescSorted();
        Task<IEnumerable<User>> GetByGender(string gender);
        Task<bool> EditUserAsync(int id, User user);
        Task<bool> DeleteUserAsync(User user);
    }
}
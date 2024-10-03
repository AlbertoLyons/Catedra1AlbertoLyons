using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Catedra1AlbertoLyons.src.data;
using Catedra1AlbertoLyons.src.interfaces;
using Catedra1AlbertoLyons.src.models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;

namespace Catedra1AlbertoLyons.src.repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly DataContext _dataContext;
        public UserRepository(DataContext dataContext) 
        {
            _dataContext = dataContext;
        }
        public async Task<bool> AddUserAsync(User user)
        {
            _dataContext.Users.Add(user);
            await _dataContext.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteUserAsync(User user)
        {
            if (await ExistsByRut(user.Rut)) 
            {
                _dataContext.Users.Remove(user);
                return true;
            }
            return false;
        }

        public async Task<bool> EditUserAsync(int id, User user)
        {
            var existingUser = await _dataContext.Users.FirstOrDefaultAsync(u => u.Id == id);

            existingUser.Rut = user.Rut;
            existingUser.Name = user.Name;
            existingUser.Email = user.Email;
            existingUser.Gender = user.Gender;
            existingUser.Birthdate = user.Birthdate;
            
            _dataContext.Users.Update(existingUser);
            await _dataContext.SaveChangesAsync();
            return true;
        }

        public async Task<bool> ExistsByRut(string rut)
        {
            return await _dataContext.Users.AnyAsync(p => p.Rut == rut);
        }
        public async Task<bool> ExistsById(int id)
        {
            return await _dataContext.Users.AnyAsync(p => p.Id == id);
        }

        public async Task<IEnumerable<User>> GetAllAsync()
        {
            return await _dataContext.Users.ToListAsync();
        }

        public async Task<IEnumerable<User>> GetAscSorted()
        {
            return await _dataContext.Users.OrderBy(p => p.Name).ToListAsync();
        }
        public async Task<IEnumerable<User>> GetDescSorted()
        {
            return await _dataContext.Users.OrderByDescending(p => p.Name).ToListAsync();
        }

        public async Task<IEnumerable<User>> GetByGender(string gender)
        {
            if (gender == null) throw new ArgumentNullException(nameof(gender));
            return await _dataContext.Users.Where(p => p.Gender == gender).ToListAsync();
        }
    }
}
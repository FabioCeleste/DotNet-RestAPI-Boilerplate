using Boilerplate.Application.Interfaces;
using Boilerplate.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Boilerplate.Persistence.Interfaces;

namespace Boilerplate.Application
{
    public class UserService : IUserService
    {
        private readonly IGeralPersist _geralPersist;
        private readonly IUserPersist _userPersist;
        public UserService(IGeralPersist geralPersist, IUserPersist userPersist)
        {
            _geralPersist = geralPersist;
            _userPersist = userPersist;
        }
        public async Task<User> AddUser(User model)
        {
            try
            {
                _geralPersist.Add<User>(model);
                if(await _geralPersist.SaveChangeAsync())
                {
                    return await _userPersist.GetUserByIdAsync(model.Id);
                }
                return null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<User> UpdateUser(User model, int userId)
        {
            try
            {
                var user = await _userPersist.GetUserByIdAsync(userId);
                if (user == null) return null;

                model.Id = user.Id;

                _geralPersist.Update(model);

                if (await _geralPersist.SaveChangeAsync())
                {
                    return await _userPersist.GetUserByIdAsync(model.Id);
                }
                return null;


            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> DeleteUser(int userId)
        {
            try
            {
                var user = await _userPersist.GetUserByIdAsync(userId);
                if (user == null) return false;

                _geralPersist.Delete(user);

                return await _geralPersist.SaveChangeAsync();

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<User[]> GetAllUserAsync()
        {
            try
            {
                var users = await _userPersist.GetAllUserAsync();
                if (users == null) return null;

                return users;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<User> GetUserByNameAsync(string username)
        {
            try
            {
                var user = await _userPersist.GetUserByNameAsync(username);
                if (user == null) return null;

                return user;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<User> GetUserByIdAsync(int id)
        {
            try
            {
                var user = await _userPersist.GetUserByIdAsync(id);
                if (user == null) return null;

                return user;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

    }
}

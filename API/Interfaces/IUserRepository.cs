using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.DTOs;
using API.Entities;

namespace API.Interfaces
{
    public interface IUserRepository
    {
        void Update(AppUser user);
        Task<bool> SaveAllAsync();
        Task<AppUser?> GetUserByIdAysnc(int Id);
        Task<AppUser?> GetUserByUsernameAsync(string username);
        Task<IEnumerable<AppUser>> GetUsersAsync();
        Task<MemberDTO?> GetMemberAsync(string username);
        Task<IEnumerable<MemberDTO>> GetMembersAsync();
    }
}
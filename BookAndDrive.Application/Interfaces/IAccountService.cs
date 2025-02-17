using BookAndDrive.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookAndDrive.Application.Interfaces
{
    public interface IAccountService
    {
        Task<bool> RegisterUserAsync(RegisterUserDTO userDTO);
        Task<string> LoginUserAsync(LoginUserDTO userDTO);
    }
}

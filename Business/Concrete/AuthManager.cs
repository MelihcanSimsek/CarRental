using Business.Abstract;
using Business.Constants;
using Core.Entities.Concrete;
using Core.Utilities.Results;
using Core.Utilities.Security.Hashing;
using Core.Utilities.Security.Jwt;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class AuthManager : IAuthService
    {
        IUserService _userService;
        ITokenHelper _tokenHelper;
        public AuthManager(IUserService userService, ITokenHelper tokenHelper)
        {
            _userService = userService;
            _tokenHelper = tokenHelper;
        }
        public IDataResult<AccessToken> CreateAccessToken(User user)
        {
            var claims = _userService.GetClaims(user);
            var accesToken = _tokenHelper.CreateToken(user, claims.Data);
            return new SuccessDataResult<AccessToken>(accesToken, Message.AccessTokenCreated);
        }

        public IDataResult<User> Login(UserForLoginDto userForLoginDto)
        {
            var userToCheck = _userService.GetByEmail(userForLoginDto.Email).Data;
            if (userToCheck == null)
            {
                return new ErrorDataResult<User>(Message.UserNotFound);
            }
            if (!HashingHelper.VerifyPasswordHash(userForLoginDto.Password, userToCheck.PasswordHash, userToCheck.PasswordSalt))
            {
                return new ErrorDataResult<User>(Message.PasswordError);
            }
            return new SuccessDataResult<User>(userToCheck, Message.SuccessLogin);

        }

        public IDataResult<User> Register(UserForRegisterDto userForRegisterDto)
        {
            byte[] passwordHash, passwordSalt;
            HashingHelper.CreatePasswordHash(userForRegisterDto.Password, out passwordHash, out passwordSalt);
            var user = new User
            {
                Email = userForRegisterDto.Email,
                FirstName = userForRegisterDto.FirstName,
                LastName = userForRegisterDto.LastName,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt,
                Status = true
            };
            _userService.Add(user);
            return new SuccessDataResult<User>(user, Message.UserRegistered);
        }

        public IDataResult<User> UpdateUserInformation(UserForUpdateDto userForUpdateDto)
        {
           
            var userToCheck = _userService.GetById(userForUpdateDto.Id).Data;
            if(!HashingHelper.VerifyPasswordHash(userForUpdateDto.CurrentPassword,userToCheck.PasswordHash,userToCheck.PasswordSalt))
            {
                return new ErrorDataResult<User>(Message.PasswordError);
            }

            if(userForUpdateDto.NewPassword.Length > 0)
            {
               return UpdateInformationWithPassword(userForUpdateDto, userToCheck);
            }
            else
            {
               return UpdateInformation(userForUpdateDto, userToCheck);
            }
        }

    

        public IResult UserExists(string email)
        {
            if (_userService.GetByEmail(email).Data != null)
            {
                return new SuccessResult(Message.UserAlreadyExists);
            }
            return new ErrorResult();
        }

        private IDataResult<User> UpdateInformationWithPassword(UserForUpdateDto userForUpdateDto,User user)
        {
            byte[] passwordHash, passwordSalt;
           if(user.Email != userForUpdateDto.Email)
            {
                var userToCheck = _userService.GetByEmail(userForUpdateDto.Email).Data;
                if(userToCheck != null)
                {
                    return new ErrorDataResult<User>(Message.UserAlreadyExists);
                }
            }
            HashingHelper.CreatePasswordHash(userForUpdateDto.NewPassword, out passwordHash, out passwordSalt);
            var userModel = new User
            {
                Email = userForUpdateDto.Email,
                FirstName = userForUpdateDto.FirstName,
                LastName = userForUpdateDto.LastName,
                Id = userForUpdateDto.Id,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt,
                Status = userForUpdateDto.Status,
            };
            _userService.Update(userModel);
            return new SuccessDataResult<User>(userModel, Message.UserUpdated);
        }

        private IDataResult<User> UpdateInformation(UserForUpdateDto userForUpdateDto, User user)
        {
            if(user.Email != userForUpdateDto.Email)
            {
                var userToCheck = _userService.GetByEmail(userForUpdateDto.Email).Data;
                if(userToCheck != null)
                {
                    return new ErrorDataResult<User>(Message.UserAlreadyExists);
                }
            }
            var userModel = new User
            {

                Email = userForUpdateDto.Email,
                FirstName = userForUpdateDto.FirstName,
                Id = userForUpdateDto.Id,
                LastName = userForUpdateDto.LastName,
                PasswordHash = user.PasswordHash,
                PasswordSalt = user.PasswordSalt,
                Status = userForUpdateDto.Status
            };
            _userService.Update(userModel);
            return new SuccessDataResult<User>(userModel, Message.UserUpdated);
        }
    }
}


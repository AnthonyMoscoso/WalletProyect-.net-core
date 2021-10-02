using AutoMapper;
using Business.DataServices.Abstracts;
using Core.DataServices.Specifics;
using Core.Entities.Utilities.Email;
using Core.Entities.Utilities.Encrypt;
using Core.Repository.Abstracts;
using Entities.DbModels.EF;
using Entities.Dto;
using Entities.Dto.Utilities;
using FluentValidation;
using Infra.DataAccess.Abstracts;
using Infra.SMTP.Resources.Bodies;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace Business.DataServices.Specifics
{
    public class UserService : DataBaseService<UserDto, Users>, IUserService
    {
        protected new IUserRepository _repository;
        protected IEmailManager _emailManager;

        public UserService(IUserRepository repository, IMapper mapper, IValidator<UserDto> validador, IEncrypterProfile<UserDto> encryptor,IEmailManager emailManager) : base(repository, mapper, validador, encryptor)
        {
            _repository = repository;
            _emailManager = emailManager;
        }

        public bool CanRestart(string code)
        {
            throw new NotImplementedException();
        }

        public string ForgetPassword(string email)
        {
            UserDto userDto = new UserDto()
            {
                Email = email
            };

            UserDto encrypter = _encryptor.EncryptEntity(userDto);
            Users search = _repository.GetSingle(w => w.Email.Equals(encrypter.Email));
            if (search!= null)
            {

                string code = Guid.NewGuid().ToString().Replace("-","").Substring(0,8);
                _emailManager.SendEmailTo(email, email,"Forget password" , ForgotPassBody.ForgetBody(code), email);
                return code;
            }
            return "NotFound email";
        }

        public override string GetNewId(UserDto entity)
        {
            int last_id =_repository.GetLastProperty(w => w.IdUser);       
            last_id++;
            return last_id.ToString();
        }

        public UserDto Login(LoginRequest loginDto)
        {
            UserDto user = new UserDto()
            {
                Password = loginDto.Password,
                Email = loginDto.Email
            };
            UserDto search = _encryptor.EncryptEntity(user);
            Users users = _repository.GetSingle(w => w.Email.Equals(search.Email) && w.Password.Equals(search.Password));
            return _encryptor.DecryptEntity(_mapper.Map<UserDto>(users));
        }

        public UserDto Register(UserDto userDto)
        {
            return Insert(userDto);
        }

        public string RestartPassword(LoginRequest loginDto)
        {
            throw new NotImplementedException();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using FloAPI.Data;
using FloAPI.Dto;
using FloAPI.Entities;
using FloAPI.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FloAPI.Controllers
{
    [Authorize]
    public class UsersController : BaseApiController
    {
        private readonly IUserRepository _userRepo;
        private readonly IMapper _mapper;

        public UsersController(IUserRepository userRepo, IMapper mapper)
        {
            _userRepo = userRepo;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<MemberDto>>> GetUsers()
        {
            //var users = await _userRepo.GetUsersAsync();
            //return Ok(_mapper.Map<IEnumerable<MemberDto>>(users));
            return Ok(await _userRepo.GetMembersDtoAsync());
        }

        [HttpGet("{username}")]
        public async Task<ActionResult<MemberDto>> GetUserByUserName(string username)
        {
            //var user = await _userRepo.GetUserByUsernameAsync(username);
            //return _mapper.Map<MemberDto>(user);
            return await _userRepo.GetMemberDtoAsync(username);
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<MemberDto>> GetUserByUserId(int id)
        {
            var user = await _userRepo.GetUserByIdAsync(id);
            return _mapper.Map<MemberDto>(user);
        }

        [HttpPost("updateuser")]
        public void  UpdateUser(AppUser user)
        {

        }
    }
}

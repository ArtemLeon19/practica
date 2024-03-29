﻿using Domain.Interfaces;
using BusinessLogic.Services;
using Domain.SQL;
using Microsoft.AspNetCore.Mvc;
using Lab2.Contracts.User;
using Mapster;

namespace BackendApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }
        /// <summary>
        ///Просмотр записей в бд
        /// </summary>
        // POST api/<UsersController>
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _userService.GetAll());
        }


        /// <summary>
        ///Просмотр записи по id
        /// </summary>
        // POST api/<UsersController>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _userService.GetById(id);
            var response = new GetUserResponse()
            {
                Id = result.Id,
                Name = result.Name,
                Email = result.Email,
                Card = result.Card,
                PhoneNumber = result.PhoneNumber,
                Role = result.Role,
                Password = result.Password,
                IsDeleted = false,

            };
            return Ok(await _userService.GetById(id));
        }
        /// <summary>
        /// Создание нового пользователя
        /// </summary>
        /// <remarks>
        /// Пример запроса:
        ///
        ///     POST /Todo
        ///     {
        ///         Name = "Влад",
        ///         Email = "А4@gmail.com",
        ///         Card = "78749274",
        ///         PhoneNumber = "89999685146",
        ///         Role = "User",
        ///         Password = "qwerty12345",
        ///     }
        ///
        /// </remarks>
        /// <param name="model">Пользователь</param>
        /// <returns></returns>

        // POST api/<UsersController>
        [HttpPost]
        public async Task<IActionResult> Add(CreateUserRequest request)
        {
            var userDto = request.Adapt<User>();
            await _userService.Create(userDto);
            return Ok();
        }
        /// <summary>
        /// Создание нового пользователя
        /// </summary>
        /// <remarks>
        /// Пример запроса:
        ///
        ///     PUT /Todo
        ///     {
        ///         id = 1,
        ///         Name = "Влад",
        ///         Email = "А4@gmail.com",
        ///         Card = "78749274",
        ///         PhoneNumber = "89999685146",
        ///         Role = "User",
        ///         Password = "qwerty12345",
        ///         isDeleted = false
        ///     }
        ///
        /// </remarks>
        /// <param name="model">Пользователь</param>
        /// <returns></returns>

        // PUT api/<UsersController>
        [HttpPut]
        public async Task<IActionResult> Update(GetUserResponse request)
        {
            var user = request.Adapt<User>();
            await _userService.Update(user);
            return Ok();
        }
        /// <summary>
        ///удаление записи по id
        /// </summary>
        // POST api/<UsersController>
        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            await _userService.Delete(id);
            return Ok();
        }
    }
}
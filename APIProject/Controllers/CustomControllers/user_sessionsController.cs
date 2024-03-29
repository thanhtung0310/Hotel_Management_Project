﻿using BusinessLayer.IService;
using Entity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Primitives;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIProject.Controllers.CustomControllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class user_sessionsController : ControllerBase
  {
    private readonly IUserSessionService _userSessionService;
    public user_sessionsController(IUserSessionService userSessionService)
    {
      _userSessionService = userSessionService;
    }

    /// <summary>
    /// Get a list of all users
    /// </summary>
    /// <returns></returns>
    // GET: api/<user_sessionsController>
    [HttpGet]
    public async Task<Response<List<UserSession>>> GetUserSessions()
    {
      return await _userSessionService.GetUserSessions();
    }

    /// <summary>
    /// Get a list of all users
    /// </summary>
    /// <param name="acc_username"></param>
    /// <returns></returns>
    // GET: api/<user_sessionsController>
    [HttpGet("{acc_username}")]
    public async Task<Response<UserSession>> GetUserSession(string acc_username)
    {
      return await _userSessionService.GetUserSession(acc_username);
    }

    /// <summary>
    /// Get user
    /// </summary>
    /// <param name="user"></param>
    /// <returns></returns>
    // POST: api/<user_sessionsController>/login
    [HttpPost("login")]
    public async Task<Response<UserSession>> Login([FromBody] UserSession user)
    {
      return await _userSessionService.Login(user);
    }

    /// <summary>
    /// clear user session
    /// </summary>
    /// <param name="acc_username"></param>
    /// <returns></returns>
    // GET: api/<user_sessionsController>/logout/thanhtung
    [HttpGet("logout/{acc_username}")]
    public async Task<Response<UserSession>> Logout(string acc_username)
    {
      return await _userSessionService.Logout(acc_username);
    }

    /// <summary>
    /// Update user's information
    /// </summary>
    /// <param name="newData"></param>
    /// <returns></returns>
    // PUT api/<user_sessionsController>
    [HttpPut("info")]
    public async Task<Response<UserSession>> UpdateUser([FromBody] UserSession newData)
    {
      return await _userSessionService.UpdateUser(newData);
    }

    /// <summary>
    /// Update user
    /// </summary>
    /// <param name="newData"></param>
    /// <returns></returns>
    // PUT api/<user_sessionsController>
    [HttpPut("pwd")]
    public async Task<Response<UserSession>> UpdatePassword([FromBody] UserSession newData)
    {
      return await _userSessionService.UpdatePassword(newData);
    }

    /// <summary>
    /// Update user
    /// </summary>
    /// <param name="newData"></param>
    /// <returns></returns>
    // PUT api/<user_sessionsController>
    [HttpPut("start")]
    public async Task<Response<UserSession>> StartSession([FromBody] UserSession newData)
    {
      return await _userSessionService.StartSession(newData);
    }

  }
}

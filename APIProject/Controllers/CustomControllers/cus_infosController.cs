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
  public class cus_infosController : ControllerBase
  {
    private readonly ICusInfoService _cusInfoService;
    public cus_infosController(ICusInfoService cusInfoService)
    {
      _cusInfoService = cusInfoService;
    }

    /// <summary>
    /// Get a list of all customers
    /// </summary>
    /// <returns></returns>
    // GET: api/<cus_infosController>
    [HttpGet]
    public async Task<Response<List<cus_info>>> GetCustomerList()
    {
      return await _cusInfoService.GetCustomerList();
    }

    // <summary>
    /// Get a list of all checked-in customers
    /// </summary>
    /// <returns></returns>
    // GET: api/<cus_infosController>/checked_in
    [HttpGet("checked_in")]
    public async Task<Response<List<checked_cus_info>>> GetCheckedinCusList()
    {
      return await _cusInfoService.GetCheckedinCusList();
    }

    /// <summary>
    /// Get customer's information by customer ID
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    // GET api/<cus_infosController>/5
    [HttpGet("{id}")]
    public async Task<Response<cus_info>> GetCustomerByID(int id)
    {
      return await _cusInfoService.GetCustomerByID(id);
    }

    /// <summary>
    /// Get new customer ID
    /// </summary>
    /// <returns></returns>
    // GET api/<cus_infosController>/5
    [HttpGet("customer_id")]
    public async Task<Response<cus_info>> GetID()
    {
      return await _cusInfoService.GetID();
    }

    /// <summary>
    /// Create new customer
    /// </summary>
    /// <param name="cus"></param>
    /// <returns></returns>
    // POST api/<cus_infosController>
    [HttpPost]
    public async Task<Response<cus_info>> CreateCustomer([FromBody] cus_info cus)
    {
      return await _cusInfoService.CreateCustomer(cus);
    }

    /// <summary>
    /// Update customer
    /// </summary>
    /// <param name="cus"></param>
    /// <returns></returns>
    // PUT api/<cus_infosController>
    [HttpPut]
    public async Task<Response<cus_info>> UpdateCustomer([FromBody] cus_info cus)
    {
      return await _cusInfoService.UpdateCustomer(cus);
    }

    /// <summary>
    /// Delete customer's information by customer ID
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    // DELETE api/<cus_infosController>/5
    [HttpDelete("{id}")]
    public async Task<Response<cus_info>> DeleteCustomerByID(int id)
    {

      return await _cusInfoService.DeleteCustomerByID(id);
    }

    /// <summary>
    /// Get customer who has booked room by their contact number
    /// </summary>
    /// <returns></returns>
    // GET api/<cus_infosController>/booked
    [HttpGet("booked")]
    public async Task<Response<List<booked_cus_info>>> GetBookedCustomerList()
    {
      return await _cusInfoService.GetBookedCustomerList();
    }

    /// <summary>
    /// Get customer who has booked room by their contact number
    /// </summary>
    /// <param name="num"></param>
    /// <returns></returns>
    // GET api/<cus_infosController>/booked/num/0123456786
    [HttpGet("booked/num/{num}")]
    public async Task<Response<booked_cus_info>> GetBookedCustomerByNum(string num)
    {
      return await _cusInfoService.GetBookedCustomerByNum(num);
    }

    /// <summary>
    /// Get customer's information by their contact number
    /// </summary>
    /// <param name="num"></param>
    /// <returns></returns>
    // GET api/<cus_by_num_infosController>/num/0123456789
    [HttpGet("num/{num}")]
    public async Task<Response<cus_info>> GetCustomerByNum(string num)
    {
      return await _cusInfoService.GetCustomerByNum(num);
    }
  }
}

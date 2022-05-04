﻿using BusinessLayer.Extentions;
using BusinessLayer.IService;
using Dapper;
using DataLayer;
using Entity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Service
{
    class BookedRoomInfoService : BaseController<booked_room_info>, IBookedRoomInfoService
    {
        private readonly IDbConnection _provider;
        public BookedRoomInfoService(IDbConnection provider) : base()
        {
            _provider = provider;
        }
        public async Task<Response<booked_room_info>> GetBookedRoomByID(int id)
        {
            var response = new Response<booked_room_info>();
            try
            {
                _provider.Open();
                DynamicParameters param = new DynamicParameters()
                    .AddParam("@id", id);
                var cusInfo = await _provider.QueryFirstOrDefaultAsync<booked_room_info>("reservation_room_get", param, commandType: CommandType.StoredProcedure);
                response.Data = cusInfo;
                response.successResp();
            }
            finally
            {
                _provider.Close();
            }
            return response;
        }
    }
}
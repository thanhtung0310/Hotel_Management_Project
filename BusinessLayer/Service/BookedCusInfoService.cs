using BusinessLayer.Extentions;
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
    public class BookedCusInfoService: BaseController<booked_cus_info>, IBookedCusInfoService
    {
        private readonly IDbConnection _provider;
        public BookedCusInfoService(IDbConnection provider) : base()
        {
            _provider = provider;
        }
        public async Task<Response<booked_cus_info>> GetBookedCustomerByNum(string num)
        {
            var response = new Response<booked_cus_info>();
            try
            {
                _provider.Open();
                DynamicParameters param = new DynamicParameters()
                    .AddParam("@num", num);
                var cusInfo = await _provider.QueryFirstOrDefaultAsync<booked_cus_info>("customer_reserv_room_by_contact_number", param, commandType: CommandType.StoredProcedure);
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

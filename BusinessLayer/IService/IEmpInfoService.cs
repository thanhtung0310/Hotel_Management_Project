﻿using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.IService
{
    public interface IEmpInfoService
    {
        Task<Response<List<emp_info>>> GetEmployeeList();
        Task<Response<emp_info>> GetEmployeeByID(int? id);
        // Task<Response<List<emp_info>>> CreateEmployee(emp_info emp);
    }
}

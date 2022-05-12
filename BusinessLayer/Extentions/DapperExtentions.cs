using Dapper;
using Microsoft.Extensions.Primitives;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Extentions
{
  public static class DapperExtentions
  {
    public static DynamicParameters AddParam(this DynamicParameters dynamicParameter, string paramName, object value, DbType? dbType = null, ParameterDirection? direction = null, int? size = null, byte? precision = null, byte? scale = null)
    {
      if (dynamicParameter == null)
      {
        throw new Exception("Unable to detect DynamicParameters.");
      }

      dynamicParameter.Add(paramName, value, dbType, direction, size, precision, scale);

      return dynamicParameter;
    }
  }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManager.Infra.Data.Enums
{
    public enum StatusCodeEnum
    {
        Ok = 200,
        BadRequest = 400,
        NotFound = 404,
        InternalServerError = 500
    }    
}

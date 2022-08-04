using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace People.Management.Framework.DTOs.Validation
{
    public class ValidationResultDTO<T>
    {
        public ValidationProblemDetails ValidationProblemDetails { get; set; }

        public T Response { get; set; }

        public T[] ListResponse { get; set; }
    }
}

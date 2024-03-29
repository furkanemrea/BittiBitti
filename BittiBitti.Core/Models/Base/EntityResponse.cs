﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BittiBitti.Core.Models.Base
{
    public class EntityResponse<T>
    {
        public T Data { get; set; }
        public string Code { get; set; }
        public string Message { get; set; }
        public void Success(T data)
        {
            this.Code = ResponseCodes.Success;
            this.Data = data;
        }
        public override string ToString() => JsonConvert.SerializeObject(this);
    }
    public sealed class ResponseCodes
    {
        public const string Success = "200";
        public const string Error = "400";
    }
}

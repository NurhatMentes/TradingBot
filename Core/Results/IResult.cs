﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Results
{
    public interface IResult
    {
        bool Success { get; }
        string Message { get; }
        int StatusCode { get; }
    }
}

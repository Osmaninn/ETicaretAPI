﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Application.Dtos.User
{
    public class CreateUserResponseDTO
    {
        public bool Succeeded { get; set; }

        public string Message { get; set; }
    }
}

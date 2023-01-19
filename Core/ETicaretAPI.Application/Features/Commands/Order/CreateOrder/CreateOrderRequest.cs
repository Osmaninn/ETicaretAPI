﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Application.Features.Commands.Order.CreateOrder
{
    public class CreateOrderRequest : IRequest<CreateOrderResponse>
    {

        public string Description { get; set; }

        public string Address { get; set; }
    }
}

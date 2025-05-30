﻿using MediatR;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.Customers.Commands.DeleteCustomer
{
    public class DeleteCustomerCommand : IRequest
    {
        public List<Guid> Ids { get; set; }
        public bool isHardDelete { get; set; }
    }
}

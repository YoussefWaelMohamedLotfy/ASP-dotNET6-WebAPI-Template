﻿namespace ASP_dotNET6_WebAPI_Template.Endpoints.V1.Customers;

public record CreateCustomerCommand
{
    public string Name { get; init; }

    public string Address { get; init; }

    public DateTimeOffset DateOfBirth { get; init; }
}

﻿namespace ASP_dotNET6_WebAPI_Template.Endpoints.Customers;

public class GetAllCustomersResult
{
    public string Name { get; set; }

    public string Address { get; set; }

    public DateTimeOffset DateOfBirth { get; set; }
}
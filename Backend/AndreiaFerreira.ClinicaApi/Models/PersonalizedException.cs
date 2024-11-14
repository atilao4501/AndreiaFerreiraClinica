using System;
using System.Net;

namespace AndreiaFerreira.ClinicaApi.Models;

public class PersonalizedException : Exception
{
    public HttpStatusCode StatusCode { get; }

    public PersonalizedException(string message, HttpStatusCode statusCode) : base(message)
    {
        StatusCode = statusCode;
    }
}


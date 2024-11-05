using System;

namespace AndreiaFerreira.ClinicaApi.Models.DTO;

public class DefaultOutput<T>
{
    public int StatusHttp { get; set; }
    public string Message { get; set; }
    public T Result { get; set; }
}

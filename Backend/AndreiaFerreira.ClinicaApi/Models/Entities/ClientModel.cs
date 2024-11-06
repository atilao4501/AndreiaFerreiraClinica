using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace AndreiaFerreira.ClinicaApi.Models.Entities;

public class ClientModel
{
    [JsonIgnore]
    public int Id { get; set; }
    public string Nome_completo { get; set; }
    public string RG { get; set; }
    public string CPF { get; set; }
    public string Endereco { get; set; }
    public string CEP { get; set; }
    public string Cidade { get; set; }
    public string Whatsapp { get; set; }
    public string Email { get; set; }
    public string? Como_nos_conheceu { get; set; }
    public AnamneseModel Anamnese { get; set; }

    [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy HH:mm:ss}")]
    public DateTime DataCadastro { get; set; }
}

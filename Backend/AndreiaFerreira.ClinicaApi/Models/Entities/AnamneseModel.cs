namespace AndreiaFerreira.ClinicaApi.Models.Entities;

public class AnamneseModel
{
    public int Id { get; set; }
    public bool Diabetes { get; set; } = false;
    public bool Fumante { get; set; } = false;
    public bool Esta_menstruada { get; set; } = false;
    public bool Esta_gravida { get; set; } = false;
    public bool Varizes_ou_Lesoes { get; set; } = false;
    public bool Cuidados_diarios_com_a_pele { get; set; } = false;
    public bool Ingere_agua { get; set; } = false;
    public bool Alimentacao_balanceada { get; set; } = false;
    public bool Ingere_bebida_alcoolica { get; set; } = false;
    public bool Pratica_atividade_fisica { get; set; } = false;
    public bool Antecedentes_oncologicos { get; set; } = false;
    public bool Problemas_ortopedicos { get; set; } = false;
    public bool Medicamentos_de_uso_diario { get; set; } = false;
    public bool Disturbio_hormonal { get; set; } = false;
    public bool Funcionamento_intestinal_regular { get; set; } = false;
    public bool Disturbio_circulatorio { get; set; } = false;
    public bool Tem_epilepsia_convulsoes { get; set; } = false;
    public bool Hiper_Hipotensao { get; set; } = false;
    public bool Problemas_cardiacos { get; set; } = false;
    public bool Em_tratamento_medico { get; set; } = false;
    public bool Problemas_de_pele { get; set; } = false;
    public bool Cirurgia_recente { get; set; } = false;
    public bool Ciclo_menstrual_regular { get; set; } = false;
    public bool Proteses_metalicas { get; set; } = false;
    public bool Possui_alergia { get; set; } = false;
    public bool Fica_muito_tempo_sentada { get; set; } = false;
    public bool Antecedentes_cirurgicos { get; set; } = false;
}


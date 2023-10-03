
namespace TrilhaApiDesafio.Models
{
    public class Tarefa
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public DateTime Data { get; set; }
        public EnumStatusTarefa Status { get; set; }


        public bool TarefaEstaValida(out Dictionary<string, string> dicionarioMensagensValidacao)
        {
            dicionarioMensagensValidacao = new Dictionary<string, string>();

            if(!DataTarefaEstaValida(out string mensagemRetorno))
            {
                dicionarioMensagensValidacao.Add($"{nameof(Data)}", mensagemRetorno);
            }

            if(!StatusTarefaEstaValida(out mensagemRetorno))
            {
                dicionarioMensagensValidacao.Add($"{nameof(Status)}", mensagemRetorno);
            }            

            return dicionarioMensagensValidacao.Count == 0;
        }

        public bool DataTarefaEstaValida(out string mensagemValidacao)
        {
            if (Data.Date == DateTime.MinValue.Date)
            { 
                mensagemValidacao = $"A data da tarefa não pode ser inválida ({DateTime.MinValue.Date.ToShortDateString()})";
                return false;
            }

            mensagemValidacao = string.Empty;
            return true;
        }

        public bool StatusTarefaEstaValida(out string mensagemValidacao)
        {
            if (!Enum.IsDefined<EnumStatusTarefa>(Status))
            { 
                mensagemValidacao = "O status da tarefa possui valor não esperado.";
                return false;
            }

            mensagemValidacao = string.Empty;
            return true;
        }
    }
}
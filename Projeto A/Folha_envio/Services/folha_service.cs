using ProjetoA.Models;
using RabbitMQ.Client;
using System;
using System.Text;
using System.Threading.Tasks;


namespace ProjetoA.Services
{
    public class FolhaService
    {
public double CalcularSalarioBruto(Folha folha)
{
    return folha.horas * folha.valor;
}public double CalcularINSS(double bruto){
            if (bruto <= 1693.72)
            {
                return bruto * 0.08;
            }
            else if (bruto <= 2822.9)
            {
                return bruto * 0.09;
            }
            else if (bruto <= 5645.8)
            {
                return bruto * 0.11;
            }
            return 621.03;
}


public double CalcularIRRF(double bruto){
            if (bruto <= 1903.98)
            {
                return 0;
            }
            else if (bruto <= 2826.65)
            {
                return bruto * 0.075 - 142.8;
            }
            else if (bruto <= 3751.05)
            {
                return bruto * 0.15 - 354.8;
            }
            else if (bruto <= 4664.68)
            {
                return bruto * 0.225 - 636.13;
            }
            return bruto * 0.275 - 869.39;
}


public double CalcularFGTS(double bruto){
            return bruto * 0.08;
        }

        public double CalcularSalarioLiquido(double bruto, double irrf, double inss)
        {
            return bruto - irrf - inss;
        }
        public async Task Enviar(string mensagem)
        {
            string fila = "FILA";
            string rabbitURL = "amqp://localhost";

            try
            {
                var factory = new ConnectionFactory() { Uri = new Uri(rabbitURL) };

                using (var connection = factory.CreateConnection())
                using (var channel = connection.CreateModel())
                {
                    channel.QueueDeclare(queue: fila,
                                         durable: false,
                                         exclusive: false,
                                         autoDelete: false,
                                         arguments: null);

                    var body = Encoding.UTF8.GetBytes(mensagem);

                    channel.BasicPublish(exchange: "",
                                         routingKey: fila,
                                         basicProperties: null,
                                         body: body);
                }
            }
            catch (Exception erro)
            {
                Console.WriteLine(erro);
            }
    }
}
}

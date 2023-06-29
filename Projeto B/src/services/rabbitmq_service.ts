import amqp from "amqplib";
import { Folha } from "../models/folhamodel";

export class RabbitMQService {
  private folhas: any[] = [];

  async consumir(): Promise<void> {
    const fila = "FILA";
    const rabbitURL = "amqp://localhost";

    try {
      const connection = await amqp.connect(rabbitURL);
      const channel = await connection.createChannel();

      await channel.assertQueue(fila, {
        autoDelete: false,
        exclusive: false,
        durable: false,
        arguments: null,
      });

      console.log("Aguardando mensagens...");

      channel.consume(fila, (mensagem) => {
        if (mensagem !== null) {
          const conteudo = mensagem.content.toString();
          console.log("Mensagem recebida:", conteudo);

          const folha = JSON.parse(conteudo);

          this.folhas.push(folha);

          channel.ack(mensagem);
        }
      });

    } catch (erro) {
      console.log(erro);
    }
  }

  getFolhas(): any[] {
    return this.folhas;
  }

  SalarioTotal(folhas: Folha[]): number {
    let somaSalarios = 0;

    for (const folha of folhas) {
      const salarioBruto = folha.bruto;
      somaSalarios += salarioBruto;
    }

    return somaSalarios;
  }
}


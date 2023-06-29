import { Request, Response } from "express";
import { Folha } from "../models/folhamodel";
import { FolhaRepository } from "../repositories/folha_repository"
import { RabbitMQService } from "../services/rabbitmq_service";

const folhaRepository = new FolhaRepository();
const queueservice = new RabbitMQService();

export class FolhaPagamentoController {
  async listar(req: Request, res: Response): Promise<void> {
    await queueservice.consumir();

    await new Promise<void>((resolve) => {
      setTimeout(resolve, 1500);
    });

    const folhas = queueservice.getFolhas();
    res.json(folhas);
  }

  async total(req: Request, res: Response): Promise<void> {
    await queueservice.consumir();

    await new Promise<void>((resolve) => {
      setTimeout(resolve, 1500);
    });

    const folhas = queueservice.getFolhas();

    const somaSalarios = queueservice.SalarioTotal(folhas);

    res.json({
      totalSalarios: somaSalarios,
    });
  }
  async media(req: Request, res: Response): Promise<void> {
    await queueservice.consumir();

    await new Promise<void>((resolve) => {
      setTimeout(resolve, 1500);
    });

    const folhas = queueservice.getFolhas();

    const quantidadeFolhas = folhas.length;
    const somaSalarios = queueservice.SalarioTotal(folhas);
    const mediaSalarios = somaSalarios / quantidadeFolhas;

    res.json({
      quantidadeFolhas,
      totalSalarios: somaSalarios,
      mediaSalarios,
    });
  }

}
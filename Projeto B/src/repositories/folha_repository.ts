import { Folha } from "../models/folhamodel";

const folhas: Folha[] = [];

export class FolhaRepository {
  cadastrar(folha: Folha) : Folha[] {
    folhas.push(folha);
    return folhas;
  }

  listar() : Folha[] {
    return folhas;
  }
}
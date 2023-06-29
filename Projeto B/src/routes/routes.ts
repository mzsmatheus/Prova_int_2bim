import { Router } from "express";
import { FolhaPagamentoController } from "../controllers/folha_controller";

const router: Router = Router();

//Folha
//router.get("/folha/consumirTeste", new FolhaPagamentoController().consumirTeste);
router.get("/folha/listar", new FolhaPagamentoController().listar);
router.get("/folha/total", new FolhaPagamentoController().total);
router.get("/folha/media", new FolhaPagamentoController().media);

export { router };
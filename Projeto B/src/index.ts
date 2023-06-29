import express from "express";
import { router } from "./routes/routes";

const app = express();

app.use(express.json());
app.use(router);

app.listen(3001, () => {
  console.clear();
  console.log("Aplicação de Consumo das folhas de pagamento está rodando na porta 3001");
});
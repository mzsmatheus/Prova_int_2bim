using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoA.Models
{
public class Folha{
        public int mes { get; set; }
        public string ano { get; set; }
        public int horas { get; set; }
        public int valor { get; set; }
        public double bruto { get; set; }
        public double irrf { get; set; }
        public double inss { get; set; }
        public double fgts { get; set; }
        public double liquido { get; set; }
        public Funcionario funcionario { get; set; }
}

public class Funcionario
    {
        public string nome { get; set; }
        public string cpf { get; set; }
    }
}
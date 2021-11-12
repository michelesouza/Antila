using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ENT
{
    public class eMovimento_Manual
    {
        public eProduto_Cosif Produto_Cosif { get; set; }
        public int Dat_Mes { get; set; }
        public int Dat_ano { get; set; }
        public int Num_Lancamento { get; set; }
        public decimal Valor { get; set; }
        public string Des_Descricao { get; set; }
        public string Cod_Usuario { get { return "teste"; } }

        public eMovimento_Manual()
        {
            this.Produto_Cosif = new eProduto_Cosif();
        }

    }
}

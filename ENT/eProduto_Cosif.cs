using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ENT
{
    public class eProduto_Cosif
    {
        public eProduto Produto { get; set; }
        public string Cod_Cosif { get; set; }
        public string Cod_Classificacao { get; set; }
        public string Sta_Status { get; set; }

        public eProduto_Cosif()
        {
            this.Produto = new eProduto();
        }
    }
}


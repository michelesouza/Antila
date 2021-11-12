using ENT;
using NEG;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UI.Models
{
    public class Movimento_ManualModel : Grids<eMovimento_Manual>
    {
        public  List<eProduto_Cosif> ListProduto_Cosif = new List<eProduto_Cosif>();

        public Movimento_ManualModel()
        {
            Entidade = new eMovimento_Manual();
            ListDados = new List<eMovimento_Manual>();
        }

        public void popularGrid()
        {
            this.ListDados = nMovimento_Manual.Get(new eMovimento_Manual()).ToList();
        }

        public void popularCheksBox()
        {
            this.ListProduto_Cosif = nProduto_Cosif.Get(new eProduto_Cosif()).ToList();
        }

        public void GravarDados(Movimento_ManualModel models)
        {
              var result = nMovimento_Manual.Set(models.Entidade);
        }
    }
}
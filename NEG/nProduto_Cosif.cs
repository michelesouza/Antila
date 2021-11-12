using DAO;
using ENT;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NEG
{
    public class nProduto_Cosif
    {
        public static IList<eProduto_Cosif> Get(eProduto_Cosif obj)
        {
            try
            {
                return new dProduto_Cosif().Get(obj);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}

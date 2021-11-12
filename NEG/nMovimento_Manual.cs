using DAO;
using ENT;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NEG
{
    public class nMovimento_Manual
    {
        public static IList<eMovimento_Manual> Get(eMovimento_Manual obj)
        {
            try
            {
                return new dMovimento_Manual().Get(obj);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static int Set(eMovimento_Manual obj)
        {
            try
            {
                return new dMovimento_Manual().Set(obj);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}

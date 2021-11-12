using DAO.Interface;
using ENT;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public class dProduto_Cosif : dBaseDAO, IObjDataBase<eProduto_Cosif>
    {
        public IList<eProduto_Cosif> Get(eProduto_Cosif obj)
        {
            IDataReader dr = null;
            IList<eProduto_Cosif> lista = new List<eProduto_Cosif>();
            SqlParameter[] param = null;

            try
            {
                cmd = new SqlCommand();
                param = new SqlParameter[2];
                lista = new List<eProduto_Cosif>();

                MontarParametro(0, param, ParameterDirection.Input, "@STA_STATUS", obj.Sta_Status, SqlDbType.VarChar);
                MontarParametro(1, param, ParameterDirection.Input, "@Cod_Produto", obj.Produto.Cod_Produto, SqlDbType.VarChar);

                dr = ExecReader("USP_PRODUTO_COSIF_GET", cmd, param);

                if (dr != null)
                    while (dr.Read())
                        lista.Add(SetObject(dr));

                return lista;
            }
            catch (SqlException sqlex)
            {
                throw sqlex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally { CloseConnection(); }
        }


        public eProduto_Cosif SetObject(IDataReader dr)
        {
            eProduto_Cosif obj = null;

            try
            {
                obj = new eProduto_Cosif();
                obj.Sta_Status = GetString("STA_STATUS", dr);
                obj.Cod_Cosif = GetString("Cod_Cosif", dr);
                obj.Cod_Classificacao = GetString("COD_CLASSIFICACAO", dr);
                obj.Produto.Des_produto = GetString("DES_PRODUTO", dr);
                obj.Produto.Cod_Produto = GetString("Cod_Produto", dr);
                return obj;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}

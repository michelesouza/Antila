using ENT;
using NEG;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace UIWF
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                popularGrid();
                popularBoxs();
            }
        }

        private void popularBoxs()
        {
            List<eProduto_Cosif> list_cosif = new List<eProduto_Cosif>();
            list_cosif = nProduto_Cosif.Get(new eProduto_Cosif()).ToList();
            List<eProduto> produtoLista = new List<eProduto>();

            foreach (var item in list_cosif)
            {
                produtoLista.Add(item.Produto);
            }

            dllProduto.DataSource = produtoLista;
            dllProduto.DataBind();
            dllProduto.Items.Insert(0, new ListItem("Selecione", ""));

            dllProduto_Cosif.DataSource = list_cosif;
            dllProduto_Cosif.DataBind();
            dllProduto_Cosif.Items.Insert(0, new ListItem("Selecione", ""));

        }

        protected void dllProduto_SelectedIndexChanged(object sender, EventArgs e)
        {
            List<eProduto_Cosif> list_cosif = new List<eProduto_Cosif>();
            eProduto produto = new eProduto();

            produto.Cod_Produto = dllProduto.SelectedValue;

            list_cosif = nProduto_Cosif.Get(new eProduto_Cosif() { Produto = produto }).ToList();

            dllProduto_Cosif.DataSource = list_cosif;
            dllProduto_Cosif.DataBind();
            dllProduto_Cosif.Items.Insert(0, new ListItem("Selecione", ""));
        }

        private void popularGrid()
        {
            var lista = nMovimento_Manual.Get(new eMovimento_Manual()).ToList();

            gdvLista.DataSource = lista;
            gdvLista.DataBind();
            if (gdvLista.Rows.Count > 0)
                gdvLista.HeaderRow.TableSection = TableRowSection.TableHeader;
        }

        protected void lbtInluir_Click(object sender, EventArgs e)
        {
            eMovimento_Manual movimento = new eMovimento_Manual();

            movimento =  MontarObjeto(movimento);

           var result =  nMovimento_Manual.Set(movimento);

            if (result == 0)
                pnlResultado.Visible = true;
            else
                Response.RedirectPermanent("Default.aspx");
        }

        protected eMovimento_Manual MontarObjeto(eMovimento_Manual movimento)
        {
            movimento.Dat_Mes = int.Parse(txt_Dat_Mes.Text);
            movimento.Dat_ano = int.Parse(txt_Dat_ano.Text);
            movimento.Des_Descricao = txt_Descricao.Text;
            movimento.Valor = decimal.Parse(txt_Valor.Text);
            movimento.Produto_Cosif.Produto.Cod_Produto = dllProduto.SelectedValue;
            movimento.Produto_Cosif.Cod_Cosif = dllProduto_Cosif.SelectedValue;

            return movimento;
        }

        protected void lbtLimpar_Click(object sender, EventArgs e)
        {
            txt_Dat_Mes.Text = "";
            txt_Dat_ano.Text = "";
            txt_Descricao.Text = "";
            txt_Valor.Text = "";
            popularBoxs();

        }
        protected void lbtNovo_Click(object sender, EventArgs e)
        {
            lbtIncluir.Visible = true;
            lbtLimpar.Visible = true;
            lbtNovo.Visible = false;
            txt_Dat_Mes.Enabled = true;
            txt_Dat_ano.Enabled = true;
            txt_Descricao.Enabled = true;
            txt_Valor.Enabled = true;
            dllProduto.Enabled = true;
            dllProduto_Cosif.Enabled = true;

        }
    }
}
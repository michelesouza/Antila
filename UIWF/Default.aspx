<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="UIWF._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <asp:Panel ID="pnlResultado" runat="server" Visible="false">
        <div class="row mb-3">
            <div class="col-md-12">
                <div class="alert alert-danger">
                    <h5>Ops!</h5>
                    <span>Ocorreu um erro :(</span>
                </div>
            </div>
        </div>
    </asp:Panel>
    <asp:Panel ID="pnlMovimentos_Manuais" runat="server">
        <asp:UpdatePanel ID="upPnlMovimento" runat="server">
            <ContentTemplate>
                <div class="panel panel-default">
                    <div class="panel-heading" style="display: flex; justify-content: space-between;">
                        <h3 class="panel-title" style="display: flex; align-items: center;">Movimentos Manuais</h3>
                    </div>
                    <div class="panel-body">
                        <div class="form-group col-md-6">
                            <label>Mês&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</label>
                            <asp:TextBox runat="server" type="number" CssClass="form-control dh" ID="txt_Dat_Mes" min="1" max="12" Enabled="false" />
                            <asp:RequiredFieldValidator ID="rvMes" runat="server" ControlToValidate="txt_Dat_Mes"
                                Display="None" ErrorMessage="Preencha o campo Mês." SetFocusOnError="True"
                                ValidationGroup="vgMovimento" />
                        </div>
                        <div class="form-group col-md-6">
                            <label>Ano&nbsp;&nbsp;&nbsp;&nbsp; </label>
                            <asp:TextBox runat="server" type="number" ID="txt_Dat_ano" CssClass="form-control dh" min="1950" max="2030" Enabled="false" />
                            <asp:RequiredFieldValidator ID="rvAno" runat="server" ControlToValidate="txt_Dat_ano"
                                Display="None" ErrorMessage="Preencha o campo Ano." SetFocusOnError="True"
                                ValidationGroup="vgMovimento" />
                        </div>
                        <div class="form-group col-md-6">
                            <label>Produto&nbsp;&nbsp;&nbsp;&nbsp; </label>
                            <asp:DropDownList ID="dllProduto" runat="server" DataTextField="Des_Produto" DataValueField="Cod_Produto" AutoPostBack="True" OnSelectedIndexChanged="dllProduto_SelectedIndexChanged" CssClass="form-control dh" Enabled="false" />
                            <asp:RequiredFieldValidator ID="rvProduto" runat="server" ControlToValidate="dllProduto"
                                Display="None" ErrorMessage="Selecione o Produto" SetFocusOnError="True"
                                ValidationGroup="vgMovimento" />
                        </div>
                        <div class="form-group col-md-6">
                            <label>Cosif&nbsp;&nbsp;&nbsp;&nbsp; </label>
                            <asp:DropDownList ID="dllProduto_Cosif" runat="server" DataTextField="Cod_Cosif" DataValueField="Cod_Cosif" CssClass="form-control dh" Enabled="false" />
                            <asp:RequiredFieldValidator ID="rvCosif" runat="server" ControlToValidate="dllProduto_Cosif"
                                Display="None" ErrorMessage="Selecione" SetFocusOnError="True"
                                ValidationGroup="vgMovimento" />
                        </div>
                        <div class="form-group col-md-6">
                            <label>Valor&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</label>
                            <asp:TextBox runat="server" type="number" CssClass="form-control dh" ID="txt_Valor" min="1" max="12" Enabled="false" />
                            <asp:RequiredFieldValidator ID="rvValor" runat="server" ControlToValidate="txt_Valor"
                                Display="None" ErrorMessage="Preencha o campo Mês." SetFocusOnError="True"
                                ValidationGroup="vgMovimento" />
                        </div>
                        <div class="form-group col-md-6">
                            <label>Descrição&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</label>
                            <asp:TextBox runat="server" TextMode="MultiLine" Rows="3" CssClass="form-control dh" ID="txt_Descricao" Enabled="false" />
                            <asp:RequiredFieldValidator ID="rvDescri" runat="server" ControlToValidate="txt_Descricao"
                                Display="None" ErrorMessage="Preencha a Descrição." SetFocusOnError="True"
                                ValidationGroup="vgMovimento" />
                        </div>
                        <asp:ValidationSummary ID="vsMovimento" runat="server" ShowMessageBox="True"
                            ShowSummary="False" ValidationGroup="vgMovimento" />
                        <div class="footer">
                            <asp:LinkButton ID="lbtNovo" runat="server" Text="Novo" OnClick="lbtNovo_Click"
                                CssClass="btn btn-success btn-sm pull-right ttt" />
                            <asp:LinkButton ID="lbtLimpar" runat="server" Text="Limpar" OnClick="lbtLimpar_Click"
                                CssClass="btn btn-primary btn-sm pull-right" Visible="false" />
                            <asp:LinkButton ID="lbtIncluir" runat="server" Text="Incluir" OnClick="lbtInluir_Click"
                                CssClass="btn btn-info btn-sm pull-right" Visible="false" />
                        </div>
                    </div>
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>

    </asp:Panel>
    <asp:Panel ID="pnlLista" runat="server">
        <asp:UpdatePanel ID="upGrid" runat="server">
            <ContentTemplate>
                <div class="panel panel-default">
                    <div class="panel-heading" style="display: flex; justify-content: space-between;">
                        <h3 class="panel-title" style="display: flex; align-items: center;">Lista</h3>
                    </div>
                    <div class="panel-body">
                        <asp:GridView ID="gdvLista" runat="server" CssClass="table table-bordered table-hover"
                            AllowPaging="true" PageSize="30" AutoGenerateColumns="false"
                            AllowSorting="true" Width="100%" EmptyDataText="Nenhum registro encontrado.">
                            <Columns>
                                <asp:BoundField DataField="Dat_Mes" HeaderText="Mês" />
                                <asp:BoundField DataField="Dat_ano" HeaderText="Ano" />
                                <asp:BoundField DataField="Produto_Cosif.Produto.Cod_Produto" HeaderText="Produto" />
                                <asp:BoundField DataField="Produto_Cosif.Produto.Des_Produto" HeaderText="Descrição Produto" />
                                <asp:BoundField DataField="Num_Lancamento" HeaderText="NM Lançamento" />
                                <asp:BoundField DataField="Valor" HeaderText="Valor" />
                            </Columns>
                        </asp:GridView>
                    </div>
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>
    </asp:Panel>
  </asp:Content>






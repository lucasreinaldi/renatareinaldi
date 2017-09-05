<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/AdmHome.Master" AutoEventWireup="true" CodeBehind="GERnoticias.aspx.cs" Inherits="WEB_RENATA.Admin.GERnoticias" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contentBody" runat="server">



    <section class="main-section" id="Portfolio"> 
	<div class="container gerServicos">
    	<h2>Gerenciador de Notícias</h2>
    	 


        <asp:Panel ID="Panel1" runat="server" DefaultButton="btnServicos" CssClass="divServicos">
                    <asp:TextBox ID="txtTitulo" runat="server" CssClass="form-control input-text" placeholder="titulo da noticia"
                        MaxLength="50"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="validador1" Font-Size="Smaller" runat="server"
                        ErrorMessage="você precisa digitar um email" CssClass="RequiredField" ControlToValidate="txtTitulo" ValidationGroup="valNoticias"></asp:RequiredFieldValidator>
                    

                    <asp:TextBox ID="txtDescricao" runat="server" CssClass="form-control input-text" placeholder="descrição breve"
                        MaxLength="50"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" Font-Size="Smaller" runat="server"
                        ErrorMessage="você precisa digitar uma descrição breve" CssClass="RequiredField" ControlToValidate="txtDescricao" ValidationGroup="valNoticias"></asp:RequiredFieldValidator>
            
                    <asp:TextBox ID="txtConteudo" runat="server" CssClass="form-control input-text" placeholder="conteúdo da notícia"
                        MaxLength="50"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" Font-Size="Smaller" runat="server"
                        ErrorMessage="você digitar o corpo da mensagem" CssClass="RequiredField" ControlToValidate="txtConteudo" ValidationGroup="valNoticias"></asp:RequiredFieldValidator>

                    

                    <asp:FileUpload ID="exampleInputFile" Width="70%" ToolTip="Selecione a imagem" runat="server" />
            
                <asp:LinkButton ID="btnServicos" runat="server" CssClass="btn btn-info"
                        CausesValidation="true" ValidationGroup="valNoticias" OnClick="btnAdicionar_Click">Adicionar</asp:LinkButton>
                </asp:Panel>
       
         
        
	</div>
    <div class="container fadeInUp delay-04s tabelaServicos">
            
        <asp:HiddenField ID="hidID" runat="server" />
       <div id="divServicos">
         
        <table id="divTabelaServico">
            <asp:Repeater ID="rptNoticias" runat="server">
                <HeaderTemplate>
                    <div id="topoLista">
                        <tr>
                            <th style="width: 3%; text-align: center;">ID
                            </th>
                            <th style="width: 7%; text-align: center;">Titulo
                            </th>
                            <th style="width: 15%; text-align: center;">Descricao Breve
                            </th>
                            <th style="width: 10%; text-align: center;">Conteudo
                            </th>
                            <th style="width: 15%; text-align: center;">Data Publicação
                            </th>
                            <th style="width: 10%; text-align: center;">Caminho
                            </th>
                            <th style="width: 3%; text-align: center;">Alterar
                            </th>
                            <th style="width: 3%; text-align: center;">Deletar
                            </th>
                        </tr>
                    </div>
                </HeaderTemplate>
                <ItemTemplate>
                    <tr class="linhaA">
                        <td align="center">
                            <%#Eval("id") %>
                        </td>
                        <td align="center">
                            <%#Eval("titulo") %>
                        </td>
                        <td align="center">
                            <%#Eval("descricao") %>
                        </td>
                        <td align="center">
                            <%#Eval("conteudo")%>
                        </td>
                        <td align="center">
                            <%#Eval("data")%>
                        </td>
                        <td align="center">
                            <%#Eval("caminho")%>
                        </td>
                        <td align="center" title="X[<%#Eval("id") %>]">
                            <asp:LinkButton ID="lblAlterar" CommandArgument='<%#Eval("ID")%>' runat="server" OnClientClick="return confirm('Tem certeza que deseja excluir?');"><i class="fa fa-wrench"></i></asp:LinkButton>
                        </td>
                        <td align="center" title="X[<%#Eval("id") %>]">
                            <asp:LinkButton ID="lbExcluir" OnCommand="imbExcluirEmail_Click" CommandArgument='<%#Eval("ID")%>' runat="server" OnClientClick="return confirm('Tem certeza que deseja excluir?');"><i class="fa fa-trash"></i></asp:LinkButton>
                        </td>
                    </tr>
                </ItemTemplate>
            </asp:Repeater>
        </table>
    </div>

    <div id="divPaginacao" class="divPaginacao" runat="server" style="text-align: center;">
        <div style="padding: 5px 0 0 0;">
            <asp:LinkButton runat="server" ID="lbtAnterior" Text="Anterior" ToolTip="Ir para a página anteiror"
                CausesValidation="false" AccessKey="A" ForeColor="#000000" OnClick="lbtAnterior_Click"></asp:LinkButton>
            <asp:Label ID="lblCurrentPage" runat="server"></asp:Label>
            <asp:LinkButton runat="server" ID="lbtProximo" Text="Próximo" ToolTip="Ir para a próxima página"
                CausesValidation="false" AccessKey="P" ForeColor="#000000" OnClick="lbtProximo_Click"></asp:LinkButton>
        </div>
    </div> 	
               
        
        
        
         
    </div>
</section>

</asp:Content>

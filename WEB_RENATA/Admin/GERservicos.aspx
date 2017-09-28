<%@ Page Title="Serviços" Language="C#" MasterPageFile="~/Admin/AdmHome.Master" AutoEventWireup="true"
    CodeBehind="GERservicos.aspx.cs" Inherits="WEB_RENATA.Admin.GERservicos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contentBody" runat="server">
    <div id="divResultado" runat="server">
        <div id="divLabel" runat="server">
            <asp:Label ID="lblResultado" runat="server"></asp:Label>
        </div>
    </div>
    <section  >
	<div class="container gerSquare">
    	<h2>Gerenciador de Serviços</h2>
    	 

         <a class="btn btn-primary" href="GERservicosDados.aspx?id=0">Novo serviço</a>
         
        
	</div>
    <div class="container fadeInUp delay-04s tabelaServicos">
            
        <asp:HiddenField ID="hidID" runat="server" />
       <div id="divTabela">
         
        <table id="divCentral">
            <asp:Repeater ID="rptServicos" runat="server">
                <HeaderTemplate>
                    <div id="topoLista">
                        <tr>
                            <th style="width: 2%; text-align: center;">ID
                            </th>
                            <th style="width: 5%; text-align: center;">Nome
                            </th>
                            <th style="width: 15%; text-align: center;">Descrição
                            </th>
                            <th style="width: 5%; text-align: center;">Valor
                            </th>
                            <th style="width: 15%; text-align: center;">Imagem
                            </th>
                            <th style="width: 3%; text-align: center;">A
                            </th>
                            <th style="width: 3%; text-align: center;">D
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
                            <%#Eval("nome") %>
                        </td>
                        <td align="center">
                            <%#Eval("descricao") %>
                        </td>
                        <td align="center">
                            <%#Eval("valor", "{0:c}")%>
                        </td>
                        <td align="center">
                            <img src="<%#Eval("caminho")%>" style="height:200px; width: 200px;" />                            
                        </td>
                        <td align="center" title="X[<%#Eval("id") %>]">                             
                            <a href="GERservicosDados.aspx?id=<%# Eval("id") %>" >
                                 <i class="fa fa-wrench"></i>
                            </a>
                        </td>
                        <td align="center" title="X[<%#Eval("id") %>]">
                            <asp:LinkButton ID="lbExcluir" OnCommand="Excluir_Click" CommandArgument='<%#Eval("ID")%>' runat="server" OnClientClick="return confirm('Tem certeza que deseja excluir?');"><i class="fa fa-trash"></i></asp:LinkButton>
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

<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/AdmHome.Master" AutoEventWireup="true" CodeBehind="GERnoticias.aspx.cs" Inherits="WEB_RENATA.Admin.GERnoticias" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contentBody" runat="server">

   
    <div id="divResultado" runat="server">
        <div id="divLabel" runat="server">
            <asp:Label ID="lblResultado" runat="server"></asp:Label>
        </div>
    </div>
   

    <section class="main-section" id="Portfolio"> 
	<div class="container gerSquare">
    	<h2>Gerenciador de Notícias</h2>
    	 


         <a href="GERnoticiasDados.aspx?id=0">Nova notícia</a>
                    
       
         
        
	</div>
    <div class="container fadeInUp delay-04s tabelaServicos">
            
        <asp:HiddenField ID="hidID" runat="server" />
       <div id="divCentral">
         
        <table id="divTabela">
            <asp:Repeater ID="rptNoticias" runat="server">
                <HeaderTemplate>
                    <div id="topoLista">
                        <tr>
                            <th style="width: 3%; text-align: center;">ID
                            </th>
                            <th style="width: 5%; text-align: center;">Titulo
                            </th>
                            <th style="width: 8%; text-align: center;">Descricao Breve
                            </th>
                            <th style="width: 20%; text-align: center;">Conteudo
                            </th>
                            <th style="width: 5%; text-align: center;">Data Publicação
                            </th>
                            <th style="width: 15%; text-align: center;">Caminho
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
                            <img src="<%#Eval("caminho")%>" style="height:200px; width: 200px;" />                            
                        </td>
                        <td align="center" title="X[<%#Eval("id") %>]">                             
                            <a href="GERnoticiasDados.aspx?id=<%# Eval("id") %>" >
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

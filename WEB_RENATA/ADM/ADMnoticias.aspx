<%@ Page Title="" Language="C#" MasterPageFile="~/ADM/ADM.Master" AutoEventWireup="true" CodeBehind="ADMnoticias.aspx.cs" Inherits="WEB_RENATA.ADM.WebForm2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contentBody" runat="server">
    
    <div class="container">
        <section class="main-section contact" id="contact">
	
        <div class="row">
        	 
        	<div class="col-lg-6 col-sm-5 wow fadeInUp delay-05s">
            	<div class="form">
                	
                    <div id="sendmessage">Your message has been sent. Thank you!</div>
                    <div id="errormessage"></div>
                    <form action="" method="post" role="form" class="contactForm">
                        <div class="form-group">
                            <input type="text" name="name" class="form-control input-text" id="nome" placeholder="Serviço" data-rule="minlen:4" data-msg="Please enter at least 4 chars" />
                            <div class="validation"></div>
                        </div>
                        <div class="form-group">
                            <input type="email" class="form-control input-text" name="valor" id="email" placeholder="Valor" data-rule="email" data-msg="Please enter a valid email" />
                            <div class="validation"></div>
                        </div>                         
                        <div class="form-group">
                            <textarea class="form-control input-text text-area" name="descricao" rows="5" data-rule="required" data-msg="Please write something for us" placeholder="Descrição"></textarea>
                            <div class="validation"></div>
                        </div>

                        <div class="form-group">
                            <textarea class="form-control input-text text-area" name="message" rows="5" data-rule="required" data-msg="Please write something for us" placeholder="upload"></textarea>
                            <div class="validation"></div>
                        </div>
                        
                        <div class="text-center"><button type="submit" class="input-btn">Adicionar</button></div>
                    </form>
                </div>	
            </div>
        </div>
</section>
    </div>

    <asp:HiddenField ID="hidID" runat="server" />
    <asp:HiddenField ID="hidD" runat="server" />

    <div id="divCadastro">
        <h2 class="section-title font-alt mb-70 mb-sm-40">
            <br />
            Adicionar Datas
        </h2>
        <asp:TextBox ID="tboxNome" CssClass="input-md form-control" placeholder="nome do evento" runat="server"></asp:TextBox>
        <br />
        <asp:TextBox ID="tboxData" CssClass="input-md form-control" placeholder="data do evento" runat="server"></asp:TextBox>
        <br />
        <asp:TextBox ID="tboxLink" CssClass="input-md form-control" placeholder="link do evento" runat="server"></asp:TextBox>
        <br />
        <p id="msgResposta" runat="server"></p>
        <asp:Button CssClass="submit_btn btn btn-mod btn-medium btn-round center-block" runat="server" ID="btnOk" Text="Adicionar" OnClick="adicionarData" />
    </div>

    <div id="divDatas">
        <h2 class="section-title font-alt mb-70 mb-sm-40">
            <br />
            Datas
        </h2>
        <table style="font-size: 10px;" cellpadding="3px" cellspacing="0px">
            <asp:Repeater ID="rptDatas" runat="server">
                <HeaderTemplate>
                    <div>
                        <tr>
                            <th style="width: 3%; text-align: center;">
                                <asp:LinkButton ID="btnId" runat="server" OnClick="btnId_Click">ID</asp:LinkButton>
                            </th>
                            <th style="width: 15%; text-align: center;">Nome
                            </th>
                            <th style="width: 10%; text-align: center;">
                                <asp:LinkButton ID="btnData" runat="server" OnClick="btnData_Click">Data</asp:LinkButton>
                            </th>
                            <th style="width: 15%; text-align: center;">Link
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
                            <%#Eval("nome") %>
                        </td>
                        <td align="center" runat="server">
                            <%#Eval("date", "{0:d}") %>
                        </td>
                        <td align="center">
                            <%#Eval("link")%>
                        </td>
                        <td align="center" title="X[<%#Eval("id") %>]">
                            <asp:LinkButton ID="lbExcluirData" OnCommand="imbExcluirData_Click" OnClientClick="return confirm('Tem certeza que deseja excluir?');"
                                CommandArgument='<%#Eval("ID")%>' runat="server"><i class="fa fa-trash"></i></asp:LinkButton>
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
</asp:Content>

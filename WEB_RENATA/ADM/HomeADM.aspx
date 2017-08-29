<%@ Page Title="" Language="C#" MasterPageFile="~/ADM/Admin.Master" AutoEventWireup="true" CodeBehind="HomeADM.aspx.cs" Inherits="WEB_RENATA.ADM.HomeADM" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contentBody" runat="server">
    
    <div class="col-md-6 col-md-offset-3">

                <h1 class="hs-line-11 font-alt mb-20 lighter">Adicionar produto</h1>

                <form class="form contact-form" id="contact_form">
                    <div class="clearfix">

                        <div>
                            <!-- Email -->
                            <div class="form-group">
                                <input type="text" name="email" id="email" class="input-md round form-control" placeholder="Nome" pattern=".{5,100}" required>
                            </div>
                            <div class="form-group">
                                <input type="text" name="name" id="name" class="input-md round form-control" placeholder="Valor" pattern=".{3,100}" required>
                            </div>
                            <textarea name="message" id="message" class="input-md round form-control" style="height: 84px;" placeholder="Descrição"></textarea>
                            <form method="post" action="#" id="form-2" role="form" class="form">
                                
                                
                                <div class="mb-20 mb-md-10">
                                    <p class="help-block">
                                        Imagem do produto
                                    </p>
                                    <input type="file" id="exampleInputFile">
                                </div>
                                
                           
                            </form>
                        </div>


                    </div>

                    <div class="clearfix">

                        <div class="cf-left-col">

                            <!-- Inform Tip -->
                            <div class="form-tip pt-20">
                                 
                            </div>

                        </div>

                        <div class="cf-right-col">

                            <!-- Send Button -->
                            <div class="align-right pt-10">
                                <button class="submit_btn btn btn-mod btn-medium btn-round" id="cadastro_btn">Cadastrar</button>                                                               
                            </div>
                            <div class="align-right pt-10">
                        </div>

                        </div>

                    </div>



                    <div id="result"></div>
                </form>

            </div>
      


</asp:Content>

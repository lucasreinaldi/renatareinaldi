<%@ Page Title="" Language="C#" MasterPageFile="~/Home.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WEB_RENATA.Default" %>
 
<asp:Content ID="Content2" ContentPlaceHolderID="contentBody" runat="server">
    
   <div class="container">
      <div class="row">
        <div class="col-xs-12 col-sm-12 col-md-12 col-lg-12 col-xl-12">
        	<br />
 
        	<div id="carousel-example-generic" class="carousel slide" data-ride="carousel">
        		<ol class="carousel-indicators">
        			<li data-target="#carousel-example-generic" data-slide-to="0" class="active"></li>
        			<li data-target="#carousel-example-generic" data-slide-to="1"></li>
        			<li data-target="#carousel-example-generic" data-slide-to="2"></li>
        		</ol>
 
        		<div class="carousel-inner" role="listbox">
        			<div class="carousel-item active">
        				<img src="http://azoom-sites.rockthemes.net/abboxed/wp-content/uploads/sites/14/2015/05/abboxed-restaurant-portfolio2.jpg" alt="First Slide" />
        			</div>
 
        			<div class="carousel-item">
        				<img src="http://azoom-sites.rockthemes.net/abboxed/wp-content/uploads/sites/14/2015/05/abboxed-beach-portfolio.jpg" alt="Second Slide" />
 
        				<div class="carousel-caption">
        					<h2>Best Caption Title</h2>
        					<p>Oh yh it is indeed!!!!!! :D</p>
        				</div>
        			</div>
 
        			<div class="carousel-item">
        				<img src="http://azoom-sites.rockthemes.net/abboxed/wp-content/uploads/sites/14/2015/05/abboxed-beach-portfolio2.jpg" alt="Third Slide" />
        			</div>
        		</div>
 
        		<a class="left carousel-control" href="#carousel-example-generic" role="button" data-slide="prev">
        			<span class="icon-prev" aria-hidden="true"></span>
        			<span class="sr-only">Previous</span>
        		</a>
 
        		<a class="right carousel-control" href="#carousel-example-generic" role="button" data-slide="next">
        			<span class="icon-next" aria-hidden="true"></span>
        			<span class="sr-only">Next</span>
        		</a>
        	</div>
        </div>
      </div>
       </div>

    <section class="main-section paddind" id="Portfolio"> 
	<div class="container">
    	<h2>Clientes satisfeitos</h2>
    	<h6>Animais também sorriem!</h6>
       
        
	</div>
    <div class="portfolioContainer wow fadeInUp delay-04s">
            	<div class=" Portfolio-box printdesign">
                	<a href="#"><img src="img/home/defaultCliente.jpg" alt=""></a>	
                	 
                    <p>Cachorro</p>
                </div>
                <div class="Portfolio-box webdesign">
                	<a href="#"><img src="img/home/defaultCliente.jpg" alt=""></a>	
                	 
                    <p>Cachorro</p>
                </div>
                <div class=" Portfolio-box branding">
                	<a href="#"><img src="img/home/defaultCliente.jpg" alt=""></a>	
                	 
                    <p>Cachorro</p>
                </div>
                
    </div>
</section>

    <section class="main-section paddind" id="">
	<div class="container">
    	<h2>Novidades</h2>
    	        
        <div id="noticias" class="row">
            <div class="col-6 col-lg-4">
              <h3>Heading</h3>
              <p>Donec id elit non mi porta gravida at eget metus. Fusce dapibus, tellus ac cursus commodo, tortor mauris condimentum nibh, ut fermentum massa justo sit amet risus. Etiam porta sem malesuada magna mollis euismod. Donec sed odio dui. </p>
              <p><a class="btn btn-secondary" href="#" role="button">ler tudo »</a></p>
            </div>
            <div class="col-6 col-lg-4">
              <h3>Heading</h3>
              <p>Donec id elit non mi porta gravida at eget metus. Fusce dapibus, tellus ac cursus commodo, tortor mauris condimentum nibh, ut fermentum massa justo sit amet risus. Etiam porta sem malesuada magna mollis euismod. Donec sed odio dui. </p>
              <p><a class="btn btn-secondary" href="#" role="button">ler tudo »</a></p>
            </div>
            <div class="col-6 col-lg-4">
              <h3>Heading</h3>
              <p>Donec id elit non mi porta gravida at eget metus. Fusce dapibus, tellus ac cursus commodo, tortor mauris condimentum nibh, ut fermentum massa justo sit amet risus. Etiam porta sem malesuada magna mollis euismod. Donec sed odio dui. </p>
              <p><a class="btn btn-secondary" href="#" role="button">ler tudo »</a></p>
            </div>
            
          </div>
	</div>
    
</section>


</asp:Content>
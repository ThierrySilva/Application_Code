<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Application_Code.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title> Aplicacão Teatro</title>
    <link href="Bootstrap/css/bootstrap.css" rel="stylesheet" />     
    <link href="StyledCss/StyleSheet.css" rel="stylesheet" type="text/css"/>                
    <script src="Scripts/Functions.js"></script>
</head>
<body>
    <form id="form1" runat="server">
        
        <asp:ScriptManager ID="Script" runat="server"></asp:ScriptManager>
        <div class="container-fluid"> 
                            
                <header>
                    <div class="principal-header jumbotron">                                                
                            <div class="col-sm-10 col-md-10">
                                 <h1> Controle de Sessão - Teatro Teste </h1>
                            </div>
                            <div class="col-sm-2 col-md-2">
                                <button type="button" class="hamburger-button">                                                        
                                <img src="Icons/.icon/Menu-icon.png" class="menu-hamburguer"/>
                                </button>                        
                            </div>    
                        
                    </div>
                    
                </header> 

                <div class="menu-top">
                    <ul class="nav justify-content-end">
                        <li class="nav-item">
                        <a class="" href="#">Inicio</a>
                        </li>
                        <li class="nav-item">
                        <a class="" href="#">Sobre</a>
                        </li>
                        <li class="nav-item">
                        <a class="" href="#" onclick="showAlertDialog">Área do Cliente</a>
                        </li>
                        
                    </ul>
                </div>

                <section  class="center container-fluid text-center">
                    <div class="search-panel input-group row">
                      <div class="search-input col-8 col-sm-8 col-md-10">
                        <input type="text" class="input-component form-control" placeholder="Pesquisa" aria-label="Pesquisar por: " aria-describedby="basic-addon2" />
                      </div>  
                      <div class="search-button col-4 col-sm-3 col-md-2 input-group-append">
                          <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional" 
                            ChildrenAsTriggers="true">  
                                <Triggers>
                                    <asp:PostBackTrigger  ControlID="PesquisarButton"/>
                                </Triggers>
                                <ContentTemplate>                                                                    
                                        <asp:Button CssClass="btn btn-dark" id="PesquisarButton" Text ="Pesquisar" runat="server"/>
                                </ContentTemplate>                                                                         
                            </asp:UpdatePanel>  
                        
                      </div>
                    </div>               
                    <div id="CarouselDiv" class="carousel-div-manual">
                        <div id="CarouselLine" class="carousel-line-manual">
                             <div class="row mx-auto my-auto">
                                 <div id="inam" class="carousel slide" data-ride="carousel">
                                    <div id="container-carousel" class="container-fluid">                                        
                                        <div id="carousel-inner" class="carousel-inner"  role="listbox">
                                        </div>     
                                        
                                         <a class="carousel-control-prev w-auto" href="#inam" role="button" data-slide="prev">
                                            <span class="carousel-control-prev-icon bg-dark border border-dark rounded-circle" aria-hidden="true"></span>   
                                             <span class="sr-only">Previous</span>
                                        </a>

                                        <a class="carousel-control-next w-auto" href="#inam" role="button" data-slide="next">
                                            <span class="carousel-control-next-icon bg-dark border border-dark rounded-circle" aria-hidden="true"></span>  
                                            <span class="sr-only">Next</span>
                                        </a>

                                    </div>
                               
                                   </div>
                              </div>
                           </div>
                        </div>

                    </section>

                    <div class="table-responsive">
                        <b>Tabela de links:</b>         
                           <br />        
                           <asp:Repeater id="Repeater1" runat="server">
                              <HeaderTemplate>
                                 <table class="table table-md">
                                    <thead>
                                        <tr>
                                           <td><b>Arquivo</b></td>
                                            <td><b>Dia</b></td>
                                            <td><b>Horário</b></td>
                                           <td><b>Cadeira 1</b></td>
                                            <td><b>Cadeira 2</b></td>
                                           <td><b>Cadeira 3</b></td>
                                            <td><b>Cadeira 4</b></td>
                                           <td><b>Cadeira 5</b></td>
                                            <td><b>Link</b></td>
                                        </tr>
                                     </thead>
                              </HeaderTemplate>
             
                              <ItemTemplate>
                                 <tr>
                                    <td> <%# DataBinder.Eval(Container.DataItem, "File") %> </td>
                                     <td> <%# DataBinder.Eval(Container.DataItem, "DaySession") %> </td>
                                     <td> <%# DataBinder.Eval(Container.DataItem, "TimeSession") %> </td>
                                    <td> <%# DataBinder.Eval(Container.DataItem, "Line1") %> </td>
                                     <td> <%# DataBinder.Eval(Container.DataItem, "Line2") %> </td>
                                     <td> <%# DataBinder.Eval(Container.DataItem, "Line3") %> </td>
                                     <td> <%# DataBinder.Eval(Container.DataItem, "Line4") %> </td>
                                     <td> <%# DataBinder.Eval(Container.DataItem, "Line5") %> </td>
                                     <td> <asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl='<%# DataBinder.Eval(Container.DataItem, "Link","{0}") %>'>Download</asp:HyperLink></td>

                                    
                                 </tr>
                              </ItemTemplate>
             
                              <FooterTemplate>
                                 </table>
                              </FooterTemplate>
             
                           </asp:Repeater>
                           <br />                                    
                    </div>                                                         
            
                <footer>
                    <div class="panel p-2">                                         
                            <asp:UpdatePanel ID="UpdatePanel" runat="server" UpdateMode="Conditional" 
                            ChildrenAsTriggers="true">  
                                <Triggers>
                                    <asp:PostBackTrigger  ControlID="SalvarButton"/>
                                </Triggers>
                                <ContentTemplate>
                                        <asp:Label CssClass="label-clients" Text="Selecione o arquivo de clientes" runat="server"></asp:Label>                                        
                                        <asp:FileUpload CssClass="FileUpload" ID="FileUpload1" runat="server" />
                                        <asp:Button CssClass="btn btn-dark" id="SalvarButton" Text ="Enviar" OnClick="SalvarButton_Click" runat="server"/>
                                </ContentTemplate>                                                 
                        
                            </asp:UpdatePanel>                                   
                    </div>
                </footer>
                
            </div>

    </form>

    <script src="Bootstrap/js/jquery-3.5.1.min.js"></script>
    <script src="Bootstrap/js/bootstrap.js"> </script>
</body>
</html>

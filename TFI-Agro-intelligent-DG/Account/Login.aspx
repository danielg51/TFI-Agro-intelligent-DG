<%@ Page Title="Iniciar sesión" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="TFI_Agro_intelligent_DG.Account.Login" Async="true" %>

<%@ Register Src="~/Account/OpenAuthProviders.ascx" TagPrefix="uc" TagName="OpenAuthProviders" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <h2><%: Title %>.</h2>

    <div class="row">
        <div class="col-md-8">
            <section id="loginForm">
                <div class="form-horizontal">
                    <h4>Ingrese su usuario para ingresar al portal.</h4>
                    <hr />
                    <asp:PlaceHolder runat="server" ID="ErrorMessage" Visible="false">
                        <p class="text-danger">
                            <asp:Literal runat="server" ID="FailureText" />
                        </p>
                    </asp:PlaceHolder>
                    <div class="form-group">
                        <asp:DropDownList ID="ComboLogin" runat="server">
                            <asp:ListItem Text="Intranet" Value="Intranet"></asp:ListItem>
                            <asp:ListItem Text="Cliente" Value="Cliente"></asp:ListItem>
                        </asp:DropDownList>

                     </div>
                    <asp:Login ID="ControlLogin" runat="server"  OnAuthenticate="Login_Authenticate" OnLoggingIn="Login_LoggingIn"></asp:Login>

                    <%--

                    <div class="form-group">
                                                <asp:Label runat="server" AssociatedControlID="Email" CssClass="col-md-2 control-label">Email</asp:Label>
                        <div class="col-md-10">
                            <asp:TextBox runat="server" ID="Email" CssClass="form-control" TextMode="Email" />
                            <asp:RequiredFieldValidator runat="server" ControlToValidate="Email"
                                CssClass="text-danger" ErrorMessage="Ingrese su Correo electrónico" />
                        </div>
                    </div>
                    <div class="form-group">
                        <asp:Label runat="server" AssociatedControlID="Password" CssClass="col-md-2 control-label">Contraseña</asp:Label>
                        <div class="col-md-10">
                            <asp:TextBox runat="server" ID="Password" TextMode="Password" CssClass="form-control" />
                            <asp:RequiredFieldValidator runat="server" ControlToValidate="Password" CssClass="text-danger" ErrorMessage="Ingrese su contraseña" />
                        </div>
                    </div>
                    <div class="form-group">
                        <div class="col-md-offset-2 col-md-10">
                            <div class="checkbox">
                                <asp:CheckBox runat="server" ID="RememberMe" />
                                <asp:Label runat="server" AssociatedControlID="RememberMe">Recuérdame</asp:Label>
                            </div>
                        </div>
                    </div>
                    <div class="form-group">
                        <div class="col-md-offset-2 col-md-10">
                            <asp:Button runat="server" OnClick="LogIn" Text="Iniciar" CssClass="btn btn-default" />
                        </div>
                    </div>
                </div>--%>
                <p>
                    <asp:HyperLink runat="server" ID="RegisterHyperLink" ViewStateMode="Disabled">Registrar como nuevo usuario.</asp:HyperLink>
                </p>
                <p>
                    <asp:HyperLink runat="server" ID="ForgotPasswordHyperLink" ViewStateMode="Disabled" NavigateUrl="~/Account/Forgot.aspx">¿Olvidó su contraseña?</asp:HyperLink>
                    
                </p>
            </section>
        </div>

        <div class="col-md-4">
            <section id="socialLoginForm">
                <uc:OpenAuthProviders runat="server" ID="OpenAuthLogin" />
            </section>
        </div>
    </div>
</asp:Content>

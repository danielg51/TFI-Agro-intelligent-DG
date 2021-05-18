<%@ Page Title="Confirmacion de la cuenta" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Confirm.aspx.cs" Inherits="TFI_Agro_intelligent_DG.Account.Confirm" Async="true" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <h2><%: Title %>.</h2>

    <div>
        <asp:PlaceHolder runat="server" ID="successPanel" ViewStateMode="Disabled" Visible="true">
            <p>
                Muchas gracias por confirmar su cuenta. Por favor, haga click en <asp:HyperLink ID="login" runat="server" NavigateUrl="~/Account/Login">aquí</asp:HyperLink>  para iniciar sesión.            
            </p>
        </asp:PlaceHolder>
        <asp:PlaceHolder runat="server" ID="errorPanel" ViewStateMode="Disabled" Visible="false">
            <p class="text-danger">
               Ha ocurrido un error.
            </p>
        </asp:PlaceHolder>
    </div>
</asp:Content>

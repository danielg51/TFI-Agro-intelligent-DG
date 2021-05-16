<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Catalogo.aspx.cs" Inherits="TFI_Agro_intelligent_DG.Catalogo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h1>Catálogo</h1>

    <table id="serviciosTable" class="table table-striped table-bordered" style="width:100%;">
        <thead>
            <tr>
                <th>Id</th>
                <th>Nombre</th>
                <th>Descripción</th>
            </tr>
        </thead>
    </table>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainScriptsContent" runat="server">
    <script src="//cdn.datatables.net/1.10.24/js/jquery.dataTables.min.js"></script>
    <script>
      
        $(document).ready(function () {
            $('#serviciosTable').DataTable({
                "ajax": 'https://localhost:44367/Packs'
            });
        });
    </script>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainCssContent" runat="server">
    <link href="//cdn.datatables.net/1.10.24/css/jquery.dataTables.min.css" rel="shortcut icon" type="image/x-icon" />
</asp:Content>


<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WebApplication2._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <main>
        <div>
            <!-- DropDown 1: Auto -->
            <div class="form-group">
                <label for="DropDownList1">Seleziona un'auto:</label>
                <asp:DropDownList ID="DropDownList1" runat="server" CssClass="form-control" AutoPostBack="true" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged"></asp:DropDownList>
                <p id="basePrice" runat="server"></p>
            </div>

            <!-- DropDown 2: Optional -->
            <div class="form-group">
                <label for="DropDownList2">Seleziona gli optional:</label>
                <asp:DropDownList ID="DropDownList2" runat="server" CssClass="form-control" Multiple="true"></asp:DropDownList>
            </div>

            <!-- DropDown 3: Anni di garanzia -->
            <div class="form-group">
                <label for="DropDownList3">Seleziona gli anni di garanzia:</label>
                <asp:DropDownList ID="DropDownList3" runat="server" CssClass="form-control"></asp:DropDownList>
            </div>

            <!-- Pulsante per calcolare e stampare i totali -->
            <asp:Button ID="Button1" runat="server" Text="Calcola e Stampa Totali" CssClass="btn btn-primary" OnClick="Button1_Click" />
            
            <!-- Risultati -->
            <div class="mt-3">
                <h4>Risultati:</h4>
                <p id="basePriceResult" runat="server"></p>
                <p id="optionalTotalResult" runat="server"></p>
                <p id="warrantyTotalResult" runat="server"></p>
            </div>
        </div>
     <div id="PlaceHolder1" runat="server"></div>

    </main>
</asp:Content>

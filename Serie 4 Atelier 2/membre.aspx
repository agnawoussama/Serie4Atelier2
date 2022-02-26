<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="membre.aspx.cs" Inherits="Serie_4_Atelier_2.membre" %>

<!DOCTYPE html>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link rel="preconnect" href="https://fonts.googleapis.com">
    <link rel="preconnect" href="https://fonts.gstatic.com" crossorigin>
    <link href="https://fonts.googleapis.com/css2?family=Lato:wght@300&display=swap" rel="stylesheet">
    <title></title>
    <style type="text/css">
        body{
            background: #f12711;  /* fallback for old browsers */
            background: -webkit-linear-gradient(to right, #f5af19, #f12711);  /* Chrome 10-25, Safari 5.1-6 */
            background: linear-gradient(to right, #f5af19, #f12711); /* W3C, IE 10+/ Edge, Firefox 16+, Chrome 26+, Opera 12+, Safari 7+ */
            font-family: 'Lato', sans-serif;
        }

        #formMembre{
            display: flex;
            justify-content: center;
            align-items: center;
            height: 100vh;
        }

        #container{
            border: 2px solid #0000001a;
            padding: 20px;
            border-radius: 28px;
            background-color: #a52a2a47;
            width: 45%;
        }

        #Label1, #Label2, #Label3,#Label4, #Label5, #Label6 {
            display: inline-block;
            width: 30%;
            font-size: 1.3rem;
            width: 25%;
            color: aliceblue;
        }

        #login, #mdp1, #mdp2, #calendar, #txtbxEmail, #txtbxNom {
            height: 1.5rem;
            width: 70%;
            border-radius: 21px;
            border: none;
            padding: 8px;
            font-family: inherit;
            font-size: 1.5rem;
            background-color: bisque;
            margin-bottom: 20px;
        }


        #Links, #Links2{
            display: flex;
            justify-content: space-between;
        }

        #linkModif, #LinkEnreg{                   
            text-decoration: none;
            font-size: 1.3em;
            color: black;
            padding: 10px;
            flex: 1;
            background-color: #e3eda1ad;
            border-radius: 15px;
            text-align: center;            
        }

        #lblLoginError, #lblMdp1Error, #lblMdp2Error, #lblEmailFormat, #lblLoginExists{
            color: #fae880;
            display: block;
            text-align: center;
        }
    </style>
</head>
<body>
    <form id="formMembre" runat="server">
        <div id="container">
            <h1 style="margin:0; font-size:2.5rem; color: aliceblue; text-align: center ">Votre Informations</h1>
            <br />
            <asp:Label ID="Label1" runat="server" Text="Login"></asp:Label>
            <asp:TextBox ID="login" runat="server"></asp:TextBox>
            <asp:Label ID="lblLoginExists" runat="server" Visible="false" Text="Ce login existe deja"></asp:Label>
            <asp:Label ID="lblLoginError" runat="server" Visible="false" Text="Veuillez Remplir les champs S'il vous plait"></asp:Label>
            <br />
            <asp:Label ID="Label2" runat="server" Text="Mot de Passe"></asp:Label>
            <input id="mdp1" type="password" runat="server" />
            <asp:Label ID="lblMdp1Error" runat="server" Visible="false" Text="le mot de passe doit etre superieur a 6 caracters"></asp:Label>
            <br />
            <asp:Label ID="Label3" runat="server" Text="Mot de Passe x2"></asp:Label>
            <input id="mdp2" type="password" runat="server" />
            <asp:Label ID="lblMdp2Error" runat="server" Visible="false" Text="Les deux mot de passe sont pas identiques<br>"></asp:Label>
            <br />
            <asp:Label ID="Label4" runat="server" Text="Email"></asp:Label>
            <asp:TextBox ID="txtbxEmail" runat="server"></asp:TextBox>
            <asp:Label ID="lblEmailFormat" runat="server" Visible="false" Text="Ladresse email est incorrect"></asp:Label>
            <br />
            <asp:Label ID="Label5" runat="server" Text="Nom"></asp:Label>
            <asp:TextBox ID="txtbxNom" runat="server"></asp:TextBox>
            <br />
            <asp:Label ID="Label6" runat="server" Text="Date de Naissance"></asp:Label>
            <input id="calendar" type="date" runat="server"/>
            <br />
            <div id="Links">
                <asp:LinkButton ID="linkModif" runat="server" OnClick="linkModif_Click">Modifier</asp:LinkButton>
            </div>
            <br />
            <div id="Links2">
                <asp:LinkButton ID="LinkEnreg" runat="server" OnClick="LinkEnreg_Click">Enregistrer</asp:LinkButton>
            </div>
        </div>
    </form>
</body>
</html>

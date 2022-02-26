<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="Serie_4_Atelier_2.index" %>

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

        #formIndex{
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
        }

        #Label1, #Label2 {
            display: inline-block;
            width: 30%;
            font-size: 1.3rem;
            width: 25%;
            color: aliceblue;
        }

        #login, #password {
            height: 1.5rem;
            width: 70%;
            border-radius: 21px;
            border: none;
            padding: 8px;
            font-family: inherit;
            font-size: 1.5rem;
            background-color: bisque;
        }

        #login{
            margin-bottom: 20px;
        }
        #Links{
            display: flex;
            justify-content: space-between;
        }
        #linkLogin{
            flex: auto;
            text-align: center;
            background-color: #ade5abad;
            border-radius: 15px 0px 0px 15px;
        }
        #linkInscr, #linkLogin{                   
            text-decoration: none;
            font-size: 1.3em;
            color: black;
            padding: 10px;
        }
        #linkInscr{
            flex: 1;
            background-color: #e3eda1ad;
            border-radius: 0px 15px 15px 0px;
            text-align: center;            
        }
    </style>
</head>
<body>
    <form id="formIndex" runat="server">
        <div id="container">
            <h1 style="margin:0; font-size:2.5rem; color: aliceblue ">Bienvenue Au Espace Membre</h1>
            <br />
            <asp:Label ID="Label1" runat="server" Text="Login"></asp:Label>
            <asp:TextBox ID="login" runat="server"></asp:TextBox>
            <br />
            <asp:Label ID="Label2" runat="server" Text="Mot de Passe"></asp:Label>
            <input id="password" type="password" runat="server" />
            <br /><br />
            <div id="Links">
                <asp:LinkButton ID="linkLogin" runat="server" OnClick="linkLogin_Click">Login</asp:LinkButton>
                <asp:LinkButton ID="linkInscr" runat="server" OnClick="linkInscr_Click">Créer un compte</asp:LinkButton>
            </div>
        </div>
    </form>
</body>
</html>

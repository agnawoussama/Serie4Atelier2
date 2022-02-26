using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Serie_4_Atelier_2
{
    public partial class index : System.Web.UI.Page
    {
        //Page Load
        protected void Page_Load(object sender, EventArgs e)
        {

        }


        //Bouton Login
        protected void linkLogin_Click(object sender, EventArgs e)
        {
            //Instancier un objet ado 
            AdoClass ado = new AdoClass();
            try
            {
                //Remplir l'objet commad par la requette
                ado.command = new System.Data.SqlClient.SqlCommand("Select * from Membres where loginn = @login and motPass = @mdp", ado.connection);
                ado.command.Parameters.AddWithValue("@login", login.Text);
                ado.command.Parameters.AddWithValue("@mdp", password.Value);
                //On ouvre la connexion
                ado.Connecter();
                //On excecute la requette qui va nous retourner un objet SqlDataReader
                //Et on stock ce resultat dans notre objet reader
                ado.reader = ado.command.ExecuteReader();
                //Si notre objet a trouver un ligne=>
                if (ado.reader.Read())
                {                   
                    Session["login"] = ado.reader[0].ToString();
                    Response.Redirect("~/membre.aspx");
                }
                //Si notre objet n'a pas trouver un ligne=>
                else
                {
                    Response.Write("Veulleiz saisir login et le mot de passe corrects");
                }
            //En cas d'exception
            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);
            }
            //Et finalement on ferme la connexion
            finally
            {
                ado.Deconnecter();
            }            
        }

        //Bouton Creer un compte
        protected void linkInscr_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/inscription.aspx");
        }
    }
}
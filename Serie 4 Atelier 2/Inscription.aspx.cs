using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Serie_4_Atelier_2
{
    public partial class Inscription : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        //Fonction qui verifie si le login existe
        private bool verifierLogin()
        {
            AdoClass ado = new AdoClass();
            //Cette requette calcule le nombre de login qui l'utilisateur a entre
            //Normalement on doit recevoir sois 1 sois 0 parceque le loginn est un cle primaire
            ado.command = new System.Data.SqlClient.SqlCommand("Select Count(*) from Membres where loginn = @login", ado.connection);
            ado.command.Parameters.AddWithValue("@login", login.Text);
            ado.Connecter();
            //Si on trouve le login dans la table Membres=>
            if ((int)ado.command.ExecuteScalar() == 1)
            {
                //On retourne true
                ado.Deconnecter();
                return true;
            }
            else
            {
                //Sinon On retourne false
                ado.Deconnecter();
                return false;
            }
        }

        //Function qui verifie si tous les champs sont remplis
        private bool verifierChamps()
        {
            return login.Text != "" && mdp1.Value != "" && mdp2.Value != "" && txtbxEmail.Text != "" && calendar.Value != "";
        }

        //Function qui verifie si la longeur de mot de passe est superieur a 6 caracters
        private bool verifierMdpLentgh()
        {
            return mdp1.Value.Length >= 6;
        }

        //Function qui verifie si les deux mot de passes sont identiques
        private bool verifierMdp()
        {
            return mdp1.Value == mdp2.Value;
        }

        //Function qui verifie si les deux mot de passes sont identiques
        private bool verifierEmail()
        {
            return txtbxEmail.Text.Contains("@");
        }


        //Bouton Enregistrer
        protected void linkEnreg_Click(object sender, EventArgs e)
        {
            //Cacher tous les errors
            lblLoginExists.Visible = lblLoginError.Visible = lblMdp1Error.Visible = lblMdp2Error.Visible = false;
            //Si on trouve le login deja existe=>
            if (verifierLogin())
            {   //On affiche le message d'erreur de login
                lblLoginExists.Visible = true;
            }
            //Sinon on creer un nouveau login
            else
            {
                //On considere que tous va bien
                bool tousVaBien = true;
                //mais dabord on dois verifier certain verifications ==>
                //1_Si l'un ou plusieurs des champs ne sont pas remplis
                if (!verifierChamps())
                {
                    lblLoginError.Visible = true;
                    tousVaBien = false;
                }
                //2_Si la longeur de mot de passe est inferieur a 6 caracters
                if (!verifierMdpLentgh())
                {
                    lblMdp1Error.Visible = true;
                    tousVaBien = false;
                }
                //3_Si les deux mot de passe ne sont pas identiques
                if (!verifierMdp())
                {
                    lblMdp2Error.Visible = true;
                    tousVaBien = false;
                }

                //4_Si l'email n'est pas valide
                if (!verifierEmail())
                {
                    lblEmailFormat.Visible = true;
                    tousVaBien = false;
                }
                //Le boolean tousVaBien indique si il ya un probleme on le rend false
                //Sinon si tous va bien on doit ajouter ce membre dans la base de donnes
                if (tousVaBien)
                {
                    //Instancier un objet ado 
                    AdoClass ado = new AdoClass();
                    try
                    {                        
                        //Inertion de ces donnes dans la table Membres dans la base de donnes
                        ado.command = new System.Data.SqlClient.SqlCommand("INSERT INTO Membres VALUES (@login, @mdp, @nom, @email, @dateNaiss)", ado.connection);
                        ado.command.Parameters.AddWithValue("@login", login.Text);
                        ado.command.Parameters.AddWithValue("@mdp", mdp1.Value);
                        ado.command.Parameters.AddWithValue("@nom", txtbxNom.Text);
                        ado.command.Parameters.AddWithValue("@email", txtbxEmail.Text);
                        ado.command.Parameters.AddWithValue("@dateNaiss", calendar.Value);
                        //On ouvre la connexion
                        ado.Connecter();
                        ado.command.ExecuteNonQuery();
                    }
                    //En cas d'exception
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
            }
        }




    }
}
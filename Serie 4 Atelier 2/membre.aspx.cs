using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Serie_4_Atelier_2
{
    public partial class membre : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //Si La premiere foix
            if (!IsPostBack)
            {
                //Si le variable de session a une valeur =>
                if (Session["login"] != null)
                {
                    //Instancier un objet ado 
                    AdoClass ado = new AdoClass();
                    try
                    {
                        //Inertion de ces donnes dans la table Membres dans la base de donnes
                        ado.command = new System.Data.SqlClient.SqlCommand("Select * From Membres where loginn = @login", ado.connection);
                        ado.command.Parameters.AddWithValue("@login", Session["login"].ToString());
                        //On ouvre la connexion
                        ado.Connecter();
                        //On excecute la commande
                        ado.reader =  ado.command.ExecuteReader();
                        //On lit le premier et le seul ligne
                        ado.reader.Read();  
                        //Et on remplie tous les champs
                        login.Text = ado.reader[0].ToString();
                        txtbxNom.Text = ado.reader[2].ToString();
                        txtbxEmail.Text = ado.reader[3].ToString();                                       
                        calendar.Value = Convert.ToDateTime(ado.reader[4].ToString()).ToString("yyyy-MM-dd");
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
                    //On desactive tous les champs
                    login.Enabled = txtbxEmail.Enabled = txtbxNom.Enabled = false;
                    mdp1.Disabled = mdp2.Disabled = calendar.Disabled = true;
                }
                //Sinon si il est vide (ça veut dire que l'utilisateur a entre a cette page directement =>
                else
                {
                    //On le réoriente vers le page login
                    Response.Redirect("~/index.aspx");
                }            
            }
        }

        protected void linkModif_Click(object sender, EventArgs e)
        {
            //On active tous les champs mais le login reste desactive
            txtbxEmail.Enabled = txtbxNom.Enabled = true;
            mdp1.Disabled = mdp2.Disabled = calendar.Disabled = false;
        }

        protected void LinkEnreg_Click(object sender, EventArgs e)
        {
            //Instancier un objet ado 
            AdoClass ado = new AdoClass();
            try
            {
                //Inertion de ces donnes dans la table Membres dans la base de donnes
                ado.command = new System.Data.SqlClient.SqlCommand("UPDATE Membres SET" +
                    "  motPass = @mdp, nom = @nom, email =  @email, dateNaissance = @dateNaiss " +
                    "  where loginn = @login", ado.connection);
                ado.command.Parameters.AddWithValue("@mdp", mdp1.Value);
                ado.command.Parameters.AddWithValue("@nom", txtbxNom.Text);
                ado.command.Parameters.AddWithValue("@email", txtbxEmail.Text);
                ado.command.Parameters.AddWithValue("@dateNaiss", calendar.Value);
                //On ouvre la connexion
                ado.Connecter();
                //On excecute la commande
                ado.reader = ado.command.ExecuteReader();
                //On lit le premier et le seul ligne
                ado.reader.Read();
                //Et on remplie tous les champs
                login.Text = ado.reader[0].ToString();
                txtbxNom.Text = ado.reader[2].ToString();
                txtbxEmail.Text = ado.reader[3].ToString();
                calendar.Value = Convert.ToDateTime(ado.reader[4].ToString()).ToString("yyyy-MM-dd");
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
            //On desactive tous les champs
            txtbxEmail.Enabled = txtbxNom.Enabled = false;
            mdp1.Disabled = mdp2.Disabled = calendar.Disabled = true;
        }
    }
}
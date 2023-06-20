using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Xml.Linq;

namespace MATINFO
{
    /// <summary>
    /// Logique d'interaction pour FenêtreAjout.xaml
    /// </summary>
    public partial class FenêtreAjout : Window
    {
        public event Action<string, string> ValiderClicked;
        public FenêtreAjout()
        {
            InitializeComponent();

        }

        public class Personne
        {
            public string Nom { get; set; }
            public string Prénom { get; set; }
        }



        private void btValider_Click(object sender, RoutedEventArgs e)
        {
            string nom = tbNom.Text;
            string prenom = tbPrenom.Text;

            ValiderClicked?.Invoke(nom, prenom);

            this.Close();

            if (tbAttribution.Text == "")
            {
                MessageBox.Show("Erreur, vous ne pouvez pas le laisser vide ", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
                Close();
            }
            else
            {
                //on demande a l'utilisateur de rentrer une chaine de caractères, dans la textbox
                string attributionName = tbAttribution.Text;
                string categorieName = tbCategorie.Text;
                string materielName = tbMateriel.Text;
                string personneName = tbPrenom.Text;
                string personnelName = tbNom.Text;

                //on récupère la chaine de caractère, saisi précédemment (Invoke)
                AttributionAjout?.Invoke(attributionName);
                CategorieAjout?.Invoke(categorieName);
                MatérielAjout?.Invoke(materielName);
                PersonneAjout?.Invoke(personneName);

                //on ferme la fenêtre
                Close();
            }
        }

        public event Action<string> AttributionAjout;
        public event Action<string> CategorieAjout;
        public event Action<string> MatérielAjout;
        public event Action<string> PersonneAjout;


        private void tbNom_TextChanged(object sender, TextChangedEventArgs e)
        {
      

        }
    }
}

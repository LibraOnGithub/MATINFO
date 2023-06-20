using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace MATINFO
{
    public partial class FenêtreAjout : Window
    {
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public string Mail => $"{Prenom?.ToLower()}.{Nom?.ToLower()}@etu.univ-smb.fr";

        public FenêtreAjout()
        {
            InitializeComponent();
            DataContext = this;
        }

        private void btValider_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(tbNom.Text) || string.IsNullOrEmpty(tbPrenom.Text))
            {
                MessageBox.Show("Veuillez saisir un nom et un prénom.", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            Nom = tbNom.Text;
            Prenom = tbPrenom.Text;
            Close();
        }
    }
}

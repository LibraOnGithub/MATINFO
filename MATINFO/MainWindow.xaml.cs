using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MATINFO
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            personnes = new ObservableCollection<Personne>();
            lvPersonne.ItemsSource = personnes;


        }

        public class Personne
        {
            public string Nom { get; set; }
            public string Prenom { get; set; }
            public string Mail => $"{Prenom.ToLower()}.{Nom.ToLower()}@etu.univ-smb.fr";
            
        }        
        
        private ObservableCollection<Personne> personnes;
        



        private void BtAjouter_Click(object sender, RoutedEventArgs e)
        {
            FenêtreAjout ajout = new FenêtreAjout();
            ajout.Show();

            ajout.AttributionAjout += (attributionName) => lvAttribution.Items.Add(attributionName);
            ajout.CategorieAjout += (categorieName) => lvCategorie.Items.Add(categorieName);
            ajout.MatérielAjout += (materielName) => lvMatériel.Items.Add(materielName);

            ajout.tbAttribution.Text = lvAttribution.DisplayMemberPath;
            ajout.tbCategorie.Text = lvCategorie.DisplayMemberPath;
            ajout.tbMateriel.Text = lvMatériel.DisplayMemberPath;
            ajout.ValiderClicked += (nom, prenom) =>
            {
              Personne personne1 = new Personne
               {
                   Nom = nom,
                 Prenom = prenom
                };

               personnes.Add(personne1);

            };

            ajout.Show();



            Personne personne = new Personne
            {
                Nom = ajout.tbNom.Text,
                Prenom = ajout.tbPrenom.Text,


            };
            personnes.Add(personne);


                lvPersonne.ItemsSource = personnes;
            ajout.Show();
        }


        private void BtSupprimer_Click(object sender, RoutedEventArgs e)
        {
            if (lvAttribution.SelectedItem != null)
            {
                MessageBoxResult result = MessageBox.Show("Êtes-vous sûr de vouloir supprimer l'attribution ?", "MATINFO", MessageBoxButton.YesNo, MessageBoxImage.Question, MessageBoxResult.No);
                switch (result)
                {
                    case MessageBoxResult.Yes:
                        lvAttribution.Items.Remove(lvAttribution.SelectedItem);
                        break;
                    case MessageBoxResult.No:
                        break;

                }
            }

            if (lvCategorie.SelectedItem != null)
            {
                MessageBoxResult result = MessageBox.Show("Êtes-vous sûr de vouloir supprimer la catégorie ?", "MATINFO", MessageBoxButton.YesNo, MessageBoxImage.Question, MessageBoxResult.No);
                switch (result)
                {
                    case MessageBoxResult.Yes:
                        lvCategorie.Items.Remove(lvCategorie.SelectedItem);
                        break;
                    case MessageBoxResult.No:
                        break;

                }
            }

            if (lvMatériel.SelectedItem != null)
            {
                MessageBoxResult result = MessageBox.Show("Êtes-vous sûr de vouloir supprimer le matériel ?", "MATINFO", MessageBoxButton.YesNo, MessageBoxImage.Question, MessageBoxResult.No);
                switch (result)
                {
                    case MessageBoxResult.Yes:
                        lvMatériel.Items.Remove(lvMatériel.SelectedItem);
                        break;
                    case MessageBoxResult.No:
                        break;

                }
            }

            if (lvPersonne.SelectedItem != null)
            {
                MessageBoxResult result = MessageBox.Show("Êtes-vous sûr de vouloir supprimer la personne ?", "MATINFO", MessageBoxButton.YesNo, MessageBoxImage.Question, MessageBoxResult.No);
                switch (result)
                {
                    case MessageBoxResult.Yes:
                        lvPersonne.Items.Remove(lvPersonne.SelectedItem); 
                        break;
                    case MessageBoxResult.No:
                        break;

                }
            }
        }

 


        private void lvPersonne_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void BtModifier_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
           //// string nomRecherche = txtNomRecherche.Text;

           // if (!string.IsNullOrWhiteSpace(nomRecherche))
           // {
           //     Personne personneTrouvee = personnes.FirstOrDefault(p => p.Nom.Equals(nomRecherche, StringComparison.OrdinalIgnoreCase));

           //     if (personneTrouvee != null)
           //     {
           //         // La personne a été trouvée, vous pouvez effectuer les actions souhaitées ici
           //         MessageBox.Show($"La personne {personneTrouvee.Nom} {personneTrouvee.Prenom} a été trouvée.");
           //     }
           //     else
           //     {
           //         // Aucune personne trouvée avec le nom spécifié
           //         MessageBox.Show("Aucune personne trouvée avec ce nom.");
           //     }
           // }
           // else
           // {
           //     // Le champ de recherche est vide
           //     MessageBox.Show("Veuillez entrer un nom de personne à rechercher.");
           // }

        }
    }
}

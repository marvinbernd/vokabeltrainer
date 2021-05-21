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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Vokabeltrainer
{
  /// <summary>
  /// Interaktionslogik für MainWindow.xaml
  /// </summary>
  public partial class MainWindow : Window
  {
        private Trainer meinTrainer = new Trainer();
    
        public MainWindow()
        {
          InitializeComponent();
        }
        
        private void btnLoad_Click(object sender, RoutedEventArgs e)
        {
            new Vokabel("warum", "why");
            new Vokabel("Tisch", "table");
            new Vokabel("Buch", "book");
            new Vokabel("Auto", "car");
            new Vokabel("schreiben", "write");

            MessageBox.Show("Vokabeln geladen!");
        }

        private void btnStart_Click(object sender, RoutedEventArgs e)
        {
            meinTrainer.PruefVokabeln = Vokabel.AlleVokabeln;
            meinTrainer.StarteDurchlauf();
            txtVokabel.Text = meinTrainer.GetNaechsteVokabel().Deutsch;
        }

        private void btnShow_Click(object sender, RoutedEventArgs e)
        {
            txtLoesung.Text = meinTrainer.AktuelleVokabel.Fremdsprache;
        }

        private void btnNext_Click(object sender, RoutedEventArgs e)
        {
            txtVokabel.Text = meinTrainer.GetNaechsteVokabel().Deutsch;
            txtEingabe.Clear();
            txtLoesung.Clear();
        }
    }
}

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
          btnLoad.Focus();
        }
        
        private void btnLoad_Click(object sender, RoutedEventArgs e)
        {
            new Vokabel("warum", "why");
            new Vokabel("Tisch", "table");
            new Vokabel("Buch", "book");
            new Vokabel("Auto", "car");
            new Vokabel("schreiben", "write");

            MessageBox.Show("Vokabeln geladen!");

            btnLoad.IsEnabled = false;
            btnStart.IsEnabled = true;
            btnStart.Focus();
        }

        private void btnStart_Click(object sender, RoutedEventArgs e)
        {
            meinTrainer.PruefVokabeln = Vokabel.AlleVokabeln;
            meinTrainer.StarteDurchlauf();
            txtVokabel.Text = meinTrainer.GetNaechsteVokabel().Deutsch;

            btnStart.IsEnabled = false;
            txtEingabe.IsEnabled = true;
            btnShow.IsEnabled = true;
            btnNext.IsEnabled = true;
            txtEingabe.Focus();
        }

        private void btnShow_Click(object sender, RoutedEventArgs e)
        {
            txtLoesung.Text = meinTrainer.AktuelleVokabel.Fremdsprache;

            txtEingabe.Background = (txtEingabe.Text == meinTrainer.AktuelleVokabel.Fremdsprache) 
                ? Brushes.Green : Brushes.Red;

            btnNext.Focus();
        }

        private void btnNext_Click(object sender, RoutedEventArgs e)
        {
            txtVokabel.Text = meinTrainer.GetNaechsteVokabel().Deutsch;
            txtEingabe.Clear();
            txtLoesung.Clear();
            txtEingabe.Background = SystemColors.WindowBrush;
            txtEingabe.Focus();
        }

        private void txtEingabe_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                e.Handled = true;
                btnShow.RaiseEvent(new RoutedEventArgs(Button.ClickEvent));
            }
        }
    }
}

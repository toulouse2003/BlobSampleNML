using System.Windows;

namespace BlobSampleNML {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {
        public MainWindow() {
            InitializeComponent();
        }

        private void button_Click(object sender, RoutedEventArgs e) {
            Window1 win1 = new Window1();
            win1.ShowDialog();
        }

        private void button1_Click(object sender, RoutedEventArgs e) {
            Window2 win2 = new Window2();
            win2.ShowDialog();
        }
    }
}

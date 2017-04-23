using BlobSampleLib;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace BlobSampleNML {
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window {

        public Window1() {
            InitializeComponent();
            Employee.emps2List();
            emps2Combo(Employee.employees);
        }

        private void button_Click(object sender, RoutedEventArgs e) {
            DateTime theDate = (DateTime)dpDato.SelectedDate;
            ComboBoxItem ComboItem = (ComboBoxItem) cbxChef.SelectedItem;
            int theBoss = Convert.ToInt32(ComboItem.Tag);
            Employee em = new Employee(0, txbFornavn.Text, txbEfternavn.Text
                                    , txbStilling.Text, theDate, theBoss
                                    , txbFoto.Text);
            em.emp2Db();
            this.Close();
        }

        private void emps2Combo(List<Employee> l) {
            cbxChef.Items.Clear();
            foreach (Employee e in l) {
                ComboBoxItem item = new ComboBoxItem();
                item.Content = e.ToString();
                item.Tag = e.getId();
                cbxChef.Items.Add(item);
            }
        }

        private void btnBrowse_Click(object sender, RoutedEventArgs e) {
            // Create OpenFileDialog 
            Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();

            // Set filter for file extension and default file extension 
            dlg.DefaultExt = ".png";
            dlg.Filter = "JPG Files (*.jpg)|*.jpg|PNG Files (*.png)|*.png|JPEG Files (*.jpeg)|*.jpeg|GIF Files (*.gif)|*.bmp|BMP Files (*.bmp)|*.bmp";

            // Display OpenFileDialog by calling ShowDialog method 
            Nullable<bool> result = dlg.ShowDialog();

            // Get the selected file name and display in a TextBox 
            if (result == true) {
                // Open document 
                string filename = dlg.FileName;
                txbFoto.Text = filename;
            }
        }
    }
}
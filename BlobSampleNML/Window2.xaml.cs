using BlobSampleLib;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace BlobSampleNML {
    /// <summary>
    /// Interaction logic for Window2.xaml
    /// </summary>
    /* ref http://stackoverflow.com/questions/8084590/how-to-load-image-from-sql-server-into-picture-box */

    public partial class Window2 : Window {
        public Window2() {
            InitializeComponent();
            Employee.emps2List();
            emps2Combo(Employee.employees);
        }

        private void emps2Combo(List<Employee> l) {
            cbxEmployees.Items.Clear();
            foreach (Employee e in l) {
                ComboBoxItem item = new ComboBoxItem();
                item.Content = e.ToString();
                item.Tag = e.getId();
                cbxEmployees.Items.Add(item);
            }
        }

        private void comboBox_SelectionChanged(object sender, SelectionChangedEventArgs e) {
            ComboBoxItem ComboItem = (ComboBoxItem) cbxEmployees.SelectedItem;
            int theWho = Convert.ToInt32(ComboItem.Tag);
            Employee em = Employee.empFromList(theWho);
            lblName.Content = em.getName();
            lblTitle.Content = em.getTitle();
            DateTime dateAndTime = em.getHiredate();
            lblHired.Content = dateAndTime.Date.ToString().Substring(0,10);
            imgImage.Source = ToImage(em.getImageData());
        }
        public BitmapImage ToImage(byte[] array) {
            BitmapImage image = new BitmapImage();
            image.BeginInit();
            image.StreamSource = new System.IO.MemoryStream(array);
            image.EndInit();
            return image;
        }
        private void button_Click(object sender, RoutedEventArgs e) {
            this.Close();
        }
    }
}

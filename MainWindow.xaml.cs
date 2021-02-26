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
using System.Net;
using System.Data;
using Microsoft.Win32;
using System.IO;

namespace Database_Connector
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Execute_Click(object sender, RoutedEventArgs e)
        {
            if (combo.SelectedIndex == 0)
            {
                Server sql = new Server(user.Text, passsword.Password.ToString(), ip.Text, db.Text);
                DataTable table = sql.RunSQLQuery(input.Text);
                if (table.Rows.Count == 0)
                {
                    MessageBox.Show("No Data Received");
                }
                output.ItemsSource = table.DefaultView;
            }
            else if (combo.SelectedIndex == 1)
            {
                Server sql = new Server(user.Text, passsword.Password.ToString(), ip.Text, db.Text);
                DataTable table = sql.Runpsql(input.Text);
                if (table.Rows.Count == 0)
                {
                    MessageBox.Show("No Data Received");
                }
                output.ItemsSource = table.DefaultView;
            }
        }

        private void OpenQuery(object sender, RoutedEventArgs e)
        {
           OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == true)
                input.Text = File.ReadAllText(openFileDialog.FileName);
        }
    }
}

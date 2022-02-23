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

namespace JobApplicationTracker
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// 

    

    public partial class MainWindow : Window
    {

        public List<JobApp> jobApps = new List<JobApp>();


        public MainWindow()
        {
            InitializeComponent();


            UpdateBinding();
        }

        private void UpdateBinding()
        {
            // Binds a collection of IEnumerable to the ListBox control
            listBox1.ItemsSource = jobApps;
            listBox1.DisplayMemberPath = "FullInfo";
        }

        private void SubmitButton_Click(object sender, RoutedEventArgs e)
        {
            //MessageBox.Show($"Hello { firstNameText.Text }");

            //Error checking - All forms have input, date is correct format(add drop-down calendar to select date?)
            DataAccess db = new DataAccess();

            db.InsertJobApp(companyText.Text, positionText.Text, locationText.Text, linkText.Text);

            companyText.Text = "";
            positionText.Text = "";
            locationText.Text = "";
            linkText.Text = "";

        }

        private void searchText_TextChanged(object sender, TextChangedEventArgs e)
        {
            DataAccess db = new DataAccess();

            // Override list of job apps with search results
            jobApps = db.GetJobApp(searchText.Text);

            UpdateBinding();
        }
    }

    //Feature to add
    //Add combobox to scroll thru job application entries?
    //Be able to search for application by date or company name and return all information

}

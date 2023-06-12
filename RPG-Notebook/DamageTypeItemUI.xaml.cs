using System;
using System.Diagnostics;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace RPG_Notebook
{
    /// <summary>
    /// Interaction logic for DamageTypeItemUI.xaml
    /// </summary>
    public partial class DamageTypeItemUI : UserControl
    {
        MainWindow controller;
        string name;

        public DamageTypeItemUI(string name, string imgURL, MainWindow controller)
        {
            InitializeComponent();
            this.name = name;
            type_name.Content = name;
            Trace.WriteLine(imgURL);
            BitmapImage img = new(new Uri(imgURL));
            type_image.Source = img;
            this.controller = controller;
        }

        private void Choose_type(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            controller.ChangeSelectedType(name);
        }
    }
}

using System;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace RPG_Notebook
{
    /// <summary>
    /// Interaction logic for ResItemUI.xaml
    /// </summary>
    public partial class ResItemUI : UserControl
    {
        public ResItemUI(string imagepath, string value, bool isImmune)
        {
            InitializeComponent();
            BitmapImage img = new(new Uri(imagepath));
            res_item_image.Source = img;
            if (isImmune)
            {
                res_item_value.Content = "Immune";
            }
            else
            {
                res_item_value.Content = value;
            }
        }
    }
}

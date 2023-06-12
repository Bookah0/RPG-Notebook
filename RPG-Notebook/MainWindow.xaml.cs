using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using static RPG_Notebook.EnemyData;

namespace RPG_Notebook
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        EnemyData enemyData;

        public MainWindow()
        {
            InitializeComponent();
            enemyData = new EnemyData();
            res_add_modalpanel.Visibility = Visibility.Hidden;
            res_type_modalpanel.Visibility = Visibility.Hidden;

        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        // Open and close modal panels
        private void OpenResPanels(object sender, RoutedEventArgs e)
        {
            res_add_modalpanel.Visibility = Visibility.Visible;
        }

        internal void ChangeSelectedType(string typeName)
        {
            foreach (DamageType type in enemyData.types)
            {
                if (typeName.Equals(type.name))
                {
                    BitmapImage img = new(new Uri(type.imgURL));
                    selected_res_image.Source = img;
                    selected_res_type.Content = type.name;
                }
            }
        }

        private void CloseResPanels(object sender, RoutedEventArgs e)
        {
            res_add_modalpanel.Visibility = Visibility.Hidden;
        }

        private void OpenTypesPanels(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            res_type_modalpanel.Visibility = Visibility.Visible;
        }

        private void AddResToWarp(object sender, RoutedEventArgs e)
        {
            string type = selected_res_type.Content.ToString() ?? "";
            string value = res_amount.Text;
            bool isImmune = immune_checkbox.IsChecked ?? false;
            string imageURL = selected_res_image.Source.ToString() ?? "";
            Trace.WriteLine(type + " " + value + " " + isImmune.ToString() + " " + imageURL);
            enemyData.AddRes(type, imageURL, value, isImmune);
            UpdateResWarpPanel();
            //res_add_modalpanel.Visibility = Visibility.Hidden;
        }

        private void UpdateResWarpPanel()
        {
            res_overview_wrappanel.Children.Clear();
            foreach (KeyValuePair<string, Resistance> entry in enemyData.resistances)
            {
                var res = entry.Value;
                ResItemUI resItem = new(res.imageURL, res.value, res.isImmune);
                res_overview_wrappanel.Children.Add(resItem);
            }
        }

        private void UpdateResTypesWarpPanel(List<DamageType.Type> filteredTypes)
        {
            res_types_wrappanel.Children.Clear();
            foreach (DamageType dmgType in enemyData.types)
            {
                if (filteredTypes.Contains(dmgType.type))
                {
                    res_types_wrappanel.Children.Add(new DamageTypeItemUI(dmgType.name, dmgType.imgURL, this));
                }
            }
        }

        private void filter_checked(object sender, RoutedEventArgs e)
        {
            var checkedTypes = new List<DamageType.Type>();
            if (res_filter_physical.IsChecked.Value || res_filter_all.IsChecked.Value)
            {
                checkedTypes.Add(DamageType.Type.melee);
            }
            if (res_filter_magic.IsChecked.Value || res_filter_all.IsChecked.Value)
            {
                checkedTypes.Add(DamageType.Type.magic);
            }
            if (res_filter_conditions.IsChecked.Value || res_filter_all.IsChecked.Value)
            {
                checkedTypes.Add(DamageType.Type.condition);
            }

            UpdateResTypesWarpPanel(checkedTypes);
        }

        private void Open(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {

        }
    }
}

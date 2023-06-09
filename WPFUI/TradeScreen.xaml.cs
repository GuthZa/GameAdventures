﻿using System;
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
using System.Windows.Shapes;
using Engine.Models;
using Engine.ViewModels;

namespace WPFUI
{
    /// <summary>
    /// Interaction logic for TradeScreen.xaml
    /// </summary>
    public partial class TradeScreen : Window
    {
        public GameSession Session => DataContext as GameSession;
        public TradeScreen()
        {
            InitializeComponent();
        }
        public void OnClick_Sell(object sender, RoutedEventArgs e)
        {
            //FrameworkElement sender gets the row on which the button was clicked
            GroupedInventoryItem groupedInventoryItem = ((FrameworkElement)sender).DataContext as GroupedInventoryItem;
            if(groupedInventoryItem !=null)
            {
                Session.CurrentPlayer.ReceiveGold(groupedInventoryItem.Item.Price);
                Session.CurrentPlayer.RemoveItemFromInventory(groupedInventoryItem.Item);
                Session.CurrentTrader.AddItemToInventory(groupedInventoryItem.Item);
            }
        } 
        public void OnClick_Buy(object sender, RoutedEventArgs e)
        {
            GroupedInventoryItem groupedInventoryItem = ((FrameworkElement)sender).DataContext as GroupedInventoryItem;
            if (groupedInventoryItem != null)
            {
                Session.CurrentPlayer.SpendGold(groupedInventoryItem.Item.Price);
                Session.CurrentTrader.RemoveItemFromInventory(groupedInventoryItem.Item);
                Session.CurrentPlayer.AddItemToInventory(groupedInventoryItem.Item);
            }
            else
            {
                MessageBox.Show("You do not have enought gold");
            }
        }
        private void OnClick_Close(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}

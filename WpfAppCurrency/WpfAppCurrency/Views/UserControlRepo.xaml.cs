﻿using Currency;
using Currency.US;
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
using WpfAppCurrency.ViewModels;

namespace WpfAppCurrency.Views
{
    /// <summary>
    /// Interaction logic for UserControlRepo.xaml
    /// </summary>
    public partial class UserControlRepo : UserControl
    {

        
        public UserControlRepo()
        {
            InitializeComponent();

            //this.DataContext = new CurrenyRepoViewModel(new List<ICoin>() { new Penny() });
            cbCoinName.SelectedIndex = 1;

            this.cbCoinName.SelectedIndex = 0;

        }

        
        
    }

    
}

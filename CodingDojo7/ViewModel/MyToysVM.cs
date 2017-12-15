using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight;
using System.Collections.ObjectModel;

namespace CodingDojo7.ViewModel
{
    public class MyToysVM:ViewModelBase
    {
        private ObservableCollection<ItemsVM> wishlist;
        
        public ObservableCollection<ItemsVM> Wishlist
        {
            get { return wishlist; }
            set { wishlist = value; RaisePropertyChanged(); }
        }

        public MyToysVM()
        {
            Wishlist = new ObservableCollection<ItemsVM>();
        }

        internal void Add(ItemsVM itemToAdd)
        {
            Wishlist.Add(itemToAdd);
            RaisePropertyChanged();
        }
    }
}

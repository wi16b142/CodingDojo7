using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Messaging;
using GalaSoft.MvvmLight.Ioc;
using System.Collections.ObjectModel;

namespace CodingDojo7.ViewModel
{
    public class MyToysVM:ViewModelBase
    {
        private ObservableCollection<ItemsVM> cart;
        Messenger messenger = SimpleIoc.Default.GetInstance<Messenger>();
        
        public ObservableCollection<ItemsVM> Cart
        {
            get { return cart; }
            set { cart = value; RaisePropertyChanged(); }
        }

        public MyToysVM()
        {
            Cart = new ObservableCollection<ItemsVM>();
            messenger.Register<PropertyChangedMessage<ItemsVM>>(this, update);
        }

        void update(PropertyChangedMessage<ItemsVM> toAdd)
        {
            Cart.Add(toAdd.NewValue);
        }
    }
}

using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using GalaSoft.MvvmLight.Ioc;
using GalaSoft.MvvmLight.Messaging;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace CodingDojo7.ViewModel
{
    public class OverviewVM : ViewModelBase
    {
        private ObservableCollection<ItemsVM> items;
        private ItemsVM selection;
        private RelayCommand<ItemsVM> buyBtnClicked;
        Messenger messenger = SimpleIoc.Default.GetInstance<Messenger>();
        public RelayCommand<ItemsVM> BuyBtnClicked
        {
            get { return buyBtnClicked; }
            set { buyBtnClicked = value; RaisePropertyChanged(); }
        }
        public ItemsVM Selection
        {
            get { return selection; }
            set { selection = value; RaisePropertyChanged(); }
        }
        public ObservableCollection<ItemsVM> Items
        {
            get { return items; }
            set { items = value; RaisePropertyChanged(); }
        }
        public OverviewVM()
        {


            Items = new ObservableCollection<ItemsVM>();          
            DummyData();

            BuyBtnClicked = new RelayCommand<ItemsVM>((itemToAdd) =>
            {
                messenger.Send<PropertyChangedMessage<ItemsVM>>(new PropertyChangedMessage<ItemsVM>(null, itemToAdd, ""));
            });
        }

        private void DummyData()
        {
            Items.Add(new ItemsVM("Lego", "-", new BitmapImage(new Uri("../Images/lego.jpg", UriKind.Relative))));
            Items.Add(new ItemsVM("Playmobil", "-", new BitmapImage(new Uri("../Images/playmobil.jpg", UriKind.Relative))));

            Items[0].ItemsAdd(new ItemsVM("Lego 1", "5+", new BitmapImage(new Uri("../Images/lego1.jpg", UriKind.Relative))));
            Items[0].ItemsAdd(new ItemsVM("Lego 2", "4+", new BitmapImage(new Uri("../Images/lego2.jpg", UriKind.Relative))));
            Items[0].ItemsAdd(new ItemsVM("Lego 3", "3+", new BitmapImage(new Uri("../Images/lego3.jpg", UriKind.Relative))));
            Items[0].ItemsAdd(new ItemsVM("Lego 4", "6+", new BitmapImage(new Uri("../Images/lego4.jpg", UriKind.Relative))));
            Items[0].ItemsAdd(new ItemsVM("Lego 5", "7+", new BitmapImage(new Uri("../Images/lego1.jpg", UriKind.Relative))));
            Items[0].ItemsAdd(new ItemsVM("Lego 6", "8+", new BitmapImage(new Uri("../Images/lego2.jpg", UriKind.Relative))));
            Items[1].ItemsAdd(new ItemsVM("Playmobil 1", "2", new BitmapImage(new Uri("../Images/playmobil1.jpg", UriKind.Relative))));
            Items[1].ItemsAdd(new ItemsVM("Playmobil 2", "3", new BitmapImage(new Uri("../Images/playmobil2.jpg", UriKind.Relative))));
            Items[1].ItemsAdd(new ItemsVM("Playmobil 3", "5", new BitmapImage(new Uri("../Images/playmobil3.jpg", UriKind.Relative))));
            Items[1].ItemsAdd(new ItemsVM("Playmobil 4", "6+", new BitmapImage(new Uri("../Images/playmobil4.jpg", UriKind.Relative))));
            Items[1].ItemsAdd(new ItemsVM("Playmobil 5", "15", new BitmapImage(new Uri("../Images/playmobil1.jpg", UriKind.Relative))));
            Items[1].ItemsAdd(new ItemsVM("Playmobil 6", "6", new BitmapImage(new Uri("../Images/playmobil2.jpg", UriKind.Relative))));
        }
    }
}

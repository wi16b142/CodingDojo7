using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace CodingDojo7.ViewModel
{
    public class ItemsVM : ViewModelBase
    {
        public ItemsVM(string description, string ageRecc, BitmapImage image)
        {
            Description = description;
            AgeRecc = ageRecc;
            Image = image;
        }

        public string Description { get; set; }
        public string AgeRecc { get; set; }
        public BitmapImage Image { get; set; }
        public ObservableCollection<ItemsVM> Items { get; set; }

        public int ItemsCount()
        {
            if (Items != null) return Items.Count;
            else return 0;
        }

        public void ItemsAdd(ItemsVM newItem)
        {
            if(Items == null)
            {
                Items = new ObservableCollection<ItemsVM>();
            }

            Items.Add(newItem);
        }

    }
}

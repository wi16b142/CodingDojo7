using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Ioc;
using GalaSoft.MvvmLight.Messaging;
using GalaSoft.MvvmLight.CommandWpf;

namespace CodingDojo7.ViewModel
{
    public class MessageVM:ViewModelBase
    {
        Messenger messenger = SimpleIoc.Default.GetInstance<Messenger>();
        private String message;

        public String Message
        {
            get { return message; }
            set { message = value; RaisePropertyChanged(); }
        }


        public MessageVM()
        {
            messenger.Register<PropertyChangedMessage<ItemsVM>>(this, showMsg);
        }

        void showMsg(PropertyChangedMessage<ItemsVM> toAdd)
        {
            Message = toAdd.NewValue.Description + " added to cart.";
        }
    }
}

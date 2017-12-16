using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Ioc;
using GalaSoft.MvvmLight.Messaging;
using GalaSoft.MvvmLight.CommandWpf;
using System.Windows;
using System.Windows.Threading;

namespace CodingDojo7.ViewModel
{
    public class MessageVM:ViewModelBase
    {
        Messenger messenger = SimpleIoc.Default.GetInstance<Messenger>();
        private String message;
        private Visibility visibility;
        private DispatcherTimer dispatcher;
        public Visibility Visibility
        {
            get { return visibility; }
            set { visibility = value; RaisePropertyChanged(); }
        }
        public String Message
        {
            get { return message; }
            set { message = value; RaisePropertyChanged(); }
        }
        public MessageVM()
        {
            Message = "";
            Visibility = Visibility.Hidden;
            initializeTimer();
            messenger.Register<PropertyChangedMessage<ItemsVM>>(this, showMsg);
        }
        void showMsg(PropertyChangedMessage<ItemsVM> toAdd)
        {
            Visibility = Visibility.Visible;
            Message = toAdd.NewValue.Description + " added to cart.";
            dispatcher.Start();
        }

        void initializeTimer()
        {
            dispatcher = new DispatcherTimer();
            dispatcher.Interval = new TimeSpan(0, 0, 2);
            dispatcher.Tick += fade;
        }

        void fade(object sender, EventArgs e)
        {
            Message = "";
            dispatcher.Stop();
            Visibility = Visibility.Hidden;
        }
    }
}

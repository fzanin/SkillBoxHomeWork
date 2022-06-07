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

namespace Homework_10_Task_01_WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        BotController client;

        public MainWindow()
        {
            InitializeComponent();

            client = new BotController(this);

            logList.ItemsSource = client.botMessageLog;
        }

        private void btnMsgSendClick(object sender, RoutedEventArgs e)
        {
            if (!String.IsNullOrEmpty(TargetSend.Text))
            {
                client.ShowTextMessagae(txtMsgSend.Text, Convert.ToInt64(TargetSend.Text));

                client.CheckTextMessage(txtMsgSend.Text, Convert.ToInt64(TargetSend.Text));
            }
        }

    }
}

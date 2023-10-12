using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Reactive;
using System.Reactive.Linq;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using TwinCAT;
using TwinCAT.Ads;
using TwinCAT.Ads.Reactive;
using TwinCAT.Ads.TypeSystem;
using TwinCAT.TypeSystem;
namespace AdsReactiveSample
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private AdsClient adsClient;
        private AmsNetId NetId = AmsNetId.Local;
        private AmsPort port = AmsPort.PlcRuntime_851;
        private List<IDisposable> subscriptions;
        private ISymbolLoader symbolLoader;
        private SymbolCollection notificationSymbols;
        private string[] values;
        public MainWindow()
        {
            values = new string[4];
            subscriptions = new List<IDisposable>();
            InitializeComponent();
            connectToPlc();
        }
        private void connectToPlc()
        {

            adsClient = new AdsClient();
            adsClient.Connect(NetId, port);
            symbolLoader = SymbolLoaderFactory.Create(adsClient, SymbolLoaderSettings.Default);

        }
        private int eventCount = 1;

        //use a symbol Collection to subscribe to variables in the PLC
        //the symbol Collection is created by loading the symbol info from the Symbol info loader that was created after connecting to the PLC.
        //the collection will just be the symbols requested by the calling method.
        //the subscription is made for the collection as a whole, however, the Observer will be called for each single symbol, not the entire collection.
        private void subscribeToSymbols(string[] symbolNames)
        {

            var valueObserver = Observer.Create<SymbolValueNotification>(not =>
            {

                Application.Current.Dispatcher.Invoke(() => { tbOutput.Text += string.Format("{0} {1:u} {2} = '{3}' ({4})" + Environment.NewLine, eventCount++, not.TimeStamp, not.Symbol.InstancePath, not.Value, not.Symbol.DataType); });

            });

            notificationSymbols = new SymbolCollection();
            foreach (string element in symbolNames)
            {
                ISymbol symbol = symbolLoader.Symbols[element];
                notificationSymbols.Add(symbol);
            }
            var iSampleSize = 20;

            if (!string.IsNullOrEmpty(tbSampleSize.Text)){
                iSampleSize = int.Parse(tbSampleSize.Text);
            }

            IDisposable subscription = adsClient.WhenNotification(notificationSymbols, NotificationSettings.Default).Take(iSampleSize).Subscribe(valueObserver);
            subscriptions.Add(subscription);

        }

        private void btnSubscribe_Click(object sender, RoutedEventArgs e)
        {
            eventCount = 1;
            tbOutput.Text = "";
            subscribeToSymbols(new string[] { "MAIN.intVal", "MAIN.dintVal", "MAIN.sintVal", "MAIN.stringVal" });
        }

        private void btnUnsubscribe_Click(object sender, RoutedEventArgs e)
        {
            foreach (IDisposable subscription in subscriptions)
            {

                subscription.Dispose();
            }
            subscriptions.Clear();
            notificationSymbols.Clear();
        }
    }
}

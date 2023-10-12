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
using TwinCAT.Ads;
using TwinCAT.Ads.SumCommand;

namespace AdsSumCommandSample
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //AdsClient adsClient;
        
        //uint[] varHandles;
        //string[] varNames;
        //Type[] varTypes;
        public MainWindow()
        {
            InitializeComponent();
            //varNames = new string[] { "MAIN.intVal", "MAIN.dintVal", "MAIN.boolVal", "MAIN.sintVal", "MAIN.realVal", "MAIN.lrealVal" };
            //varTypes = new Type[] { typeof(Int16), typeof(Int32), typeof(bool), typeof(byte), typeof(float), typeof(double) };
            //connectToPlc();
        }
        
        private void connectToPlc()
        {
            //adsClient = new AdsClient();
            //adsClient.Connect(AmsNetId.Local, AmsPort.PlcRuntime_851);

        }
        
        private void getVarHandles()
        {
            
            //var createHandles = new SumCreateHandles(adsClient, varNames);
            //varHandles = createHandles.CreateHandles();
        }
        private void deleteVarHandles()
        {
            //var deleteHandles = new SumReleaseHandles(adsClient, varHandles);
            //deleteHandles.ReleaseHandles();
        }
    
        private void readValues()
        {
            //getVarHandles();
            //var sumRead = new SumHandleRead(adsClient,varHandles,varTypes);
            //var values = sumRead.Read();
            //tbInt.Text = values[0].ToString();
            //tbDint.Text = values[1].ToString();
            //tbBool.Text = values[2].ToString();
            //tbSint.Text = values[3].ToString();
            //tbReal.Text = values[4].ToString();
            //tbLreal.Text = values[5].ToString();
            //deleteVarHandles();
        }
        private void writeValues()
        {
            //getVarHandles();
            //var writeValues = new SumHandleWrite(adsClient, varHandles, varTypes);
            //var values = new Object[6];
            //values[0] = Int16.Parse(tbInt.Text);
            //values[1] = Int32.Parse(tbDint.Text);
            //values[2] = bool.Parse(tbBool.Text);
            //values[3] = byte.Parse(tbSint.Text);
            //values[4] = float.Parse(tbReal.Text);
            //values[5] = double.Parse(tbReal.Text);

            //writeValues.Write(values);
            //deleteVarHandles();
        }

        private void btnRead_Click(object sender, RoutedEventArgs e)
        {
            readValues();
        }

        private void btnWrite_Click(object sender, RoutedEventArgs e)
        {
            writeValues();
        }
    }
}

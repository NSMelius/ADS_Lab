using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TwinCAT.Ads;
using TwinCAT.Ads.TypeSystem;
using TwinCAT.TypeSystem;

namespace AdsLnLClient
{
    public partial class Form1 : Form
    {
        //private AdsClient client;
        //private AmsAddress targetAddress;
        //private string AmsNetId = "127.0.0.1.1.1";
        //private int port = 851;

        public Form1()
        {
            //This call creates the Form and all of its controls do not touch
            //InitializeComponent();

            ////Create a new client with default connection settings and assmble the target AmsAddress
            //targetAddress = new AmsAddress(AmsNetId, port);
            //client = new AdsClient(AdsClientSettings.Default);
            ////Connect to the target This connection MUST be closed before the program is closed.

            //client.Connect(targetAddress);
            //uint integerHandle, incrementHandle, limitHandle, stringHandle;

            //integerHandle = client.CreateVariableHandle("MAIN.nInteger");
            //incrementHandle = client.CreateVariableHandle("MAIN.nIncrement");
            //limitHandle = client.CreateVariableHandle("MAIN.nLimit");

            ////--------
            ////read in integer values
            ////each call needs a variable handle and the type of value that is to be read.
            ////once we have the value we can set the textboxes to display the value as a string
            ////--------
            //var value = client.ReadAny(integerHandle, typeof(UInt16));
            //textBox1.Text = value.ToString();
            //value = client.ReadAny(incrementHandle, typeof(UInt16));
            //textBox2.Text = value.ToString();
            //value = client.ReadAny(limitHandle, typeof(UInt16));
            //textBox3.Text = value.ToString();

            ////---------------------------
            ////read in a string value
            ////Create a buffer of bytes to read the string data, then convert the data from bytes to a string format
            ////We can't use the same method as we did with integers, because the C# string type has no defined byte size
            ////so it cannot be marshaled automagically
            ////---------------------------
            //stringHandle = client.CreateVariableHandle("MAIN.sString");
            //int bytesize = 81; //string of 80 characters + /0
            //PrimitiveTypeMarshaler converter = new PrimitiveTypeMarshaler(StringMarshaler.DefaultEncoding);
            //byte[] buffer = new byte[bytesize];

            ////Now that we have our buffer and data Marshaler created, we can read the bytes from the PLC using the buffer and the variable Handle
            //value = client.Read(stringHandle, buffer.AsMemory());
            //string text;
            //converter.Unmarshal<string>(buffer.AsSpan(),out text);
            //textBox4.Text = text;

            ////--------
            ////Variable Handles need to be managed by the programmer.
            ////In order to prevent an overflow of handles, we must delete the variable handles when we are finished with them.
            ////Otherwise, any handles created that are no longer needed will take up limited resources in the AMS Router
            ////--------
            //client.DeleteVariableHandle(integerHandle);
            //client.DeleteVariableHandle(incrementHandle);
            //client.DeleteVariableHandle(limitHandle);
            //client.DeleteVariableHandle(stringHandle);
        }


        //-------------------
        //When the form is closed we want to be sure the Client is properly destroyed.
        //This may happen on its own, but it is good practice to do it ourselves
        //-------------------
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            //client.Disconnect();
            //client.Dispose();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Demonstrate reading the value by symbol path instead of variable handle
            //uint value;
            //value = client.ReadValue<uint>("MAIN.intVal");
            //textBox1.Text = value.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //Demonstrate using Variable Handles to write to an integer
            //uint Handle;
            //Handle = client.CreateVariableHandle("MAIN.dintVal");
            //int32 value = Int32.Parse(textBox2.Text);
            //client.WriteAny(Handle, value);
            //client.DeleteVariableHandle(Handle);

        }

        private void button3_Click(object sender, EventArgs e)
        {
            //Demonstrate using IADSSymbol to write to an integer
            //IAdsSymbol symbol = client.ReadSymbol("MAIN.sintVal");
            //uint value = uint.Parse(textBox3.Text);
            //client.WriteValue(symbol, value);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            //Demonstrate using Varaible Handles to write to a string
            //int byteSize = 31;
            //PrimitiveTypeMarshaler converter = new PrimitiveTypeMarshaler(StringMarshaler.DefaultEncoding);
            //byte[] buffer = new byte[byteSize];

            //string value = textBox4.Text;
            //converter.Marshal(value, buffer);

            //uint Handle = client.CreateVariableHandle("MAIN.Text");

            //client.Write(Handle,buffer);

            //client.DeleteVariableHandle(Handle);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            //Demonstrate How to Read the state of the target device
            //StateInfo stateInfo = client.ReadState();
            //switch(stateInfo.AdsState)
            //{
            //    case AdsState.Config:
            //        textBox5.Text = "Config";
            //        break;
            //    case AdsState.Run:
            //        textBox5.Text = "Run";
            //        break;
            //    case AdsState.Stop:
            //        textBox5.Text = "Stop";
            //        break;
            //    case AdsState.Error:
            //    case AdsState.Exception:
            //    default:
            //        textBox5.Text = "ERROR";
            //        break;

            //}

            
        }
    }
}

using System;
using System.Windows;
using Interop.QBFC13;
// using Interop.QBFC14;
using Zombie;
//using QBFC14Lib;

namespace JMApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            using (var cn = ConnectionMgr.GetConnection())
            {
                Console.WriteLine("Customer list from the current company file");

                var batch = cn.NewBatch();

                var qryCust = batch.MsgSet.AppendCustomerQueryRq();

                batch.SetClosures(qryCust, b =>
                {
                    var customers = new QBFCIterator<ICustomerRetList, ICustomerRet>(b);

                    foreach (var customer in customers)
                    {
                        // Console.WriteLine(Safe.Value(customer.FullName));
                    }
                });

                batch.Run();
            }

        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {

        }

        private void button3_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}

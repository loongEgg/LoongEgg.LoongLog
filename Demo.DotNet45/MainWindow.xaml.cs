using LoongEgg.LoongLog; 
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

namespace Demo.DotNet45
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            //Logger.EnableDebugLogger();
            Logger.EnableAll();
            Logger.Debug("a debug");
            Logger.Debug("a Debug");
            Logger.Info("a Info");
            Logger.Warn("a Warn");
            Logger.Error("a Error");
        }
    }
}

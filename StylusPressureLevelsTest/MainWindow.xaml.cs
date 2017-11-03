using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace StylusPressureLevelsTest
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        float lastPreesure = 0;
        float minDifference = 1;
        private void Grid_StylusMove(object sender, StylusEventArgs e)
        {
            var pts = e.GetStylusPoints(null);
            foreach (var p in pts)
            {
                rect.Opacity = p.PressureFactor;
                textBlockCurrentPressure.Text = (p.PressureFactor * 100).ToString("#.####") + "%";
                if (Math.Abs(p.PressureFactor - lastPreesure) != 0 && Math.Abs(p.PressureFactor - lastPreesure) < minDifference)
                {
                    minDifference = Math.Abs(p.PressureFactor - lastPreesure);
                    textBlockPossiblePressure.Text = (1 / minDifference).ToString("#.#");
                }
                lastPreesure = p.PressureFactor;
            }
        }

        private void Hyperlink_Click(object sender, RoutedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://github.com/SkiTiSu/StylusPressureLevelsTest");
        }
    }
}

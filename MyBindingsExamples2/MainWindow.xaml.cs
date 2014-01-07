/******************************************************************************/
/*                                                                            */
/*   Program: MyBindingsExamples2                                             */
/*   Example for bining in a ObservableCollection                             */
/*   to a ListBox                                                             */
/*                                                                            */
/*   05.01.2014 0.0.0.0 uhwgmxorg Start                                       */
/*                                                                            */
/******************************************************************************/
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
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

namespace MyBindingsExamples2
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, INotifyPropertyChanged
    {

        public event PropertyChangedEventHandler PropertyChanged;

        private int index;
        public int Index { get { return index; } set { index = value; OnPropertyChanged("Index"); } }

        private ObservableCollection<Value> olist;
        public ObservableCollection<Value> OList {get;set;}

        /// <summary>
        /// Constructor
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();

            olist = new ObservableCollection<Value>();
            OList = olist;

            button_1.ToolTip = "Add (ListBox Item random double)";
            button_2.ToolTip = "Change (Round ListBox Item at Index to first decimal place)";
            button_3.ToolTip = "Clear (ListBox)";

            DataContext = this;

            Index = 0;
        }

        /******************************/
        /*       Button Events        */
        /******************************/
        #region Button Events

        /// <summary>
        /// Button_1_Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_1_Click(object sender, RoutedEventArgs e)
        {
            OList.Add(new Value(OList.Count + 1, RandomDouble(1, 10)));
        }

        /// <summary>
        /// Button_2_Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_2_Click(object sender, RoutedEventArgs e)
        {
            if (0 <= Index && Index < OList.Count)
                OList[Index].DValue = Math.Round(OList[Index].DValue);
            else
                Console.Beep();
        }

        /// <summary>
        /// Button_3_Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_3_Click(object sender, RoutedEventArgs e)
        {
            OList.Clear();
        }

        #endregion
        /******************************/
        /*      Menu Events          */
        /******************************/
        #region Menu Events

        #endregion
        /******************************/
        /*      Other Events          */
        /******************************/
        #region Other Events

        #endregion
        /******************************/
        /*      Other Functions       */
        /******************************/
        #region Other Functions

        /// <summary>
        /// Get a random double betwen min and max
        /// </summary>
        /// <param name="min"></param>
        /// <param name="max"></param>
        /// <returns></returns>
        public double RandomDouble(double min, double max)
        {
            double F;
            Random random = new Random();
            F = (double)random.NextDouble() * (max - min) + min;
            return F;
        }

        /// <summary>
        /// OnPropertyChanged
        /// </summary>
        /// <param name="p"></param>
        private void OnPropertyChanged(string p)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(p));
        }

        #endregion

    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBindingsExamples2
{
    public class Value : INotifyPropertyChanged
    {

        public event PropertyChangedEventHandler PropertyChanged;

        public int No { get; set; }
        private double dValue;
        public double DValue { get { return dValue; } set { dValue = value; OnPropertyChanged("DValue");} }

        /// <summary>
        /// Constructor
        /// </summary>
        public Value(int no,double dvalues)
        {
            No = no;
            DValue = dvalues;
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
    }
}

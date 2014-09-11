using System;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;

namespace Simpler_Note
{
    public class Data1
    {
        string lineone;
        string linetwo;
        string linethree;
        public string LineOne
        {
            get
            {
                return lineone;
            }
            set
            {
                lineone = value;
            }
        }
        public string LineTwo
        {
            get
            {
                return linetwo;
            }
            set
            {
                linetwo = value;
            }
        }
        public string LineThree
        {
            get
            {
                return linethree;
            }
            set
            {
                linethree = value;
            }
        }


    }
}

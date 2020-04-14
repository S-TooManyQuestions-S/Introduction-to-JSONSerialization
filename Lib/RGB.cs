using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Serialization;
using System.Drawing;

namespace Lib
{
    [DataContract]
    public class RGB
    {
        [DataMember]
        public string name;
        [DataMember]
        public byte r, g, b; 
        
        public RGB (string x)
        {
            name = x;
            byte[] rgb = GetRgbValues(x);
            r = rgb[0];
            g = rgb[1];
            b = rgb[2];
        }
        public byte[] GetRgbValues(string x)
        {
            Color clr = Color.FromName(x);
            return new byte[] { clr.R, clr.G, clr.B };
        }
    }
}

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
        [DataMember(Name = "ColorName")]
        public string name;
        [DataMember(Order = 0)]
        public byte r;
        [DataMember(Order = 1)]
        public byte g;
        [DataMember(Order = 2)]
        public byte b; 
        /// <summary>
        /// Параметрический конструктор
        /// </summary>
        /// <param name="x">Название цвета</param>
        public RGB (string x)
        {
            name = x;
            byte[] rgb = GetRgbValues(x);
            r = rgb[0];
            g = rgb[1];
            b = rgb[2];
        }
        /// <summary>
        /// Метод возвращает RGB цвета по имени цвета
        /// </summary>
        /// <param name="x">Название цвета</param>
        /// <returns>Массив из трех byte, соответствующих RGB значениям цвета</returns>
        public byte[] GetRgbValues(string x)
        {
            Color clr = Color.FromName(x);
            return new byte[] { clr.R, clr.G, clr.B };
        }
    }
}

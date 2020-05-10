﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShapeLib
{
    /// <summary>
    /// Параллелепипед
    /// </summary>
    public class Parallelepiped : ShapeBase
    {
        /// <summary>
        /// Высота
        /// </summary>
        private double _height;

        /// <summary>
        /// Площадь основания
        /// </summary>
        private double _squareOfBase;

        /// <summary>
        /// Высота параллелепипеда
        /// </summary>
        public double Height
        {
            get
            {
                return _height;
            }
            set
            {
                CheckData(value);
                _height = value;
                OnPropertyChanged(nameof(Height));
            }
        }

        /// <summary>
        /// Площадь основания параллелепипеда
        /// </summary>
        public double SquareOfBase
        {
            get
            {
                return _squareOfBase;
            }
            set
            {
                CheckData(value);
                _squareOfBase = value;
                OnPropertyChanged(nameof(SquareOfBase));
            }
        }

        /// <summary>
        /// Расчет объема параллелепипеда
        /// </summary>
        public override double Volume
        {
            get
            {
                return Math.Round(SquareOfBase * Height, 2);
            }
        }
    }
}

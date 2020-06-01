﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.ComponentModel;
using ShapeLib;
using System.Runtime.CompilerServices;
using System.Collections.ObjectModel;
using Prism.Mvvm;
using Prism.Commands;
using Prism.Common;
using System.Windows.Input;
using System.Windows.Controls;

namespace oop_lab3.ViewModel
{
    /// <summary>
    /// Связь между моделью и представлением
    /// </summary>
    public class ShapesViewModel : BindableBase
    {
        /// <summary>
        /// ВЫбранная фигура
        /// </summary>
        private ShapeBase _selectedShape;

        /// <summary>
        /// Объем фигуры
        /// </summary>
        private double _volume;

        /// <summary>
        /// Отображение параметра радиус
        /// </summary>
        private bool _radiusVisability = false;

        /// <summary>
        /// Отображение параметра высота
        /// </summary>
        private bool _heightVisability = false;

        /// <summary>
        /// Отображение параметра площадь основания
        /// </summary>
        private bool _squareVisability = false;

        /// <summary>
        /// Набор рассматриваемых фигур
        /// </summary>
        public ObservableCollection<ShapeBase> Shapes { get; set; }

        /// <summary>
        /// Выбранная фигура
        /// </summary>
        public ShapeBase SelectedShape
        {
            get => _selectedShape;
            set
            {
                _selectedShape = value;
                Volume = 0;

                switch (SelectedShape)
                {
                    case Sphere sphere:
                        RadiusVisability = true;
                        HeightVisability = false;
                        SquareVisability = false;
                        break;
                    case Parallelepiped parallelepiped:
                        RadiusVisability = false;
                        HeightVisability = true;
                        SquareVisability = true;
                        break;
                    case Pyramid pyramid:
                        RadiusVisability = false;
                        HeightVisability = true;
                        SquareVisability = true;
                        break;
                    case null:
                        break;
                }

                RaisePropertyChanged(nameof(SelectedShape));
            }
        }

        /// <summary>
        /// Объем фигуры
        /// </summary>
        public double Volume
        {
            get => _volume;
            set
            {
                _volume = value;
                RaisePropertyChanged(nameof(Volume));
            }
        }

        /// <summary>
        /// Отображение параметра радиус
        /// </summary>
        public bool RadiusVisability
        {
            get => _radiusVisability;
            set
            {
                _radiusVisability = value;
                RaisePropertyChanged(nameof(RadiusVisability));
            }
        }

        /// <summary>
        /// Отображение параметра высота
        /// </summary>
        public bool HeightVisability
        {
            get => _heightVisability;
            set
            {
                _heightVisability = value;
                RaisePropertyChanged(nameof(HeightVisability));
            }
        }

        /// <summary>
        /// Отображение параметра площадь основания
        /// </summary>
        public bool SquareVisability
        {
            get => _squareVisability;
            set
            {
                _squareVisability = value;
                RaisePropertyChanged(nameof(SquareVisability));
            }
        }

        /// <summary>
        /// Получение значения объема фигуры
        /// </summary>
        private void ExecuteCalc()
        {
            if (SelectedShape != null)
            {
                Volume = SelectedShape.Volume;
            }
            else
            {
                MessageBox.Show("Не выбрана ни одна из фигур!\n" +
                    "Выберите фигуру.");
            }
        }

        /// <summary>
        /// Команда для расчета объема фигуры
        /// </summary>
        public DelegateCommand CalcVolume { get; }

        /// <summary>
        /// Инициализация фигур
        /// </summary>
        public ShapesViewModel()
        {
            Shapes = new ObservableCollection<ShapeBase>
            {
                new Parallelepiped {NameOfShape="Параллелепипед"},
                new Sphere {NameOfShape="Сфера"},
                new Pyramid {NameOfShape="Пирамида"}
            };

            CalcVolume = new DelegateCommand(() =>
             { ExecuteCalc(); }).ObservesProperty(() => Volume);
        }
    }
}

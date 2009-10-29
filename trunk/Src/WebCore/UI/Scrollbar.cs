﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Yourgan.Core.UI
{
    public class Scrollbar : Widget
    {
        private int value;

        public int Value
        {
            get { return this.value; }
            set
            {
                int newValue = EnsureValueRange(value);

                OnValueChanging(newValue);
                this.value = newValue;
                OnValueChanged(newValue);
            }
        }

        public event ScrollbarValueChangeHandler ValueChanging;

        private void OnValueChanging(int newValue)
        {
            if (ValueChanging != null)
            {
                ValueChanging(this, new ScrollbarValueChangeEventArgs(this, newValue));
            }
        }

        public event ScrollbarValueChangeHandler ValueChanged;

        private void OnValueChanged(int newValue)
        {
            if (ValueChanged != null)
            {
                ValueChanged(this, new ScrollbarValueChangeEventArgs(this, newValue));
            }
        }

        private int minimum;

        public int Minimum
        {
            get { return this.minimum; }
            set { this.minimum = value; }
        }

        private int maximum;

        public int Maximum
        {
            get { return this.maximum; }
            set { this.maximum = value; }
        }

        private int lineChange;

        public int LineChange
        {
            get { return this.lineChange; }
            set { this.lineChange = value; }
        }

        private int pixelChange;

        public int PixelChange
        {
            get { return this.pixelChange; }
            set { this.pixelChange = value; }
        }

        private ScrollOrientation scrollOrientation;

        public ScrollOrientation ScrollOrientation
        {
            get { return this.scrollOrientation; }
            set { this.scrollOrientation = value; }
        }

        public void Scroll(ScrollDirection direction, ScrollGranularity granularity, float amount)
        {
            float step = 0;

            #region Determine scroll side

            switch (this.scrollOrientation)
            {
                case ScrollOrientation.Horizontal:
                    {
                        switch (direction)
                        {
                            case ScrollDirection.Left:
                            case ScrollDirection.Up:
                                {
                                    step = -1;
                                    break;
                                }
                        }
                        break;
                    }
                case ScrollOrientation.Vertical:
                    {
                        switch (direction)
                        {
                            case ScrollDirection.Down:
                            case ScrollDirection.Right:
                                {
                                    step = 1;
                                    break;
                                }
                        }
                        break;
                    }
                default:
                    {
                        System.Diagnostics.Debug.Fail("Undefined scroll orientation");
                        break;
                    }
            }

            #endregion

            #region Determine scroll size

            switch (granularity)
            {
                case ScrollGranularity.Line:
                    {
                        step *= lineChange;
                        break;
                    }
                case ScrollGranularity.Pixel:
                    {
                        step *= pixelChange;
                        break;
                    }
                default:
                    {
                        System.Diagnostics.Debug.Fail("Undefined scrolling granularity");
                        break;
                    }
            }

            #endregion

            int newValue = this.Value + (int)(step * amount);

            this.Value = EnsureValueRange(newValue);
        }

        private int EnsureValueRange(int newValue)
        {
            return Math.Max(Math.Min(newValue, this.Maximum), this.Minimum);
        }
    }
}

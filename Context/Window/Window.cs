using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Raylib_cs;

namespace Aria.Context
{
    public class Window
    {
        public int Width { get; private set; }
        public int Height { get; private set; }
        public Window()
        {
            UpdateSize();
        }
        public void UpdateSize()
        {
            Width = Raylib.GetMonitorWidth(0);
            Height = Raylib.GetMonitorHeight(0);
        }
    }
}

using NConsoleGraphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Spiral {
  class Program {
    static void Main(string[] args) {

      ConsoleGraphics graphics = new ConsoleGraphics();
      Spiral s = new Spiral(graphics.ClientWidth, graphics.ClientHeight);

      while (true) {

        s.Update();
        s.Render(graphics);
        Thread.Sleep(10);
      }
    }
  }
}

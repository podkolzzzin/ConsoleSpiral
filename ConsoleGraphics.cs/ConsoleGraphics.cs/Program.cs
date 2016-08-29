using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NConsoleGraphics {
  class Program {

    static void Main(string[] args) {

      ConsoleGraphics graphics = new ConsoleGraphics();
      graphics.DrawLine(0xffff0000, 0, 0, 100, 100, .1f);
    }
  }
}

using NConsoleGraphics;
using System;
using System.Threading;

namespace Spiral {

  class Program {

    static void Main(string[] args) {

      ConsoleGraphics graphics = new ConsoleGraphics();

      int centerX, centerY;
      int prevX, prevY, x, y;
      double angle = 0, radius = 0;

      x = centerX = graphics.ClientWidth / 2;
      y = centerY = graphics.ClientHeight / 2;

      while (true) {

        // From math:
        // For circle:
        // https://wikimedia.org/api/rest_v1/media/math/render/svg/0086da2d5baccbc1c08eb8db3c61a2bd28a353e1

        radius += .04;
        angle += .04;

        prevX = x;
        prevY = y;

        x = centerX + (int)(radius * Math.Sin(angle));
        y = centerY + (int)(radius * Math.Cos(angle));

        graphics.DrawLine(0xFFFF0000, prevX, prevY, x, y, 1f);
        Thread.Sleep(10);
      }
    }
  }
}

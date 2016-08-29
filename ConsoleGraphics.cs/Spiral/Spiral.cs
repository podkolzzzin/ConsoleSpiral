using NConsoleGraphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spiral {

  class Spiral {

    private const uint MIN_COLOR = 0xFFFF0000;
    private const uint MAX_COLOR = 0xFFFFFFFF;

    private int centerX, centerY;

    private int prevX, prevY, x, y;
    private double angle, radius;

    private uint color = MIN_COLOR;
    private int deltaColor = 1;

    public Spiral(int w, int h) {

      x = centerX = w / 2;
      y = centerY = h / 2;
    }

    public void Update() {

      // From math:
      // For circle:
      // https://wikimedia.org/api/rest_v1/media/math/render/svg/0086da2d5baccbc1c08eb8db3c61a2bd28a353e1

      radius += .02;
      angle += .04;

      prevX = x;
      prevY = y;

      long newColor = color + deltaColor;
      if (newColor >= MAX_COLOR || newColor <= MIN_COLOR)
        deltaColor *= -1;

      color = (uint)((long)color + deltaColor);

      x = centerX + (int)(radius * Math.Sin(angle));
      y = centerY + (int)(radius * Math.Cos(angle));
    }

    public void Render(ConsoleGraphics g) {

      g.DrawLine(color, prevX, prevY, x, y, .3f);
    }
  }
}

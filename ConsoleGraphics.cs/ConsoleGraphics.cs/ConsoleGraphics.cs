using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace NConsoleGraphics {

  public class ConsoleGraphics {

    [DllImport("user32.dll")]
    private static extern IntPtr GetForegroundWindow();

    [DllImport("user32.dll")]
    private static extern IntPtr GetDC(IntPtr hWnd);

    [DllImport("user32.dll")]
    private static extern bool GetClientRect(IntPtr hWnd, out RECT lpRect);

    private Graphics graphics;
    private IntPtr hWnd;

    public ConsoleGraphics() {

      hWnd = GetForegroundWindow();
      graphics = Graphics.FromHdc(GetDC(hWnd));
    }

    public int ClientWidth {
      get {
        RECT rect;
        GetClientRect(hWnd, out rect);
        return rect.Width;
      }
    }

    public int ClientHeight {
      get {
        RECT rect;
        GetClientRect(hWnd, out rect);
        return rect.Height;
      }
    }

    public void DrawLine(uint color, int x1, int y1, int x2, int y2, float thickness = 1f) {

      Pen pen = new Pen(ToColor(color), thickness);
      graphics.DrawLine(pen, x1, y1, x2, y2);
    }

    private Color ToColor(uint argb) {

      return Color.FromArgb((byte)((argb & -16777216) >> 0x18),
                            (byte)((argb & 0xff0000) >> 0x10),
                            (byte)((argb & 0xff00) >> 8),
                            (byte)(argb & 0xff));
    }
  }
}

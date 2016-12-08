using System;
using System.Drawing;
using System.Runtime.InteropServices;

namespace NConsoleGraphics {

  public class ConsoleGraphics {

    private Graphics graphics;
    private IntPtr hWnd;

    public ConsoleGraphics() {

      hWnd = NativeMethods.GetForegroundWindow();
      graphics = Graphics.FromHdc(NativeMethods.GetDC(hWnd));
    }

    public int ClientWidth {
      get {
        RECT rect;
        NativeMethods.GetClientRect(hWnd, out rect);
        return rect.Width;
      }
    }

    public int ClientHeight {
      get {
        RECT rect;
        NativeMethods.GetClientRect(hWnd, out rect);
        return rect.Height;
      }
    }

    public ConsoleImage LoadImage(string bmpFileName) {

      return new ConsoleImage(bmpFileName);
    }

    public void DrawLine(uint color, int x1, int y1, int x2, int y2, float thickness = 1f) {

      using (Pen pen = new Pen(ToColor(color), thickness))
        graphics.DrawLine(pen, x1, y1, x2, y2);
    }

    public void DrawRectangle(uint color, int x, int y, int w, int h, float thickness = 1f) {

      using (Pen pen = new Pen(ToColor(color), thickness))
        graphics.DrawRectangle(pen, x, y, w, h);
    }

    public void DrawImage(ConsoleImage img, int x, int y) {

      graphics.DrawImage(img.Image, x, y);
    }

    public void DrawImagePart(ConsoleImage img, int offsetX, int offsetY, int width, int height, int x, int y) {

      graphics.DrawImage(img.Image, new Rectangle(x, y, width, height), new Rectangle(offsetX, offsetY, width, height), GraphicsUnit.Pixel);
    }

    public void FillRectangle(uint color, int x,  int y, int w, int h) {

      using (Brush brush = new SolidBrush(ToColor(color)))
        graphics.FillRectangle(brush, x, y, w, h);
    }

    public void DrawString(string s, string fontName, uint color, int x, int y, float emSize = 16f) {

      using (Font font = new Font(fontName, emSize))
      using (Brush brush = new SolidBrush(ToColor(color)))
        graphics.DrawString(s, font, brush, x, y);
    }

    private Color ToColor(uint argb) {

      return Color.FromArgb((byte)((argb & -16777216) >> 0x18),
                            (byte)((argb & 0xff0000) >> 0x10),
                            (byte)((argb & 0xff00) >> 8),
                            (byte)(argb & 0xff));
    }
  }
}

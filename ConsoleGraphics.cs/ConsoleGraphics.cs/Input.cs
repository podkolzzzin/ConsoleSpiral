using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace NConsoleGraphics {

  public static class Input {

    private const int KEY_PRESSED = 0x8000;

    public static int MouseX {
      get {
        return GetMousePos().X;
      }
    }

    public static int MouseY {
      get {
        return GetMousePos().Y;
      }
    }

    public static bool IsMouseLeftButtonDown {
      get {
        return IsKeyDown(Keys.LBUTTON);
      }
    }

    public static bool IsMouseRightButtonDown {
      get {
        return IsKeyDown(Keys.RBUTTON);
      }
    }

    public static bool IsKeyDown(Keys key) {

      return Convert.ToBoolean(NativeMethods.GetKeyState(key) & KEY_PRESSED);
    }

    private static Point GetMousePos() {

      POINT p;
      NativeMethods.GetCursorPos(out p);
      NativeMethods.ScreenToClient(NativeMethods.GetForegroundWindow(), ref p);
      return p;
    }
  }
}

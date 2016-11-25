using System.Drawing;

namespace NConsoleGraphics {

  public class ConsoleImage {

    internal ConsoleImage(string fileName) {

      Image = Bitmap.FromFile(fileName);
    }

    public int Width {
      get {
        return Image.Width;
      }
    }

    public int Height {
      get {
        return Image.Height;
      }
    }

    internal Image Image { get; private set; }
  }
}
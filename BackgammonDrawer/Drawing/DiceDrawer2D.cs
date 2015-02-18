using System.Drawing;

namespace BackgammonDrawer.Drawing
{
	public class DiceDrawer2D
	{
		private Rectangle _rectangle;

		public Graphics Graphics { get; private set; }
		public Color ColorBackground { get; set; }
		public Color ColorCycle { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="DiceDrawer2D" /> class.
        /// </summary>
        /// <param name="graphics">The graphics.</param>
        /// <param name="point">The point.</param>
        /// <param name="size">The size.</param>
        /// <param name="colorBackground">The color background.</param>
        /// <param name="colorCycle">The color cycle.</param>
		public DiceDrawer2D(Graphics graphics, Point point, Size size, Color colorBackground, Color colorCycle)
		{
			Graphics = graphics;
			ColorBackground = colorBackground;
			ColorCycle = colorCycle;
			_rectangle = new Rectangle(point, size);
		}

		public void Draw()
		{
			DrawBackground();
		}

		private void DrawBackground()
		{
			Graphics.FillEllipse(
				new SolidBrush(ColorBackground),
				_rectangle.Left,
				_rectangle.Top,
				(int) (_rectangle.Height * 0.2),
				(int) (_rectangle.Width * 0.2));

			Graphics.FillEllipse(
				new SolidBrush(ColorBackground),
				_rectangle.Right - (int) (_rectangle.Width * 0.2),
				_rectangle.Top,
				(int) (_rectangle.Height * 0.2),
				(int) (_rectangle.Width * 0.2));

			Graphics.FillEllipse(
				new SolidBrush(ColorBackground),
				_rectangle.Right - (int) (_rectangle.Width * 0.2),
				_rectangle.Bottom - (int) (_rectangle.Height * 0.2),
				(int) (_rectangle.Height * 0.2),
				(int) (_rectangle.Width * 0.2));

			Graphics.FillEllipse(
				new SolidBrush(ColorBackground),
				_rectangle.Left,
				_rectangle.Bottom - (int) (_rectangle.Height * 0.2),
				(int) (_rectangle.Height * 0.2),
				(int) (_rectangle.Width * 0.2));

			Graphics.FillRectangle(
				new SolidBrush(ColorBackground),
					new Rectangle(
						new Point(_rectangle.Left, (int) (_rectangle.Top + _rectangle.Height * 0.1)),
						new Size(_rectangle.Width, (int) (_rectangle.Height * 0.8))));

			Graphics.FillRectangle(
				new SolidBrush(ColorBackground),
				new Rectangle(
					new Point((int) (_rectangle.Left + _rectangle.Width * 0.1), _rectangle.Top),
					new Size((int) (_rectangle.Width * 0.8), (int) (_rectangle.Height * 0.1))));

			Graphics.FillRectangle(
				new SolidBrush(ColorBackground),
				new Rectangle(
					new Point((int) (_rectangle.Left + _rectangle.Width * 0.1), (int) (_rectangle.Bottom - _rectangle.Height * 0.1)),
					new Size((int) (_rectangle.Width * 0.8), (int) (_rectangle.Height * 0.1))));
		}
	}
}
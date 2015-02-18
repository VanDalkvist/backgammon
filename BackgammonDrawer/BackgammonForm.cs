using System.Drawing;
using System.Windows.Forms;

using Backgammon.Core.Cells;
using Backgammon.Core.Counters;
using Backgammon.Core.Fields;
using Backgammon.Drawing;
using Backgammon.Helper;
using Backgammon.Logic.Processing;

using BackgammonDrawer.Drawing;

namespace BackgammonDrawer
{
	public partial class BackgammonForm : Form, IDrawer
	{
		public BackgammonForm()
		{
			InitializeComponent();
			Invalidate();
		}

		#region Implementation of IDrawer

		/// <summary>
		/// Draw element of type <see cref="ICounter"/>.
		/// </summary>
		/// <param name="counter">The counter.</param>
		public void DrawCounter(ICounter counter)
		{
			throw new System.NotImplementedException();
		}

		/// <summary>
		/// Draw element of type <see cref="ICounter"/>.
		/// </summary>
		public void DrawCounter()
		{
			throw new System.NotImplementedException();
		}

		/// <summary>
		/// Draw element of type <see cref="ICell"/>.
		/// </summary>
		public void DrawCell()
		{
			throw new System.NotImplementedException();
		}

		/// <summary>
		/// Draw element of type <see cref="Field"/>.
		/// </summary>
		public void DrawField()
		{
			throw new System.NotImplementedException();
		}

		/// <summary>
		/// Draw element of type <see cref="Side"/>
		/// </summary>
		/// <param name="color">The color of side.</param>
		public void DrawSide(ColorHelper.ColorCell color)
		{
			throw new System.NotImplementedException();
		}

		/// <summary>
		/// Draw the dice.
		/// </summary>
		public void DrawDice()
		{
			var drawer = 
				new DiceDrawer2D(groupBoxDice.CreateGraphics(), new Point(30, 30), new Size(40, 40), Color.BurlyWood, Color.Black);
			drawer.Draw();
		}

		#endregion

		private void ButtonStartClick(object sender, System.EventArgs e)
		{
			Game.Instance.Start(GeneralConstants.PlayerType.Bot, GeneralConstants.PlayerType.Real);
		}

		private void GroupBoxDicePaint(object sender, PaintEventArgs e)
		{
			DrawDice();
		}

		private void DrawingPanelPaint(object sender, PaintEventArgs e)
		{
			//DrawFi
			new DiceDrawer2D(e.Graphics, new Point(30, 30), new Size(400, 400), Color.Black, Color.Black).Draw();
		}
	}
}
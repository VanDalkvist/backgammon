namespace Backgammon.Drawing
{
    /// <summary>
    /// Interface represents method for drawing element.
    /// </summary>
    public interface IDrawing
    {
        /// <summary>
        /// Draw the element.
        /// </summary>
        /// <param name="drawer">
        /// Object of type <see cref="IDrawer"/> performs the drawing.
        /// </param>
        void Draw(IDrawer drawer);
    }
}
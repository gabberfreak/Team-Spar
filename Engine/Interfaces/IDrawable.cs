using System.Windows.Forms.VisualStyles;

namespace Engine.Interfaces
{
    using System.Drawing;
    interface IDrawable
    {
        int X { get; set; }
        int Y { get; set; }
        Bitmap Image { get; set; }
        void Render(Graphics g);

    }
}

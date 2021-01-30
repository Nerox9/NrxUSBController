using NeroxUSBController.Manager;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NeroxUSBController.Controller.Graphic
{
    internal class DragImage : PictureBox
    {
        int dragOffset = 6;
        internal DragImage()
        {
            Enabled = false;
            Hide();
        }

        internal void SetImage(Image image, Color backColor)
        {
            Bitmap icon = new Bitmap(image.Width + 2 * dragOffset, image.Height + 2 * dragOffset);
            Size = icon.Size;

            using (Graphics g = Graphics.FromImage(icon))
            {
                Rectangle outline = new Rectangle(new Point(0, 0), icon.Size);
                g.Clear(backColor);
                g.DrawImage(image, dragOffset, dragOffset, image.Width, image.Height);
                g.DrawRectangle(new Pen(Color.Red), 0, 0, icon.Width - 1, icon.Height - 1);
            }
            Image = icon;
            SizeMode = PictureBoxSizeMode.CenterImage;
            Show();
        }

        internal void queryContinueDrag(object sender, QueryContinueDragEventArgs e)
        {
            Location = Parent.PointToClient(new Point(Cursor.Position.X - dragOffset - Image.Size.Width / 2, Cursor.Position.Y - dragOffset - Image.Size.Height / 2));
        }
    }
}

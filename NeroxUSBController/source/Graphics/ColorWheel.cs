using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using System.ComponentModel;

namespace NeroxUSBController
{
    class ColorWheel : Control
    {
        public ColorWheel()
        {
            this.Paint += DrawColorWheel;
        }

        private void InterpolateColors(Color[] surround_colors,
                                       ref int index, float stop_pt,
                                       int from_a, int from_r, int from_g, int from_b,
                                       int to_a, int to_r, int to_g, int to_b)
        {
            int num_pts = (int)stop_pt - index;
            float a = from_a, r = from_r, g = from_g, b = from_b;
            float da = (to_a - from_a) / (num_pts - 1);
            float dr = (to_r - from_r) / (num_pts - 1);
            float dg = (to_g - from_g) / (num_pts - 1);
            float db = (to_b - from_b) / (num_pts - 1);

            for (int i = 0; i < num_pts; i++)
            {
                surround_colors[index++] =
                    Color.FromArgb((int)a, (int)r, (int)g, (int)b);
                a += da;
                r += dr;
                g += dg;
                b += db;
            }
        }

        private void DrawColorWheel(object sender, PaintEventArgs e)
        {
            Graphics gr = e.Graphics;
            Color outline_color = Color.Red;
            int xmin = 0, ymin = 0, wid = base.Width - 2, hgt = base.Height - 2;

            Rectangle rect = new Rectangle(xmin, ymin, wid, hgt);
            GraphicsPath wheel_path = new GraphicsPath();
            wheel_path.AddRectangle(rect);
            wheel_path.Flatten();

            float num_pts = (wheel_path.PointCount - 1) / 1;
            Color[] surround_colors = new Color[wheel_path.PointCount];

            int index = 0;
            InterpolateColors(surround_colors, ref index,
                1 * num_pts, 255, 255, 0, 0, 255, 255, 0, 255);
            InterpolateColors(surround_colors, ref index,
                2 * num_pts, 255, 255, 0, 255, 255, 0, 0, 255);
            InterpolateColors(surround_colors, ref index,
                3 * num_pts, 255, 0, 0, 255, 255, 0, 255, 255);
            InterpolateColors(surround_colors, ref index,
                4 * num_pts, 255, 0, 255, 255, 255, 0, 255, 0);
            InterpolateColors(surround_colors, ref index,
                5 * num_pts, 255, 0, 255, 0, 255, 255, 255, 0);
            InterpolateColors(surround_colors, ref index,
                wheel_path.PointCount, 255, 255, 255, 0, 255, 255, 0, 0);
            

            using (PathGradientBrush path_brush =
                new PathGradientBrush(wheel_path))
            {
                path_brush.CenterColor = Color.White;
                path_brush.SurroundColors = surround_colors;

                gr.FillPath(path_brush, wheel_path);


                // It looks better if we outline the wheel.
                /*
                using (Pen thick_pen = new Pen(outline_color, 0))
                {
                    gr.DrawPath(thick_pen, wheel_path);
                }
                */
            }
        }
    }
}

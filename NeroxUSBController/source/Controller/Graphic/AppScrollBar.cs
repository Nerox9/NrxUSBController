using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NeroxUSBController.Controller.Graphic
{
    class AppScrollBar : UserControl
    {
        protected Color moChannelColor = Color.Empty;

        protected Image moUpArrowImage = null;
        protected Image moDownArrowImage = null;
        protected Image moThumbArrowImage = null;
        protected Image moThumbTopImage = null;
        protected Image moThumbTopSpanImage = null;
        protected Image moThumbBottomImage = null;
        protected Image moThumbBottomSpanImage = null;
        protected Image moThumbMiddleImage = null;

        protected int moLargeChange = 10;
        protected int moSmallChange = 1;
        protected int moMinimum = 0;
        protected int moMaximum = 100;
        protected int moValue = 0;

        private int nClickPoint;
        private int moThumbTop = 0;
        private bool moThumbDown = false;
        private bool moThumbDragging = false;

        public new event EventHandler Scroll = null;
        public event EventHandler ValueChanged = null;


        protected override void OnPaint(PaintEventArgs e)
        {
            //set the mode to nearest neighbour so when
            //we span our thumb graphics it doesn't try 
            //to blur or antialias anything
            e.Graphics.InterpolationMode =
              System.Drawing.Drawing2D.InterpolationMode.NearestNeighbor;
            //draw up arrow
            if (UpArrowImage != null)
            {
                e.Graphics.DrawImage(UpArrowImage, new Rectangle(new Point(0, 0),
                  new Size(this.Width, UpArrowImage.Height)));
            }

            Brush oChannelBrush = new SolidBrush(moChannelColor);
            Brush oWhiteBrush = new SolidBrush(Color.FromArgb(255, 255, 255));

            //draw channel left and right border colors
            e.Graphics.FillRectangle(oWhiteBrush, new Rectangle(0,
                                     UpArrowImage.Height, 1,
                                    (this.Height - DownArrowImage.Height)));

            e.Graphics.FillRectangle(oWhiteBrush, new Rectangle(this.Width - 1,
                       UpArrowImage.Height, 1,
                       (this.Height - DownArrowImage.Height)));

            //draw channel
            e.Graphics.FillRectangle(oChannelBrush, new Rectangle(1,
                                     UpArrowImage.Height, this.Width - 2,
                                     (this.Height - DownArrowImage.Height)));
            //draw thumb contrl
            int nTrackHeight = (this.Height -
                               (UpArrowImage.Height +
                                DownArrowImage.Height));
            float fThumbHeight = ((float)LargeChange / (float)Maximum) * nTrackHeight;
            int nThumbHeight = (int)fThumbHeight;
            if (nThumbHeight > nTrackHeight)
            {
                nThumbHeight = nTrackHeight;
                fThumbHeight = nTrackHeight;
            }
            if (nThumbHeight < 56)
            {
                nThumbHeight = 56;
                fThumbHeight = 56;
            }
            float fSpanHeight = (fThumbHeight - (ThumbMiddleImage.Height +
                  ThumbTopImage.Height + ThumbBottomImage.Height)) / 2.0f;
            int nSpanHeight = (int)fSpanHeight;
            int nTop = moThumbTop;
            nTop += UpArrowImage.Height;
            //draw top part of thumb now
            e.Graphics.DrawImage(ThumbTopImage, new Rectangle(1, nTop,
                               this.Width - 2, ThumbTopImage.Height));
            nTop += ThumbTopImage.Height;

            //draw top span thumb
            Rectangle rect = new Rectangle(1, nTop,
                                 this.Width - 2, nSpanHeight);
            e.Graphics.DrawImage(ThumbTopSpanImage, 1.0f, (float)nTop,
                                (float)this.Width - 2.0f,
                                (float)fSpanHeight * 2); nTop += nSpanHeight;
            //draw middle part of thumb
            e.Graphics.DrawImage(ThumbMiddleImage, new Rectangle(1, nTop,
                               this.Width - 2, ThumbMiddleImage.Height));

            nTop += ThumbMiddleImage.Height;
            //draw botom span thumb
            rect = new Rectangle(1, nTop, this.Width - 2, nSpanHeight * 2);
            e.Graphics.DrawImage(ThumbBottomSpanImage, rect);
            nTop += nSpanHeight;
            //draw bottom part of thumb
            e.Graphics.DrawImage(ThumbBottomImage,
                       new Rectangle(1, nTop, this.Width - 2, nSpanHeight));

            //draw down arrow
            if (DownArrowImage != null)
            {
                e.Graphics.DrawImage(DownArrowImage, new Rectangle(new Point(0,
                         (this.Height - DownArrowImage.Height)),
                         new Size(this.Width, DownArrowImage.Height)));
            }
        }

        private void CustomScrollbar_MouseDown(object sender, MouseEventArgs e)
        {
            Point ptPoint = this.PointToClient(Cursor.Position);
            int nTrackHeight = (this.Height - (UpArrowImage.Height +
                                DownArrowImage.Height));
            int nThumbHeight = GetThumbHeight();
            int nTop = moThumbTop;
            nTop += UpArrowImage.Height;

            Rectangle thumbrect = new Rectangle(new Point(1, nTop),
                      new Size(ThumbMiddleImage.Width, nThumbHeight));
            if (thumbrect.Contains(ptPoint))
            {
                //hit the thumb
                nClickPoint = (ptPoint.Y - nTop);
                this.moThumbDown = true;
            }
            Rectangle uparrowrect = new Rectangle(new Point(1, 0),
               new Size(UpArrowImage.Width, UpArrowImage.Height));
            if (uparrowrect.Contains(ptPoint))
            {
                int nRealRange = (Maximum - Minimum) - LargeChange;
                int nPixelRange = (nTrackHeight - nThumbHeight);
                if (nRealRange > 0)
                {
                    if (nPixelRange > 0)
                    {
                        if ((moThumbTop - SmallChange) < 0)
                            moThumbTop = 0;
                        else
                            moThumbTop -= SmallChange;
                        //figure out value
                        float fPerc = (float)moThumbTop / (float)nPixelRange;
                        float fValue = fPerc * (Maximum - LargeChange);

                        moValue = (int)fValue;
                        Console.WriteLine(moValue.ToString());
                        if (ValueChanged != null)
                            ValueChanged(this, new EventArgs());
                        if (Scroll != null)
                            Scroll(this, new EventArgs());
                        Invalidate();
                    }
                }
            }
            Rectangle downarrowrect = new Rectangle(new Point(1,
                      UpArrowImage.Height + nTrackHeight),
                      new Size(UpArrowImage.Width, UpArrowImage.Height));
            if (downarrowrect.Contains(ptPoint))
            {
                int nRealRange = (Maximum - Minimum) - LargeChange;
                int nPixelRange = (nTrackHeight - nThumbHeight);
                if (nRealRange > 0)
                {
                    if (nPixelRange > 0)
                    {
                        if ((moThumbTop + SmallChange) > nPixelRange)
                            moThumbTop = nPixelRange;
                        else
                            moThumbTop += SmallChange;
                        //figure out value
                        float fPerc = (float)moThumbTop / (float)nPixelRange;
                        float fValue = fPerc * (Maximum - LargeChange);

                        moValue = (int)fValue;
                        if (ValueChanged != null)
                            ValueChanged(this, new EventArgs());
                        if (Scroll != null)
                            Scroll(this, new EventArgs());
                        Invalidate();
                    }
                }
            }
        }

        private void CustomScrollbar_MouseUp(object sender, MouseEventArgs e)
        {
            this.moThumbDown = false;
            this.moThumbDragging = false;
        }

        private void MoveThumb(int y)
        {
            int nRealRange = Maximum - Minimum;
            int nTrackHeight = (this.Height - (UpArrowImage.Height +
                                               DownArrowImage.Height));
            int nThumbHeight = GetThumbHeight();
            int nSpot = nClickPoint;
            int nPixelRange = (nTrackHeight - nThumbHeight);
            if (moThumbDown && nRealRange > 0)
            {
                if (nPixelRange > 0)
                {
                    int nNewThumbTop = y - (UpArrowImage.Height + nSpot);

                    if (nNewThumbTop < 0)
                    {
                        moThumbTop = nNewThumbTop = 0;
                    }
                    else if (nNewThumbTop > nPixelRange)
                    {
                        moThumbTop = nNewThumbTop = nPixelRange;
                    }
                    else
                    {
                        moThumbTop = y - (UpArrowImage.Height + nSpot);
                    }

                    //figure out value
                    float fPerc = (float)moThumbTop / (float)nPixelRange;
                    float fValue = fPerc * (Maximum - LargeChange);
                    moValue = (int)fValue;
                    Console.WriteLine(moValue.ToString());
                    Application.DoEvents();
                    Invalidate();
                }
            }
        }

        private void CustomScrollbar_MouseMove(object sender, MouseEventArgs e)
        {
            if (moThumbDown == true)
            {
                this.moThumbDragging = true;
            }
            if (this.moThumbDragging)
            {
                MoveThumb(e.Y);
            }
            if (ValueChanged != null)
                ValueChanged(this, new EventArgs());
            if (Scroll != null)
                Scroll(this, new EventArgs());
        }

        int GetThumbHeight()
        {
            return 5;
        }

        int SetThumbTop()
        {
            return 5;
        }

        [EditorBrowsable(EditorBrowsableState.Always), Browsable(true), DefaultValue(false), Category("Behavior"), Description("LargeChange")]
        public int LargeChange
        {
            get { return moLargeChange; }
            set
            {
                moLargeChange = value;
                Invalidate();
            }
        }

        [EditorBrowsable(EditorBrowsableState.Always), Browsable(true), DefaultValue(false), Category("Behavior"), Description("SmallChange")]
        public int SmallChange
        {
            get { return moSmallChange; }
            set
            {
                moSmallChange = value;
                Invalidate();
            }
        }

        [EditorBrowsable(EditorBrowsableState.Always), Browsable(true), DefaultValue(false), Category("Behavior"), Description("Minimum")]
        public int Minimum
        {
            get { return moMinimum; }
            set
            {
                moMinimum = value;
                Invalidate();
            }
        }

        [EditorBrowsable(EditorBrowsableState.Always), Browsable(true), DefaultValue(false), Category("Behavior"), Description("Maximum")]
        public int Maximum
        {
            get { return moMaximum; }
            set
            {
                moMaximum = value;
                Invalidate();
            }
        }

        [EditorBrowsable(EditorBrowsableState.Always), Browsable(true), DefaultValue(false), Category("Behavior"), Description("Value")]
        public int Value
        {
            get { return moValue; }
            set
            {
                moValue = value;
                SetThumbTop();
            }
        }

        [EditorBrowsable(EditorBrowsableState.Always), Browsable(true), DefaultValue(false), Category("Skin"), Description("Channel Color")]
        public Color ChannelColor
        {
            get { return moChannelColor; }
            set { moChannelColor = value; }
        }

        [EditorBrowsable(EditorBrowsableState.Always), Browsable(true), DefaultValue(false), Category("Skin"), Description("Up Arrow Graphic")]
        public Image UpArrowImage
        {
            get { return moUpArrowImage; }
            set { moUpArrowImage = value; }
        }

        [EditorBrowsable(EditorBrowsableState.Always), Browsable(true), DefaultValue(false), Category("Skin"), Description("Down Arrow Graphic")]
        public Image DownArrowImage
        {
            get { return moDownArrowImage; }
            set { moDownArrowImage = value; }
        }

        [EditorBrowsable(EditorBrowsableState.Always), Browsable(true), DefaultValue(false), Category("Skin"), Description("Thumb Top Graphic")]
        public Image ThumbTopImage
        {
            get { return moThumbTopImage; }
            set { moThumbTopImage = value; }
        }

        [EditorBrowsable(EditorBrowsableState.Always), Browsable(true), DefaultValue(false), Category("Skin"), Description("Thumb Top Span Graphic")]
        public Image ThumbTopSpanImage
        {
            get { return moThumbTopSpanImage; }
            set { moThumbTopSpanImage = value; }
        }

        [EditorBrowsable(EditorBrowsableState.Always), Browsable(true), DefaultValue(false), Category("Skin"), Description("Thumb Bottom Graphic")]
        public Image ThumbBottomImage
        {
            get { return moThumbBottomImage; }
            set { moThumbBottomImage = value; }
        }

        [EditorBrowsable(EditorBrowsableState.Always), Browsable(true), DefaultValue(false), Category("Skin"), Description("Thumb Bottom Arrow Graphic")]
        public Image ThumbBottomSpanImage
        {
            get { return moThumbBottomSpanImage; }
            set { moThumbBottomSpanImage = value; }
        }

        [EditorBrowsable(EditorBrowsableState.Always), Browsable(true), DefaultValue(false), Category("Skin"), Description("Thumb Arrow Graphic")]
        public Image ThumbMiddleImage
        {
            get { return moThumbMiddleImage; }
            set { moThumbMiddleImage = value; }
        }
    }
        
}

using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Coologger
{
    internal class Pigment
    {
        public string Name { get; set; }
        public Color Value { get; set; }

        public Pigment()
        {
        }

        public Pigment(string n, Color v)
        {
            Name = n;
            Value = v;
        }

        public Pigment(string n, byte a, byte r, byte g, byte b)
        {
            Name = n;
            Value = Color.FromArgb(a, r, g, b);
        }

        public Pigment(string n, byte r, byte g, byte b)
        {
            Name = n;
            Value = Color.FromArgb(r, g, b);
        }
    }

    internal class FTheme : ContainerControl
    {
        public bool Resizeable { get; set; }

        public FTheme()
        {
            SetStyle((ControlStyles) 8198, true);
            Pigment[] C = new Pigment[]
                              {
                                  new Pigment("Border", Color.Black),
                                  new Pigment("Frame", 47, 47, 50),
                                  new Pigment("Border Highlight", 15, 255, 255, 255),
                                  new Pigment("Side Highlight", 6, 255, 255, 255),
                                  new Pigment("Shine", 20, 255, 255, 255),
                                  new Pigment("Shadow", 38, 38, 40),
                                  new Pigment("Backcolor", 247, 247, 251),
                                  new Pigment("Transparency", Color.Fuchsia)
                              };
        }

        protected override void OnHandleCreated(EventArgs e)
        {
            Dock = DockStyle.Fill;
            if (Parent is Form)
                ((Form) Parent).FormBorderStyle = FormBorderStyle.None;
            Colors = C;
            base.OnHandleCreated(e);
        }

        private const byte Count = 8;

        private Pigment[] C = new Pigment[]
                                  {
                                      new Pigment("Border", Color.Black),
                                      new Pigment("Frame", 47, 47, 50),
                                      new Pigment("Border Highlight", 15, 255, 255, 255),
                                      new Pigment("Side Highlight", 6, 255, 255, 255),
                                      new Pigment("Shine", 20, 255, 255, 255),
                                      new Pigment("Shadow", 38, 38, 40),
                                      new Pigment("Backcolor", 247, 247, 251),
                                      new Pigment("Transparency", Color.Fuchsia)
                                  };

        public Pigment[] Colors
        {
            get { return C; }
            set
            {
                if (value.Length != Count)
                    throw new IndexOutOfRangeException();

                P1 = new Pen(value[0].Value);
                P2 = new Pen(value[2].Value);

                B1 = new SolidBrush(value[6].Value);
                B2 = new SolidBrush(value[7].Value);

                if (Parent != null)
                {
                    Parent.BackColor = value[6].Value;
                    if (Parent is Form)
                        ((Form) Parent).TransparencyKey = value[7].Value;
                }

                CB = new ColorBlend();
                CB.Colors = new Color[]
                                {
                                    Color.Transparent,
                                    value[4].Value,
                                    Color.Transparent
                                };
                CB.Positions = new float[]
                                   {
                                       0,
                                       (float) 0.5,
                                       1
                                   };

                C = value;

                Invalidate();
            }
        }

        private Pen P1;
        private Pen P2;
        private Pen P3;
        private SolidBrush B1;
        private SolidBrush B2;
        private LinearGradientBrush B3;
        private LinearGradientBrush B4;
        private Rectangle R1;
        private Rectangle R2;

        private ColorBlend CB;
        private Graphics G;
        private Bitmap B;

        protected override void OnPaint(PaintEventArgs e)
        {
            B = new Bitmap(Width, Height);
            G = Graphics.FromImage(B);

            G.Clear(C[1].Value);

            G.DrawRectangle(P2, new Rectangle(1, 1, Width - 3, Height - 3));
            G.DrawRectangle(P2, new Rectangle(12, 40, Width - 24, Height - 52));

            R1 = new Rectangle(1, 0, 15, Height);
            B3 = new LinearGradientBrush(R1, C[3].Value, Color.Transparent, 90f);
            G.FillRectangle(B3, R1);
            G.FillRectangle(B3, new Rectangle(Width - 16, 0, 15, Height));

            G.FillRectangle(B1, new Rectangle(13, 41, Width - 26, Height - 54));

            R2 = new Rectangle(0, 2, Width, 2);
            B4 = new LinearGradientBrush(R2, Color.Empty, Color.Empty, 0F);
            B4.InterpolationColors = CB;
            G.FillRectangle(B4, R2);

            G.DrawRectangle(P1, new Rectangle(13, 41, Width - 26, Height - 54));
            G.DrawRectangle(P1, new Rectangle(0, 0, Width - 1, Height - 1));

            G.FillRectangle(B2, new Rectangle(0, 0, 2, 2));
            G.FillRectangle(B2, new Rectangle(Width - 2, 0, 2, 2));
            G.FillRectangle(B2, new Rectangle(Width - 2, Height - 2, 2, 2));
            G.FillRectangle(B2, new Rectangle(0, Height - 2, 2, 2));

            B.SetPixel(1, 1, Color.Black);
            B.SetPixel(Width - 2, 1, Color.Black);
            B.SetPixel(Width - 2, Height - 2, Color.Black);
            B.SetPixel(1, Height - 2, Color.Black);

            e.Graphics.DrawImage(B, 0, 0);
            B3.Dispose();
            B4.Dispose();
            G.Dispose();
            B.Dispose();
        }

        public enum Direction : int
        {
            NONE = 0,
            LEFT = 10,
            RIGHT = 11,
            TOP = 12,
            TOPLEFT = 13,
            TOPRIGHT = 14,
            BOTTOM = 15,
            BOTTOMLEFT = 16,
            BOTTOMRIGHT = 17
        }

        private Direction Current;

        public void SetCurrent()
        {
            Point T = PointToClient(MousePosition);
            if (T.X < 7 & T.Y < 7)
            {
                Current = Direction.TOPLEFT;
                Cursor = Cursors.SizeNWSE;
            }
            else if (T.X < 7 & T.Y > Height - 7)
            {
                Current = Direction.BOTTOMLEFT;
                Cursor = Cursors.SizeNESW;
            }
            else if (T.X > Width - 7 & T.Y > Height - 7)
            {
                Current = Direction.BOTTOMRIGHT;
                Cursor = Cursors.SizeNWSE;
            }
            else if (T.X > Width - 7 & T.Y < 7)
            {
                Current = Direction.TOPRIGHT;
                Cursor = Cursors.SizeNESW;
            }
            else if (T.X < 7)
            {
                Current = Direction.LEFT;
                Cursor = Cursors.SizeWE;
            }
            else if (T.X > Width - 7)
            {
                Current = Direction.RIGHT;
                Cursor = Cursors.SizeWE;
            }
            else if (T.Y < 7)
            {
                Current = Direction.TOP;
                Cursor = Cursors.SizeNS;
            }
            else if (T.Y > Height - 7)
            {
                Current = Direction.BOTTOM;
                Cursor = Cursors.SizeNS;
            }
            else
            {
                Current = Direction.NONE;
                Cursor = Cursors.Default;
            }
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (Parent is Form)
                {
                    if (((Form) Parent).WindowState == FormWindowState.Maximized)
                        return;
                }
                if (Drag.Contains(e.Location))
                {
                    Capture = false;
                    IntPtr Val = new IntPtr(2);
                    IntPtr NULL = IntPtr.Zero;
                    Message msg = Message.Create(Parent.Handle, 161, Val, NULL);
                    DefWndProc(ref msg);
                }
                else
                {
                    if (Current != Direction.NONE & Resizeable)
                    {
                        Capture = false;
                        IntPtr Val = new IntPtr(Convert.ToInt32(Current));
                        IntPtr NULL = IntPtr.Zero;
                        Message msg = Message.Create(Parent.Handle, 161, Val, NULL);
                        DefWndProc(ref msg);
                    }
                }
            }
            base.OnMouseDown(e);
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            if (Resizeable)
                SetCurrent();
            base.OnMouseMove(e);
        }

        protected override void OnSizeChanged(System.EventArgs e)
        {
            Invalidate();
            base.OnSizeChanged(e);
        }

        private Rectangle Drag
        {
            get { return new Rectangle(7, 7, Width - 14, 35); }
        }
    }

    internal class FButton : Control
    {
        private bool Shadow_ = true;

        public bool Shadow
        {
            get { return Shadow_; }
            set
            {
                Shadow_ = value;
                Invalidate();
            }
        }

        public FButton()
        {
            SetStyle((ControlStyles) 8198, true);
            Colors = new Pigment[]
                         {
                             new Pigment("Border", 254, 133, 0),
                             new Pigment("Backcolor", 247, 247, 251),
                             new Pigment("Highlight", 255, 197, 19),
                             new Pigment("Gradient1", 255, 175, 12),
                             new Pigment("Gradient2", 255, 127, 1),
                             new Pigment("Text Color", Color.White),
                             new Pigment("Text Shadow", 30, 0, 0, 0)
                         };
            Font = new Font("Verdana", 8);
        }

        private const byte Count = 7;
        private Pigment[] C;

        public Pigment[] Colors
        {
            get { return C; }
            set
            {
                if (value.Length != Count)
                    throw new IndexOutOfRangeException();

                P1 = new Pen(value[0].Value);
                P2 = new Pen(value[2].Value);

                B1 = new SolidBrush(value[6].Value);
                B2 = new SolidBrush(value[5].Value);

                C = value;
                Invalidate();
            }
        }

        private Pen P1;
        private Pen P2;
        private SolidBrush B1;
        private SolidBrush B2;
        private LinearGradientBrush B3;
        private Size SZ;

        private Point PT;
        private Graphics G;
        private Bitmap B;

        protected override void OnPaint(PaintEventArgs e)
        {
            B = new Bitmap(Width, Height);
            G = Graphics.FromImage(B);

            if (Down)
            {
                B3 = new LinearGradientBrush(ClientRectangle, C[4].Value, C[3].Value, 90f);
            }
            else
            {
                B3 = new LinearGradientBrush(ClientRectangle, C[3].Value, C[4].Value, 90f);
            }
            G.FillRectangle(B3, ClientRectangle);

            if (!string.IsNullOrEmpty(Text))
            {
                SZ = G.MeasureString(Text, Font).ToSize();
                PT = new Point(Convert.ToInt32(Width/2 - SZ.Width/2), Convert.ToInt32(Height/2 - SZ.Height/2));
                if (Shadow_)
                    G.DrawString(Text, Font, B1, PT.X + 1, PT.Y + 1);
                G.DrawString(Text, Font, B2, PT);
            }

            G.DrawRectangle(P1, new Rectangle(0, 0, Width - 1, Height - 1));
            G.DrawRectangle(P2, new Rectangle(1, 1, Width - 3, Height - 3));

            B.SetPixel(0, 0, C[1].Value);
            B.SetPixel(Width - 1, 0, C[1].Value);
            B.SetPixel(Width - 1, Height - 1, C[1].Value);
            B.SetPixel(0, Height - 1, C[1].Value);

            e.Graphics.DrawImage(B, 0, 0);
            B3.Dispose();
            G.Dispose();
            B.Dispose();
        }

        private bool Down;

        protected override void OnMouseDown(System.Windows.Forms.MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Down = true;
                Invalidate();
            }
            base.OnMouseDown(e);
        }

        protected override void OnMouseUp(System.Windows.Forms.MouseEventArgs e)
        {
            Down = false;
            Invalidate();
            base.OnMouseUp(e);
        }
    }

    internal class FProgressBar : Control
    {
        private double _Maximum = 100;

        public double Maximum
        {
            get { return _Maximum; }
            set
            {
                _Maximum = value;
                Progress = _Current/value*100;
            }
        }

        private double _Current;

        public double Current
        {
            get { return _Current; }
            set { Progress = value/_Maximum*100; }
        }

        private double _Progress;

        public double Progress
        {
            get { return _Progress; }
            set
            {
                if (value < 0)
                    value = 0;
                else if (value > 100)
                    value = 100;
                _Progress = value;
                _Current = value*0.01*_Maximum;
                Invalidate();
            }
        }

        public FProgressBar()
        {
            SetStyle((ControlStyles) 8198, true);
            Colors = new Pigment[]
                         {
                             new Pigment("Border", 214, 214, 216),
                             new Pigment("Backcolor1", 247, 247, 251),
                             new Pigment("Backcolor2", 239, 239, 242),
                             new Pigment("Highlight", 100, 255, 255, 255),
                             new Pigment("Forecolor", 224, 224, 224),
                             new Pigment("Gloss", 130, 255, 255, 255)
                         };
        }

        private const byte Count = 6;
        private Pigment[] C;

        public Pigment[] Colors
        {
            get { return C; }
            set
            {
                if (value.Length != Count)
                    throw new IndexOutOfRangeException();

                P1 = new Pen(value[0].Value);
                P2 = new Pen(value[3].Value);

                B1 = new SolidBrush(value[4].Value);

                CB = new ColorBlend();
                CB.Colors = new Color[]
                                {
                                    value[5].Value,
                                    Color.Transparent,
                                    Color.Transparent
                                };
                CB.Positions = new float[]
                                   {
                                       0,
                                       0.3F,
                                       1
                                   };

                C = value;
                Invalidate();
            }
        }

        private Pen P1;
        private Pen P2;
        private SolidBrush B1;
        private LinearGradientBrush B2;

        private ColorBlend CB;
        private Graphics G;
        private Bitmap B;

        protected override void OnPaint(PaintEventArgs e)
        {
            B = new Bitmap(Width, Height);
            G = Graphics.FromImage(B);

            G.Clear(C[2].Value);

            G.FillRectangle(B1, new Rectangle(1, 1, Convert.ToInt32((Width*_Progress*0.01) - 2), Height - 2));

            B2 = new LinearGradientBrush(ClientRectangle, Color.Empty, Color.Empty, 90f);
            B2.InterpolationColors = CB;
            G.FillRectangle(B2, ClientRectangle);

            G.DrawRectangle(P1, new Rectangle(0, 0, Width - 1, Height - 1));
            G.DrawRectangle(P2, new Rectangle(1, 1, Width - 3, Height - 3));

            B.SetPixel(0, 0, C[1].Value);
            B.SetPixel(Width - 1, 0, C[1].Value);
            B.SetPixel(Width - 1, Height - 1, C[1].Value);
            B.SetPixel(0, Height - 1, C[1].Value);

            e.Graphics.DrawImage(B, 0, 0);
            B2.Dispose();
            G.Dispose();
            B.Dispose();
        }

        protected override void OnSizeChanged(EventArgs e)
        {
            Invalidate();
            base.OnSizeChanged(e);
        }
    }
}
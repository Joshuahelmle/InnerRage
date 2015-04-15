using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace InnerRage.Interface
{

    public class VerticalTabs : TabControl
    {
        // [DllImportAttribute("uxtheme.dll")]
        // private static extern int SetWindowTheme(IntPtr hWnd, string appname, string idlist);

        private Color _tabFontColor = Color.White;
        private Color _tabBackgroundColor = Color.DimGray;
        private Color _tabSelectedFontColor = Color.Black;
        private Color _tabSelectedBackgroundColor = Color.White;
        private Font _tabFont = new Font("Tahoma", 16, FontStyle.Regular, GraphicsUnit.Pixel);

        private Color _mBackColor = Color.Transparent;

        private StringAlignment _tabTextHAlign = StringAlignment.Near;
        private StringAlignment _tabTextVAlign = StringAlignment.Center;

        public Color MyBackColor
        {
            get { return _mBackColor; }
            set { _mBackColor = value; this.Invalidate(); }
        }
        public Color TabFontColor { get { return _tabFontColor; } set { _tabFontColor = value; this.Refresh(); } }

        public Color TabBackgroundColor { get { return _tabBackgroundColor; } set { _tabBackgroundColor = value; this.Refresh(); } }

        public Color TabSelectedFontColor { get { return _tabSelectedFontColor; } set { _tabSelectedFontColor = value; this.Refresh(); } }

        public Color TabSelectedBackgroundColor { get { return _tabSelectedBackgroundColor; } set { _tabSelectedBackgroundColor = value; this.Refresh(); } }

        public Font TabFont { get { return _tabFont; } set { _tabFont = value; this.Refresh(); } }

        public StringAlignment TabTextHAlign { get { return _tabTextHAlign; } set { _tabTextHAlign = value; this.Refresh(); } }

        public StringAlignment TabTextVAlign { get { return _tabTextVAlign; } set { _tabTextVAlign = value; this.Refresh(); } }

        public VerticalTabs()
        {
            //            DrawItem += VerticalTabs_DrawItem;
            this.Alignment = TabAlignment.Left;
            this.DrawMode = TabDrawMode.OwnerDrawFixed;
            this.ItemSize = new Size(21, 200);
            this.Multiline = true;
            this.Padding = new Point(0, 6);
            this.Size = new Size(465, 296);
            this.SizeMode = TabSizeMode.Fixed;
        }


        private const int TcmAdjustrect = 0x1328;

        protected override void WndProc(ref Message m)
        {
            //Hide the tab headers at run-time
            if (m.Msg == TcmAdjustrect)
            {

                Rect rect = (Rect)(m.GetLParam(typeof(Rect)));
                rect.Left = this.Left - this.Margin.Left;
                rect.Right = this.Right + this.Margin.Right;

                rect.Top = this.Top - this.Margin.Top;
                rect.Bottom = this.Bottom + this.Margin.Bottom;
                Marshal.StructureToPtr(rect, m.LParam, true);
                //m.Result = (IntPtr)1;
                //return;
            }
            //else
            // call the base class implementation
            base.WndProc(ref m);
        }


        protected override bool ShowFocusCues
        {
            get { return false; }
        }

        private struct Rect
        {
            public int Left, Top, Right, Bottom;
        }

        //  protected override void OnHandleCreated(EventArgs e) {
        //      SetWindowTheme(this.Handle, "", "");
        //      base.OnHandleCreated(e);
        //  }



        //            private void VerticalTabs_DrawItem( object sender, DrawItemEventArgs e ) {
        protected override void OnDrawItem(DrawItemEventArgs e)
        {
            Graphics g = e.Graphics;
            Brush textBrush = default(Brush);
            Brush backgroundBrush = default(Brush);

            // Get the item from the collection. 
            TabPage tabPage = this.TabPages[e.Index];

            // Get the real bounds for the tab rectangle. 
            Rectangle tabBounds = this.GetTabRect(e.Index);

            if ((e.State == DrawItemState.Selected))
            {
                // Draw a different background color, and don't paint a focus rectangle.
                textBrush = new SolidBrush(TabSelectedFontColor);
                backgroundBrush = new SolidBrush(TabSelectedBackgroundColor);
                g.FillRectangle(backgroundBrush, e.Bounds);
            }
            else
            {
                textBrush = new SolidBrush(TabFontColor);
                backgroundBrush = new SolidBrush(TabBackgroundColor);
                g.FillRectangle(backgroundBrush, e.Bounds);
                //                    e.Graphics.Clear( System.Drawing.SystemColors.ControlDarkDark );
                //                    e.Graphics.Clear( System.Drawing.SystemColors.Control );
                // e.DrawBackground();
            }

            // Use our own font. 
            //Font _TabFont=new Font( "Arial", 10, FontStyle.Bold, GraphicsUnit.Pixel );

            // Draw string. Center the text. 
            StringFormat stringFlags = new StringFormat();
            stringFlags.Alignment = TabTextHAlign;
            stringFlags.LineAlignment = TabTextVAlign;
            g.DrawString(" " + tabPage.Text, TabFont, textBrush, tabBounds, new StringFormat(stringFlags));
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // VerticalTabs
            // 
            this.Alignment = TabAlignment.Left;
            this.DrawMode = TabDrawMode.OwnerDrawFixed;
            this.ItemSize = new Size(30, 200);
            this.Multiline = true;
            this.Padding = new Point(0, 0);
            this.Size = new Size(465, 296);
            this.SizeMode = TabSizeMode.Fixed;
            this.ResumeLayout(false);

        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            DrawControl(e.Graphics);
        }

        internal void DrawControl(Graphics g)
        {
            if (!Visible)
                return;

            Rectangle tabControlArea = this.ClientRectangle;
            Rectangle tabArea = this.DisplayRectangle;

            //----------------------------
            // fill client area
            Brush br = new SolidBrush(_mBackColor); //(SystemColors.Control); UPDATED
            g.FillRectangle(br, tabControlArea);
            br.Dispose();
            //----------------------------


        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PCB.Designs;
using PCB.Tools;
using System.Threading.Tasks;
using System.Windows.Forms;

using SharpDX;
using SharpDX.Direct2D1;
using SharpDX.DirectWrite;
using SharpDX.DXGI;

using AlphaMode = SharpDX.Direct2D1.AlphaMode;
using Color = SharpDX.Color;
using Factory = SharpDX.Direct2D1.Factory;
using FontStyle = SharpDX.DirectWrite.FontStyle;
using D2D = SharpDX.Direct2D1;
using Point = SharpDX.Point;
namespace PCB.Designs
{
    class DesignViewRenderer
    {

        //Ctor
        public DesignViewRenderer()
        {
            Resources = new RendererResources();
        }

        //PRIVATE members
        private Design m_design;
        Command m_selectedCommand;
        private SharpDX.Direct2D1.Factory m_factory2D;

        public SharpDX.DirectWrite.Factory m_factoryDWrite;

        public SolidColorBrush SceneColorBrush { get; set; }

        public SolidColorBrush SceneColorBrush1 { get; set; }
        internal Design Design
        {
            get
            {
                throw new System.NotImplementedException();
            }
            set
            {
            }
        }

        void InitRenderer()
        {
            Resources.Factory2D = new SharpDX.Direct2D1.Factory();
            FactoryDWrite = new SharpDX.DirectWrite.Factory();

            var properties = new HwndRenderTargetProperties();
            properties.Hwnd = m_designRenderer.Handle;
            properties.PixelSize = new Size2(m_designRenderer.ClientSize.Width, m_designRenderer.ClientSize.Height);
            properties.PresentOptions = PresentOptions.None;

            RenderTarget2D = new WindowRenderTarget(Factory2D, new RenderTargetProperties(new PixelFormat(Format.Unknown, AlphaMode.Premultiplied)), properties);
            RenderTarget2D.AntialiasMode = AntialiasMode.PerPrimitive;
            RenderTarget2D.TextAntialiasMode = SharpDX.Direct2D1.TextAntialiasMode.Cleartype;

            SceneColorBrush = new SolidColorBrush(RenderTarget2D, Color.Black);
        }

        void RenderControlPaint(object sender, PaintEventArgs e)
        {
            var tom = new D2D.Brush(new IntPtr());

            try
            {
                Resources.BeginDraw();

                RenderTarget2D.Clear(Color.White);


                for (UInt32 i = 0; i < 200; i += 10)
                {
                    RenderTarget2D.DrawLine(
                        new Vector2(0.0f + (200 * i), 0f),
                        new Vector2(0 + (200 * i), RenderTarget2D.Size.Height),
                        new SolidColorBrush(RenderTarget2D, Color.Black)
                        );

                    RenderTarget2D.DrawLine(
                        new Vector2(0f, 0.0f + (200 * i)),
                        new Vector2(RenderTarget2D.Size.Width, 0 + (200 * i)),
                        new SolidColorBrush(RenderTarget2D, Color.Black)
                        );
                }

                var size = this.RenderTarget2D.Size;
                var width = (float)((size.Width / 3.0));
                var ellipses = new List<D2D.Ellipse>();

                for (var i = 0; i < 3000; i++)
                {
                    ellipses.Add(new D2D.Ellipse(new Vector2(size.Width / 2.0f + i * 2, size.Height / 2.0f + i * 2), width, size.Height / 3.0f));
                }
                //var ellipse = new D2D.Ellipse(new D2D.Point2F(size.Width / 2.0f, size.Height / 2.0f), width, size.Height / 3.0f);

                // This draws the ellipse in red on a semi-transparent blue background

                for (Int32 i = 0; i < 3000; i++)
                {
                    this.RenderTarget2D.FillEllipse(ellipses[i], new SolidColorBrush(RenderTarget2D, Color.IndianRed));
                    //ellipses.Add(new D2D.Ellipse(new D2D.Point2F(size.Width / 2.0f, size.Height / 2.0f), width, size.Height / 3.0f));
                }

                RenderTarget2D.EndDraw();
            }
            catch (Exception ex)
            {

            }
        }

        public void Paint(object sender, PaintEventArgs e)
        {
            throw new System.NotImplementedException();
        }
    }
}

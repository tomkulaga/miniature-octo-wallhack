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
using D2D1Factory = SharpDX.Direct2D1.Factory;
using FontStyle = SharpDX.DirectWrite.FontStyle;
using D2D = SharpDX.Direct2D1;
using Point = SharpDX.Point;


namespace PCB.Designs
{
    public class DesignViewRenderer
    {

        //Ctor
        public DesignViewRenderer()
        {
            itemOffsetY = 0;
            itemOffsetX = 0;
            zoomLevel = 1;
        }

        //PRIVATE members

        private SolidColorBrush _blackBrush;
        private SolidColorBrush _redBrush;
        private SolidColorBrush _faintBlackBrush;

        private void CreateBrushes()
        {
            _blackBrush = new SolidColorBrush(RenderTarget2D, Color4.Black);
            _redBrush = new SolidColorBrush(RenderTarget2D, new Color4(1, 0, 0, 1));
            _faintBlackBrush = new SolidColorBrush(RenderTarget2D, new Color4(0, 0, 0, (float)0.3));
            m_sceneColorBrush = new SolidColorBrush(RenderTarget2D, Color4.Black);
        }

        private void FreeBrushes()
        {

        }


        private void CreateResources()
        {

        }

        private void FreeResources()
        {

        }
        D2D1Factory m_factory2D;

        SolidColorBrush m_sceneColorBrush;

        public List<Geometry> itemsToDraw = new List<Geometry>(); 

        public void InitRenderer(Control controlToPaint)
        {
            m_factory2D = new D2D1Factory();

            var properties = new HwndRenderTargetProperties
            {
                Hwnd = controlToPaint.Handle,
                PixelSize = new Size2(controlToPaint.ClientSize.Width, controlToPaint.ClientSize.Height),
                PresentOptions = PresentOptions.RetainContents
            };

            RenderTarget2D = new WindowRenderTarget(m_factory2D, new RenderTargetProperties(new PixelFormat(Format.Unknown, AlphaMode.Premultiplied)), properties)
            {
                AntialiasMode = AntialiasMode.Aliased,
                TextAntialiasMode = SharpDX.Direct2D1.TextAntialiasMode.Cleartype
               
                
            };

            CreateBrushes();
        }

        public void RenderControlPaint(object sender, PaintEventArgs e)
        {
            var tom = new D2D.Brush(new IntPtr());

            try
            {
                RenderTarget2D.BeginDraw();

                RenderTarget2D.Clear(Color.White);

                RenderTarget2D.Transform = Matrix3x2.Identity;

                for (var i = -2000; i < 2000; i += 10)
                {
                    RenderTarget2D.DrawLine(
                        new Vector2(0.0f + (1 * i), 0f),
                        new Vector2(0 + (1 * i), RenderTarget2D.Size.Height),
                        _faintBlackBrush
                        );

                    RenderTarget2D.DrawLine(
                        new Vector2(0f, 0.0f + (1 * i)),
                        new Vector2(RenderTarget2D.Size.Width, 0 + (1 * i)),
                        _faintBlackBrush
                        );
                }

                RenderTarget2D.Transform = Matrix3x2.Scaling(zoomLevel,zoomLevel) * Matrix3x2.Translation(itemOffsetX, itemOffsetY);

                var size = this.RenderTarget2D.Size;
                var width = (float)((size.Width / 3.0));
                var ellipses = new List<RectangleF>();
                var ellipses2 = new List<Ellipse>();
                var brush = new SolidColorBrush(RenderTarget2D, Color.IndianRed);
                var brushE = new SolidColorBrush(RenderTarget2D, Color.Chocolate);
                for (var i = 0; i < 3000; i+=40)
                {
                    for (var j = 0; j < 3000; j +=40)
                    {
                      ellipses.Add(new RectangleF(i,j,20,20));
                      ellipses2.Add(new Ellipse(new Vector2(i + 10, j + 10), 10f, 20f));
                    }

                }


                for (var i = 0; i < 5625; i++)
                {
                    switch (i)
                    {
                        case 10:
                            RenderTarget2D.Transform = Matrix3x2.Scaling(zoomLevel, zoomLevel) * Matrix3x2.Translation(singleItemX, singleItemY);
                            ;
                            break;
                        case 11:
                            RenderTarget2D.Transform =  Matrix3x2.Scaling(zoomLevel, zoomLevel) * Matrix3x2.Translation(itemOffsetX, itemOffsetY);
                            ;
                            break;
                    }
                    this.RenderTarget2D.DrawRectangle(ellipses[i], brush);
                    this.RenderTarget2D.DrawEllipse(ellipses2[i], brushE);
                    //ellipses.Add(new D2D.Ellipse(new D2D.Point2F(size.Width / 2.0f, size.Height / 2.0f), width, size.Height / 3.0f));
                }
                foreach (var item in itemsToDraw)
                {
                    RenderTarget2D.DrawGeometry(item,new SolidColorBrush(RenderTarget2D, Color4.Black));
                }
                RenderTarget2D.EndDraw();
            }
            catch (Exception ex)
            {
                MessageBox.Show((ex.ToString()));
            }
        }

        public float zoomLevel { get; set; }

        public float singleItemY { get; set; }

        public float singleItemX { get; set; }

        public float itemOffsetY { get; set; }

        public float itemOffsetX { get; set; }

        public void Paint(object sender, PaintEventArgs e)
        {
            throw new System.NotImplementedException();
        }

        public void attachRenderTarget(Object renderTarget)
        {

        }

        public void removeRenderTarget()
        {

        }

        public void AddItem(Point location,Size2 newSize)
        {
            itemsToDraw.Add(new RectangleGeometry(m_factory2D, new RectangleF(location.X, location.Y, newSize.Width, newSize.Height)));
        }

        #region Protected Members


        //The actual design that is rendered, this will be filled in with a concrete design
        //i.e. Schematic, PCB, Library (schematic or PCB)
        private Design m_design;
        private WindowRenderTarget RenderTarget2D;



        #endregion
    }
}

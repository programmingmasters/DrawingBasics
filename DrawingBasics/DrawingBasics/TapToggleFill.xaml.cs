using SkiaSharp;
using SkiaSharp.Views.Forms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DrawingBasics
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TapToggleFill : ContentPage
    {

        bool showFill = true;

        public TapToggleFill()
        {
            InitializeComponent();
        }

        private void OnCanvasViewPaintSurface(object sender, SkiaSharp.Views.Forms.SKPaintSurfaceEventArgs args)
        {
            SKImageInfo info = args.Info;
            SKSurface surface = args.Surface;
            SKCanvas canvas = surface.Canvas;

            canvas.Clear();

            SKPaint paint = new SKPaint()
            {
                Style = SKPaintStyle.Stroke,
                Color = Color.Red.ToSKColor(),
                StrokeWidth = 50,
                IsAntialias = true
            };

            canvas.DrawCircle(info.Width / 2, info.Height / 2, 100, paint);

            if (showFill)
            {
                paint.Style = SKPaintStyle.Fill;
                paint.Color = SKColors.Blue;
                canvas.DrawCircle(info.Width / 2, info.Height / 2, 100, paint);
            }

        }

        private void OnCanvasViewTapped(object sender, EventArgs e)
        {
            showFill ^= true;
            (sender as SKCanvasView).InvalidateSurface(); //Informs the canvas that it need to redraw itself;
            //Call the PaintSurface event.
        }
    }
}
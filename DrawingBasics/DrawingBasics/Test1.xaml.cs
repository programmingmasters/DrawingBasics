using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using SkiaSharp;
using SkiaSharp.Views.Forms;

namespace DrawingBasics
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Test1 : ContentPage
    {
        public Test1()
        {
            InitializeComponent();
        }

        private void CanvasView_PaintSurface(object sender, SkiaSharp.Views.Forms.SKPaintSurfaceEventArgs e)
        {
            SKImageInfo info = e.Info;
            SKSurface surface = e.Surface;
            SKCanvas canvas = surface.Canvas;

            canvas.Clear();

            SKRect rect = new SKRect();
            rect.Top = (float)0;
            rect.Bottom = (float)info.Height;
            rect.Left = (float)0;
            rect.Right = (float)info.Width;

           
            SKPaint paint = new SKPaint()
            {
                Style = SKPaintStyle.StrokeAndFill,
                StrokeWidth = 10,
                IsAntialias = true,
            };


            SKPoint start = new SKPoint()
            {
                X = info.Width / 2,
                Y = (float)0
            };

            SKPoint end = new SKPoint()
            {
                X = info.Width / 2,
                Y = (float)rect.Bottom
            };

            paint.Shader = SKShader.CreateLinearGradient(
                start,
                end,
                new SKColor[] { SKColors.Blue, SKColors.Transparent},
                null,
                SKShaderTileMode.Clamp
                );


            canvas.DrawRect(rect, paint);


        }
    }
}
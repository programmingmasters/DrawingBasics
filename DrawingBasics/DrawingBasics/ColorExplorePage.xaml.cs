using SkiaSharp;
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
    public partial class ColorExplorePage : ContentPage
    {
        public ColorExplorePage()
        {
            InitializeComponent();

            hueSlider.Value = 0;
            saturationSlider.Value = 100;
            lightnessSlider.Value = 50;
            valueSlider.Value = 100;
        }

        private void OnSliderValueChanged(object sender, ValueChangedEventArgs e)
        {
            hslCanvasView.InvalidateSurface();
            hsvCanvasView.InvalidateSurface();
        }

        private void OnHslCanvasViewPaintSurface(object sender, SkiaSharp.Views.Forms.SKPaintSurfaceEventArgs e)
        {
            SKColor color = SKColor.FromHsl((float)hueSlider.Value,
                (float)saturationSlider.Value, (float)lightnessSlider.Value);

            e.Surface.Canvas.Clear();

            hslLabel.Text = String.Format("RGB = {0:X2}-{1:X2}-{2:X2} ", color.Red, color.Green, color.Blue);
        }

        private void OnHsvCanvasViewPaintSurface(object sender, SkiaSharp.Views.Forms.SKPaintSurfaceEventArgs e)
        {
            SKColor color = SKColor.FromHsv((float)hueSlider.Value, (float)saturationSlider.Value, (float)valueSlider.Value);
            e.Surface.Canvas.Clear(color);
            hslLabel.Text = String.Format("RGB = {0:X2}-{1:X2}-{2:X2} ", color.Red, color.Green, color.Blue);
        }
    }
}
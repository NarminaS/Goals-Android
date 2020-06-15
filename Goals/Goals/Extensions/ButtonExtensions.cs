using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Goals.Extensions
{
    public static class ButtonExtensions
    {
        public static async Task ScaleAnimation(this Button source, double scaleTo, double scaleReturn)
        {
            await source.ScaleTo(scaleTo, 250, Easing.CubicInOut);
            await source.ScaleTo(scaleReturn, 250, Easing.CubicInOut);
        }
    }
}

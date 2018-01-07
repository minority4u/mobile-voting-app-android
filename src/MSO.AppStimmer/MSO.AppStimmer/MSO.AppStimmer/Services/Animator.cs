using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MSO.StimmApp.Services
{
    public static class Animator
    {
        public static int DelaySpeed = 100;

        public enum FadeType
        {
            In,
            Out
        }

        public static async Task SimpleFade(View view, FadeType fadeType, uint animationSpeed = 500)
        {
            if (fadeType == FadeType.In)
            {
                view.ScaleTo(1, animationSpeed, Easing.SinIn);
                await view.FadeTo(1, animationSpeed, Easing.SinIn);
            }
        }
    }
}

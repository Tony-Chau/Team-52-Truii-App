using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using UK.CO.Chrisjenx.Calligraphy;

namespace Truii_App.Functions
{
    public class FontFunction
    {
        public FontFunction()
        {
        }

        public void CreateFont(string fontName)
        {
            CalligraphyConfig.InitDefault(new CalligraphyConfig.Builder()
            .SetDefaultFontPath("fonts/" + fontName + ".ttf")
            .SetFontAttrId(Resource.Attribute.fontPath)
            .Build());
        }
    }
}
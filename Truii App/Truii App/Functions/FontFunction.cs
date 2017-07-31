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
	        //Marcus if u want an to see an example of how to use this, look at the main.axml code 
			//You can insert more fonts by downloading tff files online and import it to assets/fonts folder
			//Then write CreateFont("NAME_OF_FONT"); in the FontFunction() below
    public class FontFunction
    {
        public FontFunction()
        {
            CreateFont("Oswald-Regular");
            CreateFont("Arberkley");
        }

        private void CreateFont(string fontName)
        {
            CalligraphyConfig.InitDefault(new CalligraphyConfig.Builder()
            .SetDefaultFontPath("fonts/" + fontName + ".ttf")
            .SetFontAttrId(Resource.Attribute.fontPath)
            .Build());
        }
    }
}
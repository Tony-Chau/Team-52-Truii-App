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
	        //Marcus if you want an to see an example of how to use this, look at the main.axml code 
			//You can insert more fonts by downloading ttf files online and import it to assets/fonts folder
			//Then write CreateFont("NAME_OF_FONT"); in the FontFunction() below
    public class FontFunction
    {
        public FontFunction()
        {
            CreateFont("Oswald-Regular");
            CreateFont("Oswald-Stencil");
            CreateFont("Arberkley");
            CreateFont("Arial");
            //The latest font that was inputted will be the default font
            CreateFont("Times_New_Roman");
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
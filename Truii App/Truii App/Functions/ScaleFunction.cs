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

namespace Truii_App.Functions
{
    public class ScaleFunction
    {
        const float original_height = 50; //Need the size of Marcus' phone
        const float original_width = 50; //Need the size of Marcus' phone
        float height;
        float width;

        /// <summary>
        /// Scales the height of an object to match the current phone's height
        /// </summary>
        /// <param name="height">The height of the object</param>
        /// <returns>The scaled height</returns>
        public float GetScaleHeight(float height)
        {
            return ((height / this.height) * original_height); 
        }

        /// <summary>
        /// Scales the width of an object to match the current phone's width
        /// </summary>
        /// <param name="width">The width of the object</param>
        /// <returns>The scaled width</returns>
        public float GetScaleWidth(float width)
        {
            return ((width / this.width) * original_width);
        }

        /// <summary>
        /// Gains the information on the current phone's height and width
        /// </summary>
        /// <param name="height">The height of phone being used</param>
        /// <param name="width">The width of the phone being used</param>
        public ScaleFunction(float height, float width)
        {
            this.height = height;
            this.width = width;
        }

    }
}
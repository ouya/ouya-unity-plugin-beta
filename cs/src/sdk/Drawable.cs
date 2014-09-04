using Android.Runtime;
using System;
using UnityEngine;

namespace Android.Graphics.Drawables
{
    public class Drawable
    {
        static IntPtr _jcDrawable = IntPtr.Zero;
        private IntPtr _instance = IntPtr.Zero;

        static Drawable()
        {
        }

        public static Drawable GetObject(IntPtr instance)
        {
            if(Application.platform != RuntimePlatform.Android) return null;
            Drawable result = new Drawable();
            result._instance = instance;
            return result;
        }

        public IntPtr Instance
        {
            get { return _instance; }
            set { _instance = value; }
        }
    }
}
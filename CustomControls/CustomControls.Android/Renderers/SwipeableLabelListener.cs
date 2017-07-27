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

namespace CustomControls.Droid.Renderers
{
    public class SwipeableLabelListener : GestureDetector.SimpleOnGestureListener
    {
        public override bool OnScroll(MotionEvent e1, MotionEvent e2, float distanceX, float distanceY)
        {
           //return base.OnScroll(e1, e2, distanceX, distanceY);
           return true;
        }
        public override void OnLongPress(MotionEvent e)
        {
            base.OnLongPress(e);
        }

        public override bool OnDoubleTap(MotionEvent e)
        {
            return base.OnDoubleTap(e);
        }

        public override bool OnDoubleTapEvent(MotionEvent e)
        {
            return base.OnDoubleTapEvent(e);
        }

        public override bool OnSingleTapUp(MotionEvent e)
        {
            return base.OnSingleTapUp(e);
        }

        public override bool OnDown(MotionEvent e)
        {
            return base.OnDown(e);
        }

        public override bool OnFling(MotionEvent e1, MotionEvent e2, float velocityX, float velocityY)
        {
            return base.OnFling(e1, e2, velocityX, velocityY);
        }

        public override void OnShowPress(MotionEvent e)
        {
            base.OnShowPress(e);
        }

        public override bool OnSingleTapConfirmed(MotionEvent e)
        {
            return base.OnSingleTapConfirmed(e);
        }

    }
}
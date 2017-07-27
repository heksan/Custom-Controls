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
using Xamarin.Forms.Platform.Android;
using Xamarin.Forms;
using CustomControlsLibrary.SwipeToDelete;
using CustomControls.Droid.Renderers;
using Android.Views.Animations;

[assembly: ExportRenderer(typeof(SwipeableLabel), typeof(SwipeableLabelRenderer))]


namespace CustomControls.Droid.Renderers
{
    public class SwipeableLabelRenderer : LabelRenderer
    {
        private readonly SwipeableLabelListener _listener;
        private readonly GestureDetector _detector;
        private SwipeableLabel label;
        Android.Views.Animations.TranslateAnimation animation;
        public SwipeableLabelRenderer()
        {
            _listener = new SwipeableLabelListener();
            _detector = new GestureDetector(_listener);
        }
        protected override void OnElementChanged(ElementChangedEventArgs<Label> e)
        {
            base.OnElementChanged(e);
            if (e.NewElement == null)
            {
                this.Touch -= HandleTouch;
            }

            if (e.OldElement == null)
            {
                label = (SwipeableLabel)e.NewElement;
                this.Touch += HandleTouch;
            }
            if (e.OldElement!=null && e.NewElement!=null)
            {
                //fix model assigment after deletion as well as reset visuals to starting positions
                label = (SwipeableLabel)e.NewElement;
                Control.ClearAnimation();
                Control.SetX(0);
            }
        }
        void HandleTouch(object sender, TouchEventArgs e)
        {

            if (e.Event.Action == Android.Views.MotionEventActions.Down)
            {
                Control.SetX(0);
                Control.ClearAnimation();
            }
            var swiped = _detector.OnTouchEvent(e.Event);
            if (swiped)
            {
                try
                {
                    var endPoint = e.Event.HistorySize;
                    var end = e.Event.GetHistoricalX(endPoint - 1);
                    var start = e.Event.GetHistoricalX(0);
                    var dif = end - start;
                    if (dif>0)
                    {
                        Control.TranslationX = Control.TranslationX + dif;
                    }
                }
                catch (Exception)
                {
                    //sometimes historicalX gets out of bounds coz xamarin is so well written
                }

            }
            if (e.Event.Action == Android.Views.MotionEventActions.Up || e.Event.Action == Android.Views.MotionEventActions.Cancel)
            {
                var delta = Control.GetX();
                if (delta > 300)//arbitrarynumber no point in getting it every time, should be probed once based on time on app startup,
                {
                    animation = GetDeletingAnimation();
                    animation.AnimationEnd += DeleteControl;
                }else
                {
                    animation = GetReturnAnimation(delta);
                }                
                Control.StartAnimation(animation);
            }


        }

        private void DeleteControl(object sender, Android.Views.Animations.Animation.AnimationEndEventArgs e)
        {
            label.Dispose();
            Control.RefreshDrawableState();
        }

        private TranslateAnimation GetDeletingAnimation()
        {
            return new Android.Views.Animations.TranslateAnimation(0, 1000, 0, 0)
            {
                Duration = 300,
                FillBefore = true,
                FillAfter = true,
                FillEnabled = true
            };
        }

        private Android.Views.Animations.TranslateAnimation GetReturnAnimation(float delta)
        {
            return new Android.Views.Animations.TranslateAnimation(0, -delta, 0, 0)
            {
                Duration = 600,
                FillBefore = true,
                FillAfter = true,
                FillEnabled = true
            };
        }
    }
}
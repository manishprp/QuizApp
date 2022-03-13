using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QuizApp.fragments
{
    public class completedFragment : AndroidX.AppCompat.App.AppCompatDialogFragment
    {
        string remarks, image, score;
        TextView scoreTextView, remarksTextView;
        ImageView completeImage;
        Button gohomeButton;
        public event EventHandler gohome;
        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your fragment here
        }
        public completedFragment(string remarkIn, string imageIn, string scoreIn)
        {
            remarks = remarkIn;
            image = imageIn;
            score = scoreIn;
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            // Use this to return your custom view for this Fragment
            View view = inflater.Inflate(Resource.Layout.completed, container, false);
            scoreTextView = (TextView)view.FindViewById(Resource.Id.scoreTextView);
            remarksTextView=  (TextView)view.FindViewById(Resource.Id.scoreTextView);
            completeImage = (ImageView)view.FindViewById(Resource.Id.image);
            gohomeButton = (Button)view.FindViewById(Resource.Id.goHomeButton);

            scoreTextView.Text = score;
            remarksTextView.Text = remarks;
            if(image== "failed")
            {
                completeImage.SetImageResource(Resource.Drawable.sad);
            }
            gohomeButton.Click += GohomeButton_Click;
            return view;
        }

        private void GohomeButton_Click(object sender, EventArgs e)
        {
            this.Dismiss();
            gohome?.Invoke(this, new EventArgs());
        }
    }
}
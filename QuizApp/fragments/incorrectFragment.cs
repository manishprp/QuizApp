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
    public class incorrectFragment : AndroidX.AppCompat.App.AppCompatDialogFragment
    {
        string answer;
        TextView correctAnswerText;
        public event EventHandler NextQuestion;
        Button nextButton;
        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your fragment here
        }
        public incorrectFragment(string correctAnswer)
        {
            answer = correctAnswer;
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            // Use this to return your custom view for this Fragment
            // return inflater.Inflate(Resource.Layout.YourFragment, container, false);
            View view = inflater.Inflate(Resource.Layout.wrong, container, false);
            correctAnswerText = (TextView)view.FindViewById(Resource.Id.correctAnswerTextView);
            nextButton = (Button)view.FindViewById(Resource.Id.nextButton);
            correctAnswerText.Text = answer;
            nextButton.Click += NextButton_Click;
            return view;
        }

        private void NextButton_Click(object sender, EventArgs e)
        {
            this.Dismiss();
            NextQuestion?.Invoke(this,new EventArgs());
        }
    }
}
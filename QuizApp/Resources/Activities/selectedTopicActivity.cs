using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QuizApp.Resources.Activities
{
    [Activity(Label = "selectedTopicActivity")]
    public class selectedTopicActivity : Activity
    {
        ImageView quizImage;
        TextView descriptionTextView;
        TextView topicTextView;
        Button startQuiz;
        string message;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.selected_topic);
            // Create your application here
            uiRefererence();
            message = Intent.GetStringExtra("topic");
            topicTextView.Text = message;
        }
        public void uiRefererence()
        {
            quizImage = (ImageView)FindViewById(Resource.Id.quizImage);
            descriptionTextView = (TextView)FindViewById(Resource.Id.descriptionTextView);
            topicTextView = (TextView)FindViewById(Resource.Id.topicTextView);
            startQuiz = (Button)FindViewById(Resource.Id.startQuizButton);
        }
    }
}
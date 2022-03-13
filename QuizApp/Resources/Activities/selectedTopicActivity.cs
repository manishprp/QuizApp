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
        Quizhelper quizHelper = new Quizhelper();
        string message;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.selected_topic);
            // Create your application here
            uiRefererence();
            message = Intent.GetStringExtra("topic");
            topicTextView.Text = message;
            quizImage.SetImageResource(getImage(message));
            descriptionTextView.Text = quizHelper.GetTopicDescription(message);
            startQuiz.Click += StartQuiz_Click;
        }

        private void StartQuiz_Click(object sender, EventArgs e)
        {
            Intent intent = new Intent(this, typeof(quizPageActivity));
            intent.PutExtra("topic", message);
            StartActivity(intent);
            Finish();
        }

        public void uiRefererence()
        {
            quizImage = (ImageView)FindViewById(Resource.Id.quizImage);
            descriptionTextView = (TextView)FindViewById(Resource.Id.descriptionTextView);
            topicTextView = (TextView)FindViewById(Resource.Id.topicTextView);
            startQuiz = (Button)FindViewById(Resource.Id.startQuizButton);
        }
       
        int getImage(string topicBased)
        {
            int image = 0;
            if(topicBased == "History")
            {
                 image = Resource.Drawable.history;
            }
            else if(topicBased == "Geography")
            {
                 image = Resource.Drawable.geography;
            }
            else if (topicBased == "Space")
            {
                image = Resource.Drawable.space;
            }
            else if (topicBased == "Programming")
            {
                image = Resource.Drawable.programming;
            }
            else if (topicBased == "Business")
            {
                image = Resource.Drawable.business;
            }
            else if (topicBased == "Engineering")
            {
                image = Resource.Drawable.engineering;
            }
            return image;
        }
    }
}
using Android.App;
using Android.Content;
using Android.OS;
 using Android.Views;
using Android.Widget;
using AndroidX.AppCompat.App;
using AndroidX.AppCompat.Widget;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using QuizApp.model;
using QuizApp.fragments;
using Google.Android.Material.Snackbar;

namespace QuizApp.Resources.Activities
{
    [Activity(Label = "quizPageActivity")]
    public class quizPageActivity : AppCompatActivity
    {
        AndroidX.AppCompat.Widget.Toolbar toolbar;
        string quizTopic ="";
        RadioButton optionARadio, optionBRadio, optionCRadio, optionDRadio;
        TextView optionAText, optionBText, optionCText, optionDText, timeCounterText, quizPositionText, questionText;
        Button proceedButton;
        List<Question> questionList = new List<Question>();
        Quizhelper quizhelper = new Quizhelper();
        int quizPosition;
        double userScore;
        int timerCounter = 0;
        DateTime dateTime;
        System.Timers.Timer countDown = new System.Timers.Timer();
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.quiz_page);
            uiReference();

            SetSupportActionBar(toolbar);
            quizTopic = Intent.GetStringExtra("topic");

            SupportActionBar.Title = quizTopic + " Quiz";
            AndroidX.AppCompat.App.ActionBar actionbar = SupportActionBar;
            actionbar.SetHomeAsUpIndicator(Resource.Drawable.outline_arrowback);
            actionbar.SetDisplayHomeAsUpEnabled(true);
            questionList = quizhelper.GetQuizQuestions(quizTopic);
            beginQuiz();
            clickEvents();
            countDown.Interval = 1000;
            countDown.Elapsed += CountDown_Elapsed;
        }

        private void CountDown_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            timerCounter++;

            DateTime dt = new DateTime();
            dt = dateTime.AddSeconds(-1);

            var dateDifference = dateTime.Subtract(dt);
            dateTime = dateTime - dateDifference;

            RunOnUiThread(() =>
            {
                timeCounterText.Text = dateTime.ToString("mm:ss");
            });

            // End Quiz on Timeout
            if (timerCounter == 120)
            {
                countDown.Enabled = false;
                completeQuiz();
            }
        }

        public void clickEvents()
        {
            optionARadio.Click += OptionARadio_Click;
            optionBRadio.Click += OptionBRadio_Click;
            optionCRadio.Click += OptionCRadio_Click;
            optionDRadio.Click += OptionDRadio_Click;
            proceedButton.Click += ProceedButton_Click;
        }

        private void ProceedButton_Click(object sender, EventArgs e)
        {
            if(!optionARadio.Checked&& !optionBRadio.Checked && !optionCRadio.Checked && !optionDRadio.Checked )
            {
                Snackbar.Make((View)sender, "Choose one of option", Snackbar.LengthShort).Show();
               
               
            }
            else if(optionARadio.Checked)
            {
                if(optionAText.Text== questionList[quizPosition-1].Answer)
                {
                    userScore++;
                    correctAnswer();
                }
                else
                {
                    incorrectAnswer();
                }
            }
            else if (optionBRadio.Checked)
            {
                if (optionBText.Text == questionList[quizPosition - 1].Answer)
                {
                    userScore++;
                    correctAnswer();
                }
                else
                {
                    incorrectAnswer();
                }
            }
            else if (optionCRadio.Checked)
            {
                if (optionCText.Text == questionList[quizPosition - 1].Answer)
                {
                    userScore++;
                    correctAnswer();
                }
                else
                {
                    incorrectAnswer();
                }
            }
            else if (optionDRadio.Checked)
            {
                if (optionDText.Text == questionList[quizPosition - 1].Answer)
                {
                    userScore++;
                    correctAnswer();
                }
                else
                {
                    incorrectAnswer();
                }
            }
        }

        private void OptionDRadio_Click(object sender, EventArgs e)
        {
            clearSelections();
            optionDRadio.Checked = true;
        }

        private void OptionCRadio_Click(object sender, EventArgs e)
        {
            clearSelections();
            optionCRadio.Checked = true;
        }

        private void OptionBRadio_Click(object sender, EventArgs e)
        {
            clearSelections();
            optionBRadio.Checked = true;
        }

        private void OptionARadio_Click(object sender, EventArgs e)
        {
            clearSelections();
            optionARadio.Checked = true;
        }

        public void clearSelections()
        {
            optionARadio.Checked = false;
            optionBRadio.Checked = false;
            optionCRadio.Checked = false;
            optionDRadio.Checked = false;

        }

        private void uiReference()
        {
            toolbar = FindViewById<AndroidX.AppCompat.Widget.Toolbar>(Resource.Id.quiztoolbar);
            optionARadio = FindViewById<RadioButton>(Resource.Id.optionARadio);
            optionBRadio = FindViewById<RadioButton>(Resource.Id.optionBRadio);
            optionCRadio = FindViewById<RadioButton>(Resource.Id.optionCRadio);
            optionDRadio = FindViewById<RadioButton>(Resource.Id.optionDRadio);
            proceedButton = FindViewById<Button>(Resource.Id.proceedQuizButton);
            optionAText = FindViewById<TextView>(Resource.Id.optionATextView);
            optionBText = FindViewById<TextView>(Resource.Id.optionBTextView);
            optionCText = FindViewById<TextView>(Resource.Id.optionCTextView);
            optionDText = FindViewById<TextView>(Resource.Id.optionDTextView);
            timeCounterText = FindViewById<TextView>(Resource.Id.timeCounterTextView);
            quizPositionText = FindViewById<TextView>(Resource.Id.quizPositionTextView);
            questionText = FindViewById<TextView>(Resource.Id.questionTextView);
        }
        void beginQuiz()
        {
           
            quizPosition = 1;
            quizPositionText.Text = "Question " + quizPosition.ToString() + "/" + questionList.Count();
            questionText.Text = questionList[0].QuizQuestion;
            optionAText.Text = questionList[0].OptionA;
            optionBText.Text = questionList[0].OptionB;
            optionCText.Text = questionList[0].OptionC;
            optionDText.Text = questionList[0].OptionD;

            dateTime = new DateTime();
            dateTime = dateTime.AddMinutes(2);
            timeCounterText.Text = dateTime.ToString("mm:ss");

            countDown.Enabled = true;

        }
        public void incorrectAnswer()
        {
            incorrectFragment incorrect = new incorrectFragment(questionList[quizPosition - 1].Answer);
            var trans = SupportFragmentManager.BeginTransaction();
            incorrect.Cancelable = false;
            incorrect.Show(trans, "incorrect");           
            incorrect.NextQuestion += Correctfragment_NextQuestion;

        }
        public void correctAnswer()
        {
            correctFragment correctfragment = new correctFragment();
            var trans = SupportFragmentManager.BeginTransaction();
            correctfragment.Cancelable = false;
            correctfragment.Show(trans, "correct");
            correctfragment.NextQuestion += Correctfragment_NextQuestion;
        }

        private void Correctfragment_NextQuestion(object sender, EventArgs e)
        {
            //xyz
            quizPosition++;
            clearSelections();
            if(quizPosition> questionList.Count)
            {
                completeQuiz();
                return;
            }
            int index = quizPosition - 1;

            quizPositionText.Text = "Question " + quizPosition.ToString() + "/" + questionList.Count().ToString();
            questionText.Text = questionList[index].QuizQuestion;
            optionAText.Text = questionList[index].OptionA;
            optionBText.Text = questionList[index].OptionB;
            optionCText.Text = questionList[index].OptionC;
            optionDText.Text = questionList[index].OptionD;

        }
        public void completeQuiz()
        {
            timeCounterText.Text = "00:00";
            countDown.Enabled = false;
            string score = userScore.ToString() + "/" + questionList.Count.ToString();
            double percentage = (userScore / questionList.Count) * 100;
            string remarks = "";
            string image = "";

            if (percentage > 50 && percentage < 70)
            {
                remarks = "Very Good result, you\nReally tried";
            }
            else if (percentage >= 70)
            {
                remarks = "Very Outstanding result, you\nKilled it!!";
            }
            else if (percentage == 50)
            {
                remarks = "You really made it,\nAverage result";
            }
            else if (percentage < 50)
            {
                remarks = "So sad you didn't make it, \nBut you can try again";
                image = "failed";
            }
            completedFragment completeFrag = new completedFragment(remarks,image,score);
            var trans = SupportFragmentManager.BeginTransaction();
            completeFrag.Cancelable = false;
            completeFrag.Show(trans, "completed");
            completeFrag.gohome += (sender, e) =>
            {
                this.Finish();
            };


        }

      
    }
}
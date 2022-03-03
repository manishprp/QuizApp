using Android.App;
using Android.Content;
using Android.OS;
using AndroidX.AppCompat.App;
using AndroidX.AppCompat.Widget;
using AndroidX.CardView.Widget;
using QuizApp.Resources.Activities;

namespace QuizApp
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme")]
    public class MainActivity : AppCompatActivity
    {
        Toolbar toolbar;
        CardView card;
      
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);
            toolbar = FindViewById<Toolbar>(Resource.Id.toolbar);
            SetSupportActionBar(toolbar);
            card = FindViewById<CardView>(Resource.Id.historyCardView);
            card.Click += Card_Click;

        }

        private void Card_Click(object sender, System.EventArgs e)
        {
            Intent intent = new Intent(this, typeof(selectedTopicActivity));
            StartActivity(intent);
        }
    }
}
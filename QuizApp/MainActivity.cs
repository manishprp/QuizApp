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
        CardView historyCard, geographyCard, spaceCard, engineeringCard, businessCard, programmingCard;   
       
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);
            uiReferences();
           
            SetSupportActionBar(toolbar);
            SupportActionBar.Title = "Topics";
            AndroidX.AppCompat.App.ActionBar actionbar = SupportActionBar;
            actionbar.SetHomeAsUpIndicator(Resource.Drawable.menuaction);
            actionbar.SetDisplayHomeAsUpEnabled(true);

            clickEvents();
          
        }
       
        public void uiReferences()
        {
            toolbar = FindViewById<Toolbar>(Resource.Id.toolbar);
            historyCard = FindViewById<CardView>(Resource.Id.historyCardView);
            geographyCard = FindViewById<CardView>(Resource.Id.geographyCardView);
            spaceCard = FindViewById<CardView>(Resource.Id.spaceCardView);
            engineeringCard = FindViewById<CardView>(Resource.Id.engineeringCardView);
            businessCard = FindViewById<CardView>(Resource.Id.businessCardView);
            programmingCard = FindViewById<CardView>(Resource.Id.programmingCardView);

        }
        public void clickEvents()
        {
            historyCard.Click += HistoryCard_Click;
            geographyCard.Click += GeographyCard_Click;
            spaceCard.Click += SpaceCard_Click;
            engineeringCard.Click += EngineeringCard_Click;
            businessCard.Click += BusinessCard_Click;
            programmingCard.Click += ProgrammingCard_Click;
        }
        private void HistoryCard_Click(object sender, System.EventArgs e)
        {
            Intent intent = new Intent(this, typeof(selectedTopicActivity));
            intent.PutExtra("topic", "History");
            StartActivity(intent);
        }
        private void ProgrammingCard_Click(object sender, System.EventArgs e)
        {
            Intent intent = new Intent(this, typeof(selectedTopicActivity));
            intent.PutExtra("topic","Programming");
            StartActivity(intent);
        }

        private void BusinessCard_Click(object sender, System.EventArgs e)
        {
            Intent intent = new Intent(this, typeof(selectedTopicActivity));
            intent.PutExtra("topic", "Business");
            StartActivity(intent);
        }

        private void EngineeringCard_Click(object sender, System.EventArgs e)
        {
            Intent intent = new Intent(this, typeof(selectedTopicActivity));
            intent.PutExtra("topic", "Engineering");
            StartActivity(intent);
        }

        private void SpaceCard_Click(object sender, System.EventArgs e)
        {
            Intent intent = new Intent(this, typeof(selectedTopicActivity));
            intent.PutExtra("topic", "Space");
            StartActivity(intent);
        }

        private void GeographyCard_Click(object sender, System.EventArgs e)
        {
            Intent intent = new Intent(this, typeof(selectedTopicActivity));
            intent.PutExtra("topic", "Geography");
            StartActivity(intent);
        }
    }
}
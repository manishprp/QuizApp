using Android.App;
using Android.Content;
using Android.OS;
using Android.Views;
using AndroidX.AppCompat.App;
using AndroidX.AppCompat.Widget;
using AndroidX.CardView.Widget;
using AndroidX.DrawerLayout.Widget;
using Google.Android.Material.Navigation;
using QuizApp.Resources.Activities;

namespace QuizApp
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme")]
    public class MainActivity : AppCompatActivity
    {
        Toolbar toolbar;
        DrawerLayout drawerLayout;
        NavigationView navigationView;
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
            drawerLayout = FindViewById<DrawerLayout>(Resource.Id.drawerLayout);
            navigationView = FindViewById<NavigationView>(Resource.Id.nav_view);
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
            navigationView.NavigationItemSelected += NavigationView_NavigationItemSelected;
        }

        private void NavigationView_NavigationItemSelected(object sender, NavigationView.NavigationItemSelectedEventArgs e)
        {
            if(e.MenuItem.ItemId==Resource.Id.navHistory)
            {
                callActivityAndPassTopic("History");
                drawerLayout.CloseDrawers();
            }
            else if (e.MenuItem.ItemId == Resource.Id.navGeography)
            {
                callActivityAndPassTopic("Geography");
                drawerLayout.CloseDrawers();
            }
            else if (e.MenuItem.ItemId == Resource.Id.navBusiness)
            {
                callActivityAndPassTopic("Business");
                drawerLayout.CloseDrawers();
            }
            else if(e.MenuItem.ItemId == Resource.Id.navEngineering)
            {
                callActivityAndPassTopic("Engineering");
                drawerLayout.CloseDrawers();
            }
           else if (e.MenuItem.ItemId == Resource.Id.navSpace)
            {
                callActivityAndPassTopic("Space");
                drawerLayout.CloseDrawers();
            }
            else if (e.MenuItem.ItemId == Resource.Id.navProgramming)
            {
                callActivityAndPassTopic("Programming");
                drawerLayout.CloseDrawers();

            }
        }

        private void HistoryCard_Click(object sender, System.EventArgs e)
        {
            callActivityAndPassTopic("History");
        }
        private void ProgrammingCard_Click(object sender, System.EventArgs e)
        {
            callActivityAndPassTopic("Programming");
        }

        private void BusinessCard_Click(object sender, System.EventArgs e)
        {
            callActivityAndPassTopic("Business");
        }

        private void EngineeringCard_Click(object sender, System.EventArgs e)
        {
            callActivityAndPassTopic("Engineering");
        }

        private void SpaceCard_Click(object sender, System.EventArgs e)
        {
            callActivityAndPassTopic("Space");
        }

        private void GeographyCard_Click(object sender, System.EventArgs e)
        {
            callActivityAndPassTopic("Geography");
        }

        public void callActivityAndPassTopic(string topicTitle)
        {
            Intent intent = new Intent(this, typeof(selectedTopicActivity));
            intent.PutExtra("topic", topicTitle);
            StartActivity(intent);
        }
        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            switch(item.ItemId)
            {
                case Android.Resource.Id.Home:
                    drawerLayout.OpenDrawer((int)GravityFlags.Left);
                    return true;
                default: return base.OnOptionsItemSelected(item);
            }
           
        }
    }
}
using Android.Widget;
using Android.OS;
using Android.Support.Design.Widget;
using Android.Support.V4.View;
using Android.Views;
using Android.Support.V7.App;
using Android.App;

namespace Tab_Csharp
{
    [Activity(Label = "Tab_Csharp", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : AppCompatActivity
    {

        protected FragmentHome fragmentHome;
        protected FragmentAccount fragmentAccount;
        protected FragmentSettings fragmentSettings;

        protected TabLayout tabLayout;
        protected ViewPager viewPager;
        protected LinearLayout.LayoutParams layoutParamsSelected, layoutParamsDefault;
        protected View viewHome, viewAccount, viewSettings;


        private int[] tabIcons = {
            Resource.Drawable.custom_tab_home,
            Resource.Drawable.custom_tab_account,
            Resource.Drawable.custom_tab_settings
        };



        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView (Resource.Layout.Main);

            InitialiseLayoutParams();
            InitialiseTabLayout();

        }


        /// <summary>
        ///     Méthode d'initialisation de la barre
        /// </summary>
        private void InitialiseTabLayout()
        {
            tabLayout = FindViewById<TabLayout>(Resource.Id.main_tabs);
            viewPager = FindViewById<ViewPager>(Resource.Id.main_viewpager);
            viewPager.DrawingCacheEnabled = true;
            CreateViewPager(viewPager);
        }

        /// <summary>
        ///     Méthode permettant de générer le ViewPager avec l'Adaptateur
        /// </summary>
        /// <param name="viewPager">Le viewPager à générer</param>
        private void CreateViewPager(ViewPager viewPager)
        {

            var fragments = new Android.Support.V4.App.Fragment[]
            {
                new FragmentHome(),
                new FragmentAccount(),
                new FragmentSettings()
            };


            viewPager.Adapter = new ViewPagerAdapter(SupportFragmentManager, fragments);
            viewPager.CurrentItem = 0;

            tabLayout.SetupWithViewPager(viewPager);
            SetupTabIcons();
        }



        /// <summary>
        ///     Méthode d'initialisation des dimensions à attribuer aux boutons de la barre
        /// </summary>
        private void InitialiseLayoutParams()
        {
            layoutParamsSelected = new LinearLayout.LayoutParams(Resources.GetDimensionPixelSize(Resource.Dimension.value_50), Resources.GetDimensionPixelSize(Resource.Dimension.value_50));
            layoutParamsDefault = new LinearLayout.LayoutParams(Resources.GetDimensionPixelSize(Resource.Dimension.value_30), Resources.GetDimensionPixelSize(Resource.Dimension.value_30));
        }

        /// <summary>
        ///     Méthode pour créer les différentes icônes de la barre
        /// </summary>
        private void SetupTabIcons()
        {
            viewHome = LayoutInflater.Inflate(Resource.Layout.CustomTabIcon, tabLayout, false);
            viewHome.FindViewById<ImageView>(Resource.Id.icon).SetBackgroundResource(tabIcons[0]);
            viewHome.LayoutParameters = layoutParamsSelected;

            viewAccount = LayoutInflater.Inflate(Resource.Layout.CustomTabIcon, tabLayout, false);
            viewAccount.FindViewById<ImageView>(Resource.Id.icon).SetBackgroundResource(tabIcons[1]);
            viewAccount.LayoutParameters = layoutParamsDefault;

            viewSettings = LayoutInflater.Inflate(Resource.Layout.CustomTabIcon, tabLayout, false);
            viewSettings.FindViewById<ImageView>(Resource.Id.icon).SetBackgroundResource(tabIcons[2]);
            viewSettings.LayoutParameters = layoutParamsDefault;

            if (tabLayout != null)
            {
                tabLayout.GetTabAt(0).SetCustomView(viewHome);
                tabLayout.GetTabAt(1).SetCustomView(viewAccount);
                tabLayout.GetTabAt(2).SetCustomView(viewSettings);
            }

            tabLayout.TabSelected += (object sender, TabLayout.TabSelectedEventArgs e) =>
            {
                ChangeTabSelected(e.Tab.CustomView);
            };

            tabLayout.TabUnselected += (object sender, TabLayout.TabUnselectedEventArgs e) =>
            {
                ChangeTabDefault(e.Tab.CustomView);
            };
        }


        /// <summary>
        ///     Méthode permettant de grandir un item du menu sélectionné
        /// </summary>
        /// <param name="view">La vue à agrandir</param>
        private void ChangeTabSelected(View view)
        {
            view.LayoutParameters = layoutParamsSelected;
        }

        /// <summary>
        ///     Méthode permettant de diminuer un item du menu déselecctioné
        /// </summary>
        /// <param name="view">La vue à diminuer</param>
        private void ChangeTabDefault(View view)
        {
            view.LayoutParameters = layoutParamsDefault;
        }


    }
}


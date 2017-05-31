using Android.Support.V4.App;
using Android.OS;
using Android.Views;

namespace Tab_Csharp
{
    public class FragmentSettings : Fragment
    {
        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            return inflater.Inflate(Resource.Layout.FragmentSettings, container, false);
        }
    }
}
using Android.Support.V4.App;
using Android.OS;
using Android.Views;

namespace Tab_Csharp
{
    public class FragmentHome : Fragment
    {
        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            return inflater.Inflate(Resource.Layout.FragmentHome, container, false);
        }
    }
}
﻿using Android.Support.V4.App;
using Java.Lang;

namespace Tab_Csharp
{
    class ViewPagerAdapter : FragmentPagerAdapter
    {

        private readonly Fragment[] fragments;


        public ViewPagerAdapter(FragmentManager fm, Fragment[] fragments) : base(fm)
        {
            this.fragments = fragments;
        }

        public override int Count
        {
            get
            {
                return fragments.Length;
            }
        }

        public override Fragment GetItem(int position)
        {
            return fragments[position];
        }

        public override ICharSequence GetPageTitleFormatted(int position)
        {
            return null;
        }

    }
}
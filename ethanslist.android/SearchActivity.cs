﻿using System;
using Android.App;
using Android.OS;
using Android.Widget;
using System.Linq;

namespace ethanslist.android
{
    [Activity(Label = "Search", Icon = "@drawable/icon")]
    public class SearchActivity : Activity
    {
        String city;
        AvailableLocations locations;
        Location location;
        TextView cityTextView;
        EditText searchTextField;
        Button searchButton;
        SeekBar minRentSeekBar;
        SeekBar maxRentSeekBar;
        TextView minRentTextView;
        TextView maxRentTextView;
        NumberPicker minBedroomPicker;
        NumberPicker minBathroomPicker;

        public SearchActivity()
        {
        }

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.Search);
            city = Intent.GetStringExtra("city");
            locations = new AvailableLocations();
            location = locations.PotentialLocations.Where(loc => loc.SiteName == city).First();

            cityTextView = FindViewById<TextView>(Resource.Id.citySelectedText);
            cityTextView.Text = city;

            searchTextField = FindViewById<EditText>(Resource.Id.searchTextField);
            searchButton = FindViewById<Button>(Resource.Id.searchButton);
            minRentSeekBar = FindViewById<SeekBar>(Resource.Id.minRentSeekBar);
            maxRentSeekBar = FindViewById<SeekBar>(Resource.Id.maxRentSeekBar);
            minRentTextView = FindViewById<TextView>(Resource.Id.minRentTextView);
            maxRentTextView = FindViewById<TextView>(Resource.Id.maxRentTextView);
            minBedroomPicker = FindViewById<NumberPicker>(Resource.Id.minBathroomPicker);
            minBathroomPicker = FindViewById<NumberPicker>(Resource.Id.minBathroomPicker);

            minRentSeekBar.StopTrackingTouch += (object sender, SeekBar.StopTrackingTouchEventArgs e) => {
                minRentTextView.Text = FormatCurrency(minRentSeekBar.Progress * 100);
            };

            maxRentSeekBar.StopTrackingTouch += (object sender, SeekBar.StopTrackingTouchEventArgs e) => {
                maxRentTextView.Text = FormatCurrency(maxRentSeekBar.Progress * 100);
            };

            searchButton.Click += (sender, e) => {
                GenerateQuery();
            };
        }

        protected string FormatCurrency(int i)
        {
            return String.Format("{0:C0}", i);
        }

        protected string GenerateQuery()
        {
            string query;
            query = String.Format("{0}/search/apa?format=rss&min_price={1}&max_price={2}&bedrooms={3}&bathrooms{4}&query={5}", 
                location.Url, minRentTextView.Text, maxRentTextView.Text, minBedroomPicker.Value, minBathroomPicker.Value, searchTextField.Text);

            Console.WriteLine(query);

            return query;
        }
    }
}


﻿using System;
using System.Collections.Generic;
using Android.App;
using Android.Content;
using Android.Support.V7.App;
using Android.Views;
using Android.Widget;
using EthansList.Shared;

namespace EthansList.Droid
{
    public class CategoryListAdapter : BaseAdapter<CatTableGroup>
    {
        readonly Context context;
        readonly List<CatTableGroup> categories;
        readonly Location SelectedLocation;
        public event EventHandler<CategorySelectedEventArgs> CategoryLongClick;

        public CategoryListAdapter(Context context, List<CatTableGroup> categories, Location searchLocation)
        {
            this.context = context;
            this.categories = categories;
            this.SelectedLocation = searchLocation;
        }

        public override CatTableGroup this[int position]
        {
            get
            {
                return categories[position];
            }
        }

        public override int Count
        {
            get
            {
                return categories.Count;
            }
        }

        public override long GetItemId(int position)
        {
            return position;
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            var view = new CategoryGroupRow(context);
            view.Items = categories[position].Items;

            view.CategorySelected += (object sender, CategorySelectedEventArgs e) =>
            {
                var transaction = ((AppCompatActivity)context).SupportFragmentManager.BeginTransaction();
                SearchOptionsFragment searchFragment = new SearchOptionsFragment();
                searchFragment.Category = e.Selected;
                searchFragment.SearchLocation = this.SelectedLocation;

                transaction.Replace(Resource.Id.frameLayout, searchFragment);
                transaction.AddToBackStack(null);
                transaction.Commit();
            };

            view.CategoryLongClick += (sender, e) =>
            {
                if (this.CategoryLongClick != null)
                    CategoryLongClick(sender, e);
            };

            view.headerLabel.Text = categories[position].Name;

            view.Clickable = false;

            return view;
        }
    }
}


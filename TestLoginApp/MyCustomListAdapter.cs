using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace TestLoginApp
{
    public class MyCustomListAdapter:BaseAdapter<UserDetails>
    {
        List<UserDetails> users;
        public MyCustomListAdapter(List<UserDetails> users)
        {
            this.users = users;
        }

        public override UserDetails this[int position]
        {
            get {
                return users[position];
            }
        }

        public override int Count
        {
            get
            {
                return users.Count;
            }
        }

        public override long GetItemId(int position)
        {
            return position;
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            var view = convertView;

            if (view == null)
            {
                view = LayoutInflater.From(parent.Context).Inflate(Resource.Layout.Rowlayout, parent, false);

                var name = view.FindViewById<TextView>(Resource.Id.nameTextView);

                view.Tag = new ViewHolder() {  Name = name};
            }

           var holder = (ViewHolder)view.Tag;

            holder.Name.Text = users[position].Name;


            return view;
        }
    }
}
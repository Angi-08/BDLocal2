using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using BDLocal2.Dependecy;
using BDLocal2.Droid.DependecyDB;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Xamarin.Forms;

[assembly: Dependency(typeof(ObtenerRuta))]
namespace BDLocal2.Droid.DependecyDB
{
    public class ObtenerRuta : IRuta
    {
        public string GetPathBb(string filename)
        {
            string path = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            return Path.Combine(path, filename);
        }
    }
}
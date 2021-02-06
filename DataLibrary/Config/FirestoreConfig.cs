using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLibrary.DataAccess;
using Google.Cloud.Firestore;

namespace DataLibrary.Config
{
    public class FirestoreConfig
    {
        // Connect to Google Cloud Firestore and set the database in FirestoreDataAccess.cs
        public static void InitFirestore()
        {
            string path = AppDomain.CurrentDomain.BaseDirectory + @"serviceAccountKey.json";
            Environment.SetEnvironmentVariable("GOOGLE_APPLICATION_CREDENTIALS", path);

            FirestoreDb db = FirestoreDb.Create("tracker-10886");
            FirestoreDataAccess.SetDatabase(db);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Google.Cloud.Firestore;

namespace DataLibrary.DataAccess
{
    public class FirestoreConfig
    {
        // Recommended to keep one instance of FirestoreDb
        public static FirestoreDb db;

        // Connect to Google Cloud Firestore
        public static void InitFirestore()
        {
            string path = AppDomain.CurrentDomain.BaseDirectory + @"serviceAccountKey.json";
            Environment.SetEnvironmentVariable("GOOGLE_APPLICATION_CREDENTIALS", path);

            db = FirestoreDb.Create("tracker-10886");
            //CollectionReference collection = db.Collection("Tickets");
            //Dictionary<string, object> data1 = new Dictionary<string, object>()
            //{
            //    {"number", "five"}
            //};
            //collection.AddAsync(data1);
        }
    }
}

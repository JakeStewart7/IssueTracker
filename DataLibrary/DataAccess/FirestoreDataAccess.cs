using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLibrary.Config;
using Google.Cloud.Firestore;

namespace DataLibrary.DataAccess
{
    public static class FirestoreDataAccess
    {
        static FirestoreDb database;

        public static void SetDatabase(FirestoreDb db)
        {
            database = db;
        }

        // TODO
        //public static List<T> LoadData<T>()
        //{

        //}

        public static int SaveData(Dictionary<string, object> data, string collectionName)
        {
            // Creates collection if not yet created
            CollectionReference collection = database.Collection(collectionName);

            DateTime date = DateTime.Now;
            string documentID = date.ToString("yyyyMMddhhmmssfff");

            DocumentReference document = collection.Document(documentID);
            document.SetAsync(data);

            return 0;
        }
    }
}

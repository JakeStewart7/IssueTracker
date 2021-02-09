using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLibrary.Config;
using DataLibrary.Models;
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

        public static async Task<List<T>> LoadData<T>(string collectionName)
        {
            Query qref = database.Collection(collectionName);
            QuerySnapshot snap = await qref.GetSnapshotAsync();

            List<T> dataList = new List<T>();
            foreach (DocumentSnapshot docSnap in snap)
            {
                T data = docSnap.ConvertTo<T>();
                if (docSnap.Exists)
                {
                    dataList.Add(data);
                }
            }

            return dataList;
        }

        public static int SaveData<T>(T data, string collectionName)
        {
            // Creates collection if not yet created
            CollectionReference collection = database.Collection(collectionName);

            DocumentReference document = collection.Document();
            document.SetAsync(data);

            return 0;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Google.Cloud.Firestore;

namespace DataLibrary.Models
{
    [FirestoreData]
    public class TicketModel
    {
        [FirestoreProperty]
        public string Title { get; set; }

        [FirestoreProperty]
        public string ProjectName { get; set; }

        [FirestoreProperty]
        public string Description { get; set; }

        [FirestoreProperty]
        public string Type { get; set; }

        [FirestoreProperty]
        public string Resolver { get; set; }

        [FirestoreProperty]
        public string Priority { get; set; }

        [FirestoreProperty]
        public string Status { get; set; }

        [FirestoreProperty]
        public string Submitter { get; set; }

        [FirestoreProperty]
        public string Timestamp { get; set; }
    }
}

using DataLibrary.DataAccess;
using DataLibrary.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLibrary.BusinessLogic
{
    public static class TicketProcessor
    {
        public static int CreateTicket(string title, string description = "",
            string type = "Bug", string resolver = "", string priority = "High")
        {
            TicketModel ticket = new TicketModel
            {
                Title = title,
                Description = description,
                Type = type,
                Resolver = resolver,
                Priority = priority,
                Status = "In Development",
                Submitter = "Anonymous",
                Timestamp = DateTime.Now.ToString(),
            };

            Dictionary<string, object> data = ToDictionary<object>(ticket);

            return FirestoreDataAccess.SaveData(data, "Tickets");
        }

        // TODO
        //public static List<TicketModel> LoadTickets()
        //{
        //    return FirestoreDataAccess.LoadData();
        //}

        // Adapted from https://gist.github.com/jarrettmeyer/798667/a87f9bcac2ec68541511f17da3c244c0e05bdc49
        public static Dictionary<string, T> ToDictionary<T>(this object source)
        {
            if (source == null) throw new NullReferenceException("Cannot convert null object to dictionary.");

            var dictionary = new Dictionary<string, T>();
            foreach (PropertyDescriptor property in TypeDescriptor.GetProperties(source))
            {
                object value = property.GetValue(source);
                dictionary.Add(property.Name, (T)value);
            }
            return dictionary;
        }
    }
}

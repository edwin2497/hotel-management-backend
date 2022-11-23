using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities
{
    public class Audit
    {
        #region Properties

        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("Description")]
        public string Description { get; set; }

        [BsonElement("RegistrationDate")]
        public DateTime RegistrationDate { get; set; }

        #endregion

        #region Constructors
        public Audit(string id, string description, DateTime registrationDate)
        {
            Id=id;
            Description=description;
            RegistrationDate=registrationDate;
        }

        public Audit(string description, DateTime registrationDate)
        {
            Description=description;
            RegistrationDate=registrationDate;
        }

        #endregion

    }
}

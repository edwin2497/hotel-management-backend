using Entities;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess
{
    #region Attributes

    public class MongoDBAccess
    {
        //MongoDB database connection string
        private readonly string connectionString = @"mongodb+srv://Admin:123@prograavanzada.clkwxsg.mongodb.net/?retryWrites=true&w=majority";

        //Create instances to connect to database and collection
        private MongoClient dbInstance;
        private IMongoDatabase database;

        //Create constant with the name of the database to connect to
        private const string dbName = "Progra";

        #endregion

        #region Constructor 

        public MongoDBAccess()
        {
            try
            {
                VerifyConnection();
            }
            catch (MongoException exMDB)
            {
                throw exMDB;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (dbInstance != null)
                    dbInstance = null;
                if (database != null)
                    database = null;
            }
        }

        #endregion

        #region Methods

        #region Private
        private bool VerifyConnection()
        {
            bool check;
            try
            {
                //Start connection to MongoDB
                dbInstance = new MongoClient(connectionString);

                //Get database on connection
                database = dbInstance.GetDatabase(dbName);

                //Get if there was successful connection or not
                check = database.RunCommandAsync((Command<BsonDocument>)"{ping:1}").Wait(1000);
            }
            catch (MongoException exMDB)
            {
                throw exMDB;
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return check;
        }
        #endregion

        #region Public

        public bool Add(Audit audit)
        {
            bool result;

            try
            {
                VerifyConnection();

                var Coleccion = database.GetCollection<Audit>("Audit");
                Coleccion.InsertOne(audit);
                result = true;
            }
            catch (MongoException exMDB)
            {
                throw exMDB;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (dbInstance != null)
                    dbInstance = null;
                if (database != null)
                    database = null;
            }

            return result;
        }

        #endregion


        #endregion


    }
}

﻿using System.Threading.Tasks;
using Tearc.Utils.Repository.Mongo;
using MongoDB.Driver;

namespace Tearc.Repository.Mongo
{
    public class MongoRepository : Tearc.Utils.Repository.Mongo.Repository
    {
        public MongoRepository(IMongoDatabase dbContext) : base(dbContext)
        {
        }

        //public ListingData FindByListingId(int listingId)
        //{
        //    return _dbContext.GetCollection<ListingData>("listingdata", new MongoCollectionSettings())
        //            .Find(t => t.ListingID == listingId)
        //            .FirstOrDefault();
        //}

        //public int UpdateByListingId(int listingId, ListingData listing)
        //{
        //    return (int)(Collection<ListingData>().ReplaceOne(Filter<ListingData>().Eq(t => t.ListingID, listingId), listing)).ModifiedCount;
        //}
    }
}

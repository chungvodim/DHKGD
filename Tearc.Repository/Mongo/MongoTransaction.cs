using System;
using System.Collections.Generic;
using System.Text;
using Tearc.Repository.Base;

namespace Tearc.Repository.Mongo
{
    public class MongoTransaction : ITransaction
    {
        public void Commit()
        {
            //throw new NotImplementedException();
        }

        public void Dispose()
        {
            //throw new NotImplementedException();
        }

        public void Rollback()
        {
            //throw new NotImplementedException();
        }
    }
}

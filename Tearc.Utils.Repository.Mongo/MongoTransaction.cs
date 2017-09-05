using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tearc.Utils.Repository.Mongo
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

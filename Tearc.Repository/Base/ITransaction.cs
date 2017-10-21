using System;
using System.Collections.Generic;
using System.Text;

namespace Tearc.Repository.Base
{
    public interface ITransaction : IDisposable
    {
        void Commit();
        void Rollback();
    }
}

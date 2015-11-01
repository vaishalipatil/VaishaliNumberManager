using System.Collections.Generic;
using Vaishali.DataAccess;
using Vaishali.DataModel;

namespace Vaishali.NumberManager.Service
{
    public class NumberService
    {
        private IDataConnection _dataConnection;
        public IList<Number> GetNumbers()
        {
          return Read();
        }

        public NumberService(IDataConnection dataConnection)
        {
            _dataConnection = dataConnection;
        }

        public void Write(IList<Number> numbers)
        {
            _dataConnection.Write(numbers);
        }

        public IList<Number> Read()
        {
           return _dataConnection.Read();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zoo.BusinessLogic.Tests
{
    public class TestEmployee : IEmployee
    {
        public string FirstName => throw new NotImplementedException();

        public string LastName => throw new NotImplementedException();
    }
}

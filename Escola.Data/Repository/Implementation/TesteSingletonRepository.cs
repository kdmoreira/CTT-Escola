using Escola.Data.Interface;
using System;

namespace Escola.Data.Repository
{
    public class TesteSingletonRepository : ITesteSingletonRepository
    {
        private readonly Guid _guid;
        public TesteSingletonRepository()
        {
            _guid = Guid.NewGuid();
        }
    }
}

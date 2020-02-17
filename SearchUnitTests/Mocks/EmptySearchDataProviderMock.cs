using SimonsVoss.Infra.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace SearchUnitTests.Mocks
{
    public class EmptySearchDataProviderMock : ISearchDataProvider
    {
        public string GetData() => string.Empty;
    }
}

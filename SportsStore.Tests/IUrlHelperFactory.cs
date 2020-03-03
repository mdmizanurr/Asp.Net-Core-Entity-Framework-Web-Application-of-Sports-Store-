using Microsoft.AspNetCore.Mvc;

namespace SportsStore.Tests
{
    internal interface IUrlHelperFactory
    {
        void GetUrlHelper(ActionContext actionContext);
    }
}
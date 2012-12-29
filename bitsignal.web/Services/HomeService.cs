using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ServiceStack.ServiceHost;
using ServiceStack.ServiceInterface;

namespace bitsignal.web.Services
{
    //[Route("/")]
    public class HomeRequest
    {
    }

    //[Route("/")]
    public class HomeResponse
    {
    }

    public class HomeService : Service
    {
        public object Get(HomeRequest request)
        {
            return new HomeResponse();
        }
    }
}
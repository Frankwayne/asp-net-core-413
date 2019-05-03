using Microsoft.AspNetCore.Mvc;

namespace test { 

    public class LargeRequestController
    {

        public LargeRequestController()
        {
        }

   
        [HttpPost]
        [Route("LargeRequest", Name = "LargeRequest")]
        public  ActionResult BrokerAsync()
        {
            return new OkResult();

        }
    }
}
using Microsoft.AspNetCore.Mvc;

namespace test
{

    public class smallRequestController
    {

        public smallRequestController()
        {
        }

        [HttpPost]
        [Route("smallRequest", Name = "smallRequest")]
        public ActionResult BrokerAsync()
        {

            return new OkResult();

        }
    }
}

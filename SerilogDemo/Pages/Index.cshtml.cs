using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System;

namespace SerilogDemo.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger _logger;

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
            _logger.LogInformation("You requested the Index page.");

            try
            {
                for (int i = 0; i < 100; i++)
                {
                    if (i == 56) throw new Exception("This is our demo exception");
                    _logger.LogInformation("The value of i is {LoopCountValue}", i);
                }
            }
            catch (Exception exception)
            {
                _logger.LogError(exception, "We caught this exception in the Index Get call.");
            }
        }
    }
}

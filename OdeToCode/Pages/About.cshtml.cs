using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace OdeToCode.Pages
{
    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public class AboutModel : PageModel
    {
        private readonly ILogger<ErrorModel> _logger;
        public AboutModel(ILogger<ErrorModel> logger)
        {
            _logger = logger;
        }
    }
}

using System.Collections.Generic;
using System.Threading.Tasks;
using MATruck.Application.CreateDispatches;
using MATruck.Application.GetDispatches;
using MATruck.Database;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MATruck.UI.Pages
{
    public class DispatchModel : PageModel
    {
        private readonly ApplicationDbContext _ctx;

        public DispatchModel(ApplicationDbContext ctx)
        {
            _ctx = ctx;
        }

        [BindProperty]
        public Application.CreateDispatches.DispatchViewModel Dispatch { get; set; }

        public IEnumerable<Application.GetDispatches.DispatchViewModel> Dispatches { get; set; }

        public void OnGet()
        {
            Dispatches = new GetDispatches(_ctx).Do();
        }

        public async Task<IActionResult> OnPost()
        {
            await new CreateDispatch(_ctx).Do(Dispatch);

            return RedirectToPage("Dispatch");
        }
    }
}
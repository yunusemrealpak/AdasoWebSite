using Business.Abstract;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebUI.Controllers
{
    public class IndexModel : PageModel
    {
        public readonly IRecaptchaValidatorService RecaptchaValidator;
        public IndexModel(IRecaptchaValidatorService recaptchaValidator)
        {
            RecaptchaValidator = recaptchaValidator;
        }
        public void OnGet()
        {

        }

        public IActionResult OnPostSubscribeNewsletter(string email, string token)
        {
            if (!RecaptchaValidator.IsRecaptchaValid(token))
            {
                //return error message or something
                return BadRequest();
            }
            //todo add the email to newsletter
            return Page();
        }

        public JsonResult OnGetRecaptchaVerify(string token)
        {
            return new JsonResult(RecaptchaValidator.IsRecaptchaValid(token));
        }
    }
}

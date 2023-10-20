namespace Business.Abstract
{
    public interface IRecaptchaValidatorService
    {
        bool IsRecaptchaValid(string token);

    }
}


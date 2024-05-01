using Microsoft.AspNetCore.Mvc.ViewFeatures;

namespace LoanCore.Services
{
    public class FlashMessageService
    {
        private readonly ITempDataDictionaryFactory _tempDataDictionaryFactory;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public FlashMessageService(ITempDataDictionaryFactory tempDataDictionaryFactory, IHttpContextAccessor httpContextAccessor)
        {
            _tempDataDictionaryFactory = tempDataDictionaryFactory;
            _httpContextAccessor = httpContextAccessor;
        }

        public void AddError(string message)
        {
            var tempData = _tempDataDictionaryFactory.GetTempData(_httpContextAccessor.HttpContext);

            tempData["ErrorMessage"] = message;
        }

        public void AddSuccess(string message)
        {
            var tempData = _tempDataDictionaryFactory.GetTempData(_httpContextAccessor.HttpContext);

            tempData["SuccessMessage"] = message;
        }
    }
}
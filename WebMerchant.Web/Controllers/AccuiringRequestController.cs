using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebMerchant.InternetAcquiring.Contracts.Bl;
using WebMerchant.InternetAcquiring.Contracts.Logging;
using WebMerchant.InternetAcquiring.Objects.Payments;

namespace WebMerchant.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccuiringRequestController : ControllerBase
    {
        private readonly IRequestGetter _requestGetter;

        public AccuiringRequestController(IRequestGetter requestGetter)
        {
            this._requestGetter = requestGetter;
        }

        //[HttpPost]
        //public ActionResult PaymentRequest(PaymentData paymentData)
        //{
        //    string requestUrl;
        //    paymentData.BackUrl = Url.Action("Redir",
        //                                     "Request",
        //                                     new { url = paymentData.BackUrl },
        //                                     Request?.Url?.Scheme ?? "https");
        //    LoggingService.Current.Info($"paymentData.BackUrl = {paymentData.BackUrl}");
        //    var req = _requestGetter.GetRequest(paymentData, out requestUrl);
        //    ViewBag.PostAddress = requestUrl;
        //    return View(req);
        //}


        public ActionResult Redir(string url)
        {
            LoggingService.Current.Info($"url = {url}");
            return Redirect(url);
        }
    }
}
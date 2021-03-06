using NSE.WebApp.MVC.Extensions;
using System;
using System.Net.Http;

namespace NSE.WebApp.MVC.Models
{
    public abstract class Service
    {
        protected bool TratarErrosResponse(HttpResponseMessage response)
        {
            switch ((int)response.StatusCode)
            {
                case 401:
                case 403:
                case 404:
                case 500:
                    throw new CustomHttpRequestException(response.StatusCode);

                case 400:
                    return false;

                default:
                    break;
            }

            response.EnsureSuccessStatusCode();
            return true;
        }
    }
}

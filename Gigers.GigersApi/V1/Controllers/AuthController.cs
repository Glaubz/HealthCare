using Fit.HealthCareApi.Application.Intefaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fit.HealthCareApi.V1.Controllers
{
    public class AuthController : MainController
    {
        public AuthController(INotificador notificador) : base(notificador)
        {

        }
    }
}

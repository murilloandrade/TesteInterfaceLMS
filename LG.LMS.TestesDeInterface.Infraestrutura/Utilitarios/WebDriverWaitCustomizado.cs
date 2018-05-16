//-----------------------------------------------------------------------
// <copyright file="WebDriverWaitCustomizado.cs" company="LG Sistemas">
//     Copyright © LG Sistemas. All rights reserved.
//     TODOS OS DIREITOS RESERVADOS.
// </copyright>
//-----------------------------------------------------------------------
using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace LG.LMS.TestesDeInterface.Infraestrutura.Utilitarios
{
    public class WebDriverWaitCustomizado : WebDriverWait
    {
        private readonly ComponenteDeTela _componenteDeTela;

        public WebDriverWaitCustomizado(IClock clock, IWebDriver driver, TimeSpan timeout, TimeSpan sleepInterval)
            : base(clock, driver, timeout, sleepInterval)
        {
        }

        public WebDriverWaitCustomizado(IWebDriver driver, TimeSpan timeout)
            : base(driver, timeout)
        {
        }

        public WebDriverWaitCustomizado(ComponenteDeTela componenteDeTela, TimeSpan timeout)
            : base(componenteDeTela.WebDriver, timeout)
        {
            _componenteDeTela = componenteDeTela;
        }

        protected override void ThrowTimeoutException(string exceptionMessage, Exception lastException)
        {
            try
            {
                _componenteDeTela.SalvarScreenshotErro("TimeoutException");
            }
            catch (Exception ex)
            {
                lastException = ex;
            }
            finally
            {
                if (_componenteDeTela != null)
                {
                    _componenteDeTela.Dispose();
                }

                base.ThrowTimeoutException(exceptionMessage, lastException);
            }
        }
    }
}

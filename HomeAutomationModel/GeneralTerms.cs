using System;
using System.Collections.Generic;
using System.Text;

namespace HomeAutomationModel
{
    public class GeneralTerms
    {
        private string _urlSonoff;

        public string UrlSonoff {
            get {
                return _urlSonoff;
            } set {
                _urlSonoff = value;
            }
        }

    }
}

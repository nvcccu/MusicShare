using System;
using System.Collections.Generic;
using System.Net;

namespace CommonUtils.Metrics {
    public class Mixpanel {
        private static NLog.Logger _logger = NLog.LogManager.GetCurrentClassLogger();

        private static AsyncCallback CallBack(HttpWebRequest request) {
            return obj => {
                try {
                    if (request != null) {
                        request.GetResponse().Close();
                    }
                } catch (Exception exception) {
                    _logger.Info("Что-то пошло не так при отправке запроса в Mixpanel" +exception);
                }
            };
        }

        public void PostEvent(long guestId, int actionId, Dictionary<string, string> additionalParams) {
            
        }
    }
}

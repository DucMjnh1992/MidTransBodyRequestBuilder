using MidTrans.Core.Common;
using System.Collections.Generic;

namespace MidTrans.Core
{
    public class Config : BaseConfig
    {
        #region Appsettings key

        #region Midtrans settings

        public const string MID_TRANS_IS_PRODUCTION = "MidTransIsProduction";

        #region Midtrans endpoint settings

        public const string MID_TRANS_ENDPOINT_METHOD = "MidTransEndPointMethod";
        public const string MID_TRANS_ENDPOINT_SANDBOX = "MidTransEndPointSanbox";
        public const string MID_TRANS_ENDPOINT_PRODUCTION = "MidTransEndPointProduction";

        #endregion Midtrans endpoint settings

        #region Midtrans request headers settings

        public const string MID_TRANS_REQUEST_HEADER_ACCEPT = "MidTransRequestHeaderAccept";
        public const string MID_TRANS_REQUEST_HEADER_CONTENT_TYPE = "MidTransRequestHeaderContentType";
        public const string MID_TRANS_REQUEST_HEADER_SERVER_KEY= "MidTransRequestHeaderServerKey";
        public const string MID_TRANS_REQUEST_HEADER_CLIENT_KEY = "MidTransRequestHeaderClientKey";

        #endregion Midtrans request headers settings

        #region Body request settings

        public const string MID_TRANS_ENABLED_PAYMENT = "MidTransEnabledPayment";
        public const string MID_TRANS_CREDIT_CARD_SECURE = "MidTransCreditCardSecure";
        public const string MID_TRANS_CREDIT_CARD_CHANNEL = "MidTransCreditCardChannel";
        public const string MID_TRANS_CREDIT_CARD_BANK = "MidTransCreditCardBank";
        public const string MID_TRANS_CREDIT_CARD_INSTALLMENT_REQUIRED = "MidTransCreditCardInstallmentRequired";
        public const string MID_TRANS_CREDIT_CARD_INSTALLMENT_TERM_BNI = "MidTransCreditCardInstallmentTermBni";
        public const string MID_TRANS_CREDIT_CARD_INSTALLMENT_TERM_MANDIRI = "MidTransCreditCardInstallmentTermMandiri";
        public const string MID_TRANS_CREDIT_CARD_INSTALLMENT_TERM_CIMB = "MidTransCreditCardInstallmentTermCimb";
        public const string MID_TRANS_CREDIT_CARD_INSTALLMENT_TERM_BCA = "MidTransCreditCardInstallmentTermBca";
        public const string MID_TRANS_CREDIT_CARD_INSTALLMENT_TERM_OFFLINE = "MidTransCreditCardInstallmentTermOffline";
        public const string MID_TRANS_CREDIT_CARD_WHILELIST_BIN = "MidTransCreditCardWhilelistBin";
        public const string MID_TRANS_EXPIRY_UNIT = "MidTransExpiryUnit";
        public const string MID_TRANS_EXPIRY_DURATION = "MidTransExpiryDuration";

        #endregion Body request settings

        #endregion Midtrans settings

        #endregion Appsettings key

        public static bool MidTransIsProduction
        {
            get
            {
                bool value = ReadAppSettingBoolValue(MID_TRANS_IS_PRODUCTION);

                return value;
            }
        }
        
        public static string EndpointSandboxOrProductionByIsProduction
        {
            get
            {
                if (MidTransIsProduction)
                {
                    return MidTransEndpointProduction;
                }

                return MidTransEndPointSanbox;
            }
        }

        #region Midtrans endpoint settings

        public static string MidTransEndPointMethod
        {
            get
            {
                const string DEFAULT_METHOD = "POST";
                string value = ReadAppSettingValue(MID_TRANS_ENDPOINT_METHOD, DEFAULT_METHOD);

                return value;
            }
        }

        public static string MidTransEndpointProduction
        {
            get
            {
                string value = ReadAppSettingValue(MID_TRANS_ENDPOINT_PRODUCTION);

                return value;
            }
        }        

        public static string MidTransEndPointSanbox
        {
            get
            {
                string value = ReadAppSettingValue(MID_TRANS_ENDPOINT_SANDBOX);

                return value;
            }
        }

        #endregion Midtrans endpoint settings

        #region Midtrans request headers settings

        public static string MidTransRequestHeaderAccept
        {
            get
            {
                string value = ReadAppSettingValue(MID_TRANS_REQUEST_HEADER_ACCEPT);

                return value;
            }
        }

        public static string MidTransRequestHeaderContentType
        {
            get
            {
                string value = ReadAppSettingValue(MID_TRANS_REQUEST_HEADER_CONTENT_TYPE);

                return value;
            }
        }

        public static string MidTransRequestHeaderServerKey
        {
            get
            {
                string value = ReadAppSettingValue(MID_TRANS_REQUEST_HEADER_SERVER_KEY);

                return value;
            }
        }

        public static string MidTransRequestHeaderClientKey
        {
            get
            {
                string value = ReadAppSettingValue(MID_TRANS_REQUEST_HEADER_CLIENT_KEY);

                return value;
            }
        }

        public static string MidTransAuthorization
        {
            get
            {
                string serverKeyPattern = $"{MidTransRequestHeaderServerKey}:";
                string base64ServerKey = Utility.Base64Encode(serverKeyPattern);
                string authString = $"Basic {base64ServerKey}";

                return authString;
            }
        }

        #endregion Midtrans request headers settings

        #region Midtrans body request settings

        public static IList<string> MidTransEnabledPayment
        {
            get
            {                
                IList<string> values = ReadAppSettingListStringValue(MID_TRANS_ENABLED_PAYMENT);

                return values;
            }
        }

        public static bool MidTransCreditCardSecure
        {
            get
            {
                bool value = ReadAppSettingBoolValue(MID_TRANS_CREDIT_CARD_SECURE);

                return value;
            }
        }

        public static string MidTransCreditCardChannel
        {
            get
            {
                string value = ReadAppSettingValue(MID_TRANS_CREDIT_CARD_CHANNEL);

                return value;
            }
        }

        public static string MidTransCreditCardBank
        {
            get
            {
                string value = ReadAppSettingValue(MID_TRANS_CREDIT_CARD_BANK);

                return value;
            }
        }

        public static bool MidTransCreditCardInstallmentRequired
        {
            get
            {
                bool value = ReadAppSettingBoolValue(MID_TRANS_CREDIT_CARD_INSTALLMENT_REQUIRED);

                return value;
            }
        }

        public static IList<int> CreditCardInstallmentTermBni
        {
            get
            {
                IList<int> values = ReadAppSettingListIntValue(MID_TRANS_CREDIT_CARD_INSTALLMENT_TERM_BNI);

                return values;
            }
        }

        public static IList<int> MidTransCreditCardInstallmentTermMandiri
        {
            get
            {
                IList<int> values = ReadAppSettingListIntValue(MID_TRANS_CREDIT_CARD_INSTALLMENT_TERM_MANDIRI);

                return values;
            }
        }

        public static IList<int> MidTransCreditCardInstallmentTermCimb
        {
            get
            {
                IList<int> values = ReadAppSettingListIntValue(MID_TRANS_CREDIT_CARD_INSTALLMENT_TERM_CIMB);

                return values;
            }
        }

        public static IList<int> MidTransCreditCardInstallmentTermBca
        {
            get
            {
                IList<int> values = ReadAppSettingListIntValue(MID_TRANS_CREDIT_CARD_INSTALLMENT_TERM_BCA);

                return values;
            }
        }

        public static IList<int> MidTransCreditCardInstallmentTermOffline
        {
            get
            {
                IList<int> values = ReadAppSettingListIntValue(MID_TRANS_CREDIT_CARD_INSTALLMENT_TERM_OFFLINE);

                return values;
            }
        }

        public static IList<string> MidTransCreditCardWhilelistBin
        {
            get
            {
                IList<string> values = ReadAppSettingListStringValue(MID_TRANS_CREDIT_CARD_WHILELIST_BIN);

                return values;
            }
        }

        public static string MidTransExpiryUnit
        {
            get
            {
                string value = ReadAppSettingValue(MID_TRANS_EXPIRY_UNIT);

                return value;
            }
        }

        public static int MidTransExpiryDuration
        {
            get
            {
                int value = ReadAppSettingIntValue(MID_TRANS_EXPIRY_DURATION);

                return value;
            }
        }

        #endregion Midtrans body request settings
    }
}

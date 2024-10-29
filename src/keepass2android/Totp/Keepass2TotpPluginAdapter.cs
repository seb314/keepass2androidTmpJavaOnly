using System;
using System.Collections.Generic;
using Android.Content;
using keepass2android;
using KeePassLib;
using KeePassLib.Cryptography;
using KeePassLib.Utility;
using KeeTrayTOTP.Libraries;

namespace PluginTOTP
{
    class Keepass2TotpPluginAdapter : ITotpPluginAdapter
    {
        public TotpData GetTotpData(IDictionary<string, string> entryFields, Context ctx, bool muteWarnings)
        {
            TotpData res = new TotpData();
            byte[] pbSecret = (GetOtpSecret(entryFields, "TimeOtp-", out string secretFieldKey) ?? MemUtil.EmptyByteArray);

            if (pbSecret.Length == 0)
                return res;

            res.InternalFields.Add(secretFieldKey);

            string strPeriod;
            uint uPeriod = 0;
            if (entryFields.TryGetValue("TimeOtp-Period", out strPeriod))
            {
                res.InternalFields.Add("TimeOtp-Period");
                uint.TryParse(strPeriod, out uPeriod);
            }

            res.IsTotpEntry = true;

            if (uPeriod == 0)
                uPeriod = 30U;

            string strLength;
            uint uLength = 0;
            if (entryFields.TryGetValue("TimeOtp-Length", out strLength))
            {
                res.InternalFields.Add("TimeOtp-Length");
                uint.TryParse(strLength, out uLength);
            }
            
            
            if (uLength == 0) uLength = 6;

            string strAlg;
            entryFields.TryGetValue("TimeOtp-Algorithm", out strAlg);
            if (!string.IsNullOrEmpty(strAlg))
                res.InternalFields.Add("TimeOtp-Algorithm");

            res.HashAlgorithm = strAlg;
            res.TotpSecret = pbSecret;
            res.Length = uLength.ToString();
            res.Duration = uPeriod.ToString();

            return res;
        }


        private static byte[] GetOtpSecret(IDictionary<string, string> entryFields, string strPrefix, out string secretFieldKey)
        {
            try
            {
                string str;
                secretFieldKey = strPrefix + "Secret";
                entryFields.TryGetValue(secretFieldKey, out str);
                if (!string.IsNullOrEmpty(str))    
                    return StrUtil.Utf8.GetBytes(str);
                
                secretFieldKey = strPrefix + "Secret-Hex";
                entryFields.TryGetValue(secretFieldKey, out str);
                if (!string.IsNullOrEmpty(str))
                    return MemUtil.HexStringToByteArray(str);
                
                secretFieldKey = strPrefix + "Secret-Base32";
                entryFields.TryGetValue(secretFieldKey, out str);
                if (!string.IsNullOrEmpty(str))
                    return Base32.Decode(str); 

                secretFieldKey = strPrefix + "Secret-Base64";
                entryFields.TryGetValue(secretFieldKey, out str);
                if (!string.IsNullOrEmpty(str))
                    return Convert.FromBase64String(str);
                
            }
            catch (Exception e)
            {
                Kp2aLog.LogUnexpectedError(e);
            }
            secretFieldKey = null;
            return null;
        }
    }
}
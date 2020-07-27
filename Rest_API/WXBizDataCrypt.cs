using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Rest_API
{
    public class WXBizDataCrypt
    {

        private string _sessionKey;

        /// <summary>
        /// 
        /// </summary>
        /// <param name = "sessionKey" > sessionKey用户在小程序登录后获取的会话密钥 </ param >
        public WXBizDataCrypt(string sessionKey)
        {
            _sessionKey = sessionKey;
        }

        /// <summary>
        /// 检验数据的真实性，并且获取解密后的明文.
        /// </summary>
        /// <param name = "encryptedData" > 加密的用户数据 </ param >
        /// < param name="iv">与用户数据一同返回的初始向量</param>
        /// <param name = "data" > 解密后的原文 </ param >
        /// < returns > 成功0，失败返回对应的错误码</returns>
        /**
         * error code 说明.
         * <ul>
         *    <li>-41001: encodingAesKey 非法</li>
         *    <li>-41003: aes 解密失败</li>
         *    <li>-41004: 解密后得到的buffer非法</li>
         *    <li>-41005: base64加密失败</li>
         *    <li>-41016: base64解密失败</li>
         * </ul>
         */
        public int decryptData(string encryptedData, string iv, out string date)
        {
            date = string.Empty;
            if (this._sessionKey.Length != 24)
            {
                return -41001;
            }
            if (iv.Length != 24)
            {
                return -41002;
            }
            try
            {
                date = AESDecrypt(encryptedData, this._sessionKey, iv);
            }
            catch (Exception)
            {
                return -41004;
            }
            return 0;
        }

        public static string AESDecrypt(string encryptedDatatxt, string AesKey, string AesIV)
        {
            try
            {
                byte[] encryptedData = Convert.FromBase64String(encryptedDatatxt);
                RijndaelManaged rijndaelCipher = new RijndaelManaged();
                rijndaelCipher.Key = Convert.FromBase64String(AesKey);
                rijndaelCipher.IV = Convert.FromBase64String(AesIV);
                rijndaelCipher.Mode = CipherMode.CBC;
                rijndaelCipher.Padding = PaddingMode.PKCS7;
                ICryptoTransform transform = rijndaelCipher.CreateDecryptor();
                byte[] plainText = transform.TransformFinalBlock(encryptedData, 0, encryptedData.Length);
                string result = Encoding.Default.GetString(plainText);
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}

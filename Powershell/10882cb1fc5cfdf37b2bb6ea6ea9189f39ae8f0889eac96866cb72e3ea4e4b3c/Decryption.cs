using System;
using System.IO;
using System.Text;
using System.Security.Cryptography;

namespace AsyncClient
{
    class Program
    {
        static void Main(string[] args)
        {
            string masterKey = "Zv67DKsCR0XqXvqcPJffiLQwkLHvCLW2";
			// Salt is found in the class file for the decryption function
            byte[] salt = new byte[]
            {
            191, 235, 30, 86, 251, 205, 151, 59, 178, 25,
            2, 36, 48, 165, 120, 67, 0, 61, 86, 68,
            210, 30, 98, 185, 212, 241, 128, 231, 230, 195,
            57, 65
            };
			
			byte[] aesKey;
			byte[] hmacKey;
			
			//Derive bytes to be used as the keys for AES and HMAC256
            using (Rfc2898DeriveBytes rfc2898DeriveBytes = new Rfc2898DeriveBytes(masterKey, salt, 50000))
            {
                aesKey = rfc2898DeriveBytes.GetBytes(32);
                hmacKey = rfc2898DeriveBytes.GetBytes(64);
            }
			//Strings to be decrypted
			string[] enc = { "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" };
			for (int i = 0; i < enc.Length; i++)
            {
				byte[] toDecrypt = decrypt(aesKey, hmacKey, Convert.FromBase64String(enc[i]));

				Console.Out.WriteLine(Encoding.UTF8.GetString(toDecrypt));
			}
		}
		//Decrpytion function extracted from the class file
        public static byte[] decrypt(byte[] aes, byte[] hmac, byte[] input)
        {
			byte[] array6;
			using (MemoryStream memoryStream = new MemoryStream(input))
			{
				using (AesCryptoServiceProvider aesCryptoServiceProvider = new AesCryptoServiceProvider())
				{
					aesCryptoServiceProvider.KeySize = 256;
					aesCryptoServiceProvider.BlockSize = 128;
					aesCryptoServiceProvider.Mode = CipherMode.CBC;
					aesCryptoServiceProvider.Padding = PaddingMode.PKCS7;
					aesCryptoServiceProvider.Key = aes;
					using (HMACSHA256 hmacsha = new HMACSHA256(hmac))
					{
						byte[] array = hmacsha.ComputeHash(memoryStream.ToArray(), 32, memoryStream.ToArray().Length - 32);
						byte[] array2 = new byte[32];
						memoryStream.Read(array2, 0, array2.Length);
						/*if (!this.eVyjICiMbxVibmz(array, array2))
						{
							throw new CryptographicException("Invalid message authentication code (MAC).");
						}*/
					}
					byte[] array3 = new byte[16];
					memoryStream.Read(array3, 0, 16);
					aesCryptoServiceProvider.IV = array3;
					using (CryptoStream cryptoStream = new CryptoStream(memoryStream, aesCryptoServiceProvider.CreateDecryptor(), CryptoStreamMode.Read))
					{
						byte[] array4 = new byte[memoryStream.Length - 16L + 1L];
						byte[] array5 = new byte[cryptoStream.Read(array4, 0, array4.Length)];
						Buffer.BlockCopy(array4, 0, array5, 0, array5.Length);
						array6 = array5;
					}
				}
			}
			return array6;
		}
    }
}

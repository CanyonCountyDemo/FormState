using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Cryptography;
using System.IO;

namespace CC.Common.Utils
{
  class Crypto
  {
    private static byte[] _getKey(string password)
    {
      byte[] salt = Encoding.Default.GetBytes("abcdefgh");
      Rfc2898DeriveBytes key = new Rfc2898DeriveBytes(password, salt);
      return key.GetBytes(16);
    }
    
    static internal string Decrypt(string encryptedData, string password)
    {
      string retStr = string.Empty;

      byte[] key = _getKey(password);

      // Create a symmetric decryptor 
      RijndaelManaged rijndael = new RijndaelManaged();
      rijndael.Mode = CipherMode.ECB;
      rijndael.Padding = PaddingMode.PKCS7;

      // Convert our ciphertext into a byte array. 
      byte[] cipherTextBytes = Convert.FromBase64String(encryptedData);
      // Define memory stream to use to read encrypted data. 
      MemoryStream inStream = new MemoryStream(cipherTextBytes);

      // Read the IV length from the buffer 
      int ivLength = BitConverter.ToInt32(cipherTextBytes, 0);
      // Reposition to after 'length' bytes in stream 
      inStream.Position = 4;

      // Read the IV from the input stream 
      byte[] iv = new byte[ivLength];
      inStream.Read(iv, 0, ivLength);

      using (ICryptoTransform decryptor = rijndael.CreateDecryptor(key, iv))
      {
        // Create a CryptStream to read from the file 
        CryptoStream cryptStrm = new CryptoStream(inStream, decryptor, CryptoStreamMode.Read);

        // Create another MemoryStream for the output 
        MemoryStream memStrm = new MemoryStream();
        byte[] buffer = new byte[2048];
        int totalbytes = 0;
        do
        {
          int bytesRead = cryptStrm.Read(buffer, 0, buffer.Length);
          if (bytesRead == 0)
          {
            break;
          }
          memStrm.Write(buffer, 0, bytesRead);
          totalbytes += bytesRead;
        }
        while (true);

        // Write the content to be encrypted 
        memStrm.Flush();
        memStrm.Seek(0, SeekOrigin.Begin);

        // Get the string from the bytes we read 
        retStr = System.Text.Encoding.Unicode.GetString(memStrm.GetBuffer(), 0, totalbytes);
        cryptStrm.Close();
      }
      return retStr;
    }

    static internal string Encrypt(string plainText, string password)
    {
      byte[] key = _getKey(password);

      // Get the bytes to encrypt 
      byte[] plaintextByte = System.Text.Encoding.Unicode.GetBytes(plainText);

      // Create a Rijndael instance - automatically generates symmetric key 
      // and an initialization vector 
      RijndaelManaged rijndael = new RijndaelManaged();

      // Set encryption mode 
      rijndael.Mode = CipherMode.ECB;
      rijndael.Padding = PaddingMode.PKCS7;

      // Create a random initialization vector 
      rijndael.GenerateIV();
      byte[] iv = rijndael.IV;

      string encodedText = string.Empty;

      // Define memory stream which will be used to hold encrypted data. 
      MemoryStream memStrm = new MemoryStream();

      // Write the IV length and the IV 
      memStrm.Write(BitConverter.GetBytes(iv.Length), 0, 4);
      memStrm.Write(iv, 0, iv.Length);

      // Create a symmetric encryptor 
      using (ICryptoTransform encryptor = rijndael.CreateEncryptor(key, iv))
      {
        // Create a CryptStream to write to the output file 
        CryptoStream cryptStrm = new CryptoStream(memStrm, encryptor, CryptoStreamMode.Write);

        // Write the content to be encrypted 
        cryptStrm.Write(plaintextByte, 0, plaintextByte.Length);
        cryptStrm.FlushFinalBlock();

        // Convert encrypted data from a memory stream into a byte array. 
        byte[] cipherTextBytes = memStrm.ToArray();

        // Close the treams 
        memStrm.Close();
        cryptStrm.Close();

        // Convert encrypted data into a base64-encoded string. 
        encodedText = Convert.ToBase64String(cipherTextBytes);
      }

      return encodedText;
    }

    public static string Encrypt(byte[] salt, byte[] iv, byte[] key)
    {
      AesCryptoServiceProvider aesProvider = new AesCryptoServiceProvider();

      Console.WriteLine(String.Format("Key Size status: {0}", aesProvider.ValidKeySize(128)));

      ICryptoTransform cryptoEncryptor = aesProvider.CreateEncryptor(key, iv);

      MemoryStream mStream = new MemoryStream();

      CryptoStream writerStream = new CryptoStream(mStream, cryptoEncryptor, CryptoStreamMode.Write);

      byte[] buffer = Encoding.Default.GetBytes("Hello World");

      writerStream.Write(buffer, 0, buffer.Length);
      writerStream.FlushFinalBlock();

      byte[] cipherTextinBytes = mStream.ToArray();

      mStream.Close();
      writerStream.Close();

      string cipherText = Convert.ToBase64String(cipherTextinBytes);

      return cipherText;
    }

    public static string DecryptData(string cipherText, byte[] iv, byte[] key)
    {

      AesCryptoServiceProvider aesProvider = new AesCryptoServiceProvider();

      byte[] cipherTextBytesForDecrypt = Convert.FromBase64String(cipherText);

      ICryptoTransform cryptoDecryptor = aesProvider.CreateDecryptor(key, iv);

      MemoryStream memStreamEncryptData = new MemoryStream(cipherTextBytesForDecrypt);

      CryptoStream rStream = new CryptoStream(memStreamEncryptData, cryptoDecryptor, CryptoStreamMode.Read);

      byte[] plainTextBytes = new byte[cipherTextBytesForDecrypt.Length];

      int decryptedByteCount = rStream.Read(plainTextBytes, 0, plainTextBytes.Length);

      memStreamEncryptData.Close();
      rStream.Close();

      string plainText = Encoding.UTF8.GetString(plainTextBytes, 0, decryptedByteCount);

      return plainText;

    }

    public static void Test()
    {
      byte[] salt = Encoding.Default.GetBytes("abcdefgh");

      Rfc2898DeriveBytes keyGenerator = new Rfc2898DeriveBytes("demo", salt);

      byte[] key = keyGenerator.GetBytes(16);
      byte[] iv = keyGenerator.GetBytes(16);

      string keyString = Convert.ToBase64String(key);
      byte[] keyFromString = Convert.FromBase64String(keyString);

      string ivString = Convert.ToBase64String(iv);
      byte[] ivFromString = Convert.FromBase64String(ivString);

      Console.WriteLine(String.Format("Keys are equal? : {0} ", key.Equals(keyFromString)));

      string encData = Encrypt(salt, iv, key);
      Console.WriteLine("Encrypted data:" + encData);
      Console.WriteLine("DecryptData: " + DecryptData(encData, iv, key));
      //Console.ReadLine();
    }
  }
}

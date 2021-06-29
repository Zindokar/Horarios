using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace HorariosBack.Utils
{
  public static class Sha512
  {
    public static string Generate512Digest(string input)
    {
      byte[] hash;
      byte[] data = Encoding.UTF8.GetBytes(input);
      string hashToString = "";
      try
      {
        using SHA512 shaM = new SHA512Managed();
        hash = shaM.ComputeHash(data);
        hashToString = BitConverter.ToString(hash).Replace("-", "");
      }
      catch (Exception)
      {
        hashToString = "";
      }

      return hashToString;
    }
  }
}

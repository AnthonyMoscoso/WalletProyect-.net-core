using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Entities.Utilities.Encrypt
{
    public interface IEncrypt
    {
        string Encrypt(string value);
        string Decrypt(string value);
    }
}

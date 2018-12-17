using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HashUtil {
    class Hashes {
        public enum Type
        {
            CRC32,
            MD5,
            SHA1
        }

        //парсер
        public static Type ParseType(string t)
        {
            switch (t.ToLower())
            {
                case "crc32":
                    return Type.CRC32;
                case "md5":
                    return Type.MD5;
                case "sha1":
                    return Type.SHA1;
                default:
                    throw new Exception("Unable to parse hash type: " + t);
            }
        }

        public static string String(Type t)
        {
            switch(t)
            {
                case Type.CRC32 :
                    return "CRC32";
                case Type.MD5 :
                    return "MD5";
                case Type.SHA1 :
                    return "SHA1";
                default:
                    throw new Exception("Unknown hash code: " + t.ToString());
            }
        }

        //вывод хэша по длине
        public static Type FindType(string t)
        {
            switch(t.Length) {
                case 8:
                    return Type.CRC32;
                case 32:
                    return Type.MD5;
                case 40:
                    return Type.SHA1;
                default:
                    throw new Exception("Unknown hash length: " + t.Length);
            }
        }
    }
}

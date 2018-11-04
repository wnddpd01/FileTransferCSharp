using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace MyPacket
{
    [Serializable]
    public class Packet
    {
        public int type;
        public int Length;
        public string filename;
        public long filesize;
        public byte[] filedata;
        

        public Packet()
        {
            this.type = 0;
            this.Length = 0;
            this.filedata = new byte[1024 * 4];
        }

        public static byte[] Serialize(Object o)
        {
            MemoryStream ms = new MemoryStream();
            BinaryFormatter bf = new BinaryFormatter();
            bf.Serialize(ms, o);
            return ms.ToArray();
        }
        
        public static Object Deserialize(byte[] bt)
        {
            MemoryStream ms = new MemoryStream(bt);
            ms.Position = 0;
            BinaryFormatter bf = new BinaryFormatter();
            Object obj = bf.Deserialize(ms);
            return obj;
        }
    }
    

}

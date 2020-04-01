using System;
using System.IO;

namespace Copy_Binary_File
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var reader = new FileStream("../../../copyMe.png", FileMode.Open))
            {
                using (var copy = new FileStream("../../../copyDone.png", FileMode.Create))
                {
                    var buffer = new byte[1024];

                    var read = reader.Read(buffer, 0, buffer.Length);

                    while (read != 0)
                    {
                        copy.Write(buffer, 0, read);

                        read = reader.Read(buffer, 0, buffer.Length);
                    }
                }
            }
        }
    }
}

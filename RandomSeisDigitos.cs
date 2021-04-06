using System;
using System.Security.Cryptography;

namespace autoGenRandomCode
{
    class RandomSeisDigitos
    {

        private static RNGCryptoServiceProvider Rand =
            new RNGCryptoServiceProvider();


        static void Main(string[] args)
        {
            for (int i = 0; i < 3000; i++)
            {
                Console.WriteLine(GenerarSeisDigitosVerificacion(99999, 999999));
            }

            Console.Read();
        }

        private static int GenerarSeisDigitosVerificacion(int min, int max)
        {
            uint rango = uint.MaxValue;
            while (rango == uint.MaxValue)
            {
                byte[] four_bytes = new byte[4];
                Rand.GetBytes(four_bytes);

                rango = BitConverter.ToUInt32(four_bytes, 0);
            }

            return (int)(min + (max - min) *
                (rango / (double)uint.MaxValue));
        }


    }
}

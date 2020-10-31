using System;

namespace Camones.Shop.Identity.Test
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            ConnectService.Get("afernandeznet@gmail.com", "Camones2020.").Wait();

            Console.ReadKey();
        }
    }
}
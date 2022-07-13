using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TokenAcquirer;

namespace TokenRequester
{
    internal class Program
    {
        private static readonly ITokenAcquirerHelper _tokenAcquirer;
        static Program() => _tokenAcquirer = new TokenAcquirerHelper();
        static void Main()
        {

            GetTokenFirstTime();
            GetTokenSubsequently();
            Console.ReadLine();
        }

        private static void GetTokenFirstTime()
        {
            Console.WriteLine("Acquiring a token for the first time...\n");
            var result = _tokenAcquirer.GetTokenAsync().GetAwaiter().GetResult();
            Console.WriteLine($"Token source: {result.AuthenticationResultMetadata.TokenSource}\n");
            Console.WriteLine($"Access Token:\n\n{result.AccessToken}");

        }

        private static void GetTokenSubsequently()
        {
            Console.WriteLine("\n\nAcquiring a token subsequent time...\n");
            var result = _tokenAcquirer.GetTokenAsync().GetAwaiter().GetResult();
            Console.WriteLine($"Token source: {result.AuthenticationResultMetadata.TokenSource}\n");
            Console.WriteLine($"Access Token:\n\n{result.AccessToken}");
        }
    }
}

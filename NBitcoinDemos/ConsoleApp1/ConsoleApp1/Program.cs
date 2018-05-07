using NBitcoin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            RandomUtils.Random = new UnsecureRandom(); // set the random number generator.
            Key privateKey = new Key(); // generate a random private key

            PubKey publicKey = privateKey.PubKey;

            Console.WriteLine(publicKey);
            Console.WriteLine(publicKey.GetAddress(Network.Main));
            Console.WriteLine(publicKey.GetAddress(Network.TestNet));

            var publicKeyHash = publicKey.Hash;
            Console.WriteLine("publicKeyHash: " + publicKeyHash);
            var mainNetAddress = publicKeyHash.GetAddress(Network.Main);
            var testNetAddress = publicKeyHash.GetAddress(Network.TestNet);

            Console.WriteLine("mainNetAddress: " + mainNetAddress);
            Console.WriteLine("testNetAddress: " + testNetAddress);

            var paymentScript = publicKeyHash.ScriptPubKey;
            var sameMainNetAddress = paymentScript.GetDestinationAddress(Network.Main);
            Console.WriteLine(mainNetAddress == sameMainNetAddress);


            var samePublicKeyHash = (KeyId)paymentScript.GetDestination();
            Console.WriteLine(publicKeyHash == samePublicKeyHash); 
            var sameMainNetAddress2 = new BitcoinPubKeyAddress(samePublicKeyHash, Network.Main);
            Console.WriteLine(mainNetAddress == sameMainNetAddress2);

            var bitcoinSecret = privateKey.GetWif(Network.Main);
            Console.WriteLine("Hello World! " + bitcoinSecret);

            Console.WriteLine("#######################################################################");

            var publicKeyHash2 = new KeyId("14836dbe7f38c5ac3d49e8d790af808a4ee9edcf");
            var testNetAddress2 = publicKeyHash2.GetAddress(Network.TestNet);
            var mainNetAddress2 = publicKeyHash2.GetAddress(Network.Main);
            // OP_DUP OP_HASH160 14836dbe7f38c5ac3d49e8d790af808a4ee9edcf OP_EQUALVERIFY OP_CHECKSIG
            Console.WriteLine(mainNetAddress2.ScriptPubKey);

            // OP_DUP OP_HASH160 14836dbe7f38c5ac3d49e8d790af808a4ee9edcf OP_EQUALVERIFY OP_CHECKSIG
            Console.WriteLine(testNetAddress2.ScriptPubKey); 

            Console.ReadLine();
        }
    }
}

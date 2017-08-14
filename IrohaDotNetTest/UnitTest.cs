/**
  * Copyright Jin Adachi All Rights Reserved.
  * https://github.com/hyperledger/iroha-dotnet
  * Licensed under the Apache License, Version 2.0 (the "License");
  * you may not use this file except in compliance with the License.
  * You may obtain a copy of the License at
  *      http://www.apache.org/licenses/LICENSE-2.0
  * Unless required by applicable law or agreed to in writing, software
  * distributed under the License is distributed on an "AS IS" BASIS,
  * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
  * See the License for the specific language governing permissions and
  * limitations under the License.
  */
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using IrohaDotNet;

namespace IrohaDotNetTest
{
    [TestClass]
    public class UnitTest
    {
        [TestMethod]
        public void Sign()
        {
            string publicKey = "N1X+Fv7soLknpZNtkdW5cRphgzFjqHmOJl9GvVahWxk=";
            string privateKey = "aFJfbcedA7p6X0b6EdQNovfFtmq4YSGK/+Bw+XBrsnAEBpXRu+Qfw0559lgLwF2QusChGiDEkLAxPqodQH1kbA==";
            KeyPair keyPair = new KeyPair(privateKey, publicKey);
            string message = Sha3Util.Sha3_256("test");
            string signature = "bl7EyGwrdDIcHpizHUcDd4Ui34pQRv5VoM69WEPGNveZVOIXJbX3nWhvBvyGXaCxZIuu0THCo5g8PSr2NZJKBg==";

            string result = Iroha.Sign(keyPair, message);

            Assert.AreEqual(signature, result);
        }

        [TestMethod]
        public void Verify()
        {
            string publicKey = "N1X+Fv7soLknpZNtkdW5cRphgzFjqHmOJl9GvVahWxk=";
            string message = Sha3Util.Sha3_256("test");
            string signature = "bl7EyGwrdDIcHpizHUcDd4Ui34pQRv5VoM69WEPGNveZVOIXJbX3nWhvBvyGXaCxZIuu0THCo5g8PSr2NZJKBg==";

            bool result = Iroha.Verify(publicKey, signature, message);

            Assert.AreEqual(true, result);
        }

        [TestMethod]
        public void VerifyWithCreateKeyPair()
        {
            KeyPair keyPair = Iroha.CreateKeyPair();
            string message = "Iroha .NET";

            string signature = Iroha.Sign(keyPair, message);
            bool result = Iroha.Verify(keyPair.PublicKey, signature, message);

            Assert.AreEqual(true, result);
        }

        [TestMethod]
        public void Sha3_256()
        {
            string hash1 = "a7ffc6f8bf1ed76651c14756a061d662f580ff4de43b49fa82d80a4b80f8434a";
            string hash2 = Sha3Util.Sha3_256("");
            Assert.AreEqual(hash1, hash2);

            string hash3 = "36f028580bb02cc8272a9a020f4200e346e276ae664e45ee80745574e2f5ab80";
            string hash4 = Sha3Util.Sha3_256("test");
            Assert.AreEqual(hash3, hash4);

        }

        [TestMethod]
        public void Sha3_384()
        {
            string hash1 = "0c63a75b845e4f7d01107d852e4c2485c51a50aaaa94fc61995e71bbee983a2ac3713831264adb47fb6bd1e058d5f004";
            string hash2 = Sha3Util.Sha3_384("");
            Assert.AreEqual(hash1, hash2);

            string hash3 = "e516dabb23b6e30026863543282780a3ae0dccf05551cf0295178d7ff0f1b41eecb9db3ff219007c4e097260d58621bd";
            string hash4 = Sha3Util.Sha3_384("test");
            Assert.AreEqual(hash3, hash4);

        }

        [TestMethod]
        public void Sha3_512()
        {
            string hash1 = "a69f73cca23a9ac5c8b567dc185a756e97c982164fe25859e0d1dcc1475c80a615b2123af1f5f94c11e3e9402c3ac558f500199d95b6d3e301758586281dcd26";
            string hash2 = Sha3Util.Sha3_512("");
            Assert.AreEqual(hash1, hash2);

            string hash3 = "9ece086e9bac491fac5c1d1046ca11d737b92a2b2ebd93f005d7b710110c0a678288166e7fbe796883a4f2e9b3ca9f484f521d0ce464345cc1aec96779149c14";
            string hash4 = Sha3Util.Sha3_512("test");
            Assert.AreEqual(hash3, hash4);

        }
    }
}

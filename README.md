# Iroha .NET

## What is Iroha?
Iroha is [this](https://github.com/hyperledger/iroha).

## Description
Iroha .NET is client library for using iroha for .NET.


- [Requirements](#requirements)
- [Building](#building)
- [Usage](#usage)
- [License](#license)

## Requirements

- Visual Studio 2015  
- .NET Framework 4.5+  
- Windows 7+

## Building

### Build an entire solution
1. In __Solution Explorer__, choose the solution.
1. On the menu bar, choose __Build Solution__.

### Build a single project
1. In __Solution Explorer__, choose the project.
1. On the menu bar, choose __Build__.

## Testing with MSTest

1. Open __Test Explorer__.
    - If Test Explorer is not visible, choose __Test__ on the menu, choose __Windows__, and then choose __Test Explorer__.
1. To run all the tests in the solution, choose __Run All__.

## Usage
### API

### IrohaDotNet
#### CreateKeyPair
```csharp
using IrohaDotNet;

KeyPair keyPair = Iroha.CreateKeyPair();
//===> keypair.PublicKey : Ed25519 public key encoded by base64
//===> keypair.PrivateKey : Ed25519 private key encoded by base64
```

#### Sign
```csharp
using IrohaDotNet;

string signature = Iroha.Sign(keyPair, message);
//===> signature : signature encoded by base64
```

#### Verify
```csharp
using IrohaDotNet;

bool verify = Iroha.Verify(publicKey, signature, message);
//===> verify : true if the correct message
```

#### Sha3_256
```csharp
using IrohaDotNet;

string hash = Sha3Util.Sha3_256("");
//===> hash : "a7ffc6f8bf1ed76651c14756a061d662f580ff4de43b49fa82d80a4b80f8434a"
```

#### Sha3_384
```csharp
using IrohaDotNet;

string hash = Sha3Util.Sha3_384("");
//===> hash : "0c63a75b845e4f7d01107d852e4c2485c51a50aaaa94fc61995e71bbee983a2ac3713831264adb47fb6bd1e058d5f004"
```

#### Sha3_512
```csharp
using IrohaDotNet;

string hash = Sha3Util.Sha3_512("");
//===> hash : "a69f73cca23a9ac5c8b567dc185a756e97c982164fe25859e0d1dcc1475c80a615b2123af1f5f94c11e3e9402c3ac558f500199d95b6d3e301758586281dcd26"
```

## Author
[adachij2002](https://github.com/adachij2002)

## License

Copyright 2017 Jin Adachi.

Licensed under the Apache License, Version 2.0 (the "License");
you may not use this file except in compliance with the License.
You may obtain a copy of the License at

    http://www.apache.org/licenses/LICENSE-2.0

Unless required by applicable law or agreed to in writing, software
distributed under the License is distributed on an "AS IS" BASIS,
WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
See the License for the specific language governing permissions and
limitations under the License.

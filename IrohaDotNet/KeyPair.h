#pragma once

using namespace System;

namespace IrohaDotNet
{
	public ref class KeyPair sealed
	{
	public:
		KeyPair(String ^privateKey, String ^publicKey)
		{
			PrivateKey = privateKey;
			PublicKey = publicKey;
		}
		property String ^PrivateKey;
		property String ^PublicKey;
	};
}
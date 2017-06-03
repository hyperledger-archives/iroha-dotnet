#pragma once

#include "msclr/marshal.h"
#pragma managed(push, off)
#include "Vendor/ed25519/src/sha3.h"
#pragma managed(pop)

using namespace msclr::interop;
using namespace System;
using namespace System::Runtime::InteropServices;

namespace IrohaDotNet {

	public ref class Sha3Util sealed
	{
	public:
		static String^ Sha3_256(String ^message)
		{
			return Sha3_x(sha3_256, message, 32);
		}
		static String^ Sha3_384(String ^message)
		{
			return Sha3_x(sha3_384, message, 48);
		}
		static String^ Sha3_512(String ^message)
		{
			return Sha3_x(sha3_512, message, 64);
		}
	private:
		static String^ Sha3_x(void(*sha3_func)(const unsigned char *, size_t, unsigned char *), String ^message, int hashlen)
		{
			marshal_context ^context = gcnew marshal_context();
			const char *msgbuf = context->marshal_as<const char *>(message);
			unsigned char *hashbuf = new unsigned char[hashlen];

			sha3_func((const unsigned char *)msgbuf, strlen(msgbuf), hashbuf);

			array<unsigned char> ^hash = gcnew array<unsigned char>(hashlen);
			Marshal::Copy((IntPtr)hashbuf, hash, 0, hashlen);

			delete hashbuf;
			delete context;

			return BytesToHexString(hash);
		}
		static String^ BytesToHexString(array<unsigned char> ^bytes)
		{
			return BitConverter::ToString(bytes)->Replace("-", String::Empty)->ToLower();
		}
	};
}

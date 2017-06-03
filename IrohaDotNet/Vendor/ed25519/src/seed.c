#include "ed25519.h"
#include "winapifamily.h"

#ifndef ED25519_NO_SEED

#if WINAPI_FAMILY_PARTITION(WINAPI_PARTITION_APP)
#include <windows.h>
#include <bcrypt.h>
#elif _WIN32
#include <windows.h>
#include <wincrypt.h>
#else
#include <stdio.h>
#endif

int ed25519_create_seed(unsigned char *seed) {
#if (WINVER >= _WIN32_WINNT_VISTA)
	BCRYPT_ALG_HANDLE prov;

	if (!BCryptOpenAlgorithmProvider(&prov, BCRYPT_RNG_ALGORITHM, MS_PRIMITIVE_PROVIDER, NULL)) {
		return 1;
	}

	if (!BCryptGenRandom(prov, seed, 32, NULL)) {
		BCryptCloseAlgorithmProvider(prov, 0);
		return 1;
	}

	BCryptCloseAlgorithmProvider(prov, 0);
#elif _WIN32
    HCRYPTPROV prov;

    if (!CryptAcquireContext(&prov, NULL, NULL, PROV_RSA_FULL, CRYPT_VERIFYCONTEXT))  {
        return 1;
    }

    if (!CryptGenRandom(prov, 32, seed))  {
        CryptReleaseContext(prov, 0);
        return 1;
    }

    CryptReleaseContext(prov, 0);
#else
    FILE *f = fopen("/dev/urandom", "rb");

    if (f == NULL) {
        return 1;
    }

    fread(seed, 1, 32, f);
    fclose(f);
#endif

    return 0;
}

#endif

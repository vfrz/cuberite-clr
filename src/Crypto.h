
// Crypto.h

// Declares classes that wrap the cryptographic code library





#pragma once

#include "polarssl/rsa.h"
#include "polarssl/aes.h"
#include "polarssl/entropy.h"
#include "polarssl/ctr_drbg.h"
#include "polarssl/sha1.h"





/** Decrypts data using the AES / CFB (128) algorithm */
class cAESCFBDecryptor
{
public:
	Byte test;
	
	cAESCFBDecryptor(void);
	~cAESCFBDecryptor();
	
	/** Initializes the decryptor with the specified Key / IV */
	void Init(const Byte a_Key[16], const Byte a_IV[16]);
	
	/** Decrypts a_Length bytes of the encrypted data; produces a_Length output bytes */
	void ProcessData(Byte * a_DecryptedOut, const Byte * a_EncryptedIn, size_t a_Length);
	
	/** Returns true if the object has been initialized with the Key / IV */
	bool IsValid(void) const { return m_IsValid; }
	
protected:
	aes_context m_Aes;
	
	/** The InitialVector, used by the CFB mode decryption */
	Byte m_IV[16];
	
	/** Current offset in the m_IV, used by the CFB mode decryption */
	size_t m_IVOffset;
	
	/** Indicates whether the object has been initialized with the Key / IV */
	bool m_IsValid;
} ;





/** Encrypts data using the AES / CFB (128) algorithm */
class cAESCFBEncryptor
{
public:
	cAESCFBEncryptor(void);
	~cAESCFBEncryptor();
	
	/** Initializes the decryptor with the specified Key / IV */
	void Init(const Byte a_Key[16], const Byte a_IV[16]);
	
	/** Encrypts a_Length bytes of the plain data; produces a_Length output bytes */
	void ProcessData(Byte * a_EncryptedOut, const Byte * a_PlainIn, size_t a_Length);
	
	/** Returns true if the object has been initialized with the Key / IV */
	bool IsValid(void) const { return m_IsValid; }
	
protected:
	aes_context m_Aes;
	
	/** The InitialVector, used by the CFB mode encryption */
	Byte m_IV[16];
	
	/** Current offset in the m_IV, used by the CFB mode encryption */
	size_t m_IVOffset;
	
	/** Indicates whether the object has been initialized with the Key / IV */
	bool m_IsValid;
} ;





/** Calculates a SHA1 checksum for data stream */
class cSHA1Checksum
{
public:
	typedef Byte Checksum[20];  // The type used for storing the checksum
	
	cSHA1Checksum(void);
	
	/** Adds the specified data to the checksum */
	void Update(const Byte * a_Data, size_t a_Length);
	
	/** Calculates and returns the final checksum */
	void Finalize(Checksum & a_Output);
	
	/** Returns true if the object is accepts more input data, false if Finalize()-d (need to Restart()) */
	bool DoesAcceptInput(void) const { return m_DoesAcceptInput; }
	
	/** Converts a raw 160-bit SHA1 digest into a Java Hex representation
	According to http://wiki.vg/wiki/index.php?title=Protocol_Encryption&oldid=2802
	*/
	static void DigestToJava(const Checksum & a_Digest, AString & a_JavaOut);
	
	/** Clears the current context and start a new checksum calculation */
	void Restart(void);
	
protected:
	/** True if the object is accepts more input data, false if Finalize()-d (need to Restart()) */
	bool m_DoesAcceptInput;
	
	sha1_context m_Sha1;
} ;





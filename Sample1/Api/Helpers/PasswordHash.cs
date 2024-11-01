using System.Security.Cryptography;

namespace Api.Helpers;

public sealed class PasswordHash
{
    private const int _saltSize = 16;
    private const int _hashSize = 20;
    private const int _hashIter = 10000;

    readonly byte[] _salt;
    readonly byte[] _hash;

    public PasswordHash(string password)
    {

        _salt = RandomNumberGenerator.GetBytes(_saltSize);
        _hash = new Rfc2898DeriveBytes(password, _salt, _hashIter, HashAlgorithmName.SHA3_512)
            .GetBytes(_hashSize);
    }

    public byte[] Salt { get { return (byte[])_salt.Clone(); } }
    public byte[] Hash { get { return (byte[])_hash.Clone(); } }

    public bool Verify(string password)
    {
        var test = new Rfc2898DeriveBytes(password, _salt, _hashIter, HashAlgorithmName.SHA3_512)
            .GetBytes(_hashSize);

        for (var i = 0; i < _hashSize; i++)
            if (test[i] != _hash[i])
                return false;
        return true;
    }
}
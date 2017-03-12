﻿// <copyright file="Certificate.cs">
//    2017 - Johan Boström
// </copyright>

using System.IO;
using System.Security.Cryptography.X509Certificates;

namespace IdentityServer3.StarterKit.Config
{
    public static class Certificate
    {
        public static X509Certificate2 Get()
        {
            var assembly = typeof(Certificate).Assembly;
            using (var stream = assembly.GetManifestResourceStream("IdentityServer3.StarterKit.Config.idsrv3test.pfx"))
                // Should be the path to the embeded certificate
            {
                return new X509Certificate2(ReadStream(stream), "idsrv3test");
            }
        }

        private static byte[] ReadStream(Stream input)
        {
            var buffer = new byte[16 * 1024];
            using (var ms = new MemoryStream())
            {
                int read;
                while ((read = input.Read(buffer, 0, buffer.Length)) > 0)
                    ms.Write(buffer, 0, read);
                return ms.ToArray();
            }
        }
    }
}
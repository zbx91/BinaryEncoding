﻿using System.IO;
using Xunit;

namespace BinaryEncoding.Tests
{
    public partial class BinaryTests
    {
        [Fact]
        public void Stream_ReadUInt32()
        {
            var bytes = Binary.BigEndian.GetBytes(uint.MaxValue);
            using (var ms = new MemoryStream(bytes))
            {
                var n = Binary.BigEndian.ReadUInt32(ms);

                Assert.Equal(n, uint.MaxValue);
                Assert.Equal(ms.Position, 4);
                Assert.Equal(ms.Length, 4);
            }
        }

        [Fact]
        public void Stream_ReadAndWriteUInt32()
        {
            using (var ms = new MemoryStream())
            {
                Binary.BigEndian.Write(ms, uint.MaxValue);
                ms.Seek(0, SeekOrigin.Begin);
                var n = Binary.BigEndian.ReadUInt32(ms);

                Assert.Equal(n, uint.MaxValue);
                Assert.Equal(ms.Position, 4);
                Assert.Equal(ms.Length, 4);
            }
        }

        [Fact]
        public void Stream_ReadUInt32PastEndOfStream_DoesNotBlock()
        {
            using (var ms = new MemoryStream())
            {
                Binary.BigEndian.Write(ms, uint.MaxValue);
                ms.Seek(0, SeekOrigin.Begin);
                var n = Binary.BigEndian.ReadUInt32(ms);

                Assert.Equal(n, uint.MaxValue);
                Assert.Equal(ms.Position, 4);
                Assert.Equal(ms.Length, 4);

                Assert.Throws<EndOfStreamException>(() => Binary.BigEndian.ReadUInt32(ms));
            }
        }

        [Fact]
        public void Stream_ReadVarintPastEndOfStream_DoesNotBlock()
        {
            using (var ms = new MemoryStream())
            {
                Binary.Varint.Write(ms, uint.MaxValue);
                ms.Seek(0, SeekOrigin.Begin);
                uint n = 0;
                Binary.Varint.Read(ms, out n);

                Assert.Equal(n, uint.MaxValue);

                Assert.Throws<EndOfStreamException>(() => Binary.Varint.Read(ms, out n));
            }
        }
    }
}

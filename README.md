# BinaryEncoding

[![Build Status](https://travis-ci.org/tabrath/BinaryEncoding.svg?branch=master)](https://travis-ci.org/tabrath/BinaryEncoding)
[![Build status](https://ci.appveyor.com/api/projects/status/p5x257u2645daj8b/branch/master?svg=true)](https://ci.appveyor.com/project/tabrath/binaryencoding/branch/master)
[![NuGet Badge](https://buildstats.info/nuget/BinaryEncoding)](https://www.nuget.org/packages/BinaryEncoding/)

BinaryEncoding simplifies the encoding of numbers to BigEndian, LittleEndian and Varint to byte arrays.

## API

To set values to an array of bytes:
``` cs
Binary.BigEndian.Set(bytes, offset, value);
Binary.LittleEndian.Set(bytes, offset, value);
Binary.Varint.Write(bytes, offset, value);
```

Extension methods are provided for retrieving the bytes:
``` cs
Binary.BigEndian.GetBytes(value);
Binary.LittleEndian.GetBytes(value);
Binary.Varint.GetBytes(value);
```

Also, for converting bytes to numbers:
``` cs
Binary.BigEndian.GetInt16(bytes, offset);
Binary.BigEndian.GetInt32(bytes, offset);
Binary.BigEndian.GetInt64(bytes, offset);
Binary.BigEndian.GetUInt16(bytes, offset);
Binary.BigEndian.GetUInt32(bytes, offset);
Binary.BigEndian.GetUInt64(bytes, offset);
Binary.LittleEndian.GetInt16(bytes, offset);
Binary.LittleEndian.GetInt32(bytes, offset);
Binary.LittleEndian.GetInt64(bytes, offset);
Binary.LittleEndian.GetUInt16(bytes, offset);
Binary.LittleEndian.GetUInt32(bytes, offset);
Binary.LittleEndian.GetUInt64(bytes, offset);

// varint, returns number of bytes consumed
// value can be short, ushort, int, uint, long, ulong
Binary.Varint.Read(bytes, out value);
```

.. more to come
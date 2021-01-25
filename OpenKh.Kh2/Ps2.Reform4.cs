namespace OpenKh.Kh2
{
    public partial class Ps2
    {
        private static readonly byte[] tbl4bc =
        {
            0, 2, 8, 10, 1, 3, 9, 11, 4, 6, 12, 14, 5, 7, 13, 15,
            16, 18, 24, 26, 17, 19, 25, 27, 20, 22, 28, 30, 21, 23, 29, 31
        };

        private static readonly int[] tbl4col0 =
        {
            0x00, 0x20, 0x80, 0xa0, 0x100, 0x120, 0x180, 0x1a0, 0x08, 0x28, 0x88, 0xa8, 0x108, 0x128, 0x188, 0x1a8,
            0x10, 0x30, 0x90, 0xb0, 0x110, 0x130, 0x190, 0x1b0, 0x18, 0x38, 0x98, 0xb8, 0x118, 0x138, 0x198, 0x1b8,
            0x40, 0x60, 0xc0, 0xe0, 0x140, 0x160, 0x1c0, 0x1e0, 0x48, 0x68, 0xc8, 0xe8, 0x148, 0x168, 0x1c8, 0x1e8,
            0x50, 0x70, 0xd0, 0xf0, 0x150, 0x170, 0x1d0, 0x1f0, 0x58, 0x78, 0xd8, 0xf8, 0x158, 0x178, 0x1d8, 0x1f8,
            0x104, 0x124, 0x184, 0x1a4, 0x04, 0x24, 0x84, 0xa4, 0x10c, 0x12c, 0x18c, 0x1ac, 0x0c, 0x2c, 0x8c, 0xac,
            0x114, 0x134, 0x194, 0x1b4, 0x14, 0x34, 0x94, 0xb4, 0x11c, 0x13c, 0x19c, 0x1bc, 0x1c, 0x3c, 0x9c, 0xbc,
            0x144, 0x164, 0x1c4, 0x1e4, 0x44, 0x64, 0xc4, 0xe4, 0x14c, 0x16c, 0x1cc, 0x1ec, 0x4c, 0x6c, 0xcc, 0xec,
            0x154, 0x174, 0x1d4, 0x1f4, 0x54, 0x74, 0xd4, 0xf4, 0x15c, 0x17c, 0x1dc, 0x1fc, 0x5c, 0x7c, 0xdc, 0xfc
        };

        private static readonly int[] tbl4col1 =
        {
            0x100, 0x120, 0x180, 0x1a0, 0x00, 0x20, 0x80, 0xa0, 0x108, 0x128, 0x188, 0x1a8, 0x08, 0x28, 0x88, 0xa8,
            0x110, 0x130, 0x190, 0x1b0, 0x10, 0x30, 0x90, 0xb0, 0x118, 0x138, 0x198, 0x1b8, 0x18, 0x38, 0x98, 0xb8,
            0x140, 0x160, 0x1c0, 0x1e0, 0x40, 0x60, 0xc0, 0xe0, 0x148, 0x168, 0x1c8, 0x1e8, 0x48, 0x68, 0xc8, 0xe8,
            0x150, 0x170, 0x1d0, 0x1f0, 0x50, 0x70, 0xd0, 0xf0, 0x158, 0x178, 0x1d8, 0x1f8, 0x58, 0x78, 0xd8, 0xf8,
            0x04, 0x24, 0x84, 0xa4, 0x104, 0x124, 0x184, 0x1a4, 0x0c, 0x2c, 0x8c, 0xac, 0x10c, 0x12c, 0x18c, 0x1ac,
            0x14, 0x34, 0x94, 0xb4, 0x114, 0x134, 0x194, 0x1b4, 0x1c, 0x3c, 0x9c, 0xbc, 0x11c, 0x13c, 0x19c, 0x1bc,
            0x44, 0x64, 0xc4, 0xe4, 0x144, 0x164, 0x1c4, 0x1e4, 0x4c, 0x6c, 0xcc, 0xec, 0x14c, 0x16c, 0x1cc, 0x1ec,
            0x54, 0x74, 0xd4, 0xf4, 0x154, 0x174, 0x1d4, 0x1f4, 0x5c, 0x7c, 0xdc, 0xfc, 0x15c, 0x17c, 0x1dc, 0x1fc
        };

        public static byte[] Decode4(byte[] bin, int bw, int bh)
        {
            var buffer = new byte[bin.Length];
            for (int i = 0; i < (0x80 * bh); i += 0x80)
            {
                for (int j = 0; j < (0x80 * bw); j += 0x80)
                {
                    int num3 = 0x2000 * ((j / 0x80) + (bw * (i / 0x80)));
                    for (int k = 0; k < 0x80; k += 0x10)
                    {
                        for (int m = 0; m < 0x80; m += 0x20)
                        {
                            int num6 = 0x100 * tbl4bc[(m / 0x20) + (4 * (k / 0x10))];
                            for (int n = 0; n < 4; n++)
                            {
                                int num8 = 0x40 * n;
                                int[] numArray = ((n & 1) == 0) ? tbl4col0 : tbl4col1;
                                for (int num9 = 0; num9 < 0x80; num9++)
                                {
                                    int num10 = numArray[num9] / 8;
                                    int num11 = numArray[num9] % 8;
                                    var num12 = (byte)((bin[((num3 + num6) + num8) + num10] >> num11) & 15);
                                    int num13 = (j + m) + (num9 % 0x20);
                                    int num14 = ((i + k) + (4 * n)) + (num9 / 0x20);
                                    int num15 = num13 + ((0x80 * bw) * num14);
                                    byte num16 = buffer[num15 / 2];
                                    if ((num15 & 1) == 1)
                                    {
                                        num16 = (byte)(num16 & 240);
                                        num16 = (byte)(num16 | num12);
                                    }
                                    else
                                    {
                                        num16 = (byte)(num16 & 15);
                                        num16 = (byte)(num16 | ((byte)(num12 << 4)));
                                    }
                                    buffer[num15 / 2] = num16;
                                }
                            }
                        }
                    }
                }
            }
            return buffer;
        }

        public static byte[] Encode4(byte[] bin, int bw, int bh)
        {
            var buffer = new byte[bin.Length];
            for (int i = 0; i < (0x80 * bh); i += 0x80)
            {
                for (int j = 0; j < (0x80 * bw); j += 0x80)
                {
                    int num3 = 0x2000 * ((j / 0x80) + (bw * (i / 0x80)));
                    for (int k = 0; k < 0x80; k += 0x10)
                    {
                        for (int m = 0; m < 0x80; m += 0x20)
                        {
                            int num6 = 0x100 * tbl4bc[(m / 0x20) + (4 * (k / 0x10))];
                            for (int n = 0; n < 4; n++)
                            {
                                int num8 = 0x40 * n;
                                int[] numArray = ((n & 1) == 0) ? tbl4col0 : tbl4col1;
                                for (int num9 = 0; num9 < 0x80; num9++)
                                {
                                    int num10 = (j + m) + (num9 % 0x20);
                                    int num11 = ((i + k) + (4 * n)) + (num9 / 0x20);
                                    int num12 = num10 + ((0x80 * bw) * num11);
                                    byte num13 = bin[num12 / 2];
                                    if ((num12 & 1) == 0)
                                    {
                                        num13 = (byte)(num13 >> 4);
                                    }
                                    else
                                    {
                                        num13 = (byte)(num13 & 15);
                                    }
                                    int num14 = numArray[num9] / 8;
                                    int num15 = numArray[num9] % 8;
                                    int index = ((num3 + num6) + num8) + num14;
                                    byte num17 = buffer[index];
                                    switch (num15)
                                    {
                                        case 0:
                                            num17 = (byte)(num17 & 240);
                                            num17 = (byte)(num17 | num13);
                                            break;

                                        case 4:
                                            num17 = (byte)(num17 & 15);
                                            num17 = (byte)(num17 | ((byte)(num13 << 4)));
                                            break;
                                    }
                                    buffer[index] = num17;
                                }
                            }
                        }
                    }
                }
            }
            return buffer;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace Coologger
{
    public class IconInjector
    {
        public class NativeMethods
        {
            [DllImport("kernel32.dll", SetLastError = true)]
            public static extern IntPtr BeginUpdateResource(string pFileName,
                [MarshalAs(UnmanagedType.Bool)]bool bDeleteExistingResources);

            [DllImport("kernel32.dll", SetLastError = true)]
            public static extern bool UpdateResource(IntPtr hUpdate, IntPtr lpType, IntPtr lpName, short wLanguage, byte[] lpData, int cbData);

            [DllImport("kernel32.dll", SetLastError = true)]
            public static extern bool EndUpdateResource(IntPtr hUpdate, bool fDiscard);
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct ICONDIR
        {
            public ushort Reserved;
            public ushort Type;
            public ushort Count;
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct ICONDIRENTRY
        {
            public byte Width, Height;
            public byte ColorCount, Reserved;
            public ushort Planes, BitCount;
            public int ByteInRes, ImageOffset;
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct BITMAPINFOHEADER
        {
            public uint Size;
            public int Width, Height;
            public ushort Planes, BitCount;
            public uint Compressions, SizeImage;
            public int XPelsPerMeter, YPelsPerMeter;
            public uint ClrUsed, ClrImportant;
        }

        [StructLayout(LayoutKind.Sequential, Pack = 2)]
        public struct GRPICONDIRENTRY
        {
            public byte Width, Height;
            public byte ColorCount, Reserved;
            public ushort Planes, BitCount;
            public int BytesInRes;
            public ushort ID;
        }

        public static void InjectIcon(string exeFileName, string iconFileName)
        {
            InjectIcon(exeFileName, iconFileName, 1, 1);
        }

        public static void InjectIcon(string exeFileName, string iconFileName, int iconGroupID, uint iconBaseID)
        {
            const uint RT_ICON = 3;
            IntPtr RT_GROUP_ICON = new IntPtr(14);
            IconFile iconFile = new IconFile().FromFile(iconFileName);
            IntPtr hUpdate = NativeMethods.BeginUpdateResource(exeFileName, false);
            byte[] data = iconFile.CreateIconGroupData(iconBaseID);
            NativeMethods.UpdateResource(
                hUpdate, RT_GROUP_ICON, new IntPtr(iconGroupID), 0, data, data.Length);
            for (int i = 0; i < iconFile.ImageCount - 1; i++)
            {
                byte[] image = iconFile.ImageData(i);
                NativeMethods.UpdateResource(hUpdate, new IntPtr(RT_ICON), new IntPtr(iconBaseID + i), 0, image,
                                             image.Length);
            }
            NativeMethods.EndUpdateResource(hUpdate, false);
        }
    }

    public class IconFile
    {
        private IconInjector.ICONDIR iconDir;
        private IconInjector.ICONDIRENTRY[] iconEntry;
        private byte[][] iconImage;
        public int ImageCount
        {
            get { return iconDir.Count; }
        }

        public byte[] ImageData(int index)
        {
            return iconImage[index];
        }

        public IconFile FromFile(string filename)
        {
            byte[] fileBytes = System.IO.File.ReadAllBytes(filename);
            GCHandle pinnedBytes = GCHandle.Alloc(fileBytes, GCHandleType.Pinned);
            IconFile instance = new IconFile();
            {
                iconDir = (IconInjector.ICONDIR)Marshal.PtrToStructure(pinnedBytes.AddrOfPinnedObject(), typeof(IconInjector.ICONDIR));
                iconEntry = new IconInjector.ICONDIRENTRY[instance.iconDir.Count];
                iconImage = new byte[instance.iconDir.Count][];
            }
            int offset = Marshal.SizeOf(instance.iconDir);
            Type iconDirEntryType = typeof(IconInjector.ICONDIRENTRY);
            int size = Marshal.SizeOf(iconDirEntryType);

            for (int i = 0; i < instance.iconDir.Count - 1; i++)
            {
                IconInjector.ICONDIRENTRY entry =
                    (IconInjector.ICONDIRENTRY)
                    Marshal.PtrToStructure(new IntPtr(pinnedBytes.AddrOfPinnedObject().ToInt64() + offset),
                                           iconDirEntryType);
                instance.iconEntry[i] = entry;
                instance.iconImage[i] = new byte[entry.ByteInRes];
                Buffer.BlockCopy(fileBytes, entry.ImageOffset, instance.iconImage[i], 0, entry.ByteInRes);
                offset += size;
            }
            pinnedBytes.Free();
            return instance;
        }

        public byte[] CreateIconGroupData(uint iconBaseID)
        {
            int sizeOfIconGroupData = Marshal.SizeOf(typeof(IconInjector.ICONDIR)) +
                                      Marshal.SizeOf(typeof(IconInjector.GRPICONDIRENTRY)) * ImageCount;
            byte[] data = new byte[sizeOfIconGroupData];
            GCHandle pinnedData = GCHandle.Alloc(data, GCHandleType.Pinned);
            Marshal.StructureToPtr(iconDir, pinnedData.AddrOfPinnedObject(), false);
            int offset = Marshal.SizeOf(iconDir);
            for (int i = 0; i < ImageCount - 1; i++)
            {
                IconInjector.GRPICONDIRENTRY grpEntry = new IconInjector.GRPICONDIRENTRY();
                IconInjector.BITMAPINFOHEADER bitmapheader = new IconInjector.BITMAPINFOHEADER();
                GCHandle pinnedBitmapInfoHeader = GCHandle.Alloc(bitmapheader, GCHandleType.Pinned);
                Marshal.Copy(ImageData(i), 0, pinnedBitmapInfoHeader.AddrOfPinnedObject(), Marshal.SizeOf(typeof(IconInjector.BITMAPINFOHEADER)));
                pinnedBitmapInfoHeader.Free();
                grpEntry.Width = iconEntry[i].Width;
                grpEntry.Height = iconEntry[i].Height;
                grpEntry.ColorCount = iconEntry[i].ColorCount;
                grpEntry.Reserved = iconEntry[i].Reserved;
                grpEntry.Planes = iconEntry[i].Planes;
                grpEntry.BitCount = iconEntry[i].BitCount;
                grpEntry.BytesInRes = iconEntry[i].ByteInRes;
                grpEntry.ID = Convert.ToUInt16(iconBaseID + i);
                Marshal.StructureToPtr(grpEntry, new IntPtr(pinnedData.AddrOfPinnedObject().ToInt64() + offset), false);
                offset += Marshal.SizeOf(typeof(IconInjector.GRPICONDIRENTRY));
            }
            pinnedData.Free();
            return data;
        }
    }
}
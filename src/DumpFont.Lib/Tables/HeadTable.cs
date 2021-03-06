﻿using DumpFont.Extensions;
using System;
using System.IO;
using System.Text;

namespace DumpFont.Tables
{
    public class HeadTable
    {
        public const string Tag = "head"; 
        public ushort MajorVersion { get; private set; }
        public ushort MinorVersion { get; private set; }
        public decimal FontRevision { get; private set; }          // Fixed Point Number
        public uint CheckSumAdjustment { get; private set; }
        public uint MagicNumber { get; private set; }
        public ushort Flags { get; private set; }
        public ushort UnitsPerEm { get; private set; }
        public DateTime Created { get; private set; }
        public DateTime Modified { get; private set; }
        public short XMin { get; private set; }
        public short YMin { get; private set; }
        public short XMax { get; private set; }
        public short YMax { get; private set; }
        public ushort MacStyle { get; private set; }
        public ushort LowestRecPPEM { get; private set; }
        public short FontDirectionHint { get; private set; }
        public short IndexToLocFormat { get; private set; }
        public short GlyphDataFormat { get; private set; }

        public static HeadTable Read(BinaryReader reader)
        {
            var instance = new HeadTable
            {
                MajorVersion = reader.ReadUInt16BigEndian(),
                MinorVersion = reader.ReadUInt16BigEndian(),
                FontRevision = reader.ReadFixedPointNumber(),
                CheckSumAdjustment = reader.ReadUInt32BigEndian(),
                MagicNumber = reader.ReadUInt32BigEndian(),
                Flags = reader.ReadUInt16BigEndian(),
                UnitsPerEm = reader.ReadUInt16BigEndian(),
                Created = reader.ReadLongDateTime(),
                Modified = reader.ReadLongDateTime(),
                XMin = reader.ReadInt16BigEndian(),
                YMin = reader.ReadInt16BigEndian(),
                XMax = reader.ReadInt16BigEndian(),
                YMax = reader.ReadInt16BigEndian(),
                MacStyle = reader.ReadUInt16BigEndian(),
                LowestRecPPEM = reader.ReadUInt16BigEndian(),
                FontDirectionHint = reader.ReadInt16BigEndian(),
                IndexToLocFormat = reader.ReadInt16BigEndian(),
                GlyphDataFormat = reader.ReadInt16BigEndian()
            };
            return instance;
        }

        public string Dump()
        {
            var sb = new StringBuilder();
            sb.AppendTitleValueLine("MajorVersion", MajorVersion);
            sb.AppendTitleValueLine("MinorVersion", MinorVersion);
            sb.AppendTitleValueLine("FontRevision", Math.Round(FontRevision, 2));
            sb.AppendTitleValueLine("CheckSumAdjustment", CheckSumAdjustment);
            sb.AppendTitleValueLine("MagicNumber", MagicNumber);
            sb.AppendTitleValueLine("Flags", Convert.ToString(Flags, 2).PadLeft(16, '0'));
            sb.AppendTitleValueLine("UnitsPerEm", UnitsPerEm);
            sb.AppendTitleValueLine("Created", Created);
            sb.AppendTitleValueLine("Modified", Modified);
            sb.AppendTitleValueLine("XMin", XMin);
            sb.AppendTitleValueLine("YMin", YMin);
            sb.AppendTitleValueLine("XMax", XMax);
            sb.AppendTitleValueLine("YMax", YMax);
            sb.AppendTitleValueLine("MacStyle", MacStyle);
            sb.AppendTitleValueLine("LowestRecPPEM", LowestRecPPEM);
            sb.AppendTitleValueLine("FontDirectionHint", FontDirectionHint);
            sb.AppendTitleValueLine("IndexToLocFormat", IndexToLocFormat);
            sb.AppendTitleValueLine("GlyphDataFormat", GlyphDataFormat);
            return sb.ToString();
        }
    }
}

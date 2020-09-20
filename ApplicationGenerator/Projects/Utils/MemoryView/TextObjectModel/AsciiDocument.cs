﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Utils.MemoryView.TextObjectModel;
using Utils.MemoryView.TextObjectModel;
using System.IO;
using Utils;
using Utils.TextObjectModel;

namespace Utils.MemoryView.TextObjectModel
{
    public class AsciiDocument : MemoryTextDocument
    {
        public AsciiDocument()
        {
        }

        public override void Read(Stream stream, int lineWidth)
        {
            var reader = new BinaryReader(stream);
            var length = reader.BaseStream.Length;
            var rows = (int)length / lineWidth;
            string text;

            using (var reset = reader.MarkForReset())
            {
                reader.Seek(0);

                for (var y = 0; y < rows; y++)
                {
                    var offset = (y * lineWidth);
                    byte[] bytes;
                    var asciiArray = new string[lineWidth];
                    var count = 0;

                    count = Math.Max(0, Math.Min(lineWidth, (int)(reader.BaseStream.Length - reader.BaseStream.Position)));

                    if (count > 0)
                    {
                        bytes = reader.ReadBytes(count);

                        for (var x = 0; x < bytes.Length; x++)
                        {
                            var _byte = bytes[x];
                            char _char = (char)_byte;

                            text = (_byte < 0x20 ? "." : new string(_char, 1));
                            asciiArray[x] = text;
                        }

                        this.Lines.Add((TextLine)asciiArray);
                    }
                }
            }
        }
    }
}

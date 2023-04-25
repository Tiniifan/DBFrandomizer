using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DBFrandomizer.Tool;
using DBFrandomizer.Logic;

namespace DBFrandomizer.Formats
{
    public class jARC
    {
        public Stream BaseStream;

        public VirtualDirectory Directory;

        public jARC(Stream stream)
        {
            BaseStream = stream;
            Directory = Open();
        }

        public VirtualDirectory Open()
        {
            VirtualDirectory folder = new VirtualDirectory();

            BinaryDataReader data = new BinaryDataReader(BaseStream);
            var header = data.ReadStruct<jARCSupport.Header>();

            // Get files
            data.Seek((uint)header.Offset);
            for (int i =0; i < header.Count; i++)
            {
                long position = data.Position;
                var fileName = Encoding.UTF8.GetString(data.GetSection(6)) + "_" + Encoding.UTF8.GetString(data.GetSection(10));
                folder.AddFile(fileName, new SubMemoryStream(BaseStream, position, header.Size));
                data.Skip(0x110);
            }

            // Sort files by name
            folder.Reorganize();
            folder.SortAlphabetically();

            return folder;
        }

        public void Save(string filename)
        {
            // No add implemented

            using (FileStream stream = new FileStream(filename, FileMode.Create, FileAccess.Write))
            {
                BaseStream.Position = 0;
                BaseStream.CopyTo(stream);

                foreach (var file in Directory.Files)
                {
                    if (file.Value.ByteContent != null)
                    {
                        stream.Position = file.Value.Offset;
                        file.Value.CopyTo(stream);
                    }
                }
            }
        }

        public void Close()
        {
            BaseStream?.Dispose();
            BaseStream = null;
            Directory = null;
        }
    }
}

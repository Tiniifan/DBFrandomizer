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

        public jARCSupport.Header Header;

        public jARCSupport.FileEntry[] FileEntries;

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
            Header = data.ReadStruct<jARCSupport.Header>();

            // Get files
            FileEntries = data.ReadMultipleStruct<jARCSupport.FileEntry>(Header.FileCount);
            foreach (var entry in FileEntries)
            {
                folder.AddFile(entry.Hash2.ToString("X8") + ".bin", new SubMemoryStream(BaseStream, entry.Offset, entry.Size));
            }

            return folder;
        }

        public void Save(string filename)
        {
            string directoryPath = Path.GetDirectoryName(filename);
            if (!System.IO.Directory.Exists(directoryPath))
            {
                System.IO.Directory.CreateDirectory(directoryPath);
            }

            using (FileStream stream = new FileStream(filename, FileMode.Create, FileAccess.Write))
            {
                BinaryDataWriter writer = new BinaryDataWriter(stream);
                writer.WriteStruct(Header);
                writer.WriteMultipleStruct(FileEntries);

                foreach (var file in Directory.Files)
                {
                    stream.Position = file.Value.Offset;
                    file.Value.CopyTo(stream);
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

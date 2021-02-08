using System;
using System.IO;
using System.IO.MemoryMappedFiles;
using System.Threading.Tasks;

namespace Symulator.Domain.Message
{
    public class MessageStorageService : IMessageService
    {
        private const long Capacity = 1048576;

        private readonly MemoryMappedFile memoryFile;
        private readonly MemoryMappedViewStream streamFile;
        private readonly StreamWriter streamWriter;

        public MessageStorageService(string fileName)
        {
            if (Exists(fileName))
            {
                Console.WriteLine($"File {fileName} exists.");
            }
            memoryFile = MemoryMappedFile.CreateOrOpen(fileName, Capacity);
            streamFile = memoryFile.CreateViewStream();
            streamWriter = new StreamWriter(streamFile);
        }

        public void Append(byte[] frame)
        {
            var message = Message.Builder().WithFrame(frame).Build();
            streamWriter.WriteLineAsync(toString(message));
        }

        public async Task<string> ReadFile()
        {
            using (var stream = memoryFile.CreateViewStream())
            {
                using (var reader = new StreamReader(stream))
                {
                    var contentReadFromStream = await reader.ReadToEndAsync();
                    return contentReadFromStream;
                }
            }
        }

        public void SaveFile()
        {
            FileStream stream = File.OpenRead(@"D:\FFv1\dpx1\1.dpx");
            byte[] fileBytes = new byte[stream.Length];

            string Output = @"D:\Vanthiya Thevan\FFv1\dpx1\2.dpx";
            using var fileStream = new FileStream(Output, FileMode.Create, FileAccess.ReadWrite, FileShare.ReadWrite);

            using var memoryMapped = MemoryMappedFile.CreateFromFile(fileStream, "MapName", fileBytes.Length, MemoryMappedFileAccess.ReadWrite, new MemoryMappedFileSecurity(), HandleInheritability.Inheritable, true);
            var viewStream = memoryMapped.CreateViewStream();
            
            viewStream.Write(fileBytes, 0, fileBytes.Length);
        }

        private bool Exists(string fileName)
        {
            try
            {
                using var mm = MemoryMappedFile.OpenExisting(fileName);
                return false;
            }
            catch (FileNotFoundException)
            {
                return true;
            }
        }

        private string toString(Message m)
        {
            return $"{m.CanNo},{m.CanId},{m.DataLength},{string.Join(",", m.Data)}";
        }

        ~MessageStorageService()
        {
            streamWriter.Dispose();
            streamFile.Dispose();
            memoryFile.Dispose();
        }
    }
}

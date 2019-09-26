using System;

namespace CyClone.Core
{
    public interface IcyRemoteFileStream 
    {
        IAsyncResult BeginRead(byte[] buffer, int offset, int count, AsyncCallback callback, object state);
        IAsyncResult BeginWrite(byte[] buffer, int offset, int count, AsyncCallback callback, object state);
        bool CanRead { get; }
        bool CanSeek { get; }
        bool CanTimeout { get; }
        bool CanWrite { get; }
        void Close();
        SharedLib.Dispatcher.IMessageDispatcher Dispatcher { get; }
        int EndRead(IAsyncResult asyncResult);
        void EndWrite(IAsyncResult asyncResult);
        void Flush();
        string GetMD5Hash();
        string GetMD5Hash(long offset, int length);
        long Length { get; }
        long Position { get; set; }
        int Read(byte[] buffer, int offset, int count);
        int ReadByte();
        int ReadTimeout { get; set; }
        long Seek(long offset, System.IO.SeekOrigin origin);
        void SetLength(long value);
        int StreamHandle { get; }
        void Write(byte[] buffer, int offset, int count);
        void WriteByte(byte value);
        int WriteTimeout { get; set; }
    }
}

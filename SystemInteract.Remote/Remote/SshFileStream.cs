using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Renci.SshNet.Sftp;

namespace SystemInteract.Remote.Remote
{
    class SshFileStream: Stream
    {
         private SftpFileStream _fs;

         public SshFileStream(SftpFileStream fs)
        {
            _fs = fs;
        }

        public override bool CanRead
        {
            get
            {
                return _fs.CanRead;
            }
        }

        public override bool CanSeek
        {
            get
            {
                return _fs.CanSeek;
            }
        }

        public override bool CanWrite
        {
            get
            {
                return _fs.CanWrite;
            }
        }

        public override long Length
        {
            get
            {
                return _fs.Length;
            }
        }

        public override long Position
        {
            get
            {
                return _fs.Position;
            }
            set
            {
                _fs.Position = value;
            }
        }

        public override void Flush()
        {
            _fs.Flush();
        }

        public override long Seek(long offset, SeekOrigin origin)
        {
            return _fs.Seek(offset, origin);
        }

        public override void SetLength(long value)
        {
            _fs.SetLength(value);
        }

        public override int Read(byte[] buffer, int offset, int count)
        {
            return _fs.Read(buffer, offset, count);
        }

        public override void Write(byte[] buffer, int offset, int count)
        {
            _fs.Write(buffer, offset, count);
        }
    }
}

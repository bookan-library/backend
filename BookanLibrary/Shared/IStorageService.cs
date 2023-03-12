using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookanLibrary.Shared
{
    public interface IStorageService
    {
        Task<string> UploadFile(byte[] file, string filename);
    }
}

using System.IO;
using RestWithASPNETCore.Data.VO;

namespace RestWithASPNETCore.Business.Implementations
{
    public class FileBusinessImpl : IFileBusiness
    {
        public byte[] GetPDFFile()
        {
            string path = Directory.GetCurrentDirectory();
            var fullPath = path + "\\Other\\Contrato.pdf";
            return File.ReadAllBytes(fullPath);
        }
    }
}

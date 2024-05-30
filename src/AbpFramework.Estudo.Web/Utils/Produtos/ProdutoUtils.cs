using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace AbpFramework.Estudo.Web.Utils.Produtos
{
    public static class ProdutoUtils
    {
        public static async Task<bool> UploadArquivo(IFormFile arquivo, string imgPrefixo)
        {
            if (arquivo.Length <= 0)
            {
                return false;
            }

            var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/imagens", imgPrefixo + arquivo.FileName); //Definindo o path do arquivo da imagem que será feito o upload

            if (File.Exists(path))
            {
                return false;
            }

            using (var stream = new FileStream(path, FileMode.Create))
            {
                await arquivo.CopyToAsync(stream);
            }

            return true;
        }

        public static void ExcluirArquivos(List<string> filesNames)
        {
            foreach(string fileName in  filesNames)
            {
                var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/imagens", fileName);

                if (File.Exists(path))
                {
                    File.Delete(path);
                }
            }
        }
    }
}

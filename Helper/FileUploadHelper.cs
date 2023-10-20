
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;

namespace Helper
{
    public static class FileUploadHelper
    {
        public static string ToFileUploadKaydet(this object o, string KlasorYol, string DosyaYol)
        {
            string ExistFolder = "";
            for (int i = 1; i < KlasorYol.Split('/').Length - 1; i++)
            {
                ExistFolder += "/" + KlasorYol.Split('/')[i] + "/";
                if (!Directory.Exists(System.Web.HttpContext.Current.Server.MapPath(ExistFolder)))
                {
                    Directory.CreateDirectory(System.Web.HttpContext.Current.Server.MapPath(ExistFolder));
                }
            }

            IFormFile Fu = (o as IFormFile);
            String FileName = Guid.NewGuid().ToString();
            String FileNameExtension = "";
            try
            {
                if (Fu != null)
                {
                    FileNameExtension = System.IO.Path.GetExtension(Fu.FileName);
                    using (Stream fileStream = new FileStream(System.Web.HttpContext.Current.Server.MapPath(KlasorYol) + FileName + FileNameExtension, FileMode.Create))
                    {
                        Fu.CopyTo(fileStream);
                    }
                    return KlasorYol + FileName + FileNameExtension;
                }
                else
                {
                    return DosyaYol;
                }
            }
            catch
            {
                FileName = "";
                FileNameExtension = "";
                return DosyaYol;
            }
        }

        public static string ToFileIFromFileUploadKaydet(List<IFormFile> fileDosyaUrl, string KlasorYol, string DosyaYol, string extension)
        {
            FileInfo fi = new FileInfo(fileDosyaUrl[0].FileName);

            if (fi.Extension.ToLower() != extension)
            {
                return "err| Dosya  " + extension + " uzantılı olmalıdır";
            }
            else
            {
                string path = "";
                string fileUrl = "";
                foreach (var formFile in fileDosyaUrl)
                {
                    if (formFile.Length > 0)
                    {

                        string filename_ = CharacterHelper.MakeValidFileName(Guid.NewGuid().ToString() + "_" + formFile.FileName);
                        path = Path.Combine(Directory.GetCurrentDirectory(), KlasorYol, filename_);
                        bool exists = System.IO.Directory.Exists(KlasorYol);
                        if (!exists)
                            System.IO.Directory.CreateDirectory(KlasorYol);
                        var stream = new FileStream(path, FileMode.Create);
                        formFile.CopyTo(stream);

                        fileUrl = KlasorYol.Replace("wwwroot", "..") + filename_;

                    }
                }

                return fileUrl;
            }

        }
        public static List<String> ToFileMutipleUploadKaydet(IFormFileCollection file, string KlasorYol, string DosyaYol)
        {
            string path = "";
            string fileUrl = "";
            var FileUrlList = new List<string>();

            foreach (var formFile in file)
            {
                if (formFile.Length > 0)
                {
                    var filePath = Path.GetTempFileName();
                    string filename_ = CharacterHelper.MakeValidFileName(Guid.NewGuid().ToString() + "_" + formFile.FileName);
                    path = Path.Combine(Directory.GetCurrentDirectory(), KlasorYol, filename_);

                    bool exists = System.IO.Directory.Exists(KlasorYol);
                    if (!exists)
                        System.IO.Directory.CreateDirectory(KlasorYol);

                    var stream = new FileStream(path, FileMode.Create);
                    formFile.CopyTo(stream);
                    fileUrl = KlasorYol.Replace("wwwroot", "..") + filename_;
                    FileUrlList.Add(fileUrl);

                }

            }
            return FileUrlList;
        }

        public static string ToFileIFromSingleFileUploadKaydet(IFormFile fileDosyaUrl, string KlasorYol, string DosyaYol, string extension)
        {
            FileInfo fi = new FileInfo(fileDosyaUrl.FileName);

            if (fi.Extension != extension)
            {
                return "err| Dosya  " + extension + " uzantılı olmalıdır";
            }
            else
            {
                string path = "";
                string fileUrl = "";

                if (fileDosyaUrl.Length > 0)
                {

                    string filename_ = CharacterHelper.MakeValidFileName(Guid.NewGuid().ToString() + "_" + fileDosyaUrl.FileName);
                    path = Path.Combine(Directory.GetCurrentDirectory(), KlasorYol, filename_);
                    bool exists = System.IO.Directory.Exists(KlasorYol);
                    if (!exists)
                        System.IO.Directory.CreateDirectory(KlasorYol);
                    var stream = new FileStream(path, FileMode.Create);
                    fileDosyaUrl.CopyTo(stream);

                    fileUrl = KlasorYol.Replace("wwwroot", "..") + filename_;

                }


                return fileUrl;
            }
        }
    }
}

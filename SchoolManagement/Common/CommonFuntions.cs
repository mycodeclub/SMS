
using System.Collections.Specialized;

namespace SchoolManagement.Common
{
    public static class CommonFuntions
    {
      

        public static async Task<string> UploadFile(IFormFile? file, string userType, int userId, string docType)
        {
            var filePathToBrows = string.Empty;
            if (file != null && file.Length > 0)
            {
                string filePath = StaticVariables.FileUploadDefaultPath;
                switch (userType)
                {
                    case "Student":
                        filePath += StaticVariables.StudentFilesDefaultPath + "\\" + userId.ToString() + "\\";
                        break;
                    case "Staff":
                        filePath += StaticVariables.StaffFilesDefaultPath + "\\" + userId.ToString() + "\\";
                        break;
                }

                if (!Directory.Exists(filePath))
                    Directory.CreateDirectory(filePath);

                var fileName = docType + "." + file.FileName.Split('.').LastOrDefault();
                using (var stream = new FileStream(Directory.GetCurrentDirectory() + "\\" + filePath + "\\" + fileName, FileMode.Create))
                    await file.CopyToAsync(stream);
                filePathToBrows = "/" + filePath.Substring(8).Replace('\\', '/') + fileName;
            }
            return filePathToBrows;
        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Maui.Storage;
using DocumentFormat.OpenXml.Packaging;

namespace ProctorMVP
{
    static class Fileprompt
    {
        public static async Task<IFile> PickAndLoadFileAsync() {

            var fileTypes = new FilePickerFileType(new Dictionary<DevicePlatform, IEnumerable<string>>
            {
                { DevicePlatform.WinUI, new[] { ".png", ".jpg", ".docx", ".pdf" } },
                { DevicePlatform.Android, new[] { "image/png", "image/jpeg", "application/vnd.openxmlformats-officedocument.wordprocessingml.document", "application/pdf" } },
                { DevicePlatform.iOS, new[] { "public.png", "public.jpeg", "org.openxmlformats.wordprocessingml.document", "com.adobe.pdf" } },
                { DevicePlatform.MacCatalyst, new[] { "public.png", "public.jpeg", "org.openxmlformats.wordprocessingml.document", "com.adobe.pdf" } }
            });

            var options = new PickOptions {
                PickerTitle = "Select an image or document",
                FileTypes = fileTypes
            };

            var file = await FilePicker.Default.PickAsync(options);

            if (file == null)
                return null;

            using var stream = await file.OpenReadAsync();
            Console.WriteLine("File Exists: " + file);
            Console.WriteLine("Filename: " + file.FileName);
            return await LoadFileAsync(file.FileName, stream);
        }

        private static async Task<IFile> LoadFileAsync(string fileName, Stream stream) {
            if (fileName.EndsWith(".png", StringComparison.OrdinalIgnoreCase) ||
                fileName.EndsWith(".jpg", StringComparison.OrdinalIgnoreCase)) {
                using MemoryStream ms = new MemoryStream();
                await stream.CopyToAsync(ms);
                return new ImageFile { data = ms.ToArray(), name = fileName };
            }
            else if (fileName.EndsWith(".pdf", StringComparison.OrdinalIgnoreCase)) {
                using MemoryStream ms = new MemoryStream();
                await stream.CopyToAsync(ms);
                return new PDFFile { data = ms.ToArray(), name = fileName };
            }
            else if (fileName.EndsWith(".docx", StringComparison.OrdinalIgnoreCase)) {
                using MemoryStream ms = new MemoryStream();
                await stream.CopyToAsync(ms);
                return new WordFile { data = ms.ToArray(), name = fileName };
            }

            throw new NotSupportedException("Unsupported file type");
        }

    }
}

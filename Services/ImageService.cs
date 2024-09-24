namespace UserData.Services {
    public class ImageService {
        public static async Task<string> SaveImage(IFormFile? image) {
            var uploadPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "Images");
            if(!Directory.Exists(uploadPath)) {
                Directory.CreateDirectory(uploadPath);
            }
            var uniqueFileName = Guid.NewGuid().ToString() + Path.GetExtension(image.FileName);
            var filePath = Path.Combine(uploadPath, uniqueFileName);

            var fileStream = new FileStream(filePath, FileMode.Create);
            using(fileStream) {
                await image.CopyToAsync(fileStream);
            }

            return filePath;
        }

        public static void DeleteImage(string? filePath) {
            if(filePath != null) {
                File.Delete(filePath);
            }
        }
    }
}

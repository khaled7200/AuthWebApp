namespace AuthWebApplication.Helpers
{
    public  class ImageManager
    {
        private readonly IWebHostEnvironment hostEnvironment;

        public ImageManager(IWebHostEnvironment hostEnvironment)
        {
            this.hostEnvironment = hostEnvironment;
        }
        public  async Task<string> SavePhotoAsync(IFormFile imgFile, string ImgName)
        {

            try
            {
                var SavePath = hostEnvironment.WebRootPath + "/Images/";
                var id = Guid.NewGuid().ToString();
                var ImageName = ImgName + "  " + id + ".jpg";
                if (!Directory.Exists(SavePath))
                {
                    Directory.CreateDirectory(SavePath);
                }
                await System.IO.File.WriteAllBytesAsync(SavePath + ImageName,
                    new BinaryReader(imgFile.OpenReadStream()).ReadBytes((int)new BinaryReader(imgFile.OpenReadStream()).BaseStream.Length));
                return ImageName;
            }
            catch (Exception)
            {

                return "";
            }

        }
    }
}

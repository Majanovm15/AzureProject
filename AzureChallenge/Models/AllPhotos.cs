namespace AzureChallenge.Models
{
    public class AllPhotos
    {
        public List<string> PhotoURLs { get; set; } = new List<string>();

        public AllPhotos()
        {
        }

        public AllPhotos(List<PhotoData> photos)
        {

            foreach (var photo in photos)
            {
                PhotoURLs.Add(photo.URL);
            }
        }
    }
}

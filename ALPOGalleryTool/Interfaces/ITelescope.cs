using MongoDB.Bson;

namespace ALPOGalleryTool.Interfaces
{
    public interface ITelescope
    {
        int Aperture { get; set; }
        double FocalLength { get; set; }
        double FocalRatio { get; set; }
        ObjectId Id { get; set; }
        string Initials { get; set; }
        string Notes { get; set; }
        string ScopeType { get; set; }
    }
}
using DgmlApi;

namespace DGMLTransformer.Services.Dgml
{
    public interface IDgmlService
    {
        DgmlDoc GetFromFile(string filepath);
    }
}
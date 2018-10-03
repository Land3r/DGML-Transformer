using DgmlLib;
using DGMLTransformer.Domain;
using System.Collections.Generic;

namespace DGMLTransformer.Services.Dgml
{
    public interface IDgmlService
    {
        DgmlDoc GetFromFile(string filepath);
        DgmlDoc HideAllCategories(DgmlDoc doc);
        DgmlDoc HideCategory(DgmlDoc doc, DgmlCategory dgmlCategory);
        DgmlDoc HideCategories(DgmlDoc doc, IList<DgmlCategory> dgmlCategories);
        void SaveFile(DgmlDoc dgmlDoc);
        DgmlDoc ShowAllCategories(DgmlDoc doc);
        DgmlDoc ShowCategories(DgmlDoc doc, IList<DgmlCategory> dgmlCategories);
    }
}
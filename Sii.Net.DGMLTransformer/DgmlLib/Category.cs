using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using GeTools;


namespace DgmlApi
{
    public class Category
    {
        public string Id { get; set; }
        public string Label { get; set; }

        public static readonly string CATEGORY_ATTR_NAME = "Category";
        public static readonly string CATEGORY_ELEMENT_NAME = "Category";

        /// <summary>
        /// Depuis l'élément XML d'un objet du diagramme, obtenir l'élément Categrory pour la catégorie donnée.
        /// </summary>
        /// <param name="diagObjXElement">Element XML de l'objet du diagramme qui peut porter des catgéories. Ex: Node ou Link.</param>
        /// <param name="catId"></param>
        /// <returns></returns>
        internal static XElement GetCategorySubElement(XElement diagObjXElement, string catId)
        {
            return diagObjXElement.GetSingleElement(string.Format("./{0}[@Ref='{1}']", CATEGORY_ELEMENT_NAME, catId));
        }

        /// <summary>
        /// Depuis l'élément XML d'un objet du diagramme : est-ce que l'objet porte la catégorie donnée ?
        /// </summary>
        /// <param name="diagObjXElement">Element XML de l'objet du diagramme qui peut porter des catgéories. Ex: Node ou Link.</param>
        /// <param name="catId"></param>
        /// <returns></returns>
        public static bool HasCategory(XElement diagObjXElement, string catId)
        {
            // firstCatVal != null && firstCatVal.Equals(catId)
            var firstCatVal = diagObjXElement.GetSingleAttributeValueOrDefault(CATEGORY_ATTR_NAME, null);


            return (firstCatVal != null && firstCatVal.Equals(catId)) || (GetCategorySubElement(diagObjXElement, catId) != null);
        }
    }
}

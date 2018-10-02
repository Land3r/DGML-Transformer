using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using GeTools;

namespace DgmlLib
{
    public abstract class SingleElement
    {

        
        #region PROP : XmlElement
        /// <summary>
        /// Variable privée relative à XmlElement
        /// </summary>        
        private XElement _XmlElement;
        /// <summary>
        /// Element xml associé
        /// </summary>   
        public XElement XmlElement
        {
            get
            {
                return _XmlElement;
            }
            set
            {
                _XmlElement = value;
                OnXmlElementSet();
            }
        }
        #endregion

        protected virtual void OnXmlElementSet()
        {
            // par défaut on ne fait rien
        }
        
        /// <summary>
        /// Notifier l'élément qu'il a été intégré dans le document
        /// </summary>
        internal void NotifyOfDocIntegration()
        {
            OnIntegratedIntoDoc();
        }

        protected virtual void OnIntegratedIntoDoc()
        {

        }
        

        public SingleElement()
        {
            XmlElement = new XElement(GetXmlElementName());
        }

        protected abstract string GetXmlElementName();

        /// <summary>
        /// Ajouter une catégorie
        /// </summary>
        public void AddCategory(string categoryId)
        {
            // Maintenir les catégories du document ? Pas la peine de designer VS gère cela
            var catEls = XmlElement.GetElements("Category");
            XElement catEl = null;
            // la catégorie est elle déjà attribuée ?
            if (!EnumTools.IsNullOrEmpty(catEls))
                catEl = !EnumTools.IsNullOrEmpty(catEls) ? catEls.FirstOrDefault(c => c.GetSingleAttributeValueOrDefault(Category.CATEGORY_ATTR_NAME, string.Empty) == categoryId) : null;
            if (catEl == null)
            {
                var newCatEl = new XElement("Category");
                XmlElement.Add(newCatEl);
                newCatEl.SetAttributeValue("Ref", categoryId);
            }
        }
        
    }
}

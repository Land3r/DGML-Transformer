using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using GeTools;

namespace DgmlApi
{
    public class Node : LabeledElement
    {

        /// <summary>
        /// Compteur pour l'attribution des ID
        /// </summary>
        private static int _idCounter = 0;
        private static string _idAttribPrefix = DateTime.Now.ToString("yyMMddHHmmssff");

        #region PROP : Id
        /// <summary>
        /// Variable privée relative à Id
        /// </summary>        
        private string _Id;
        /// <summary>
        /// ID du noeud. Attention Id avec Aliases non résolu ! Contient donc les références aux alias éventuels.
        /// </summary>   
        public string Id
        {
            get
            {
                return _Id;
            }
            set
            {
                _Id = value;
                XmlElement.SetAttributeValue("Id", _Id);
            }
        }
        #endregion

        /// <summary>
        /// Obtenir un nouvel ID
        /// </summary>
        /// <returns></returns>
        private static string GetNewId()
        {
            _idCounter++;
            return string.Format("{0}_{1}", _idAttribPrefix, _idCounter.ToString());

        }







        internal static Node TechnicalFactory(XElement nodeXElement)
        {
            Node result = null;
            if (Category.HasCategory(nodeXElement, ClassNode.CLASS_CATEGORY_ID))
                result = new ClassNode();
            else
                result = new Node();

            result.InitFromXElement(nodeXElement);
            return result;
        }

        protected virtual void InitFromXElement(XElement nodeXElement)
        {
            XmlElement = nodeXElement;
        }

        public static Node GetNew(XElement nodeXelement)
        {
            var result = TechnicalFactory(nodeXelement);
            return result;
        }

        protected override void OnXmlElementSet()
        {
            base.OnXmlElementSet();
            if (XmlElement != null)
                _Id = XmlElement.GetSingleAttributeValueOrDefault("Id", null);
        }

        /// <summary>
        /// Instanciation
        /// </summary>
        /// <returns></returns>
        public static Node GetNew()
        {
            var result = new Node();
            result.Id = GetNewId();
            return result;
        }

        protected override string GetXmlElementName()
        {
            return "Node";
        }

        public override string ToString()
        {
            return string.Format("{0} >> {1}", Id, XmlElement != null ? XmlElement.ToString() : null);
        }




        
    }
}

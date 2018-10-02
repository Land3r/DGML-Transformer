using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using GeTools;

namespace DgmlLib
{
    public class Link : LabeledElement
    {
        public static readonly string SOURCE_ATTR_NAME = "Source";
        public static readonly string TARGET_ATTR_NAME = "Target";



        #region PROP : Source
        /// <summary>
        /// Variable privée relative à Source
        /// </summary>        
        private Node _Source;
        /// <summary>
        /// Noeud source
        /// </summary>   
        public Node Source
        {
            get
            {
                return _Source;
            }
            set
            {
                _Source = value;
                XmlElement.SetAttributeValue(SOURCE_ATTR_NAME, _Source.Id);
            }
        }
        #endregion

        #region PROP : Target
        /// <summary>
        /// Variable privée relative à Target
        /// </summary>        
        private Node _Target;
        /// <summary>
        /// Cible du lien
        /// </summary>   
        public Node Target
        {
            get
            {
                return _Target;
            }
            set
            {
                _Target = value;
                XmlElement.SetAttributeValue(TARGET_ATTR_NAME, _Target.Id);
            }
        }
        #endregion

        public override string ToString()
        {
            return string.Format("{2} | {0} --> {1}", Source != null ? string.Format("[{0}] {1}", Source.Id, Source.Label) : "NULL", Target != null ? string.Format("[{0}] {1}", Target.Id, Target.Label) : "NULL", Label);
        }
        
        
        

        //#region PROP : TargetNodeId
        ///// <summary>
        ///// Variable privée relative à TargetNodeId
        ///// </summary>        
        //private string _TargetNodeId;
        ///// <summary>
        ///// Id du noeud cible du lien
        ///// </summary>   
        //public string TargetNodeId
        //{
        //    get
        //    {
        //        return _TargetNodeId;
        //    }
        //    set
        //    {
        //        _TargetNodeId = value;
        //        XmlElement.SetAttributeValue("Target", _TargetNodeId);
        //    }
        //}
        //#endregion
        

        //#region PROP : SourceNodeId
        ///// <summary>
        ///// Variable privée relative à SourceNodeId
        ///// </summary>        
        //private string _SourceNodeId;
        ///// <summary>
        ///// Id du noeud source
        ///// </summary>   
        //public string SourceNodeId
        //{
        //    get
        //    {
        //        return _SourceNodeId;
        //    }
        //    set
        //    {
        //        _SourceNodeId = value;
        //        XmlElement.SetAttributeValue("Source", _TargetNodeId);
        //    }
        //}
        //#endregion
        

        protected override string GetXmlElementName()
        {
            return "Link";
        }



        public static Link GetNew(Node source, Node target)
        {
            var result = new Link();
            result.Source = source;
            result.Target = target;
            return result;
        }



        /// <summary>
        /// Instancier depuis l'élément XML et les nodes du document
        /// </summary>
        /// <param name="linkElement"></param>
        /// <param name="documentNodes"></param>
        /// <returns></returns>
        public static Link GetNewFromXmlEl(XElement linkElement, IEnumerable<Node> documentNodes)
        {
            var result = new Link();
            var srcId = linkElement.GetSingleAttributeValueOrDefault(SOURCE_ATTR_NAME, null);
            var trgId = linkElement.GetSingleAttributeValueOrDefault(TARGET_ATTR_NAME, null);
            
            if (srcId != null)
                result.Source = documentNodes.SingleOrDefault(n => n.Id == srcId);

            if (trgId != null)
                result.Target = documentNodes.SingleOrDefault(n => n.Id == trgId);

            result.Label = linkElement.GetSingleAttributeValueOrDefault("Label", null);

            return result;
        }




        
    }
}

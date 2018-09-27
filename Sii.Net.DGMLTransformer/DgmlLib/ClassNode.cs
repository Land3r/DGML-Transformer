using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using GeTools;

namespace DgmlApi
{
    public class ClassNode : Node
    {
        public static readonly string CLASS_CATEGORY_ID = "CodeSchema_Class";
        private static readonly string FULL_CLASS_NAME_EXTRACT_PATTERN = "(?<get>Namespace=.+ Type=.+\\))";
        private static readonly string SHORT_CLASS_NAME_EXTRACT_PATTERN = "Type=(?<get>.+)\\)";
        private static readonly string CLASS_NAMESPACE_EXTRACT_PATTERN = "Namespace=(?<get>.+) ";

        /// <summary>
        /// Exemple : FmGraph
        /// </summary>
        public string ClassShortName { get; set; }

        /// <summary>
        /// Namespace de la classe
        /// </summary>
        public string ClassNamespace { get; set; }

        /// <summary>
        /// Exemple : "Namespace=Bytel.PLN.Sources.Graph.Forms Type=FmGraph"
        /// </summary>
        public string FullClassName { get; set; }

        /// <summary>
        /// La classe a t elle été identifiée dans le noeud ?
        /// </summary>
        public bool ClassInfosAreComputed { get; set; }


        public override string ToString()
        {
            return string.Format("{0} {1} >> {2}", Id, ClassShortName, XmlElement != null ? XmlElement.ToString() : null);
        }

        public static IEnumerable<XElement> GetAllClassNodesElements(XDocument document)
        {
            var result = document.GetElements("//Nodes/Node").Where(e => Category.HasCategory(e, ClassNode.CLASS_CATEGORY_ID));

            // Première version
            if (result != null)
                return result.ToArray();

            return null;
        }

        protected override void InitFromXElement(XElement nodeXElement)
        {
            base.InitFromXElement(nodeXElement);
            ComputeClassInfosFromElementDoc();

            

            // Il faut calculer les infos de classe
            if (nodeXElement.Document == null)
                return;

            
        }

        protected override void OnIntegratedIntoDoc()
        {
            base.OnIntegratedIntoDoc();
            ComputeClassInfosFromElementDoc();
        }

        public void ComputeClassInfosFromElementDoc()
        {

            // Pour pouvoir calculer les infos de class on a besoin du doc
            if (XmlElement.Document == null)
                return;

            var idWithResolvedAliases = IdentifierAliases.ResolveIdAliases(XmlElement.Document, Id);
            FullClassName = idWithResolvedAliases.ExtractGetGroup(FULL_CLASS_NAME_EXTRACT_PATTERN);
            ClassShortName = idWithResolvedAliases.ExtractGetGroup(SHORT_CLASS_NAME_EXTRACT_PATTERN);
            ClassNamespace = idWithResolvedAliases.ExtractGetGroup(CLASS_NAMESPACE_EXTRACT_PATTERN);
            ClassInfosAreComputed = true;
        }



        public static IEnumerable<ClassNode> GetClassNodes(IEnumerable<Node> source, string classNamespace, string classShortName)
        {
            var r = source.OfType<ClassNode>().Where(n => n.ClassNamespace == classNamespace && n.ClassShortName == classShortName);
            if (!EnumTools.IsNullOrEmpty(r))
                return r.ToArray();
            else
                return null;
        }


        //public static ClassNode NewClassNode(System.Reflection.TypeInfo typeInfo)
        //{
        //    var classNodeEl = new XElement("Node");
        //    classNodeEl.SetAttributeValue("Id", null);
        //    classNodeEl.SetAttributeValue("Category", "CodeSchema_Class");
        //    classNodeEl.SetAttributeValue("CodeSchemaProperty_IsPublic", "True");
        //    classNodeEl.SetAttributeValue("CommonLabel", typeInfo.Name);
        //    classNodeEl.SetAttributeValue("Icon", "Microsoft.VisualStudio.Class.Public");
        //    classNodeEl.SetAttributeValue("Label", typeInfo.Name);       
        //}
        
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using GeTools;
using System.IO;


namespace DgmlLib
{
    /// <summary>
    /// Document DGML. Fournit les fonction utile pour la constitution d'un document DGML.
    /// </summary>
    public class DgmlDoc : ICloneable
    {
        public string LoadedFilePath { get; private set; }
        public string LastSavedFilePath { get; set; }
        
        #region PROP : Nodes
        /// <summary>
        /// Variable privée relative à Nodes
        /// </summary>        
        private List<Node> _Nodes = new List<Node>();
        /// <summary>
        /// Collection des nodes courant du document
        /// </summary>   
        public IEnumerable<Node> Nodes
        {
            get
            {
                return _Nodes;
            }
            set
            {
                _Nodes = value != null ? value.ToList() : null;
            }
        }
        #endregion
        
        #region PROP : Links
        /// <summary>
        /// Variable privée relative à Link
        /// </summary>        
        private List<Link> _Links = new List<Link>();
        /// <summary>
        /// Collection des Links
        /// </summary>
        public IEnumerable<Link> Links
        {
            get
            {
                return _Links;
            }
            set
            {
                _Links = value != null ? value.ToList() : null;
            }
        }
        #endregion

        private IList<Category> _categories = new List<Category>();
        public IList<Category> Categories
        {
            get { return _categories; }
        }

        private XDocument _xdoc = null;
        private XElement _nodesParentEl = null;
        private XElement _aliasParentEl = null;
        private XElement _LinksParentEl = null;

        /// <summary>
        /// Compteur pour attribution de nouveaux alias
        /// </summary>
        private int _aliasCounter = 1000;

        /// <summary>
        /// Path Id="adff5a07-75ca-4654-84f5-bfdc5d44298e.OutputPathUri" Value="file:///P:/SVN_IOR_ECO/PLN/PLN/bin/Debug/PLN.exe"
        /// </summary>
        private string _assOutputPathUriId = null;

        /// <summary>
        /// Initialiser la prise en charge du document
        /// </summary>
        private void InitDocHandling()
        {
            // On veut travailler HORS namespace par défaut
            // Pour cela on charge le doc à partir du texte dont on aura supprimé la chaine xmlns="http://schemas.microsoft.com/vs/2009/dgml"

            var initialContent = File.ReadAllText(LoadedFilePath);
            initialContent = initialContent.Replace("xmlns=\"http://schemas.microsoft.com/vs/2009/dgml\"", string.Empty);
            _xdoc = XDocument.Parse(initialContent);

            _aliasParentEl = _xdoc.GetSingleElement("//IdentifierAliases");
            _nodesParentEl = _xdoc.GetSingleElement("//Nodes");
            _LinksParentEl = _xdoc.GetSingleElement("//Links");

            var categoriesElement = (_xdoc.GetSingleElement("//Categories").Nodes());
            foreach (XNode categorieNode in categoriesElement)
            {
                XElement categorieElement = (XElement)categorieNode;
                string categoryId = categorieElement.Attribute("Id")?.Value;
                string categoryLabel = categorieElement.Attribute("Label")?.Value;
                Category category = new Category() { Id = categoryId, Label = !string.IsNullOrEmpty(categoryLabel) ? categoryLabel : categoryId };
                this._categories.Add<Category>(category);
            }

            Nodes = _nodesParentEl.GetElements("./Node").Select(e => Node.GetNew(e)).ToArray();
            Links = _LinksParentEl.GetElements("./Link").Select(e => Link.GetNewFromXmlEl(e, Nodes));

            InitAliasCounter();

            
            
            #region Cette partie est ignorée pour le moment, on s'appuie sur un argument requis pour connaitre le Path/@Id
            // Sélectionner l'Id du Path <Path Id="adff5a07-75ca-4654-84f5-bfdc5d44298e.OutputPathUri" Value="file:///P:/SVN_IOR_ECO/PLN/PLN/bin/Debug/PLN.exe" />
            // cad le path dont l'id contient OutputPathUri
            // var pathesEls = _xdoc.GetElements("//Paths/Path");
            //_assOutputPathUriId = _xdoc.GetElements("//Paths/Path"); 
            #endregion


        }

        public void HideAllCategories()
        {
            var categoriesElement = _xdoc.GetSingleElement("//Categories").Nodes();
            foreach (XNode categorieNode in categoriesElement)
            {
                XElement categorieElement = (XElement)categorieNode;
                this.HideCategory(categorieElement);
            }
        }

        public void HideCategory(Category category)
        {
            var categoriesElement = _xdoc.GetSingleElement("//Categories").Nodes();
            XElement categorieElement = null;
            foreach (XNode categorieNode in categoriesElement)
            {
                categorieElement = (XElement)categorieNode;
                if (categorieElement.Attribute("Id")?.Value == category.Id)
                {
                    break;
                }
            }
            this.HideCategory(categorieElement);
        }

        public void HideCategory(XElement category)
        {
            if (!string.IsNullOrEmpty(category.Attribute("Visibility")?.Value))
            {
                category.Attribute("Visibility").SetValue("Collapsed");
            }
            else
            {
                category.Add(new XAttribute("Visibility", "Collapsed"));
            }
        }

        public void ShowAllCategories()
        {
            var categoriesElement = _xdoc.GetSingleElement("//Categories").Nodes();
            foreach (XNode categorieNode in categoriesElement)
            {
                XElement categorieElement = (XElement)categorieNode;
                this.ShowCategory(categorieElement);
            }
        }

        public void ShowCategories(IList<Category> categories)
        {
            foreach (Category category in categories)
            {
                this.ShowCategory(category);
            }
        }

        public void ShowCategory(Category category)
        {
            var categoriesElement = _xdoc.GetSingleElement("//Categories").Nodes();
            XElement categorieElement = null;
            foreach (XNode categorieNode in categoriesElement)
            {
                categorieElement = (XElement)categorieNode;
                if (categorieElement.Attribute("Id")?.Value == category.Id)
                {
                    break;
                }
            }
            this.ShowCategory(categorieElement);
        }

        public void ShowCategory(XElement category)
        {
            if (!string.IsNullOrEmpty(category.Attribute("Visibility")?.Value))
            {
                category.Attribute("Visibility").SetValue("Visible");
            }
            else
            {
                category.Add(new XAttribute("Visibility", "Visible"));
            }
        }

        public static DgmlDoc GetFromFile(string filePath)
        {
            var newDoc = new DgmlDoc();
            newDoc.LoadFromFile(filePath);
            return newDoc;
        }


        public void LoadFromFile(string filePath)
        {
            this.LoadedFilePath = filePath;
            this.InitDocHandling();
        }
        
        public void Backup(string filePath = null)
        {
            string backupFolderPath, backupFilePath;
            if (string.IsNullOrWhiteSpace(filePath))
            {
                IList<string> filePaths = LoadedFilePath.Split('\\');
                string fileName = filePaths.LastOrDefault();
                backupFolderPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "DgmlBackups");
                backupFilePath =  Path.Combine(backupFolderPath, fileName);
            }
            else
            {
                IList<string> filePaths = filePath.Split('\\');
                string fileName = filePaths.LastOrDefault();
                filePaths = filePaths.Take(filePaths.Count() - 1).ToArray();
                backupFolderPath = string.Join("\\", filePaths);
                backupFilePath = Path.Combine(backupFolderPath, fileName);
            }

            if (!Directory.Exists(backupFolderPath))
            {
                Directory.CreateDirectory(backupFolderPath);
            }
            backupFilePath = this.GetNextFileAvailable(backupFilePath);

            XDocument docToSave = XDocument.Parse(_xdoc.ToString().Replace("<DirectedGraph ", "<DirectedGraph xmlns=\"http://schemas.microsoft.com/vs/2009/dgml\" "));
            docToSave.Save(backupFilePath);
        }

        private string GetNextFileAvailable(string filePath)
        {
            int i = 0;
            bool availabilityFound = false;
            string nextFileAvailable = string.Empty;

            IList<string> filePaths = filePath.Split('.');
            string ext = filePaths.LastOrDefault();

            filePaths = filePaths.Take(filePaths.Count() - 1).ToArray();
            string fileBasePath = string.Join(string.Empty, filePaths);
            do
            {
                string fileAttempt = string.Format("{0}-{1}.{2}", fileBasePath, i, ext);
                if (File.Exists(fileAttempt))
                {
                    i++;
                }
                else
                {
                    nextFileAvailable = fileAttempt;
                    availabilityFound = true;
                }
            }
            while (!availabilityFound);
            return nextFileAvailable;
        }

        public void Save(string filePath = null)
        {
            if (string.IsNullOrWhiteSpace(filePath))
                filePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), string.Format("FromDgmlDocApi_{0:yyMMdd_HHmmss}.dgml", DateTime.Now));

            LastSavedFilePath = filePath;

            
            // _xdoc.Root.SetAttributeValue("xmlns", "http://schemas.microsoft.com/vs/2009/dgml");


            // File.WriteAllText(filePath, _xdoc.ToString().Replace("<DirectedGraph ", "<DirectedGraph xmlns=\"http://schemas.microsoft.com/vs/2009/dgml\" "), Encoding.UTF8);
            var docToSave = XDocument.Parse(_xdoc.ToString().Replace("<DirectedGraph ", "<DirectedGraph xmlns=\"http://schemas.microsoft.com/vs/2009/dgml\" "));
            docToSave.Save(filePath);
        }
        
        public void SaveOnCurrentFile(bool backup = false)
        {
            if (backup == false)
            {
                this.Save(LoadedFilePath);
            }
            else
            {
                this.Backup();
                this.Save(LoadedFilePath);
            }
        }


        /// <summary>
        /// initialiser _aliasCounter en fonction des alias attribués
        /// </summary>
        private void InitAliasCounter()
        {
            var aliasesEls = _aliasParentEl.GetElements("Alias");
            _aliasCounter = aliasesEls.Max(a => int.Parse(a.GetSingleAttributeValueOrDefault("n", "0")));
        }


        public Node AddGenericNode(string label, string id = null)
        {
            
            var newNode = Node.GetNew();            
            newNode.Label = label;
            if (!string.IsNullOrWhiteSpace(id))
                newNode.Id = id;

            InsertNodeToDoc(newNode);

            return newNode;
        }


        public Link AddLink(Node srcNode, Node trgNode, string label = null)
        {
            var newLink = Link.GetNew(srcNode, trgNode);
            _LinksParentEl.Add(newLink.XmlElement);
            newLink.Label = label;
            _Links.Add(newLink);
            return newLink;
        }
        
        

        /// <summary>
        /// Ajouter un noeud de type class et retourne l'élément XElement
        /// </summary>
        /// <param name="dgmlAssemblyPathIdToUse">Id de l'élément Path à utiliser pour intégrer la classe</param>
        public ClassNode AddClassNode(TypeInfo classType, string dgmlAssemblyPathIdToUse)
        {

            // Pour écrire un node class, il faut pouvoir intégrer la référence au type, cela passe par l'exploitation d'un alias dédié
            // <Node Id="@9" Category="CodeSchema_Class" Bounds="494.253697293933,320.92098054479,114.416666666667,26" CodeSchemaProperty_IsPublic="True" CommonLabel="GET_SIT" Icon="Microsoft.VisualStudio.Class.Public" Label="GET_SIT *ensc" />
            // Pour pouvoir déterminer l'alias du type pour la classe à intégrer il faut exploiter un alias de la forme suivante : 
            // <Alias n="9" Id="(@1 Namespace=Bytel.PLN.Sources.Graph.DefBDD Type=GET_SIT)" />
            // qui lui même exploite un autre alias @1 : 
            // <Alias n="1" Uri="Assembly=$(adff5a07-75ca-4654-84f5-bfdc5d44298e.OutputPathUri)" />
            // Dans ce dernier alias on exploite l'id d'un path dédié à l'assembly
            // <Path Id="adff5a07-75ca-4654-84f5-bfdc5d44298e.OutputPathUri" Value="file:///P:/SVN_IOR_ECO/PLN/PLN/bin/Debug/PLN.exe" />

            // Pour définir le Path/@Id on le demande en arg


            var classId = GetDgmlTypeId(classType);
            var aliasEls = _xdoc.GetElements("//Alias");

            // Rechercher l'alias dédié à l'assembly du type de la classe
            var assemblyAliasEl = aliasEls.First(a => a.GetSingleAttributeValueOrDefault("Uri", string.Empty).Contains(dgmlAssemblyPathIdToUse));
            if(assemblyAliasEl == null)
            {
                assemblyAliasEl = new XElement("Alias"); //.Parse("<Alias n=\"666\" Uri=\"Assembly=$()\" />");
                assemblyAliasEl.SetAttributeValue("n", GetNewAliasNumber());
                assemblyAliasEl.SetAttributeValue("Uri", string.Format("Assembly=$({0})", dgmlAssemblyPathIdToUse));
                _aliasParentEl.Add(assemblyAliasEl);
            }
            var assemblyAliasId = int.Parse(assemblyAliasEl.GetSingleAttributeValueOrDefault("n", ""));

            // Rechercher l'existence de l'alias dédié au type de la classe
            var classAliasId = string.Format("(@{0} {1})", assemblyAliasId, classId);
            var aliasEl = aliasEls.FirstOrDefault(e => e.GetSingleAttributeValueOrDefault("Id", string.Empty).Equals(classAliasId));
            if (aliasEl == null)
            {
                aliasEl = new XElement("Alias");
                _aliasParentEl.Add(aliasEl);                
                aliasEl.SetAttributeValue("n", GetNewAliasNumber());
                aliasEl.SetAttributeValue("Id", classAliasId);
            }

            // Le numéro d'alias 
            var classAliasNumber = aliasEl.GetSingleAttributeValueOrDefault("n", null);
            var nodeId = string.Format("@{0}", classAliasNumber);
            var sameIdNode = GetNode(nodeId);
            var classNode = sameIdNode as ClassNode;

            if (classNode == null && sameIdNode != null)
                throw new Exception("Cas non supporté : on a trouvé un noeud avec l'id " + nodeId + " qui devrait être un noeud de type ClassNode et qui n'en est pas un !");


            if(classNode == null)
            {
                var classNodeEl = new XElement("Node");
                classNodeEl.SetAttributeValue("Id", nodeId);
                classNodeEl.SetAttributeValue("Category", "CodeSchema_Class");
                classNodeEl.SetAttributeValue("CodeSchemaProperty_IsPublic", "True");
                classNodeEl.SetAttributeValue("CommonLabel", classType.Name);
                classNodeEl.SetAttributeValue("Icon", "Microsoft.VisualStudio.Class.Public");
                classNodeEl.SetAttributeValue("Label", classType.Name);
                classNode = (ClassNode)Node.GetNew(classNodeEl);
                InsertNodeToDoc(classNode);                
            }


            //// Le noeud existe-t-il déjà ?
            //var classNodeEl = GetNodeXElById(classAliasNumber);
            //if(classNodeEl == null)
            //{
            //    classNodeEl = new XElement("Node");
            //    classNodeEl.SetAttributeValue("Id", nodeId);
            //    classNodeEl.SetAttributeValue("Category", "CodeSchema_Class");
            //    classNodeEl.SetAttributeValue("CodeSchemaProperty_IsPublic", "True");
            //    classNodeEl.SetAttributeValue("CommonLabel", classType.Name);
            //    classNodeEl.SetAttributeValue("Icon", "Microsoft.VisualStudio.Class.Public");
            //    classNodeEl.SetAttributeValue("Label", classType.Name);                
            //}

            //var newNode = (ClassNode)Node.GetNew(classNodeEl);
            //InsertNodeToDoc(newNode);

            return classNode;

        }

        /// <summary>
        /// Ajouter un noeud au document
        /// </summary>
        /// <param name="nodeToAdd"></param>
        public void InsertNodeToDoc(Node nodeToAdd)
        {

            // On ajoute au noeud parent seulement si l'élément XML n'a pas encore de parent
            if (nodeToAdd.XmlElement.Parent == null)
            {
                _nodesParentEl.Add(nodeToAdd.XmlElement);
                _Nodes.AddIfNotAdded(nodeToAdd);
                nodeToAdd.NotifyOfDocIntegration();
            }
            
        }
        


        private int GetNewAliasNumber()
        {
            _aliasCounter++;
            return _aliasCounter;
        }
        

        /// <summary>
        /// Calculer la chaine d'identifiant du type dans le DGML. Exemple : "Namespace=Bytel.PLN.Sources.Graph.DefBDD Type=GET_ANT"
        /// </summary>
        /// <returns></returns>
        private string GetDgmlTypeId(TypeInfo classType)
        {
            return string.Format("Namespace={0} Type={1}", classType.Namespace, classType.Name);
        }



        /// <summary>
        /// Obtention du node par Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Node GetNode(string id)
        {
            // Rechercher dans les noeuds chargés 
            var node = _Nodes.SingleOrDefault(n => n.Id == id);
            if (node != null)
                return node;

            var xEl = GetNodeXElById(id);
            if(xEl != null)
            {
                node = Node.GetNew(xEl);
                _Nodes.Add(node);
                return node;
            }

            return null;
        }


        
        

        /// <summary>
        /// Obtention des nodes de type "class" depuis le nom court de la classe.
        /// </summary>
        /// <param name="shortClassName"></param>
        /// <returns></returns>
        public IEnumerable<ClassNode> GetClassNodesByShortClassName(string shortClassName)
        {

            if (!EnumTools.IsNullOrEmpty(Nodes))
                return Nodes.OfType<ClassNode>().Where(cn => cn.ClassShortName == shortClassName);

            //var allClassElements = ClassNode.GetAllClassNodesElements(_xdoc);
            //if(!EnumTools.IsNullOrEmpty(allClassElements))
            //{

            //    var stringToSearch = string.Format("Type={0})", shortClassName);
            //    var result = allClassElements.Where(e => e.GetSingleAttributeValueOrDefault("Id", string.Empty).Contains(stringToSearch));

            //    if (!EnumTools.IsNullOrEmpty(result))
            //        return result.ToArray();
            //}

            return null;

        }


        public IEnumerable<ClassNode> GetClassNode(string classNamespace, string classShortName)
        {
            return ClassNode.GetClassNodes(this.Nodes, classNamespace, classShortName);
        }
        


        private XElement GetNodeXElById(string id)
        {
            return _nodesParentEl.GetSingleElement(string.Format("./Node[@Id='@{0}']", id));
        }


        /// <summary>
        /// Rechercher les nodes ascendants
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Node> GetAscendantNodes(Node node)
        {

            // On exploite les link dont le node est la cible
            if (Links.IsNullOrEmpty())
                return null;

            return Links.Where(l => l.Target == node).Select(l => l.Source).ToArray();

        }

        public override string ToString()
        {
            return _xdoc.ToString().Replace("<DirectedGraph ", "<DirectedGraph xmlns=\"http://schemas.microsoft.com/vs/2009/dgml\" ");
        }

        public override bool Equals(object obj)
        {
            if (obj is DgmlDoc)
            {
                DgmlDoc dgmlObj = (DgmlDoc)obj;
                return this.ToString().Equals(dgmlObj.ToString());
            }
            else
            {
                return base.Equals(obj);
            }
        }

        public object Clone()
        {
            return (DgmlDoc)this.MemberwiseClone();
        }
    }
}

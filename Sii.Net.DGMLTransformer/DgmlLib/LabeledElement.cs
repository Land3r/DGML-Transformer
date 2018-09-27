using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GeTools;

namespace DgmlApi
{
    public abstract class LabeledElement : SingleElement
    {
        #region PROP : Label
        /// <summary>
        /// Variable privée relative à Label
        /// </summary>        
        private string _Label;
        /// <summary>
        /// Label
        /// </summary>   
        public string Label
        {
            get
            {
                return _Label;
            }
            set
            {
                _Label = value;
                XmlElement.SetAttributeValue("Label", _Label);
            }
        }
        #endregion

        protected override void OnXmlElementSet()
        {
            base.OnXmlElementSet();

            if (XmlElement != null)
                Label = XmlElement.GetSingleAttributeValueOrDefault("Label", null);

        }

        /// <summary>
        /// Ajouter le tag au label.
        /// </summary>
        /// <param name="tag">Le nom du tag, sans les caractères d'intégration, seulement le nom.</param>
        public void AddTagOnLabel(string tag)
        {
            if (string.IsNullOrWhiteSpace(tag)) return;
            
            if (!HasTagOnLabel(tag))
            {
                var tagString = GetTagString(tag);

                if (Label == null)
                    Label = string.Empty;
                Label = string.Format("{0} {1}", Label, tagString).Trim();
            }
        }

        /// <summary>
        /// Supprimer le tag donné
        /// </summary>
        /// <param name="tag"></param>
        public void RemoveTag(string tag)
        {
            var tg = GetTagString(tag);
            Label = Label.Replace(tg, string.Empty).TrimOrNull();
        }
        

        /// <summary>
        /// 
        /// </summary>
        /// <param name="tag">Le nom du tag, sans les caractères d'intégration, seulement le nom.</param>
        /// <returns></returns>
        private string GetTagString(string tag)
        {
            return string.Format("*{0}", tag);
        }


        public IEnumerable<string> GetAllTagsOnLabel()
        {
            if (string.IsNullOrWhiteSpace(Label))
                return null;

            var tags = Label.ExtractGetGroups("\\*(?<get>[a-zA-Z0-9]+)");
            return tags;
        }



        /// <summary>
        /// Assigner le label mais en préservant les tags
        /// </summary>
        public void SetLabelWithTagsPreservation(string newLabel)
        {
            var tags = GetAllTagsOnLabel();
            Label = newLabel;

            if (!EnumTools.IsNullOrEmpty(tags))
                foreach (var tag in tags)
                    AddTagOnLabel(tag);
        
        }
        
        

        /// <summary>
        /// a t il le tag sur le libellé ?
        /// </summary>
        /// <returns></returns>
        public bool HasTagOnLabel(string tagName)
        {
            var tagString = GetTagString(tagName);
            return Label != null && Label.Contains(tagString);

        }
        

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using GeTools;
using System.Text.RegularExpressions;

namespace DgmlApi
{
    public class IdentifierAliases
    {


        private static string AliasRefNumberExtractPattern = "@(?<get>\\d+)";
        public static readonly string ALIAS_NUMBER_ATTR_NAME = "n";

        /// <summary>
        /// Résoudre les aliases qui peuvent appraitre dans la chaine grâce au document [RECURSIF]
        /// </summary>
        /// <param name="doc"></param>
        /// <param name="inputString"></param>
        public static string ResolveIdAliases(XDocument doc, string inputString)
        {
            if (string.IsNullOrWhiteSpace(inputString))
                return null;

            // Des Alias sont ils présents dans la chaine ? 
            // Les références aux alias sont de la forme "@\d"            
            var inputStrAliasesRefs = inputString.ExtractGetGroups(AliasRefNumberExtractPattern);
            if (!EnumTools.IsNullOrEmpty(inputStrAliasesRefs))
            {
                inputStrAliasesRefs = inputStrAliasesRefs.Distinct();

                // Charger les XmlElements correspondant, si ils n'existent pas alors ignorer les références
                var aliasEls = doc.GetElements("//IdentifierAliases/Alias");

                var resolveCounter = 0;

                if (!EnumTools.IsNullOrEmpty(aliasEls))
                {
                    
                    foreach (var aliasRef in inputStrAliasesRefs)
                    {
                        // L'alias existe t il ?
                        var matchingAlias = aliasEls.SingleOrDefault(e => e.GetSingleAttributeValueOrDefault(ALIAS_NUMBER_ATTR_NAME, null) == aliasRef);
                        if (matchingAlias != null)
                        {
                            resolveCounter++;
                            inputString = inputString.Replace(string.Format("@{0}", aliasRef), matchingAlias.GetSingleAttributeValueOrDefault("Id", matchingAlias.GetSingleAttributeValueOrDefault("Uri", string.Empty)));
                        }
                            
                    }
                }

                // Après avoir résolu les alias, il peut rester les alias intégré par les alias résolu, il faut exécuter une nouvelle fois la même résolution
                if(resolveCounter > 0)
                    return ResolveIdAliases(doc, inputString);
            }
            
                return inputString;


        }
        
    }
}

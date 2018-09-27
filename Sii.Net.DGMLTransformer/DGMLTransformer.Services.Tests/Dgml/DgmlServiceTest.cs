namespace DGMLTransformer.Services.Tests.Dgml
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Xml;
    using DGMLTransformer.Services.Dgml;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class DgmlServiceTest
    {
        public static IEnumerable<string> DgmlExamplesFilepath { get; private set; } 
        
        [TestInitialize]
        public void Initialize()
        {
            DgmlExamplesFilepath = new List<string>()
            {
                "./Dgml/Examples/FonctionalGraphPerso.dgml"
            };
        }

        [TestMethod]
        public void DgmlService_GetFromFile_LoadExamplesShouldWork()
        {
            foreach (string example in DgmlExamplesFilepath)
            {
                DgmlService service = new DgmlService();
                Assert.IsNotNull(service.GetFromFile(example));
            }
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void DgmlService_GetFromFile_LoadEmptyShouldNotWork()
        {
            DgmlService service = new DgmlService();
            // It should throw an exception.
            service.GetFromFile(string.Empty);
        }

        [TestMethod]
        [ExpectedException(typeof(FileNotFoundException))]
        public void DgmlService_GetFromFile_LoadInvalidShouldNotWork()
        {
            DgmlService service = new DgmlService();
            // It should throw an exception.
            service.GetFromFile("non existing file");
        }

        [TestMethod]
        [ExpectedException(typeof(XmlException))]
        public void DgmlService_GetFromFile_LoadNonDgmlFileShouldNotWork()
        {
            DgmlService service = new DgmlService();
            // It should throw an exception.
            service.GetFromFile("./Dgml/Examples/SampleFile.txt");
        }
    }
}

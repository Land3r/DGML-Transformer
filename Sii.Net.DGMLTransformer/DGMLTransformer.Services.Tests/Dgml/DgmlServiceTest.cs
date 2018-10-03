namespace DGMLTransformer.Services.Tests.Dgml
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Xml;
    using DgmlLib;
    using DGMLTransformer.Services.Dgml;
    using DGMLTransformer.Transversal.Extensions;
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

        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        public void DgmlService_SaveFile_SaveNullShouldNotWork()
        {
            DgmlService service = new DgmlService();
            service.SaveFile(null);
        }

        [TestMethod]
        public void DgmlService_SaveFile_NoChangesOnDgmlFileShouldWork()
        {
            DgmlService service = new DgmlService();
            IEnumerator<string> exampleDgmlPathEnumerator = DgmlExamplesFilepath.GetEnumerator();
            exampleDgmlPathEnumerator.MoveNext();
            DgmlDoc doc = service.GetFromFile(exampleDgmlPathEnumerator.Current);
            service.SaveFile(doc);

            DgmlDoc docReopened = service.GetFromFile(exampleDgmlPathEnumerator.Current);
            Assert.AreEqual<DgmlDoc>(doc, docReopened);
        }

        [TestMethod]
        public void DgmlService_SaveFile_ShouldUpdateFileModifiedTime()
        {
            DgmlService service = new DgmlService();
            IEnumerator<string> exampleDgmlPathEnumerator = DgmlExamplesFilepath.GetEnumerator();
            exampleDgmlPathEnumerator.MoveNext();
            DateTime originalModifiedFileDateTime = File.GetLastWriteTimeUtc(exampleDgmlPathEnumerator.Current);
            DgmlDoc doc = service.GetFromFile(exampleDgmlPathEnumerator.Current);
            service.SaveFile(doc);

            DateTime updatedModifiedFileDateTime = File.GetLastWriteTimeUtc(exampleDgmlPathEnumerator.Current);
            Assert.IsTrue(updatedModifiedFileDateTime - originalModifiedFileDateTime > TimeSpan.MinValue);
        }

        [TestMethod]
        public void DgmlService_ShowAllCategories_SimulateChangesShouldWork()
        {
            DgmlService service = new DgmlService();
            IEnumerator<string> exampleDgmlPathEnumerator = DgmlExamplesFilepath.GetEnumerator();
            exampleDgmlPathEnumerator.MoveNext();
            DgmlDoc doc = service.GetFromFile(exampleDgmlPathEnumerator.Current);
            DgmlDoc originalDoc = (DgmlDoc)doc.Clone();
            doc.ShowAllCategories();
            originalDoc.HideAllCategories();
            originalDoc.ShowAllCategories();

            Assert.AreEqual<DgmlDoc>(doc, originalDoc);
        }

        [TestMethod]
        public void DgmlService_HideAllCategories_SimulateChangesShouldWork()
        {
            DgmlService service = new DgmlService();
            IEnumerator<string> exampleDgmlPathEnumerator = DgmlExamplesFilepath.GetEnumerator();
            exampleDgmlPathEnumerator.MoveNext();
            DgmlDoc doc = service.GetFromFile(exampleDgmlPathEnumerator.Current);
            DgmlDoc originalDoc = (DgmlDoc)doc.Clone();
            doc.HideAllCategories();
            originalDoc.ShowAllCategories();
            originalDoc.HideAllCategories();

            Assert.AreEqual<DgmlDoc>(doc, originalDoc);
        }
    }
}

namespace DGMLTransformer.Services.Tests.Dgml
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Xml;
    using DgmlLib;
    using DGMLTransformer.Domain;
    using DGMLTransformer.Services.Dgml;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System.Linq;

    [TestClass]
    public class DgmlServiceTest
    {
        private static Random random = new Random();

        private static IEnumerable<string> DgmlExamplesFilepath { get; set; } 
        
        [TestInitialize]
        public void Initialize()
        {
            DgmlExamplesFilepath = new List<string>()
            {
                "./Dgml/Examples/FonctionalGraphPerso.dgml",
                "./Dgml/Examples/FromDgmlDocApi_181002_150237.dgml"
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
            while (exampleDgmlPathEnumerator.MoveNext())
            {
                DgmlDoc doc = service.GetFromFile(exampleDgmlPathEnumerator.Current);
                service.SaveFile(doc);

                DgmlDoc docReopened = service.GetFromFile(exampleDgmlPathEnumerator.Current);
                Assert.AreEqual<DgmlDoc>(doc, docReopened);
            }
        }

        [TestMethod]
        public void DgmlService_SaveFile_ShouldUpdateFileModifiedTime()
        {
            DgmlService service = new DgmlService();
            IEnumerator<string> exampleDgmlPathEnumerator = DgmlExamplesFilepath.GetEnumerator();
            while (exampleDgmlPathEnumerator.MoveNext())
            {
                DateTime originalModifiedFileDateTime = File.GetLastWriteTimeUtc(exampleDgmlPathEnumerator.Current);
                DgmlDoc doc = service.GetFromFile(exampleDgmlPathEnumerator.Current);
                service.SaveFile(doc);

                DateTime updatedModifiedFileDateTime = File.GetLastWriteTimeUtc(exampleDgmlPathEnumerator.Current);
                Assert.IsTrue(updatedModifiedFileDateTime - originalModifiedFileDateTime > TimeSpan.MinValue);
            }
        }

        [TestMethod]
        public void DgmlService_ShowAllCategories_SimulateChangesShouldWork()
        {
            DgmlService service = new DgmlService();
            IEnumerator<string> exampleDgmlPathEnumerator = DgmlExamplesFilepath.GetEnumerator();
            while (exampleDgmlPathEnumerator.MoveNext())
            {
                DgmlDoc doc = service.GetFromFile(exampleDgmlPathEnumerator.Current);
                DgmlDoc originalDoc = (DgmlDoc)doc.Clone();

                service.ShowAllCategories(doc);
                service.HideAllCategories(originalDoc);
                service.ShowAllCategories(originalDoc);

                Assert.AreEqual<DgmlDoc>(doc, originalDoc);
            }
        }

        [TestMethod]
        public void DgmlService_HideAllCategories_SimulateChangesShouldWork()
        {
            DgmlService service = new DgmlService();
            IEnumerator<string> exampleDgmlPathEnumerator = DgmlExamplesFilepath.GetEnumerator();
            while (exampleDgmlPathEnumerator.MoveNext())
            {
                DgmlDoc doc = service.GetFromFile(exampleDgmlPathEnumerator.Current);
                DgmlDoc originalDoc = (DgmlDoc)doc.Clone();

                service.HideAllCategories(doc);
                service.ShowAllCategories(originalDoc);
                service.HideAllCategories(originalDoc);

                Assert.AreEqual<DgmlDoc>(doc, originalDoc);
            }
        }

        [TestMethod]
        public void DgmlService_HideCategories_SimulateAllChangesShouldWork()
        {
            DgmlService service = new DgmlService();
            IEnumerator<string> exampleDgmlPathEnumerator = DgmlExamplesFilepath.GetEnumerator();
            while (exampleDgmlPathEnumerator.MoveNext())
            {
                DgmlDoc doc = service.GetFromFile(exampleDgmlPathEnumerator.Current);
                DgmlDoc originalDoc = (DgmlDoc)doc.Clone();

                IList<DgmlCategory> dgmlCategories = doc.Categories.Select(p => new DgmlCategory() { Id = p.Id, Label = p.Label }).ToList();
                service.HideAllCategories(doc);
                service.HideCategories(originalDoc, dgmlCategories);

                Assert.AreEqual<DgmlDoc>(doc, originalDoc);
            }
        }

        [TestMethod]
        public void DgmlService_HideCategory_SimulateChangesShouldWork()
        {
            DgmlService service = new DgmlService();
            IEnumerator<string> exampleDgmlPathEnumerator = DgmlExamplesFilepath.GetEnumerator();
            while (exampleDgmlPathEnumerator.MoveNext())
            {
                DgmlDoc doc = service.GetFromFile(exampleDgmlPathEnumerator.Current);
                DgmlDoc originalDoc = (DgmlDoc)doc.Clone();

                IList<DgmlCategory> dgmlCategories = doc.Categories.Select(p => new DgmlCategory() { Id = p.Id, Label = p.Label }).ToList();
                service.HideAllCategories(doc);
                service.HideCategories(originalDoc, dgmlCategories);

                Assert.AreEqual<DgmlDoc>(doc, originalDoc);
            }
        }

        [TestMethod]
        public void DgmlService_HideCategories_SimulateChangesShouldWork()
        {
            DgmlService service = new DgmlService();
            IEnumerator<string> exampleDgmlPathEnumerator = DgmlExamplesFilepath.GetEnumerator();
            while (exampleDgmlPathEnumerator.MoveNext())
            {
                DgmlDoc doc = service.GetFromFile(exampleDgmlPathEnumerator.Current);
                DgmlDoc originalDoc = (DgmlDoc)doc.Clone();

                IList<DgmlCategory> dgmlCategories = doc.Categories.Select(p => new DgmlCategory() { Id = p.Id, Label = p.Label }).ToList();
                int categoryIndex = random.Next(dgmlCategories.Count);
                
                service.HideCategory(doc, dgmlCategories[categoryIndex]);
                Assert.AreEqual<DgmlDoc>(doc, originalDoc);
            }
        }
    }
}

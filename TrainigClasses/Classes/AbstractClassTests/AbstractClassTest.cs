using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using AbstractClass;
using System.Xml;

namespace AbstractClassTests
{
    [TestClass]
    public class AbstractClassTest
    {
        // Color values for in
        private Color[] colors1 = new Color[2] { new Color(0, 0, 185), new Color(23, 45, 45) };
        private Color[] colors2 = new Color[3] { new Color(0, 0, 185), new Color(23, 45, 45), new Color(145, 245, 245) };
        private Color[] colors3 = new Color[4] { new Color(0, 0, 185), new Color(23, 45, 45), new Color(13, 35, 35), new Color(223, 145, 145) };

        /// <summary>
        /// Testing ReWrite(Color[])
        /// </summary>
        [TestMethod]
        public void ReWriteTest_InColor2_OutColor2NewDateTime()
        {
            Picture picture = new Picture();

            // Default values
            Color[] previousColors = picture.Colors;
            DateTime previousTime = picture.Creation;

            picture.ReWrite(colors1);

            // Check chenging
            Assert.AreNotEqual(previousColors, picture.Colors);
            Assert.AreNotEqual(previousTime, picture.Creation);
            Assert.AreEqual(colors1, picture.Colors);
        }
        /// <summary>
        /// Testing ReWrite(uint height, uint width)
        /// </summary>
        [TestMethod]
        public void ReWriteTest_InHeight500Width250_OutHeight500Width250NewDataTime()
        {
            Picture picture = new Picture();

            // Default values
            Color[] previousColors = picture.Colors;
            uint prevH = picture.Height;
            uint prevW = picture.Width;
            DateTime previousTime = picture.Creation;


            // new height and width of picture
            uint h = 500;
            uint w = 250;

            picture.ReWrite(h, w);

            // Check chenging
            Assert.AreNotEqual(prevH, picture.Height);
            Assert.AreNotEqual(prevW, picture.Width);
            Assert.AreNotEqual(previousTime, picture.Creation);
            Assert.AreEqual(h, picture.Height);
            Assert.AreEqual(w, picture.Width);
        }
        /// <summary>
        /// Testing ReWrite(uint height, uint width, Color[])
        /// </summary>
        [TestMethod]
        public void ReWriteTest_InColor3Height1000Width750_OutColor3Height1000Width750NewDataTime()
        {
            Picture picture = new Picture();

            // Default values
            Color[] previousColors = picture.Colors;
            uint prevH = picture.Height;
            uint prevW = picture.Width;
            DateTime previousTime = picture.Creation;


            // new height and width of picture
            uint h = 1000;
            uint w = 750;

            picture.ReWrite(h, w, colors3);

            // Check chenging
            Assert.AreNotEqual(prevH, picture.Height);
            Assert.AreNotEqual(prevW, picture.Width);
            Assert.AreNotEqual(previousColors, picture.Colors);
            Assert.AreNotEqual(previousTime, picture.Creation);
            Assert.AreEqual(colors3, picture.Colors);
            Assert.AreEqual(h, picture.Height);
            Assert.AreEqual(w, picture.Width);
        }
        /// <summary>
        /// Testing Clear() method
        /// </summary>
        [TestMethod]
        public void ClearTest_InHeight1000Width750Color1_OutColorNullCreationUtcNow()
        {
            uint h = 1000; // heigth
            uint w = 750;   // width

            Picture picture = new Picture(h, w, colors1);

            DateTime dateTime = picture.Creation; // standart creation date time

            picture.Clean();

            // Check chenging
            Assert.AreEqual(h, picture.Height);
            Assert.AreEqual(w, picture.Width);
            Assert.AreNotEqual(colors1, picture.Colors);
            Assert.AreNotEqual(dateTime, picture.Creation);
        }
        /// <summary>
        /// Testing Delete() method
        /// </summary>
        [TestMethod]
        public void DeleteTest_InHeight1200Width950Color2DataTimeNow_OutHeight0Width0ColorNullCreationMinValue()
        {
            uint h = 1200; // heigth
            uint w = 950;   // width

            Picture picture = new Picture(h, w, colors2, DateTime.Now);

            picture.Delete();

            // Check chenging
            Assert.AreNotEqual(h, picture.Height);
            Assert.AreNotEqual(w, picture.Width);
            Assert.AreNotEqual(colors2, picture.Colors);
            Assert.AreEqual(DateTime.MinValue, picture.Creation);
        }
        /// <summary>
        /// Testing Save() method
        /// </summary>
        [TestMethod]
        public void SaveTest()
        {
            Picture picture = new Picture();

            picture.Save();
            
        }
        /// <summary>
        /// Testing SaveAs() method
        /// </summary>
        [TestMethod]
        public void SaveAsTest()
        {
            Picture picture = new Picture(300, 500);
            string path = @"..\..\Xml_Documents\picture.xml";

            picture.SaveAs(path);
        }
    }
}

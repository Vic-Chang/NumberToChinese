using Microsoft.VisualStudio.TestTools.UnitTesting;
using NumberToChinese;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumberToChinese.Tests
{
    [TestClass()]
    public class ConvertLibraryTests
    {
        private TestContext testContextInstance;
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        [TestMethod()]
        [DeploymentItem("Convert_DTT_csv.csv")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV",
    "|DataDirectory|\\Convert_DTT_csv.csv",
    "Convert_DTT_csv#csv", DataAccessMethod.Random)]
        public void ConvertToNumberTest()
        {
            string input = TestContext.DataRow[1].ToString();
            string output = TestContext.DataRow[0].ToString();

            System.Diagnostics.Debug.WriteLine("input:>> " + output);
            System.Diagnostics.Debug.WriteLine("output:>> " + output);
            string actual;
            
            actual = ConvertLibrary.ConvertToNumber(input);
            System.Diagnostics.Debug.WriteLine("actual:>> " + actual);
            Assert.AreEqual(output, actual);

        }

        [TestMethod()]
        [DeploymentItem("Convert_DTT_csv.csv")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV",
    "|DataDirectory|\\Convert_DTT_csv.csv",
    "Convert_DTT_csv#csv", DataAccessMethod.Random)]
        public void ConvertToChineseTest()
        {
            string input = TestContext.DataRow[0].ToString();
            string output = TestContext.DataRow[1].ToString();

            string actual = ConvertLibrary.ConvertToChinese(input);
            Assert.AreEqual(output, actual);
        }

        //相互測試(隨機產生一組號碼，轉為國字後再轉回數字，看是否一樣)
        [TestMethod]
        public void Random_Numbert_intput_Convert_to_Chinese_then_Convert_to_Number()
        {
            Random rd = new Random();
            string Chinese = "";
            string Number = "";
            string temp_Number = "";
            for (int x = 3; x < 8; x++)
            {
                string max = "";
                max += x;
                for (int i = 0; i <= x; i++)
                {
                    max += 0;
                }
                for (int i = 0; i < 10000; i++)
                {
                    int MaxValues = Convert.ToInt32(max);
                    Number = rd.Next(0, MaxValues).ToString();
                    Chinese = ConvertLibrary.ConvertToChinese(Number);
                    temp_Number = ConvertLibrary.ConvertToNumber(Chinese);
                    Assert.AreEqual(Number, temp_Number);

                    //測試至輸出視窗(單元測試觀看方法>總管視窗>點擊該測試>點擊下方說明之"輸出")
                    System.Diagnostics.Debug.WriteLine(Number);
                }
            }
        }
    }
}
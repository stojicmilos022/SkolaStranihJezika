using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using SkolaStranihJezika.Model;
using SkolaStranihJezika.Help;
using System.IO;

namespace UnitTestProjectSkola
{
    [TestClass]
    public class ProveriDaliUcenikPostojiTest
    {
        [TestMethod]
        public void ProveraDaliUcenikPostojiUspesna()
        {
            int userInput = 4; // Existing valid ID
            string input = userInput.ToString();
            var reader = new StringReader(input);
            Console.SetIn(reader);

            var result = UcenikHelp.UcenikPreuzmiPoId(userInput);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(userInput, result.id);
        }

        [TestMethod]
        public void ProveraDaliKursPostojiUspesna()
        {
            int userInput = 3; // Existing valid ID
            string input = userInput.ToString();
            var reader = new StringReader(input);
            Console.SetIn(reader);

            var result = KursHelp.KursPreuzmiPoId(userInput);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(userInput, result.id);
        }



        [TestMethod]
        public void UnosUcenikaNaKursUspesno()
        {
            Ucenik noviUcenik = UcenikHelp.UcenikPreuzmiPoId(4);
            Kurs noviKurs = KursHelp.KursPreuzmiPoId(3);
            bool testDodavanja= PohadjaHelp.TestDodavanjaUcenikaNaKurs(noviKurs.id, noviUcenik.id);
            Assert.IsTrue(testDodavanja);
        }

    }
}

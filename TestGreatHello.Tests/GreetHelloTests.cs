using NUnit.Framework;

namespace TestGreatHello.Tests
{
    [TestFixture]
    public class GreetHelloTests
    {
        private IGreetHello _sut;

        [SetUp]
        public void Setup()
        {
            _sut = new Greet();
        }

        [Test]
        public void Should_Send_Me_Hello_By_Name()
        {
            var actual = _sut.GreetHello("Gino"); 
            Assert.AreEqual("Hello, Gino.", actual);
            Assert.Pass("ho salutato");
        }

        [Test]
        public void Should_Send_Me_Hello_My_Friend()
        {
            var actual = _sut.GreetHello(null);
            Assert.AreEqual("Hello, my friend.", actual);
            Assert.Pass("ti ho salutato ma non ti conosco");
        }

        [Test]
        public void Should_Send_Me_Hello_By_Uppercase()
        {
            var actual = _sut.GreetHello("IGOR");
            Assert.AreEqual("HELLO IGOR!", actual);
            Assert.Pass("ti ho salutato urlando");
        }

        [Test]
        public void Should_Send_Me_Hello_To_Two_Names()
        {
            var actual = _sut.GreetHello("Oussama", "Nicola");
            Assert.AreEqual("Hello, Oussama and Nicola." , actual);
            Assert.Pass("vi ho salutato entrambi");
        }
        [Test]
        public void Should_Split_Name()
        {
            var actual = _sut.GreetHello("Oussama", "Nicola", "Emilio");
            Assert.AreEqual("Hello, Oussama, Nicola and Emilio." , actual);
            Assert.Pass("Vi ho salutato tutti");
        }

        [Test]
        public void Should_Split_Name_Upper()
        {
            var actual = _sut.GreetHello("Oussama", "BRIAN", "Emilio");
            Assert.AreEqual("Hello, Oussama and Emilio. AND HELLO BRIAN!", actual);
            Assert.Pass("Vi ho salutato tutti");
        }
        [Test]
        public void Should_Split_Name_Comma()
        {
            var actual = _sut.GreetHello("Bob", "Charlie, Dianne");
            Assert.AreEqual("Hello, Bob, Charlie and Dianne.", actual);
            Assert.Pass("Vi ho salutato tutti");
        }
        [Test]
        public void Should_Avoid_Split_Name_Comma()
        {
            var actual = _sut.GreetHello("Bob", "\"Charlie, Dianne\"");
            Assert.AreEqual("Hello, Bob and Charlie, Dianne.", actual);
            Assert.Pass("Split AVOID");
        }
    }
}
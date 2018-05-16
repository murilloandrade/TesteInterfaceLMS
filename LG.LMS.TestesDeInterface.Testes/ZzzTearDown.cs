using LG.LMS.TestesDeInterface.Infraestrutura;
using LG.LMS.TestesDeInterface.Testes;
using NUnit.Framework;

namespace LG.LMS.TestesDeInterface
{
    [TestFixture]
    public class ZzzTearDown : TestesDeInterfaceBase
    {
        [Test]
        public void ZzzFinaliza()
        {
            Assert.IsTrue(true);
        }

        protected override ContextoDeTeste CrieContextoDeTeste()
        {
            return new ContextoDeTeste(string.Empty, string.Empty, string.Empty);
        }
    }
}

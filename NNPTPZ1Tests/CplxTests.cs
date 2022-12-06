using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace NNPTPZ1.Mathematics.Tests
{
    [TestClass()]
    public class CplxTests
    {

        [TestMethod()]
        public void AddTest()
        {
            ComplexNumbers a = new ComplexNumbers()
            {
                Re = 10,
                Imaginari = 20
            };
            ComplexNumbers b = new ComplexNumbers()
            {
                Re = 1,
                Imaginari = 2
            };

            ComplexNumbers actual = a.Add(b);
            ComplexNumbers shouldBe = new ComplexNumbers()
            {
                Re = 11,
                Imaginari = 22
            };

            Assert.AreEqual(shouldBe, actual);

            var e2 = "(10 + 20i)";
            var r2 = a.ToString();
            Assert.AreEqual(e2, r2);
            e2 = "(1 + 2i)";
            r2 = b.ToString();
            Assert.AreEqual(e2, r2);

            a = new ComplexNumbers()
            {
                Re = 1,
                Imaginari = -1
            };
            b = new ComplexNumbers() { Re = 0, Imaginari = 0 };
            shouldBe = new ComplexNumbers() { Re = 1, Imaginari = -1 };
            actual = a.Add(b);
            Assert.AreEqual(shouldBe, actual);

            e2 = "(1 + -1i)";
            r2 = a.ToString();
            Assert.AreEqual(e2, r2);

            e2 = "(0 + 0i)";
            r2 = b.ToString();
            Assert.AreEqual(e2, r2);
        }

        [TestMethod()]
        public void AddTestPolynome()
        {
            Polynomial poly = new Mathematics.Polynomial();
            poly.Coe.Add(new ComplexNumbers() { Re = 1, Imaginari = 0 });
            poly.Coe.Add(new ComplexNumbers() { Re = 0, Imaginari = 0 });
            poly.Coe.Add(new ComplexNumbers() { Re = 1, Imaginari = 0 });
            ComplexNumbers result = poly.Eval(new ComplexNumbers() { Re = 0, Imaginari = 0 });
            var expected = new ComplexNumbers() { Re = 1, Imaginari = 0 };
            Assert.AreEqual(expected, result);
            result = poly.Eval(new ComplexNumbers() { Re = 1, Imaginari = 0 });
            expected = new ComplexNumbers() { Re = 2, Imaginari = 0 };
            Assert.AreEqual(expected, result);
            result = poly.Eval(new ComplexNumbers() { Re = 2, Imaginari = 0 });
            expected = new ComplexNumbers() { Re = 5.0000000000, Imaginari = 0 };
            Assert.AreEqual(expected, result);

            var r2 = poly.ToString();
            var e2 = "(1 + 0i) + (0 + 0i)x + (1 + 0i)xx";
            Assert.AreEqual(e2, r2);
        }
    }
}



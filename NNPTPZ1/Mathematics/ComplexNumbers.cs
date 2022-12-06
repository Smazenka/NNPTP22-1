using System;

namespace NNPTPZ1.Mathematics
{
    public class ComplexNumbers
    {
        public double Re { get; set; }
        public float Imaginari { get; set; }

        public override bool Equals(object obj)
        {
            if (obj is ComplexNumbers)
            {
                ComplexNumbers x = obj as ComplexNumbers;
                return x.Re == Re && x.Imaginari == Imaginari;
            }
            return base.Equals(obj);
        }

        public readonly static ComplexNumbers Zero = new ComplexNumbers()
        {
            Re = 0,
            Imaginari = 0
        };

        public ComplexNumbers Multiply(ComplexNumbers b)
        {
            ComplexNumbers a = this;
            // aRe*bRe + aRe*bIm*i + aIm*bRe*i + aIm*bIm*i*i
            return new ComplexNumbers()
            {
                Re = a.Re * b.Re - a.Imaginari * b.Imaginari,
                Imaginari = (float)(a.Re * b.Imaginari + a.Imaginari * b.Re)
            };
        }
        public double GetAbS()
        {
            return Math.Sqrt(Re * Re + Imaginari * Imaginari);
        }

        public ComplexNumbers Add(ComplexNumbers b)
        {
            ComplexNumbers a = this;
            return new ComplexNumbers()
            {
                Re = a.Re + b.Re,
                Imaginari = a.Imaginari + b.Imaginari
            };
        }
        public double GetAngleInDegrees()
        {
            return Math.Atan(Imaginari / Re);
        }
        public ComplexNumbers Subtract(ComplexNumbers b)
        {
            ComplexNumbers a = this;
            return new ComplexNumbers()
            {
                Re = a.Re - b.Re,
                Imaginari = a.Imaginari - b.Imaginari
            };
        }

        public override string ToString()
        {
            return $"({Re} + {Imaginari}i)";
        }

        internal ComplexNumbers Divide(ComplexNumbers b)
        {
            // (aRe + aIm*i) / (bRe + bIm*i)
            // ((aRe + aIm*i) * (bRe - bIm*i)) / ((bRe + bIm*i) * (bRe - bIm*i))
            //  bRe*bRe - bIm*bIm*i*i
            var tmp = this.Multiply(new ComplexNumbers() { Re = b.Re, Imaginari = -b.Imaginari });
            var tmp2 = b.Re * b.Re + b.Imaginari * b.Imaginari;

            return new ComplexNumbers()
            {
                Re = tmp.Re / tmp2,
                Imaginari = (float)(tmp.Imaginari / tmp2)
            };
        }
    }
}


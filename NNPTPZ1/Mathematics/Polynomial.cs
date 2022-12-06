﻿using System.Collections.Generic;

namespace NNPTPZ1.Mathematics
{
    public class Polynomial
    {
        /// <summary>
        /// Coe
        /// </summary>
        public List<ComplexNumbers> Coe { get; set; }

        /// <summary>
        /// Constructor
        /// </summary>
        public Polynomial() => Coe = new List<ComplexNumbers>();

        public void Add(ComplexNumbers coe) =>
            Coe.Add(coe);

        /// <summary>
        /// Derives this polynomial and creates new one
        /// </summary>
        /// <returns>Derivated polynomial</returns>
        public Polynomial Derive()
        {
            Polynomial p = new Polynomial();
            for (int q = 1; q < Coe.Count; q++)
            {
                p.Coe.Add(Coe[q].Multiply(new ComplexNumbers() { Re = q }));
            }

            return p;
        }

        /// <summary>
        /// Evaluates polynomial at given point
        /// </summary>
        /// <param name="x">point of evaluation</param>
        /// <returns>y</returns>
        public ComplexNumbers Eval(double x)
        {
            var y = Eval(new ComplexNumbers() { Re = x, Imaginari = 0 });
            return y;
        }

        /// <summary>
        /// Evaluates polynomial at given point
        /// </summary>
        /// <param name="x">point of evaluation</param>
        /// <returns>y</returns>
        public ComplexNumbers Eval(ComplexNumbers x)
        {
            ComplexNumbers s = ComplexNumbers.Zero;
            for (int i = 0; i < Coe.Count; i++)
            {
                ComplexNumbers coef = Coe[i];
                ComplexNumbers bx = x;
                int power = i;

                if (i > 0)
                {
                    for (int j = 0; j < power - 1; j++)
                        bx = bx.Multiply(x);

                    coef = coef.Multiply(bx);
                }

                s = s.Add(coef);
            }

            return s;
        }

        /// <summary>
        /// ToString
        /// </summary>
        /// <returns>String repr of polynomial</returns>
        public override string ToString()
        {
            string s = "";
            int i = 0;
            for (; i < Coe.Count; i++)
            {
                s += Coe[i];
                if (i > 0)
                {
                    int j = 0;
                    for (; j < i; j++)
                    {
                        s += "x";
                    }
                }
                if (i + 1 < Coe.Count)
                    s += " + ";
            }
            return s;
        }
    }
}

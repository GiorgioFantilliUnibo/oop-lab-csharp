namespace ExtensionMethods
{
    using System;

    /// <inheritdoc cref="IComplex"/>
    public class Complex : IComplex
    {
        private readonly double re;
        private readonly double im;

        /// <summary>
        /// Initializes a new instance of the <see cref="Complex"/> class.
        /// </summary>
        /// <param name="re">the real part.</param>
        /// <param name="im">the imaginary part.</param>
        public Complex(double re, double im)
        {
            this.re = re;
            this.im = im;
        }

        /// <inheritdoc cref="IComplex.Real"/>
        public double Real => this.re;

        /// <inheritdoc cref="IComplex.Imaginary"/>
        public double Imaginary => this.im;

        /// <inheritdoc cref="IComplex.Modulus"/>
        public double Modulus => Math.Sqrt(this.Real * this.Real + this.Imaginary * this.Imaginary);

        /// <inheritdoc cref="IComplex.Phase"/>
        public double Phase => Math.Atan2(this.Imaginary, this.Real);

        /// <inheritdoc cref="IComplex.ToString"/>
        public override string ToString()
        {
            string re = this.Real.ToString();
            if (this.Imaginary == 0.0) return re;

            string sign = "";
            if (this.Imaginary < 0)
            {
                sign = "-";
            }
            else if (re != "0")
            {
                sign = "+";
            }
            if (re == "0") re = "";

            string im = Math.Abs(this.Imaginary).ToString();
            if (im == "1")
                im = sign + "i";
            else
                im = sign + im + "i";

            return re + im;
        }

        /// <inheritdoc cref="IEquatable{T}.Equals(T)"/>
        public bool Equals(IComplex other)
        {
            throw new System.NotImplementedException();
        }

        /// <inheritdoc cref="object.Equals(object?)"/>
        public override bool Equals(object obj)
        {
            // TODO improve
            return base.Equals(obj);
        }

        /// <inheritdoc cref="object.GetHashCode"/>
        public override int GetHashCode()
        {
            // TODO improve
            return base.GetHashCode();
        }
    }
}

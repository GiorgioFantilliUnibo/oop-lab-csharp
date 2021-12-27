namespace ExtensionMethods
{
    using System;

    /// <inheritdoc cref="IComplex"/>
    public class Complex : IComplex
    {
        private const double Tolerance = 1E-7;

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
            if (other == null)
                return false;
            else if (this == other)
                return true;
            else
                return Math.Abs(this.Real - other.Real) < Tolerance &&
                       Math.Abs(this.Imaginary - other.Imaginary) < Tolerance;
        }

        /// <inheritdoc cref="object.Equals(object?)"/>
        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            if (!(obj is IComplex)) return false;
            return this.Equals(obj as IComplex);
        }

        /// <inheritdoc cref="object.GetHashCode"/>
        public override int GetHashCode()
        {
            return HashCode.Combine(this.Real, this.Imaginary);
        }
    }
}

using System;
using System.Collections.Generic;
using System.IO;

namespace ClassesOOP
{
    class Triangle
    {
        // Fields
        int numberOfSides;
        int sideA;
        int sideB;
        int sideC;
        int numberOfAngles;
        double angleX;
        double angleY;
        double angleZ;

        // Constructors
        public Triangle()
        {
            this.numberOfSides = 3;
            this.numberOfAngles = 3;
        }

        public Triangle (int a, int b, int c)
        {
            this.numberOfSides = 3;
            this.numberOfAngles = 3;
            this.sideA = a;
            this.sideB = b;
            this.sideC = c;

            // Any side may not be equal to or greated than the sum of the other two sides
            if((this.sideA > this.sideB) && (this.sideA > this.sideC))
            {
                if(this.sideA > (this.sideB + this.sideC))
                {
                    throw new Exception();
                }
            }
            else if((this.sideB > this.sideA) && (this.sideB > this.sideC))
            {
                if(this.sideB > (this.sideA + this.sideC))
                {
                    throw new Exception();
                }
            }
            else if((this.sideC > this.sideA) && (this.sideC > this.sideB))
            {
                if(this.sideC > (this.sideA + this.sideB))
                {
                    throw new Exception();
                }
            }
        }

        public Triangle(int a)
        {
            // Defined equilateral triangle
            this.numberOfSides = 3;
            this.numberOfAngles = 3;
            this.sideA = a;
            this.sideB = a;
            this.sideC = a;
        }

        public Triangle(int a, int b)
        {
            // Defined isoceles triangle
            this.numberOfSides = 3;
            this.numberOfAngles = 3;
            this.sideA = a;
            this.sideB = b;
            this.sideC = a;
        }

        public Triangle(double a, double b, double c)
        {
            this.numberOfSides = 3;
            this.numberOfAngles = 3;
            this.sideA = (int)a;    // Explicit casting
            this.sideB = Convert.ToInt32(b);    // Explicit conversion
            this.sideC = Convert.ToInt32(c);

            int[] sides = (this.sideA, this.sideB, this.sideC);
            Array.Sort(sides);

            // Same function as above but much cleaner
            if(sides[2] !> sides[1] + sides[0])
            {
                throw new Exception();
            }

        }

        // Floor and Ceilling
        // Happens when we lose a precision (e.g. double -> int)

        // Polymorphism - Overloading - overloading a method or constructor
        // Create a new definition for a method, that is differentiated based on the parameters


        // Methods
        public int Perimeter()
        {
            int perimeter = this.sideA + this.sideB + this.sideC;
            return perimeter;
        }

    }

}
using System;
using System.Collections.Generic;
using System.IO;

namespace ClassesOOP
{
    class Square
    {
        // Fields - class variables
        public int numberOfSides;
        double area;
        double perimeter;
        double sideLength; //{get; set; } Shorthand of getter and setter methods

        // Constructor
        public Square()
        {
            this.numberOfSides = 4;
            this.sideLength = 1;
            setCaclPerimeter(this.numberOfSides, this.sideLength);
            setCalcArea(this.sideLength);
        }


        // Setter methods - methods that set the value of private fields
        void setCaclPerimeter(int sides, double length)
        {
            this.perimeter = (sides * length);
        }

        void setCalcArea(double length)
        {
            this.area = (length * length);
        }

        // Getter methods - methods that return the value of private fields
        public double getPerimeter()
        {
            return this.perimeter;
        }
 


    }
}
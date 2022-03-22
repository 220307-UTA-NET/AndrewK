namespace FileInteraction
{ 
    // Create a Person class
    class Person
    {
        // Fields - variables that are part of each instance of a class object
        public string name;
        public double height;
        public int age = 40;

        // Constructor - a method used to initialize instances of the class
        public Person(string name, double height, int age)
        {
            this.name = name;
            this.height = height;
            this.age = age;
        }

        // Another example of constructor
        //public Person(string name = "Default", double height = 60.0, int age = 20)
        //{
        //    this.name = name;
        //    this.height = height;
        //    this.age = age;
        //}

        // Another constructor
        public Person(string name, double height)
        {
            this.name = name;
            this.height = height;
        }

        // Another example of a constructor
        public Person(string name, int age)
        {
            this.name = name;
            this.height = 67.9;
            this.age = age;
        }

        // Functions
        public int GrowUp()
        {
            this.age++;
            return this.age;
        }

        public void Shrink() {
            this.height--;
        }
    }
}
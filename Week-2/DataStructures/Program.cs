// Arrays
string[] arrayName = {"Kevin", "Dan", "Anu", "Kelly", "Trygg"}; // Declaring and initializing an array

string Name = arrayName[2]; // Initializing an array of size 2

arrayName[1] = "Cam";   // Replacing the 2nd element in the array

Array.Sort(arrayName);  // Sort the array in ascending order

// Enumerables - iteratable
// Iterate over every element in order
foreach(string name in arrayName)
{
    Console.WriteLine(name);
}

int[] myNumbers = {2, 4, 6, 14, 0, 23, 2, 19};  // Create an int array

Array.Sort(myNumbers);  // Sort the array in ascending order
Array.Reverse(myNumbers);   // Reverse the order of the array

// Iterate over every element in order
foreach(int i in myNumbers)
{
    Console.WriteLine(i);
}

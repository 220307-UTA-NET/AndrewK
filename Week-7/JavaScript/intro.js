// Now that I'm inside the script tags, I am using javascript.
// This is a comment

// JavaScript is unrelated to Java!
// JS is weakly typed that allows us to declare a variable, and then change it's type later.
// It is not as looely typed as Bash, but not so strongly typed as C#.

// In JS, we can use numbers.
let x = 5;  // let is one way we can declare a variable
// Use semicolon ; as an end-thought/section/action character.

var y = 6;  // var is another way to declare a variable
let z = Infinity;
x = 3 * 6;
y = 1 / 0;  // We can actually get infinity values from a calculation!
z = NaN; // This is a special value that represents a variable/object that is not a number
z = 'asdf' - 5; // This results in NaN

// Boolean operators: testing for a true/false condition.
x = 3 == 3; // "==" is the equality operator, it checks if the values are equal.
x = 3 != 2; // "!=" is the inequality operator, it checks if the values are not equal.
x = 3 > 2;  // ">" is the greater than operator, it checks if the value on the left is greater than the value on the right.
x = 3 < 2;  // "<" is the less than operator, it checks if the value on the left is less than the value on the right.
x = 3 >= 2; // ">=" is the greater than or equal to operator, it checks if the value on the left is greater than or equal to the value on the right.
x = 3 <= 2;  // "<=" is the less than or equal to operator, it checks if the value on the left is less than or equal to the value on the right.
//"&&" is the logical AND operator, it checks if both values are true.
//"||" is the logical OR operator, it checks if either value is true.

// Strings
x = 'hello';    // This is a string.
x = "hello";    // This is also a string.
x = 'as"df\`';

// JS can accept multi-line strings. Use "back-tick" (under the ~)
x = `asf
asdf
asdf`;

// JS can perform template literal (string interpolation)
x = `3 + 3 == ${3 + 3}`;

// console.log()
// The console of your browser is where you can see the output of your code.
console.log('Hello World!');
console.log(x);


// Objects in JS
x = {}; // This is an object literal.
console.log(x);
x.name = 'Fred';    // This is how to add a property to an object.
console.log(x);
delete x.name;  // This is how to delete a property from an object.

x = {
    name: 'Fred',
    'properties can have spaces in their names': 5,
    3: 5
};
console.log(x);
console.log(x.name);
console.log(x[3]);
console.log(x['properties can have spaces in their names']);
x['name of'] = "Amin";
console.log(x['name of']);
x.newProperty = "Rich";
console.log(x.newProperty);

// Undefined
// Sepcial data type with only one possible value, undefined.
// If you don't pass something for a function parameter, it will be undefined.
// If you don't return a value from a function, it will be undefined.
x = undefined;

// Null
// Special data type with ony one possible value, null,
// Null represents missing data.
// typeof says null is an object, wrongly!
x = null;
console.log(x);
console.log(typeof x);

// Functions
// Functions are of object type, but typeof calls them functions. (for historical reasons)
x = function ()
{
    console.log('hello');
}
x();
// Functions can accept and return data similar to how we are familiar in C#.
// Arrow functions are similar to lambda expressions in C#.
x = () =>{
    console.log('Hi there!');
}
x();

x = a => a + a;
console.log(x(2,2));
console.log(x("hi"));
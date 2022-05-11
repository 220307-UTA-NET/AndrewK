function myFunction()
{
    console.log("myFunction is running.");
   
    // Get the div and creating an object in JS for us to interact with
    let testDiv = document.getElementById("testdiv");
    
    // Create a new object, that is a paragraph element.
    let newParagraph = document.createElement('p');

    // Set the context of the paragraph, giving it some data.
    newParagraph.textContent = "this is a new paragraph";

    // Append the paragraph to the div
    testDiv.append(newParagraph);
}

let counter  = 0;
function countFunction()
{
    ++counter;
    console.log(counter);
}

//document.addEventListener("DOMContentLoader", countFunction());

// DOMContentLoaded event fires as soon as all the elements are created on the page.
// Even if they haven't fully loaded yet.
// When we use this, it doesn't really matter where you put the script in your HTML.
// Often it's put at the end of the HEAD.

document.addEventListener('DOMContentLoader', function() {  // When the DOM loads, do this thing...
    let somethingAmazing = document.getElementById('button2')   // Create an object based on the button2 element
    somethingAmazing.addEventListener('click', () => {  // When the button is clicked,
        location.href = 'https://www.google.com/';  // Send a GET request to google.com
    });

    let somethingLessmazing = document.getElementById('button3')   // Create an object based on the button3 element
    somethingLessAmazing.addEventListener('click', () => {  // When the button is clicked,
        location.href = 'https://www.github.com/';  // Send a GET request to github.com

});









document.addEventListener('DOMContentLoaded', () =>
{
    const loadTodosButton = document.getElementById('load-todos-button');
    const dataComponent = document.getElementById('data-component');
    const errorComponent = document.getElementById('error-component');
    const userInput = document.getElementById('user-id');
    const loadUserButton = document.getElementById('load-user-button');

    loadTodosButton.addEventListener('click', () =>
    {
        fetch('https://jsonplaceholder.typicode.com/todos')
            .then( response =>
                {
                    if (!response.ok)
                    {
                        throw new Error(`Server error: ${response.status}`);
                    }
                    return response.json();
                })
            .then(obj =>
                {
                    errorComponent.hidden = true;
                    let html = `<ul>` + obj.map(x => `<li>${x.title}</li>`).join('') + `</ul>                    `;
                    dataComponent.innerHTML = html;

                })
            .catch(error =>
                {
                    errorComponent.hidden = false;
                    errorComponent.innerHTML = `<p>${error.message}</p>`;
                    dataComponent.textContent = '';
                })

    });

    loadUserButton.addEventListener('click', () =>
    {
        fetch(`https://jsonplaceholder.typicode.com/users/${userInput.value}`)
            .then(response =>
                {
                    if (!response.ok)
                    {
                        throw new Error(`Server error: ${response.status}`);
                    }
                    return response.json();
                })
            then(obj =>
                {
                    errorComponent.hidden = true;
                    displayData(obj, dataComponent);
                })
            .catch(error =>
                {
                    errorComponent.hidden = false;
                    errorComponent.innerHTML = `<p>${error.message}</p>`;
                    dataComponent.textContent = '';
                })
    });
});

function displayData(users, dataComponent)
{

    if(!(users instanceof Array))
    {
        users = [users];
    }

    let html = '';

    html += `<ul>`;
    for (let user of users)
    {
        html += `<li>${user.name}</li>`;
    }
    html += `</ul>`;

    dataComponent.innerHTML = html;
}

// Callbakcs
// JavaScript allows us to pass a function as a parameter
// a function in JavaScript is an object

function printSomething(x)
{
    console.low(x);
}

function addWithCallback(x, y, callback)
{
    let result = x + y;
    callback(result);
}

addWithCallback(1, 1, printSomething);
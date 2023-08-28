var mainDiv = document.getElementById("mainDiv");
    
//Create registration form.
async function createRegistrationForm()
{
    if(document.forms["regForm"])
        return;

    if(document.forms["logForm"])
    {
        mainDiv.removeChild(document.forms["logForm"]);
    }
    const form = document.createElement("form");
    form.name = "regForm";

    let formDiv = document.createElement("div");
    let label = document.createElement("label");
    label.innerText = "Username";
    label.className = "form-label";
    const nameInput = document.createElement("input");
    nameInput.name = "name";
    nameInput.className = "form-control";
    let span = document.createElement("span");
    span.id = "Name";
    formDiv.append(label, nameInput, span);
    form.append(formDiv);

    formDiv = document.createElement("div");
    label = document.createElement("label");
    label.innerText = "Age";
    label.className = "form-label";
    const ageInput = document.createElement("input");
    ageInput.type = "number";
    ageInput.value = 18;
    ageInput.id = "age";
    ageInput.className = "form-control";
    span = document.createElement("span");
    span.id = "Age";
    formDiv.append(label, ageInput, span);
    form.append(formDiv);

    formDiv = document.createElement("div");
    label = document.createElement("label");
    label.innerText = "Email";
    label.className = "form-label";
    const emailInput = document.createElement("input");
    emailInput.name = "email";
    emailInput.className = "form-control";
    span = document.createElement("span");
    span.id = "Email";
    formDiv.append(label, emailInput, span);
    form.append(formDiv);

    formDiv = document.createElement("div");
    label = document.createElement("label");
    label.innerText = "Phone number";
    label.className = "form-label";
    const phoneInput = document.createElement("input");
    phoneInput.name = "phone";
    phoneInput.className = "form-control";
    span = document.createElement("span");
    span.id = "PhoneNumber";
    formDiv.append(label, phoneInput, span);
    form.append(formDiv);
    
    formDiv = document.createElement("div");
    label = document.createElement("label");
    label.innerText = "Country";
    label.className = "form-label";
    const countyInput = await getCountries();
    countyInput.name = "country";
    countyInput.addEventListener("change", updateCities);
    countyInput.className = "form-select";
    span = document.createElement("span");
    span.id = "Country";
    formDiv.append(label, countyInput, span);
    form.append(formDiv);

    formDiv = document.createElement("div");
    label = document.createElement("label");
    label.innerText = "City";
    label.className = "form-label";
    const cityInput = document.createElement("select");;
    cityInput.name = "city";
    cityInput.disabled = true;
    cityInput.className = "form-select";
    span = document.createElement("span");
    span.id = "City";
    formDiv.append(label, cityInput, span);
    form.append(formDiv);

    formDiv = document.createElement("div");
    label = document.createElement("label");
    label.innerText = "Password";
    label.className = "form-label";
    const passwordInput = document.createElement("input");
    passwordInput.name = "password";
    passwordInput.type = "password";
    passwordInput.className = "form-control";
    span = document.createElement("span");
    span.id = "Password";
    formDiv.append(label, passwordInput, span);
    form.append(formDiv);

    formDiv = document.createElement("div");
    label = document.createElement("label");
    label.innerText = "Confirm password";
    label.className = "form-label";
    const confirmPasswordInput = document.createElement("input");
    confirmPasswordInput.name = "confirmPassword";
    confirmPasswordInput.type = "password";
    confirmPasswordInput.className = "form-control";
    span = document.createElement("span");
    span.id = "ConfirmPassword";
    formDiv.append(label, confirmPasswordInput, span);
    form.append(formDiv);

    formDiv = document.createElement("div");
    formDiv.className = "container";
    const button = document.createElement("button");
    button.type = "submit";
    button.innerText = "Submit";
    button.className = "box";
    formDiv.append(button);
    
    const logInBtn = document.createElement("button");
    logInBtn.innerText = "Log In";
    logInBtn.name = "logIn";
    logInBtn.className = "box";
    logInBtn.addEventListener("click",createLoginForm);
    formDiv.append(logInBtn);
    form.append(formDiv);

    form.addEventListener("submit", e => {
        e.preventDefault();
        getRegFormValues();
    });
    
    mainDiv.append(form);
}

//Get values from form and call registerUser function.
async function getRegFormValues()
{
    const form = document.forms["regForm"];
    const name = form["name"].value;
    const age = form["age"].value;
    const email = form["email"].value;
    const phone = form["phone"].value;
    const country = form["country"].value;
    const city = form["city"].value;
    const password = form["password"].value;
    const confirmPassword = form["confirmPassword"].value;

    await registerUser(name, age, email, phone, country, city, password, confirmPassword)
}

//Register new user.
async function registerUser(userName, userAge, userEmail, userPhone, userCounty, userCity, userPassword, userConfirmPassword)
{
    const response = await fetch("/api/User/register", {
        method: "POST",
        headers: {"Accept": "application/json", "Content-Type": "application/json"},
        body : JSON.stringify({
            name: userName,
            age: parseInt(userAge),
            email: userEmail,
            phoneNumber: userPhone,
            country: userCounty,
            city: userCity,
            password: userPassword,
            confirmPassword: userConfirmPassword
        })
    });

    if(response.ok == true)
    {
        const text = await response.text();

        mainDiv.removeChild(document.forms["regForm"]);
        createLoginForm();
    }
    else if(response.status === 400)
    {
        const errors = await response.json();
        
        var spanList = document.querySelectorAll("span");
        spanList.forEach(s => {
            s.innerText = "";
            s.style.color = "green";
            s.previousElementSibling.style.borderColor = "black";
        });

        errors.forEach(e => {
            
            var prop = JSON.stringify(e.propertyName);
            prop = prop.replace(/["']/g, '');
            
            var msg = JSON.stringify(e.errorMessage);
            msg = msg.replace(/["']/g, '');

            var span = document.getElementById(prop);
            span.innerText = msg;
            span.style.color = "red";

            var input = span.previousElementSibling;
            input.style.borderColor = "red";
            
        });
        
    }   
}

//Get all Countries.
async function getCountries()
{
    const response = await fetch("/api/User/countries", {
        method: "GET",
        headers: {"Accept": "application/json", "Content-Type": "text/plain"}
    });

    if(response.ok === true)
    {
        const countries = await response.json();

        const select = document.createElement("select");
        const option = document.createElement("option");

        select.append(option);

        countries.forEach(c => select.append(createOption(c)));

        return select;
    }


}

//Get Cities.
async function getCities(country)
{
    const response = await fetch(`/api/User/${country}`, {
        method: "GET",
        headers: {"Accept": "application/json", "Content-Type": "text/plain"}
    });

    if(response.ok === true)
    {
        const cities = await response.json();

        const select = document.getElementsByName("city")[0];
        select.innerHTML = "";
        
        const option = document.createElement("option");

        select.append(option);
        
        cities.forEach(c => select.append(createOption(c)));
       
    }
}

//Update cities dropdown.
function updateCities()
{
    if(document.getElementsByName("country")[0].value)
    {
        const country = document.getElementsByName("country")[0].value;
        document.getElementsByName("city")[0].disabled = false;
        getCities(country);
    }
    else
    {
        const country = document.getElementsByName("city")[0].disabled = true;
    }
    
}

//Create option.
function createOption(data)
{
    const option = document.createElement("option");
    option.value = data.name;
    option.innerText = data.name;

    return option;
}

//Create log in form.
async function createLoginForm()
{
    if(document.forms["logForm"])
        return;
    
    if(document.forms["regForm"])
    {
        mainDiv.removeChild(document.forms["regForm"]);
    }
    if(document.getElementById("userDiv"))
    {
        mainDiv.removeChild(document.getElementById("userDiv"));
    }
    const logForm = document.createElement("form");
    logForm.name = "logForm";

    let formDiv = document.createElement("div");
    let label = document.createElement("label");
    label.innerText = "Username";
    label.className = "form-label";
    const nameInput = document.createElement("input");
    nameInput.name = "logName";
    nameInput.className = "form-control";
    let span = document.createElement("span");
    span.id = "Name";
    formDiv.append(label, nameInput, span);
    logForm.append(formDiv);

    formDiv = document.createElement("div");
    label = document.createElement("label");
    label.innerText = "Password";
    label.className = "form-label";
    const passwordInput = document.createElement("input");
    passwordInput.name = "logPassword";
    passwordInput.type = "password";
    passwordInput.className = "form-control";
    span = document.createElement("span");
    span.id = "Password";
    formDiv.append(label, passwordInput, span);
    logForm.append(formDiv);

    const errorDiv = document.createElement("div");
    errorDiv.id = "errorDiv";
    logForm.append(errorDiv);

    formDiv = document.createElement("div");
    formDiv.className = "container";
    const logInBtn = document.createElement("button");
    logInBtn.innerText = "Submit";
    logInBtn.type = "submit";
    logInBtn.className = "box";
    formDiv.append(logInBtn);


    const registrationBtn = document.createElement("button");
    registrationBtn.innerText = "Register";
    registrationBtn.name = "register";
    registrationBtn.className = "box";
    registrationBtn.addEventListener("click", await createRegistrationForm);
    formDiv.append(registrationBtn);
    logForm.append(formDiv);

    logForm.addEventListener("submit", e => {
        e.preventDefault();
        getLogFormValues();
    });


    mainDiv.append(logForm);

    
}

//Log in function.
async function logIn(userName, userPassword)
{
    const response = await fetch("/api/User/login", {
        method: "POST",
        headers: {"Accept": "application/json", "Content-Type": "application/json"},
        body : JSON.stringify({
            name: userName,
            password: userPassword,
        })
    });

    if(response.ok === true)
    {
        mainDiv.removeChild(document.forms["logForm"]);

        const user = await response.json();

        displayUser(user);
    }
    else
    {
        var text = await response.text();
        text = text.replace(/["']/g, '');

        const div = document.getElementById("errorDiv");
        div.style.color = "red";
        div.innerText = text;
        
        const name = document.getElementsByName("logName")[0];
        name.style.borderColor = "red";

        const password = document.getElementsByName("logPassword")[0];
        password.style.borderColor = "red";   
    }
}

//Get values from log in form and call logIn function.
async function getLogFormValues()
{
    const form = document.forms["logForm"];
    const name = form["logName"].value;
    const password = form["logPassword"].value;

    await logIn(name,password)
}

//Display user data.
function displayUser(user)
{
    const userDiv = document.createElement("div");
    userDiv.id = "userDiv";
    userDiv.className = "mainDiv";

    var input = document.createElement("input");
    input.value = user.name;
    input.className = "form-control";
    input.readOnly = true;
    var label = document.createElement("label");
    label.innerText = "Username";
    label.className = "form-label";
    userDiv.append(label);
    userDiv.append(input);

    input = document.createElement("input");
    input.value = user.age;
    input.className = "form-control";
    input.readOnly = true;
    label = document.createElement("label");
    label.innerText = "Age";
    label.className = "form-label";
    userDiv.append(label);
    userDiv.append(input);

    input = document.createElement("input");
    input.value = user.email;
    input.className = "form-control";
    input.readOnly = true;
    label = document.createElement("label");
    label.innerText = "Email";
    label.className = "form-label";
    userDiv.append(label);
    userDiv.append(input);

    input = document.createElement("input");
    input.value = user.phoneNumber;
    input.className = "form-control";
    input.readOnly = true;
    label = document.createElement("label");
    label.innerText = "Phone number";
    label.className = "form-label";
    userDiv.append(label);
    userDiv.append(input);

    input = document.createElement("input");
    input.value = user.country;
    input.className = "form-control";
    input.readOnly = true;
    label = document.createElement("label");
    label.innerText = "Country";
    label.className = "form-label";
    userDiv.append(label);
    userDiv.append(input);

    input = document.createElement("input");
    input.value = user.city;
    input.className = "form-control";
    input.readOnly = true;
    label = document.createElement("label");
    label.innerText = "City";
    label.className = "form-label";
    userDiv.append(label);
    userDiv.append(input);

    input = document.createElement("input");
    input.value = user.password;
    input.className = "form-control";
    input.readOnly = true;
    label = document.createElement("label");
    label.innerText = "Password";
    label.className = "form-label";
    userDiv.append(label);
    userDiv.append(input);

    const button = document.createElement("button");
    button.innerText = "Log out";
    button.className = "box";
    button.addEventListener("click",createLoginForm);
    userDiv.append(button);

    mainDiv.append(userDiv);
}


createRegistrationForm();



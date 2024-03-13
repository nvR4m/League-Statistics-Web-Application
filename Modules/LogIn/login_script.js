document.getElementById('loginForm').addEventListener('submit', function(e) {
    e.preventDefault(); 

    const username = document.getElementById('username').value;
    const password = document.getElementById('password').value;


    if (username && password) {

        console.log('Login successful for user:', username);
        alert('Login successful!'); 
    } else {
        alert('Please enter both username and password.');
    }
});

document.getElementById('registerLink').addEventListener('click', function() {
    document.getElementById('loginContainer').classList.add('hidden');
    document.getElementById('registerContainer').classList.remove('hidden');
});

document.getElementById('loginLink').addEventListener('click', function() {
    document.getElementById('registerContainer').classList.add('hidden');
    document.getElementById('loginContainer').classList.remove('hidden');
});

document.getElementById('registerForm').addEventListener('submit', function(e) {
    e.preventDefault(); 
    const username = document.getElementById('registerUsername').value;
    const password = document.getElementById('registerPassword').value;
    const confirmPassword = document.getElementById('confirmPassword').value;
    const email = document.getElementById('registerEmail').value;

    if (!validatePassword(password)) {
        alert('Password must contain at least one uppercase letter, one number, one special character, and be at least 8 characters long.');
        return;
    }

    if (password !== confirmPassword) {
        alert('Passwords do not match.');
        return;
    }

    if (username && email) {

        console.log('Registration successful for user:', username);
        alert('Registration successful!'); 

    } else {
        alert('Please fill in all fields.');
    }
});

function validatePassword(password) {
    const passwordRegex = /^(?=.*[A-Z])(?=.*[0-9])(?=.*[^A-Za-z0-9]).{8,}$/;
    return passwordRegex.test(password);
}

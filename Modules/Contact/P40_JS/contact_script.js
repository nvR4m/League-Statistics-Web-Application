document.getElementById('contactForm').addEventListener('submit', function(e) {
    e.preventDefault();

    const name = document.getElementById('name').value;
    const email = document.getElementById('email').value;
    const message = document.getElementById('message').value;

    // Here you can handle the form data, e.g., send it to a server or display a confirmation message
    console.log('Name:', name, 'Email:', email, 'Message:', message);
    alert('Thank you for contacting us, ' + name + '!');

    // Reset form after submission for convenience
    this.reset();
});

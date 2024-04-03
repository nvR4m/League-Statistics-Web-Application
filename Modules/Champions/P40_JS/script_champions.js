document.addEventListener('DOMContentLoaded', function() {
    // Initialize the modal to be hidden on page load
    const modal = document.getElementById('championModal');
    modal.style.display = 'none';

    // Dynamically add champions to the grid
    const grid = document.getElementById('championGrid');
    for (let i = 0; i < 52; i++) {
        const championDiv = document.createElement('div');
        championDiv.className = 'champion';
        championDiv.setAttribute('data-name', 'Jax'); // Example attribute, set accordingly
        championDiv.innerHTML = `
            <img src="../P50_Images/jax.jpg" alt="Jax">
            <p>Jax</p>
        `;
        grid.appendChild(championDiv);
    }

    // Search functionality
    const searchBox = document.getElementById('searchBox');
    searchBox.addEventListener('input', function(e) {
        const searchText = e.target.value.toLowerCase();
        const champions = document.querySelectorAll('.champion-grid .champion');

        champions.forEach(champion => {
            const name = champion.querySelector('p').textContent.toLowerCase();
            if (name.includes(searchText)) {
                champion.style.display = ''; // Show matching champions
            } else {
                champion.style.display = 'none'; // Hide non-matching champions
            }
        });
    });

    // Modal display functionality
    const champions = document.querySelectorAll('.champion');
    champions.forEach(champion => {
        champion.addEventListener('click', function() {
            const name = this.getAttribute('data-name'); // Assumes data-name attribute is set
            const imgSrc = this.querySelector('img').src; // Get src from the img element within the clicked champion

            // Update modal content
            document.getElementById('championName').textContent = name;
            document.getElementById('championImage').src = imgSrc;
            document.getElementById('championInfo').textContent = "More info about " + name;

            // Show the modal
            modal.style.display = 'flex';
        });
    });

    // Close the modal when the close button is clicked
    document.querySelector('.close-button').addEventListener('click', function() {
        modal.style.display = 'none';
    });
});

// At the end of your existing champions.js or in a <script> tag in champions.html
document.addEventListener('DOMContentLoaded', function() {
    // Your existing code to generate champions, handle search, and modal interactions...

    // Function to read URL parameters
    function getQueryParam(param) {
        const urlParams = new URLSearchParams(window.location.search);
        return urlParams.get(param);
    }

    const championNameFromURL = getQueryParam('champion');
    if (championNameFromURL) {
        const championElement = document.querySelector(`.champion[data-name="${championNameFromURL}"]`);
        if (championElement) {
            championElement.click(); // Programmatically click the champion to open the modal
        }
    }
});


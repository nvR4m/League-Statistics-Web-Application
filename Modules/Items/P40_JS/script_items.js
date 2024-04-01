document.addEventListener('DOMContentLoaded', function() {
    // Define the categories
    const categories = [
        "starter-items", "consumable-items", "trinkets", 
        "distributed-items", "boots", "basic-items", 
        "epic-items", "legendary-items", "ornn-items"
    ];

    // Placeholder item details
    const placeholderItem = {
        name: "Health Potion",
        imageUrl: "../P50_Images/health_potion.jpg"
    };

    // Function to generate placeholders for each category
    function generatePlaceholders() {
        categories.forEach(category => {
            const grid = document.getElementById(category).querySelector('.item-grid');
            for (let i = 0; i < 20; i++) { // 20 items per category
                const itemDiv = document.createElement('div');
                itemDiv.className = 'item';
                itemDiv.innerHTML = `
                    <img src="${placeholderItem.imageUrl}" alt="${placeholderItem.name}">
                    <p>${placeholderItem.name}</p>
                `;
                grid.appendChild(itemDiv);
            }
        });
    }

    generatePlaceholders();
});

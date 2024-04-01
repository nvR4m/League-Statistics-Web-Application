const champions = ["Aatrox", "Ahri", "Akali", "Alistar", "Amumu", "Anivia", "Annie", "Ashe", "Aurelion Sol", "Azir", "Jax"];

document.getElementById('searchBox').addEventListener('input', function(e) {
    const userInput = e.target.value;
    const inputLowerCase = userInput.toLowerCase();
    const recommendations = champions.filter(champion => champion.toLowerCase().startsWith(inputLowerCase));

    updateRecommendations(recommendations);
    if (userInput) {
        updateAutocompleteSuggestion(recommendations[0], userInput);
    } else {
        updateAutocompleteSuggestion('', '');
    }
});

function updateRecommendations(recommendations) {
    const recommendationBox = document.getElementById('recommendation');

    recommendationBox.innerHTML = '';
    
    const maxRecommendations = 4;

    if (recommendations.length > 0) {
        recommendations.slice(0, maxRecommendations).forEach(recommendation => {
            const div = document.createElement('div');
            div.textContent = recommendation;
            div.addEventListener('click', () => {
                document.getElementById('searchBox').value = recommendation;
                recommendationBox.classList.add('hidden');
                document.getElementById('autocompleteSuggestion').textContent = '';
            });
            recommendationBox.appendChild(div);
        });
        recommendationBox.classList.remove('hidden');
    } else {
        recommendationBox.classList.add('hidden');
    }
}

function updateAutocompleteSuggestion(suggestion, userInput) {
    const autocompleteSuggestionBox = document.getElementById('autocompleteSuggestion');

    if (suggestion && userInput && suggestion.toLowerCase().startsWith(userInput.toLowerCase())) {

        autocompleteSuggestionBox.innerHTML = userInput + '<span class="suggestion-part">' + suggestion.slice(userInput.length) + '</span>';
    } else {
        autocompleteSuggestionBox.innerHTML = '';
    }
}

document.getElementById('searchBox').addEventListener('keydown', function(e) {
    if (e.key === 'Tab' && !e.shiftKey) {
        e.preventDefault(); 
        
        const inputVal = document.getElementById('searchBox').value.toLowerCase();
        const match = champions.find(champion => champion.toLowerCase().startsWith(inputVal));
        
        if (match) {
            document.getElementById('searchBox').value = match; 
            document.getElementById('autocompleteSuggestion').textContent = '';
            document.getElementById('recommendation').classList.add('hidden'); 
        }
    }
});

function checkSearchInput(event) {
    if (event.type === "click" || (event.type === "keydown" && event.key === "Enter")) {
        event.preventDefault(); // Prevent default form submission behavior
        const searchBoxValue = document.getElementById('searchBox').value.trim().toLowerCase();
        
        // Check for "user" search
        if (searchBoxValue === "user") {
            window.location.href = '../../User/P20_HTML/user.html';
        } else {
            // Check if the entered value is a known champion
            const championFound = champions.find(champion => champion.toLowerCase() === searchBoxValue);
            if (championFound) {
                // Redirect to the champions page with the champion's name as a parameter
                window.location.href = `../../Champions/P20_HTML/champions.html?champion=${encodeURIComponent(championFound)}`;
            }
        }
    }
}

// Attach the function to both click and keydown events for the search box and button
document.getElementById('searchButton').addEventListener('click', checkSearchInput);
document.getElementById('searchBox').addEventListener('keydown', checkSearchInput);




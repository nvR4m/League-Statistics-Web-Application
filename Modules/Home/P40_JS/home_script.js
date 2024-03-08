const champions = ["Aatrox", "Ahri", "Akali", "Alistar", "Amumu", "Anivia", "Annie", "Ashe", "Aurelion Sol", "Azir"];

document.getElementById('searchBox').addEventListener('input', function(e) {
    const input = e.target.value.toLowerCase();
    const recommendations = champions.filter(champion => champion.toLowerCase().startsWith(input));
    
    updateRecommendations(recommendations);
});

function updateRecommendations(recommendations) {
    const recommendationBox = document.getElementById('recommendation');
    
    // Clear previous recommendations
    recommendationBox.innerHTML = '';
    
    // Limit the number of recommendations to display
    const maxRecommendations = 4;

    if (recommendations.length > 0) {
        // Use slice to get only the first 4 recommendations
        recommendations.slice(0, maxRecommendations).forEach(recommendation => {
            const div = document.createElement('div');
            div.textContent = recommendation;
            div.addEventListener('click', () => {
                document.getElementById('searchBox').value = recommendation;
                recommendationBox.classList.add('hidden');
            });
            recommendationBox.appendChild(div);
        });
        recommendationBox.classList.remove('hidden');
    } else {
        recommendationBox.classList.add('hidden');
    }
}
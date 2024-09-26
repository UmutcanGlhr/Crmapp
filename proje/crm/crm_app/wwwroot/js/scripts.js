
let logos = document.querySelector('.logos');
let leftArrow = document.querySelector('.left-arrow');
let rightArrow = document.querySelector('.right-arrow');
let logoWidth = 200 + 60; // 200px width + 60px margin

leftArrow.addEventListener('click', function() {
    logos.scrollBy({ left: -logoWidth, behavior: 'smooth' });
});

rightArrow.addEventListener('click', function() {
    logos.scrollBy({ left: logoWidth, behavior: 'smooth' });
});


document.querySelectorAll('header nav ul li a').forEach(anchor => {
    anchor.addEventListener('click', function(e) {
        e.preventDefault();
        const section = document.querySelector(this.getAttribute('href'));
        section.scrollIntoView({ behavior: 'smooth' });
    });
});

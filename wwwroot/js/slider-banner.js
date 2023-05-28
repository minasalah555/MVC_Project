var images_banner = ["univ1.jpeg", "univ2.jpg", "univ3.jpg"];

setInterval(() => {
    var randomImage = images_banner[Math.floor(Math.random() * images_banner.length)];

    document.querySelector(".banner").style.cssText = `background-image: url(/images/${randomImage})`;
}, 2000)
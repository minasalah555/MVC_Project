// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
const responsive = {
    960: {
      items: 1,
    },
  };
 
  
  AOS.init();

const images = [{ name: "Medicine", img: "doctors.jpg" }, { name: "Computer Science", img: "computer-science.jpg" }, { name: "Engineering", img: "engineering.jpg" }];

setInterval(() => {
    var randomImage = images[Math.floor(Math.random() * images.length)];

    document.querySelector(".slider h4").innerText = randomImage.name;
    document.querySelector(".slider").style.cssText = `position: absolute; top: 0; left:0; width: 100%; height:100%;background-image: url(/images/${randomImage.img})`;
}, 2000)
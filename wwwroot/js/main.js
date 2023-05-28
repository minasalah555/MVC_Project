const responsive = {
  0: {
    items: 1,
  },
  320: {
    items: 1,
  },
  560: {
    items: 2,
  },
  960: {
    items: 3,
  },
};

const menu = document.querySelector(".toggle-menu");
menu.addEventListener("click", () => {
  menu.classList.toggle("active");
  menu.parentElement.parentElement.classList.toggle("active");
});

$(".owl-carousel").owlCarousel({
  loop: true,
  autoplay: true,
  autoplayTimeout: 3000,
  dots: true,
  responsive: responsive,
  // nav: true,
});

function goUp() {
  window.scrollTo({
    top: 0,
    behavior: "smooth",
  });
}

AOS.init();

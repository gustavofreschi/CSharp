// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

let botaoCardapio = document.querySelector('.botaoCardapio');

let cardapioNav = document.querySelector('.nav-cardapio');

let cardapio = document.querySelector('.cardapio');

let sobre = document.querySelector('.sobre');

let sobreBotao = document.querySelector('.nav-sobre');

botaoCardapio.addEventListener('click', () => {
    cardapio.scrollIntoView();
})

cardapioNav.addEventListener('click', () => {
    cardapio.scrollIntoView();
})
sobreBotao.addEventListener('click', () => {
    sobre.scrollIntoView();
})

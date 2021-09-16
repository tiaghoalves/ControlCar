// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
(function () {
    const links = document.getElementsByClassName("nav-item");

    for (let link of links) {
        link.addEventListener('click', function (e) {
            e.target.className += "active";

            links.filter(link => link.innerText != e.target.innerText).forEach(link => {
                e.target.className += "";
            });
        });
    }
})();
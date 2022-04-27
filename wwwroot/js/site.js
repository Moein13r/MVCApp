// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
var toggleBtn = document.querySelector('.sidebar-toggle');
var sidebar = document.querySelector('.sidebarr');

toggleBtn.addEventListener('click', function () {
    toggleBtn.classList.toggle('is-closed');
    sidebar.classList.toggle('is-closed');
})

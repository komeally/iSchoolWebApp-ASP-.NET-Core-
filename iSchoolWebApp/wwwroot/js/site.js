// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

//this is to ensure that the body is loaded!
$(function () {
    $('#ugAccordion').accordion({
        collapsible: true,
        active: false,
        heightStyle: "content"
    });
    $("#PeopleTab").tabs();
})

$(document).ready(function () {
    $('#coopTable').DataTable();
    $('#employmentTable').DataTable();

    $("#gradAccordion").accordionjs({
        activeIndex: false
    });
});

$('button').click(function (element) {
    var target = $(element.target);
    var courseBtn = target.hasClass('courseBtn');
    if (courseBtn) {
        $('.course').not(target.next()).collapse('hide');
    } else {
        $('.collapse').collapse('hide');
    }
});

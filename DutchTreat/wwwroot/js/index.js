$(document).ready(function () {

    var theForm = $("#theForm");
    theForm.hide();

    var button = $("#buyButton");
    button.on("click", function () {
        alert("Buying item");
    });

    var productInfo = $(".product-props li");
    productInfo.on("click", function () {
        console.log("You clicked on " + $(this).text());
    });

    var $logInToggle = $("#logInToggle");
    var $popupForm = $(".popup-form");

    $logInToggle.on("click", function () {
        $popupForm.fadeToggle(1000);
    });
});
// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your Javascript code.

function ShowImageButton(ImageId) {
    document.getElementById('ClothingButton ' + ImageId).style.visibility = "visible";
    let theImage = document.getElementById('ClothingImage ' + ImageId);
    theImage.style.backgroundColor = "transparent";
    theImage.style.border = "5px Solid Black";
}

function HideImageButton(ImageId) {
    document.getElementById('ClothingButton ' + ImageId).style.visibility = "hidden";
    let theImage = document.getElementById('ClothingImage ' + ImageId);
    theImage.style.backgroundColor = "transparent";
    theImage.style.border = "1px Solid Black";
}

$(document).ready(function () {
    let count = document.getElementById("ShoppingCartCounter").value;
    let shoppingCartIcon = document.getElementById("ShoppingCartIcon");
    if (count === "1") {
        shoppingCartIcon.innerHTML = shoppingCartIcon.innerHTML + " - " + count + " item";
    }
    else {
        shoppingCartIcon.innerHTML = shoppingCartIcon.innerHTML + " - " + count + " items";
    }

});


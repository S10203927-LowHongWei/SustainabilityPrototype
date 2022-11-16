
var modals = document.getElementsByClassName("modal");
// Get the button that opens the modal
var btns = document.getElementsByClassName("submit");
var spans = document.getElementsByClassName("no");
for (let i = 0; i < btns.length; i++) {
    btns[i].onclick = function () {
        modals[i].style.display = "block";
    }
}
for (let i = 0; i < spans.length; i++) {
    spans[i].onclick = function () {
        modals[i].style.display = "none";
    }
}
btns.onclick = function () {
    modals.style.display = "block";
}

// When the user clicks on <span> (x), close the modal
spans.onclick = function () {
    modals.style.display = "none";
}

// When the user clicks anywhere outside of the modal, close it
newFunction();

function newFunction() {
    window.onclick = function(close) {
        if (close.target == modal) {
            modal.style.display = "none";
        }
    };
}

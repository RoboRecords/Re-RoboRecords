let games = document.getElementsByClassName("game-entry");

let rowButton = document.getElementById("RowButton");
let columnButton = document.getElementById("ColumnButton");

rowButton.addEventListener("click", ActivateRowLayout);
columnButton.addEventListener("click", ActivateColumnLayout);
function ActivateRowLayout() {
    columnButton.classList.remove("bg-primary","border-white");
    rowButton.classList.add("bg-primary","border","border-white");
    SwitchToRowLayout();
}

function ActivateColumnLayout() {
    rowButton.classList.remove("bg-primary", "border-white");
    columnButton.classList.add("bg-primary", "border","border-white");
    SwitchToColumnLayout();
}

function SwitchToRowLayout() {
    for (let i = 0; i < games.length; i++) {
        games[i].classList.remove("col-sm-6", "col-md-4", "col-lg-3");
        games[i].classList.add("col-sm-12");
    }
}

function SwitchToColumnLayout() {
    for (let i = 0; i < games.length; i++) {
        games[i].classList.remove("col-sm-12");
        games[i].classList.add("col-sm-6", "col-md-4", "col-lg-3");
    }
}


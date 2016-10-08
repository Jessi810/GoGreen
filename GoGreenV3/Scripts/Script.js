function listAgencies() {
    var type = document.getElementById("Type").value;

    if (type == "Hospital") {
        document.getElementById("hospital").className = "show";
        document.getElementById("police").className = "hidden";
        document.getElementById("fire").className = "hidden";
        document.getElementById("empty").className = "hidden";
    } else if (type == "Police Department") {
        document.getElementById("hospital").className = "hidden";
        document.getElementById("police").className = "show";
        document.getElementById("fire").className = "hidden";
        document.getElementById("empty").className = "hidden";
    } else if (type == "Fire Station") {
        document.getElementById("hospital").className = "hidden";
        document.getElementById("police").className = "hidden";
        document.getElementById("fire").className = "show";
        document.getElementById("empty").className = "hidden";
    } else if (type == "") {
        document.getElementById("hospital").className = "hidden";
        document.getElementById("police").className = "hidden";
        document.getElementById("fire").className = "hidden";
        document.getElementById("empty").className = "show";
    }
}

function listAgencies2() {
    var type = document.getElementById("Type").value;

    if (type == "Hospital") {
        document.getElementById("hospital").className = "show";
        document.getElementById("police").className = "hidden";
        document.getElementById("fire").className = "hidden";
    } else if (type == "Police Department") {
        document.getElementById("hospital").className = "hidden";
        document.getElementById("police").className = "show";
        document.getElementById("fire").className = "hidden";
    } else if (type == "Fire Station") {
        document.getElementById("hospital").className = "hidden";
        document.getElementById("police").className = "hidden";
        document.getElementById("fire").className = "show";
    } else if (type == "") {
        document.getElementById("hospital").className = "hidden";
        document.getElementById("police").className = "hidden";
        document.getElementById("fire").className = "hidden";
    }
}
document.getElementById("imgInput").onchange = function (e) {
    let reader = new FileReader();
    reader.onload = function (event) {
        document.getElementById("preview").src = event.target.result;
    };
    reader.readAsDataURL(e.target.files[0]);
};

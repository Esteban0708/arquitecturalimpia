var eye = document.getElementById('Eye');
var contra = document.getElementById('contra');

eye.addEventListener("click", function () {
    if (contra.type == "password") {
        contra.type = "text";  
        eye.style.opacity = 0.8;
        eye.src = "/imagenes/ojoo2.png";  
    } else {
        contra.type = "password";  
        eye.style.opacity = 1; 
        eye.src = "/imagenes/ojo.png";  
    }
});

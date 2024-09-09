// Restablecer el tiempo a 15 segundos cada vez que se carga la página
localStorage.setItem('tiempo', 15);

let tiempo = parseInt(localStorage.getItem('tiempo')) || 15;

let timer = setInterval(function() {
    let minutes = Math.floor(tiempo / 60);
    let seconds = tiempo % 60;
    document.getElementById('tiempo').innerHTML = `${minutes}:${seconds < 10 ? '0' : ''}${seconds}`;

    // Guardar el tiempo restante en el almacenamiento local
    localStorage.setItem('tiempo', tiempo);

    // Redirigir cuando el tiempo llega a 0
    if (tiempo <= 0) {
        clearInterval(timer);
        location.href = '/Home/Fin'; // Ajusta la ruta según sea necesario
        localStorage.removeItem('tiempo'); // Eliminar el tiempo del almacenamiento local
    }
    tiempo--;
}, 1000);

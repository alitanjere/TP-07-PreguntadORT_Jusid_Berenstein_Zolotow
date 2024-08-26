// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
function girarRuleta() {
    const ruleta = document.getElementById('ruleta');
    const resultado = document.getElementById('resultado');

    // Genera un número aleatorio para la rotación (0 a 3600 grados para varios giros)
    const rotacion = Math.floor(Math.random() * 3600) + 360;

    // Aplica la animación de rotación
    ruleta.style.transition = 'transform 5s ease-out';
    ruleta.style.transform = `rotate(${rotacion}deg)`;

    // Calcula en qué sección se detiene la ruleta después de girar
    setTimeout(() => {
        const anguloFinal = rotacion % 360;
        let seccion;

        if (anguloFinal >= 0 && anguloFinal < 60) {
            seccion = 'Ciencia';
        } else if (anguloFinal >= 60 && anguloFinal < 120) {
            seccion = 'Deportes';
        } else if (anguloFinal >= 120 && anguloFinal < 180) {
            seccion = 'Historia';
        } else if (anguloFinal >= 180 && anguloFinal < 240) {
            seccion = 'Geografía';
        } else if (anguloFinal >= 240 && anguloFinal < 300) {
            seccion = 'Arte';
        } else {
            seccion = 'Entretenimiento';
        }

        resultado.textContent = `¡La categoría es: ${seccion}!`;
    }, 5000); // El tiempo coincide con la duración de la animación
}

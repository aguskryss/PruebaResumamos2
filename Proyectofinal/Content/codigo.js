document.getElementById('botonValidar').onclick = validar;

function validar() {
  var inputNombre = document.getElementById('inputNombre');
  var textoIngresado = inputNombre.value;

  if (textoIngresado.length > 4) {
    inputNombre.style.color = 'red';
    document.getElementsByClassName('form-nombre')[0].appendChild(crearValidacion());
  } else {
    inputNombre.style.color = 'green';
  }
}

function crearValidacion() {
  var tagValidacion = document.createElement('small');
  tagValidacion.setAttribute('class', 'form-text text-muted');
  tagValidacion.innerHTML = 'El texto ingresado no puede ser mayor a 4 caracteres';
  
  return tagValidacion;
}












/*document.getElementById('parrafo').style.background = 'red';

document.getElementById('parrafo').onmouseover = function() {
  decirHola();
}

document.getElementById('parrafo').onmouseout = function () {
  resetear();
}

function decirHola() {
  var elemento = document.getElementById('parrafo');
  elemento.style.background = 'blue';
  elemento.style.color = 'yellow';
}

function resetear() {
  var elemento = document.getElementById('parrafo');
  elemento.style.background = 'red';
  elemento.style.color = 'black';
}

function crearTitulo() {
  var elementoCreado = document.createElement('h1');
  
  elementoCreado.innerHTML = 'Hola soy un titulo creado dinamicamente';
  elementoCreado.style.textDecoration = 'underline';

  return elementoCreado;
}*/











/*var elemento = document.getElementById('parrafo');

elemento.innerHTML = 'Se cambio el texto';
elemento.style.background = 'red';
elemento.setAttribute('class', 'texto-parrafos');*/


/*function ponerBackground() {
  var elementos = document.getElementsByClassName('texto-parrafos');

  for (var i = 0; i < elementos.length; i++) {
    elementos[i].style.background = 'blue';
  }
}

function crearTitulo() {
  var elementoCreado = document.createElement('h1');
  document.getElementById('acaVaElHtmlCreado').appendChild(elementoCreado);

  elementoCreado.innerHTML = 'Hola soy un titulo creado dinamicamente';
  elementoCreado.style.textDecoration = 'underline';

  return elementoCreado;
}

function eliminarTitulo(elementoABorrar) {
  document.getElementById('acaVaElHtmlCreado').removeChild(elementoABorrar);
}

ponerBackground();

var elemento = crearTitulo();

eliminarTitulo(elemento);
*/

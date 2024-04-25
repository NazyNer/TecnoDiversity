console.log("hola mundo")

function CrearCategoria() {
  $("#ModalCategoria").modal("show");
}

function GuardarCategoria() {
  let id = $("#IdCategoria").val();
  let nombre = $("#NombreCategoria").val();
  $.ajax({
    url: '../../categoria/AgregarCategoria',
    data: {NombreCategoria: nombre, ID: id},
    type: 'POST',
    dataType: 'json',
    success: function (categorias) {
      console.log(categorias);
    }
  })
  console.log(nombre,id);
}

function EditarCategoria() {
  let labelIdCategoria = $("#labelIdCategoria");
  // labelIdCategoria[0].childNodes[0].textContent = "Seleccionar categoria";
  labelIdCategoria[0].innerHTML = `Seleccionar categoria
  <select>
  <option value="0">[Seleccionar Categoria]</option>
  </select>`;

  labelIdCategoria[0].attributes.removeNamedItem("hidden");


  console.log(labelIdCategoria,);
}
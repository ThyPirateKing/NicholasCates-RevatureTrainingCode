async function handleSubmit(e){
  let pageName = document.title;
  if (pageName == 'ClassItem')
    handleItemSubmit(e);
}

async function handleItemSubmit(e) {
  e.preventDefault();
  disable(textarea);
  disable(button);
  show(loadingMessage);
  hide(successMessage);
  hide(errorMessage);
  let quantities = [q1.value];
  try {
      await submitClassItemForm(textarea.value, quantities);
      show(successMessage);
  } catch (err) {
    show(errorMessage);
    errorMessage.textContent = err.message;
  } finally {
    hide(loadingMessage);
    enable(textarea);
    enable(button);
  }
}

function handleTextareaChange() {
  if (textarea.value.length === 0) {
    disable(button);
  } else {
    enable(button);
  }
}

function hide(el) {
  el.style.display = 'none';
}

function show(el) {
  el.style.display = '';
}

function enable(el) {
  el.disabled = false;
}

function disable(el) {
  el.disabled = true;
}

async function submitClassItemForm(name, quantities) {
  // Hit the network.
  await post(event,'characterClassItems', JSON.stringify({
    'className':name,
    'itemID':quantities[0],
  }))
  .then(response => {
    if (!response)
      throw new Error('Something went wrong; null response.')
  })
}


async function getClassItems(){
  hide(errorMessage);
  try{
    await get(event, 'characterClassItems').then(response => {
      console.log("getClassItems: ", response);
      outputBox.textContent = JSON.stringify(response);
    })
  }
  catch (err) {
    show(errorMessage);
    errorMessage.textContent = err.message;
  }
}

async function deleteClassItem(){
  hide(errorMessage);
  hide(successMessage);
  try{
    console.log("Read user input: " + id_delete.value);
    await deleteByID(event,'characterClassItems', id_delete.value)
    .then(response => {
      if (!response)
        throw new Error('Something went wrong; null response.')
      else
        show(successMessage);
    })
  } catch (err) {
    show(errorMessage);
    errorMessage.textContent = err.message;
  }
}

let form = document.getElementById('form');
let textarea = document.getElementById('textarea');
let textarea2 = document.getElementById('textarea2');
let id_delete = document.getElementById('id_delete');
let button = document.getElementById('submitbutton');
let loadingMessage = document.getElementById('loading');
let errorMessage = document.getElementById('error');
let successMessage = document.getElementById('success');
let outputBox = document.getElementById('outputBox')
let q1 = document.getElementById('quantity1')
form.onsubmit = handleSubmit;
textarea.oninput = handleTextareaChange;
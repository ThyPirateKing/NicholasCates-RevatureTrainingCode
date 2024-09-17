async function handleSubmit(e){
  let pageName = document.title;
  if (pageName == 'Item')
    handleItemSubmit(e);
}

async function handleItemSubmit(e) {
  e.preventDefault();
  disable(textarea);
  disable(button);
  show(loadingMessage);
  hide(successMessage);
  hide(errorMessage);
  let quantities = [q1.value,q2.value];
  try {
      await submitItemForm(textarea.value, textarea2.value, quantities);
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

async function submitItemForm(name, type, quantities) {
  // Hit the network.
  await post(event,'items', JSON.stringify({
    'name':name,
    'weight':quantities[0],
    'value':quantities[1],
    'typeOfItem':type
  }))
  .then(response => {
    if (!response)
      throw new Error('Something went wrong; null response.')
  })
}


async function getItems(){
  hide(errorMessage);
  try{
    await get(event, 'items').then(response => {
      console.log("getItems: ", response);
      outputBox.textContent = JSON.stringify(response);
    })
  }
  catch (err) {
    show(errorMessage);
    errorMessage.textContent = err.message;
  }
}

async function deleteItem(){
  hide(errorMessage);
  hide(successMessage);
  try{
    console.log("Read user input: " + textarea_delete.value);
    await deleteByName(event,'items', textarea_delete.value)
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
let textarea_delete = document.getElementById('textarea_delete');
let button = document.getElementById('submitbutton');
let loadingMessage = document.getElementById('loading');
let errorMessage = document.getElementById('error');
let successMessage = document.getElementById('success');
let outputBox = document.getElementById('outputBox')
let q1 = document.getElementById('quantity1')
let q2 = document.getElementById('quantity2')
form.onsubmit = handleSubmit;
textarea.oninput = handleTextareaChange;
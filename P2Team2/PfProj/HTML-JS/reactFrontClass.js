async function handleSubmit(e){
  let pageName = document.title;
  if (pageName == 'Class')
    handleClassSubmit(e);
}

async function handleClassSubmit(e) {
  e.preventDefault();
  disable(textarea);
  disable(button);
  show(loadingMessage);
  hide(successMessage);
  hide(errorMessage);
  let quantities = [q1.value,q2.value,q3.value,q4.value,q5.value]
  try {
      await submitClassForm(textarea.value, quantities);
      show(successMessage);
    }
    catch (err) {
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

async function submitClassForm(name, quantities) {
  // Hit the network.
  await post(event,'characterClasses', JSON.stringify({
    'className':name,
    'baseScore': quantities[0],
    'str': quantities[1],
    'dex': quantities[2],
    'wis': quantities[3],
    'magic': quantities[4]
  }))
  .then(response => {
    if (!response)
      throw new Error('Something went wrong; null response.')
  })
}

async function getClasses(){
  hide(errorMessage);
  try{
    await get(event, 'characterClasses').then(response => {
      console.log("getClasses: ", response);
      outputBox.textContent = JSON.stringify(response);
    })
  }
  catch (err) {
    show(errorMessage);
    errorMessage.textContent = err.message;
  }
}

async function deleteClass(){
  hide(errorMessage);
  hide(successMessage);
  try{
    console.log("Read user input: " + textarea_delete.value);
    await deleteByName(event,'characterClasses', textarea_delete.value)
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
let textarea_delete = document.getElementById('textarea_delete');
let button = document.getElementById('submitbutton');
let loadingMessage = document.getElementById('loading');
let errorMessage = document.getElementById('error');
let successMessage = document.getElementById('success');
let outputBox = document.getElementById('outputBox')
let q1 = document.getElementById('quantity1')
let q2 = document.getElementById('quantity2')
let q3 = document.getElementById('quantity3')
let q4 = document.getElementById('quantity4')
let q5 = document.getElementById('quantity5')
form.onsubmit = handleSubmit;
textarea.oninput = handleTextareaChange;
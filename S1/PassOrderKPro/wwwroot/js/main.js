var x;

const clr = document.getElementById('clearform')
clr.addEventListener('click', event => {
    document.getElementById("soloForm").reset();
})
const sbm = document.getElementById('submitform')
sbm.addEventListener('click', event => {
    var x = document.getElementById('username').value;
    console.log(x);
})

// const thong_tin_nv = document.querySelector('.thong-tin-nv')
// const btn_themmoi = document.querySelector('.btn-add')
// const btn_close = document.querySelector('.btn-close')
// function show(){
//     form.classList.add('open')
// }
// btn_themmoi.onclick = function show(){
//     thong_tin_nv.classList.add('open')
//     thong_tin_nv.classList.remove('display-none')
//     $("#maNV").focus();
// }
// btn_close.onclick = function hide(){
//     thong_tin_nv.classList.remove('open')
//     thong_tin_nv.classList.add('display-none')
// }
const menu = document.querySelector('.menu');
const collapseButton = document.querySelector('.thugon');
const content = document.querySelector('.content')
collapseButton.addEventListener('click', function() {
    menu.classList.toggle('collapsed');
    content.classList.toggle('width-95')
});
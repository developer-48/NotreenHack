const activity= document.querySelector(".activity");

const activityText = document.querySelectorAll(".activity__text");


activity.addEventListener("click", function(event){
   let element = event.target;
   while ((element.classList[0] !== "hurt" 
   && element.classList[0] !== "author" 
   && element.classList[0] !== "more") 
   && element !== this) {
      element = element.parentNode;
   }
   if(element.classList[0] == "hurt" || element.classList[0] == "author"){
      onHurtBtn(element)
   }
   if(element.classList[0] == "more"){
      onMore(element);
   }
})

function onMore(el) {
   document.querySelectorAll(".open-card").forEach((item) => {
      if(el != item.querySelector(".more")){
         item.classList.add("close-card");
         item.classList.remove("open-card");
         item.querySelector(".more").innerText = "Подробнее";
      }
      
   })
   let textBlock = el.closest(".activity__info").querySelector(".activity__text");
   let cardBlock = el.closest(".activity-card");
   textBlock.style.maxHeight = "100%";
   let difference = textBlock.scrollHeight - 91;
   if(difference <=0){
      return false;
   }
   textBlock.style.maxHeight = "72px";
   let close = true;
   
   cardBlock.classList.forEach(item => {
      item == "open-card" ? close = false : "";
   })
   
   if(close){
      textBlock.classList.add("open-text");
      cardBlock.closest(".activity").style.setProperty('--height', cardBlock.clientHeight + difference + "px");
      cardBlock.classList.remove("close-card");
      cardBlock.classList.add("open-card");
      el.innerText = "Свернуть";
     
   }else{
     
      cardBlock.classList.remove("open-card");
      cardBlock.classList.add("close-card");
      el.innerText = "Подробнее";
   }
   
   
   
}

function onHurtBtn(el){
   let hurt;
   let hurtCount;
   for(let item of el.parentNode.children){
      if(item.classList[0] == "hurt"){
         hurt = item;
         hurtCount = item.children[0];
      }  
   }
   let count = false;
   hurt.classList.forEach(item =>item == "hurt__liked" ? count = true : true); 
   if(count){
      hurt.classList.remove("hurt__liked");
      hurtCount.style.display = "none";
   }else{
      hurt.classList.add("hurt__liked");
      hurtCount.style.display = "block";
   }
}


const fileUploader = document.getElementById('file-uploader');
const reader = new FileReader();
const imageGrid = document.getElementById('image-grid');

fileUploader.addEventListener('change', (event) => {
  const files = event.target.files;
  const file = files[0];
  reader.readAsDataURL(file);
  
  reader.addEventListener('load', (event) => {
    const img = document.createElement('img');
    img.style.width = "100%";
    img.style.marginLeft = "0";
    fileUploader.parentNode.removeChild(fileUploader);
    imageGrid.appendChild(img);
    img.src = event.target.result;
    img.alt = file.name;
  });
});

const formAddVol = document.getElementById('form-add__vol');
const poleAddVol = document.querySelector(".two-pole");
const formAddSpn = document.getElementById('form-add__sponsor');
const poleAddSpn = document.querySelector(".one-pole");

formAddVol.addEventListener("click", () => {
   if(formAddVol.checked){
      poleAddVol.classList.add("form-visible");
   }else{
      poleAddVol.value = "";
      poleAddVol.classList.remove("form-visible");
   }
})
formAddSpn.addEventListener("click", () => {
   if(formAddSpn.checked){
      poleAddSpn.classList.add("form-visible");
   }else{
      poleAddSpn.value = "";
      poleAddSpn.classList.remove("form-visible");
   }
})

const addFormBtn = document.querySelector(".submenu__add");
const addForm = document.querySelector(".form-add_wrap");
const closeForm = document.querySelector(".form-add__close");
addFormBtn.addEventListener("click", () => {
   addForm.style.display = "block";
})
closeForm.addEventListener("click", () => {
   addForm.style.display = "none";
})
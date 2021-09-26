const helpForm = document.querySelector(".form-help");
const helpBtn = document.querySelector(".help-btn");
const helpCloseBtn = document.querySelector(".help-close");
console.log(helpBtn)

helpBtn.addEventListener("click", () => {
   helpForm.style.display = "block";
})
helpCloseBtn.addEventListener("click", () => {
   helpForm.style.display = "none";
})
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
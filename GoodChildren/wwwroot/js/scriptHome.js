let navItems = document.querySelectorAll(".header__nav-item");
let nav = document.querySelector(".header__nav");
nav.addEventListener("click", (e) =>{
    if(e.target.classList.contains("header__nav-item") && !e.target.classList.contains("active")){
        for(let item of navItems){
            if(item.classList.contains("active")){
                item.classList.remove("active")
                break;
            }
        }
        e.target.classList.add("active")
    }
})


let moovePlay = document.querySelector(".content__right-button");
let mooveBlock = document.querySelector(".content__videoBlock");
moovePlay.addEventListener("click", () => {
    mooveBlock.style.display = "flex";
    setTimeout(() => {                
        mooveBlock.style.opacity = "1";
    }, 300)
})

mooveBlock.addEventListener("click", (e) => {
    if(e.target.classList.contains("content__videoBlock")){
        mooveBlock.style.opacity = "0";
        setTimeout(() => {                
            mooveBlock.style.display = "none";
        }, 300)
    }
})

let favoritesBtn = document.querySelector(".content__right-favorites");
favoritesBtn.addEventListener("click", ()=>{
    if(!favoritesBtn.classList.contains("active")){
        favoritesBtn.classList.add("active")
    }
    else favoritesBtn.classList.remove("active")
})


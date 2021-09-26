async function postServ(data, url) {
    const response = fetch(url, {
        method: "POST",
        body: data
    })
    if ((await response).status == 200) document.location.href = "Home"
}

let autorization = document.querySelector(".autorization");
let registrationBtn = document.querySelector(".registration");
let volunteerBlock = document.querySelector(".registration-volunteer");
let childrenBlock = document.querySelector(".registration-children");
let volunteerBtn = document.querySelectorAll(".form__buttons-volunteer");
let childrenBtn = document.querySelectorAll(".form__buttons-children");
let volunteer1 = document.querySelector(".form__regist-vol1");
let volunteer2 = document.querySelector(".form__regist-vol2");
let children1 = document.querySelector(".form__regist-child");
let children2 = document.querySelector(".form__regist-orp");
let volunteerContinue = document.querySelector(".volunteer-continue");
let childrenContinue = document.querySelector(".children-continue");
let volunteer2Continue = document.querySelector(".volunteer2-continue");
let children2Continue = document.querySelector(".children2-continue");
let volutreen1Back = document.querySelector(".back-vol1");
let volutreen2Back = document.querySelector(".back-vol2");
let children1Back = document.querySelector(".back-child1");
let children2Back = document.querySelector(".back-child2");
let autorizeBtn = document.getElementById("autorize-join")

autorizeBtn.addEventListener("click", () => {
    let password = document.querySelector(".autoriz #password");
    let login = document.querySelector(".autoriz #login");
    let error = document.querySelector(".autoriz .error");
    if (password.value != "" && login.value != "") {
        const data = new FormData();
        data.append("Email", login.value);
        data.append("Password", password.value);
        postServ(data, "/Account/Login")
        console.log(data)
    }
    else error.innerText = "Необходимо заполнить все поля*"
})
registrationBtn.addEventListener("click", () => {
    volunteerBlock.style.display = "flex";
    volunteerBlock.style.opacity = "1";
    autorization.style.opacity = "0";
    setTimeout(() => {
        autorization.style.display = "none";
    }, 300)
})
for (let item of volunteerBtn) {
    item.addEventListener("click", () => {
        for (let i of volunteerBtn) {            
            i.classList.remove("active")            
        }
        item.classList.add("active");
        volunteerBlock.style.display = "flex";
        volunteerBlock.style.opacity = "1";
        childrenBlock.style.opacity = "0";
        setTimeout(() => {
            childrenBlock.style.display = "none";
            children1.style.display = "block";
            children1.style.opacity = "1";
            children2.style.display = "none";
            children2.style.opacity = "0";
        }, 300)
    })
}

for (let item of childrenBtn) {
    item.addEventListener("click", () => {
        childrenBlock.style.display = "flex";
        childrenBlock.style.opacity = "1";
        volunteerBlock.style.opacity = "0";
        setTimeout(() => {
            volunteerBlock.style.display = "none";
            volunteer1.style.display = "block";
            volunteer1.style.opacity = "1";
            volunteer2.style.display = "none";
            volunteer2.style.opacity = "0";
        }, 300)
    })
}

volutreen1Back.addEventListener("click", () => {
    autorization.style.display = "flex";
    autorization.style.opacity = "1";
    volunteerBlock.style.opacity = "0";
    setTimeout(() => {
        volunteerBlock.style.display = "none";
        volunteer1.style.display = "block";
        volunteer1.style.opacity = "1";
        volunteer2.style.display = "none";
        volunteer2.style.opacity = "0";
    }, 300)
})

children1Back.addEventListener("click", () => {
    autorization.style.display = "flex";
    autorization.style.opacity = "1";
    childrenBlock.style.opacity = "0";
    setTimeout(() => {
        childrenBlock.style.display = "none";
        children1.style.display = "block";
        children1.style.opacity = "1";
        children2.style.display = "none";
        children2.style.opacity = "0";
    }, 300)
})


volutreen2Back.addEventListener("click", () => {
    volunteer1.style.display = "block";
    volunteer1.style.opacity = "1";
    volunteer2.style.opacity = "0";
    setTimeout(() => {
        volunteer2.style.display = "none";
    }, 300)
})

children2Back.addEventListener("click", () => {
    children1.style.display = "block";
    children1.style.opacity = "1";
    children2.style.opacity = "0";
    setTimeout(() => {
        children2.style.display = "none";
    }, 300)
})

volunteerContinue.addEventListener("click", () => {
    let name = document.querySelector(".regist-vol1 #vol-name");
    let date = document.querySelector(".regist-vol1 #vol-date");
    let city = document.querySelector(".regist-vol1 #vol-city");
    let phone = document.querySelector(".regist-vol1 #vol-telephone");
    let error = document.querySelector(".regist-vol1 .error");
    if (name.value != "" && date.value != "" && city.value != "" && phone.value != "") {
        volunteer2.style.display = "block";
        volunteer2.style.opacity = "1";
        volunteer1.style.opacity = "0";
        setTimeout(() => {
            volunteer1.style.display = "none";
        }, 300)
    }
    else error.innerText = "Необходимо заполнить все поля*"
})

childrenContinue.addEventListener("click", () => {
    let name = document.querySelector(".regist-child1 #child-name");
    let date = document.querySelector(".regist-child1 #child-date");
    let houseName = document.querySelector(".regist-child1 #childHouse-name");
    let city = document.querySelector(".regist-child1 #child-city");
    let error = document.querySelector(".regist-child1 .error");

    if (name.value != "" && date.value != "" && houseName.value != "" && city.value != "") {
        children2.style.display = "block";
        children2.style.opacity = "1";
        children1.style.opacity = "0";
        setTimeout(() => {
            children1.style.display = "none";
        }, 300)
    }
    else error.innerText = "Необходимо заполнить все поля*"
})

volunteer2Continue.addEventListener("click", () => {
    let name = document.querySelector(".regist-vol1 #vol-name");
    let date = document.querySelector(".regist-vol1 #vol-date");
    let city = document.querySelector(".regist-vol1 #vol-city");
    let phone = document.querySelector(".regist-vol1 #vol-telephone");
    let login = document.querySelector(".regist-vol2 #vol-email");
    let password = document.querySelector(".regist-vol2 #vol-new_password");
    let passwordTwo = document.querySelector(".regist-vol2 #vol-password");
    let error = document.querySelector(".regist-vol2 .error");
    if (login.value != "" && password.value != "" && passwordTwo.value != "") {
        if (password.value == passwordTwo.value) {
            let volunt = "";
            for (let i of volunteerBtn) {
                if (i.classList.contains("active")) volunt = i.innerText;                
                
            }
            console.log(volunt)
            const data = new FormData();
            data.append("Email", login.value);
            data.append("Password", password.value);
            data.append("Role", volunt);
            data.append("fullName", name.value);
            data.append("BirthDate", date.value);
            data.append("cityChillHouse", city.value);
            data.append("PhoneNum", phone.value);
            postServ(data, "/Account/Register")
        }
        else error.innerText = "Пороли не совпадают*"
    }
    else error.innerText = "Необходимо заполнить все поля*"
})

children2Continue.addEventListener("click", () => {
    let name = document.querySelector(".regist-child1 #child-name");
    let date = document.querySelector(".regist-child1 #child-date");
    let houseName = document.querySelector(".regist-child1 #childHouse-name");
    let city = document.querySelector(".regist-child1 #child-city");
    let login = document.querySelector(".regist-child2 #child-new_login");
    let password = document.querySelector(".regist-child2 #child-new_password");
    let passwordTwo = document.querySelector(".regist-child2 #child-password");
    let phone = document.querySelector(".regist-child2 #child-telephone");
    let error = document.querySelector(".regist-child2 .error");
    if (login.value != "" && password.value != "" && passwordTwo.value != "" && phone.value != "") {
        if (password.value == passwordTwo.value) {
            const data = new FormData();
            data.append("Email", login.value);
            data.append("Password", password.value);
            data.append("Role", "Ребенок");
            data.append("fullName", name.value);
            data.append("BirthDate", date.value);
            data.append("cityChillHouse", `${city.value},${houseName.value}`);
            data.append("PhoneNum", phone.value);
            postServ(data, "/Account/Register")
        }
        else error.innerText = "Пороли не совпадают*"
    }
    else error.innerText = "Необходимо заполнить все поля*"
})
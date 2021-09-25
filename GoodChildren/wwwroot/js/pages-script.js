let user = {
    username: "Сагариев Юсуп Ибрагимович",
    usernameChat: "Сагариев Юсуп",
    id: "4855",
}
let userRecivier = {
    username: "Бараев Аюб Алиханович",
    usernameChat: "Бараев Аюб",
    id: "2378",
}

// hubConnection.on("Receive", function (message, userName) {
//     let date = new Date()
//     let datevalue = {date: `${date.getDate()}.${(date.getMonth() + 1 < 10)? `0${date.getMonth() + 1}`: date.getMonth() + 1}`,   time: `${new Date(01, 11, 2020, date.getUTCHours() + 3).getHours()}:${(date.getUTCMinutes() + 1 < 10)? `0${date.getUTCMinutes() + 1}`: date.getUTCMinutes() + 1}`};
//     addComment(message, userName, datevalue, document.querySelector(".chat__messages"))
// });

// document.querySelector(".chat__sendingBlock-send").addEventListener("click", function (e) {
//     let message = document.querySelector(".chat__sendingBlock-message").value;
//     let to = userRecivier.username;
//     hubConnection.invoke("Send", message, to);
//     let message = document.querySelector(".chat__sendingBlock-message").value;
//     let date = new Date()
//     let datevalue = {date: `${date.getDate()}.${(date.getMonth() + 1 < 10)? `0${date.getMonth() + 1}`: date.getMonth() + 1}`,   time: `${new Date(01, 11, 2020, date.getUTCHours() + 3).getHours()}:${(date.getUTCMinutes() + 1 < 10)? `0${date.getUTCMinutes() + 1}`: date.getUTCMinutes() + 1}`}
//     addComment(message, user.usernameChat, datevalue, document.querySelector(".chat__messages"))
// });

document.querySelector(".chat__sendingBlock-send").addEventListener("click", function (e) {
    let message = document.querySelector(".chat__sendingBlock-message").value;
    let date = new Date()
    addComment(message, user.usernameChat, {date: `${date.getDate()}.${(date.getMonth() + 1 < 10)? `0${date.getMonth() + 1}`: date.getMonth() + 1}`,   time: `${new Date(01, 11, 2020, date.getUTCHours() + 3).getHours()}:${(date.getUTCMinutes() + 1 < 10)? `0${date.getUTCMinutes() + 1}`: date.getUTCMinutes() + 1}`}, document.querySelector(".chat__messages"))
});

let addComment = (message, username, time, comments) =>{
    let commentElem = document.createElement("div")
    commentElem.classList.add("commentsListElem");
    let comment = document.createElement("div");
    comment.classList.add("commentsListTitle");
    let author = document.createElement("p");
    author.classList.add("commentName")
    author.innerText = username;
    comment.appendChild(author)
    author = document.createElement("p");
    let date = new Date();
    author.innerText = `${(time.date == `${date.getDate()}.${(date.getMonth() + 1 < 10)? `0${date.getMonth() + 1}`: date.getMonth() + 1}`)? `Сегодня ${time.time}` :`${time.date} ${time.time}`}`
    comment.appendChild(author);
    commentElem.appendChild(comment);
    comment = document.createElement("p")
    comment.innerText = message;
    comment.classList.add("commentsText");
    commentElem.appendChild(comment);
    comments.appendChild(commentElem);
}

const isValid = (str) =>{
    return !/[~`#$\^&\[\]\\';/{}|\\<>]/g.test(str);
}
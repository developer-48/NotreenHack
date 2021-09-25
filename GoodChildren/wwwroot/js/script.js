"use strict";

var telephone = document.querySelectorAll(".telephone");

for (let item of telephone) {
    item.oninput = function (event) {
        var phone = event.target.value;

        if (phone.length == 1) {
            phone = "+7(" + phone;
        }

        event.target.value = phone;

        if (phone.length == 6) {
            event.target.value = phone + ")";
        }

        if (phone.length == 10 || phone.length == 13) {
            event.target.value = phone + "-";
        }

        if (phone.length > 16) {
            event.target.value = phone.substr(0, 16);
        }
    };
}
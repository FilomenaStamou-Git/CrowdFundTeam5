﻿// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.


// ---------------------------USER------------------------------
function addUser() {
    actionUrl = "/api/user"
    actiontype = "POST"
    actionDataType = "json"

    sendData = {
        "firstName": $("#FirstName").val(),
        "lastName": $("#LastName").val(),
        "email": $("#Email").val(),
        "password": $("#Password").val()
    }


    $.ajax({
        url: actionUrl,
        dataType: actionDataType,
        type: actiontype,
        data: JSON.stringify(sendData),
        contentType: 'application/json',
        processData: false,

        success: function (data, textStatus, jQxhr) {

            alert(JSON.stringify(data))
            window.open("/Home/Dashboard", "_self")
        },
        error: function (jqXhr, textStatus, errorThrown) {
            alert(errorThrown);
        }

    });

}


function updateUser() {
    id = $("#Id").val()

    actionUrl = "/api/user/" + id
    actiontype = "PUT"
    actionDataType = "json"

    sendData = {
        "firstName": $("#FirstName").val(),
        "lastName": $("#LastName").val(),
        "email": $("#Email").val(),
        "password": $("#Password").val()
    }


    $.ajax({
        url: actionUrl,
        dataType: actionDataType,
        type: actiontype,
        data: JSON.stringify(sendData),
        contentType: 'application/json',
        processData: false,

        success: function (data, textStatus, jQxhr) {

            alert(JSON.stringify(data))

            window.open("/home/users", "_self")
        },
        error: function (jqXhr, textStatus, errorThrown) {
            alert(errorThrown);
        }

    });

}


function deleteUser() {

    id = $("#Id").val()

    actionUrl = "/api/user/" + id
    actiontype = "DELETE"
    actionDataType = "json"

    $.ajax({
        url: actionUrl,
        dataType: actionDataType,
        type: actiontype,

        contentType: 'application/json',
        processData: false,

        success: function (data, textStatus, jQxhr) {

            alert(JSON.stringify(data))
        },
        error: function (jqXhr, textStatus, errorThrown) {
            alert(errorThrown);
        }

    });
}



function findToUpdateUser() {

    id = $("#Id").val()
    actionUrl = "/Home/UpdateUser/" + id

    window.open(actionUrl, "_self");

}





// --------------------PROJECT----------------------------

function addProject() {
    var actionUrl = "/api/project"
    var input = document.getElementById('Picture');
    var files = input.files;
    var formData = new FormData();


    for (var i = 0; i != files.length; i++) {
        formData.append("Picture", files[i]);
    }

        formData.append("Title", $('#Title').val());
        formData.append("Description", $("#Description").val());
        formData.append("Category", $("#Category").val());
        formData.append("Update", $("#Update").val());
        formData.append("Amount", $("#Amount").val());


    $.ajax({
        url: actionUrl,
        data: formData,
        processData: false,
        contentType: false,
        type: "POST",

        success: function (data) {
            window.open("/home/projects", "_self")
        },
        error: function (jqXhr, textStatus, errorThrown) {
            alert("Error from server:" + errorThrown);
        }

    });

}

function updateProject() {
    id = $("#Id").val()

    actionUrl = "/api/project/" + id
    actiontype = "PUT"
    actionDataType = "json"

    sendData = {
        "Title": $("#Title").val(),
        "Description": $("#Description").val(),
        "Category": $("#Category").val(),
        "Update": $("#Update").val(),
        "Amount": $("Amount").val(),
        "Photo": $("Photo").val(),
        "Video": $("Video").val()
    }


    $.ajax({
        url: actionUrl,
        dataType: actionDataType,
        type: actiontype,
        data: JSON.stringify(sendData),
        contentType: 'application/json',
        processData: false,

        success: function (data, textStatus, jQxhr) {

            alert(JSON.stringify(data))

            window.open("/home/projects", "_self")
        },
        error: function (jqXhr, textStatus, errorThrown) {
            alert(errorThrown);
        }

    });

}

function findToUpdateProject() {

    id = $("#Id").val()
    actionUrl = "/Home/UpdateProject/" + id

    window.open(actionUrl, "_self");

}

function searchProject() {

    searchText = $("#searchText").val()
    actionUrl = "/Home/SearchProjectDisplay?text=" + searchText

    window.open(actionUrl, "_self");

}


    function handle(e) {
        if (e.keyCode === 13) {
            e.preventDefault(); 
            searchProject();
        }


    }

let $successAlert = $('#create-profile-success')
// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

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
            window.open("/home/users", "_self")
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

debugger;

/*
function addPackage() {
    actionUrl = "/api/package"
    actiontype = "POST"
    actionDataType = "json"

    sendData = {
        "amount": $("#Amount").val(),
        "description": $("#Description").val(),
        "reward": $("#Reward").val()
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
            window.open("/home/packages", "_self")
        },
        error: function (jqXhr, textStatus, errorThrown) {
            alert(errorThrown);
        }

    });

}
*/

function addPackage() {
    var actionUrl = "/api/package"
    var formData = new FormData();

    formData.append("amount", $('#Amount').val());
    formData.append("description", $('#Description').val());
    formData.append("reward", $('#Reward').val());
    formData.append("isactive", $('#IsActive').val());
 
    $.ajax(
        {
            url: actionUrl,
            data: JSON.stringify(formData),
            contentType: "application / json; odata=verbose", //'application/json',
            dataType: 'json',
            type: "POST",
            success: function (data, textStatus, jQxhr) {
                alert(JSON.stringify(data))
                window.open("/home/packages", "_self")
            },
            error: function (jqXhr, textStatus, errorThrown) {
                alert("Error from server: " + errorThrown);
            }
        }
    );
       
}

//function changeIsActive() {}

function updatePackage() {
    id = $("#Id").val()
    actionUrl = "/api/package/" + id

    formData = new FormData();

    formData.append("amount", $('#Amount').val());
    formData.append("description", $('#Description').val());
    formData.append("reward", $('#Reward').val());
    formData.append("isactive", $('#IsActive').val());

    $.ajax(
        {
            url: actionUrl,
            data: JSON.stringify(formData),
            processData: false,
            contentType: 'application/json',
            type: "PUT",
            success: function (data) {
                window.open("/home/packages", "_self")
            },
            error: function (jqXhr, textStatus, errorThrown) {
                alert("Error from server: " + errorThrown);
            }
        }
    );



}

function deletePackage() {

    id = $("#Id").val()

    actionUrl = "/api/package/" + id
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

function findToUpdatePackage() {

    id = $("#Id").val()
    actionUrl = "/Home/UpdatePackageWithDetails/" + id

    window.open(actionUrl, "_self");

}
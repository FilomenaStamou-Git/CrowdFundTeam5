// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

function getUserId() {
    return localStorage.getItem('userId');
}

if (getUserId()) {
    $('#logout-btn').show();
    $('#login-btn').hide();


}


// Events

$('#login-btn').on('click', function () {
    var Email = $('#userEmail').val();
    var Password = $('#userPassword').val();

    var loginOptions = {
        email: Email,
        password: Password
    };

    $.ajax({
        url: "/home/login",
        contentType: 'application/json',
        type: 'POST',
        data: JSON.stringify(loginOptions),
        success: function (data) {
            localStorage.setItem('userId', data.getUserId);
            window.open("/Home/Projects", "_self")
            //$('#login-btn').hide();
            $('#logout-btn').show();
           

        },
        error: function () {
            alert('Login denied');
        }
    });
});

$('#logout-btn').on('click', function () {
    localStorage.removeItem('userId');
    $('#logout-btn').hide();
    $('#login-btn').show();

});


// ---------------------------USER------------------------------
function addUser() {
    actionUrl = '/api/user'
    actiontype = 'POST'
    actionDataType = 'json'

    sendData = {
        'firstName': $('#FirstName').val(),
        'lastName': $('#LastName').val(),
        'email': $('#Email').val(),
        'password': $('#Password').val()
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
            window.open('/Home/Dashboard', '_self')
        },
        error: function (jqXhr, textStatus, errorThrown) {
            alert(errorThrown);
        }

    });

}

function updateUser() {
    id = $('#Id').val()

    actionUrl = '/api/user/' + id
    actiontype = 'PUT'
    actionDataType = 'json'

    sendData = {
        'firstName': $('#FirstName').val(),
        'lastName': $('#LastName').val(),
        'email': $('#Email').val(),
        'password': $('#Password').val()
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

            window.open('/home/users', '_self')
        },
        error: function (jqXhr, textStatus, errorThrown) {
            alert(errorThrown);
        }

    });

}

function deleteUser() {

    id = $('#Id').val()

    actionUrl = '/api/user/' + id
    actiontype = 'DELETE'
    actionDataType = 'json'

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

    id = $('#Id').val()
    actionUrl = '/Home/UpdateUser/' + id

    window.open(actionUrl, '_self');

}



// --------------------PROJECT----------------------------



let successAlert = $('#success-alert-project').hide();
let dangerAlert = $('#danger-alert-project').hide();

btn = $('#addProject').on('click', () => {
    debugger;
    var actionUrl = '/api/project/'
    var input = document.getElementById('Picture');
    var files = input.files;
    var formData = new FormData();


    for (var i = 0; i != files.length; i++) {
        formData.append('Picture', files[i]);
    }

        formData.append('Title', $('#Title').val());
        formData.append('Description', $('#Description').val());
        formData.append('Categories', $('#Categories').val());
        formData.append('Amount', $('#Amount').val());
        formData.append('UserId', $('#UserId').val());


    $.ajax({
        url: actionUrl,
        data: formData,
        processData: false,
        contentType: false,
        type: 'POST',

        success: function (data) {

            $('#success-alert-project').fadeIn(1000);
            window.open('/home/addpackage', '_self')

        },
        error: function (jqXhr, textStatus, errorThrown) {
            console.log('Error from server:' + errorThrown);
            $('#danger-alert-project').fadeIn(2000);
        }

    });

})




btn = $('#updateProject').on('click', () => {
    debugger;
    let actionUrl = '/api/project/'
    let input = document.getElementById('Picture');
    let files = input.files;
    let formData = new FormData();
    let actionType ='PUT'

    for (var i = 0; i != files.length; i++) {
        formData.append('Picture', files[i]);
    }

    formData.append('Title', $('#Title').val());
    formData.append('Description', $('#Description').val());
    formData.append('Categories', $('#Categories').val());
    formData.append('Amount', $('#Amount').val());
    formData.append('UserId', $('#UserId').val());


    $.ajax({
        url: actionUrl,
        data: formData,
        processData: false,
        contentType: false,
        type: actionType,

        success: function (data) {

            $('#success-alert-project').fadeIn(1000);

        },
        error: function (jqXhr, textStatus, errorThrown) {
            console.log('Error from server:' + errorThrown);
            $('#danger-alert-project').fadeIn(2000);
        }

    });

})

//function updateProject() {
//    debugger;
//    id = $('#ProjectId').val()

//    actionUrl = '/api/project/' + id
//    actiontype = 'PUT'
//    actionDataType = 'json'

//    sendData = {
//        'Title': $('#Title').val(),
//        'Description': $('#Description').val(),
//        'Categories': $('#Categories').val(),
//        'Update': $('#Update').val(),
//        'Amount': $('Amount').val(),
//        'Photo': $('Photo').val(),
//    }

//    $.ajax({
//        url: actionUrl,
//        data: sendData,
//        processData: false,
//        contentType: false,
//        type: actiontype,

//        success: function (data) {

//            window.open('/home/projects', '_self');

//        },
//        error: function (jqXhr, textStatus, errorThrown) {
//            console.log('Error from server:' + errorThrown);
//            $('#danger-alert-project').fadeIn(2000);
//        }

//    });
//}

//------------------------------- PACKAGE ----------------------------------------

                    /* Create Packages */

        btn = $('.js-submit-package-create').on('click', () => {
        let ProjectId = parseInt($('#js-ProjectId-Package').val());


        debugger;
            for (var i = 1; i <= 3; i++) {
        let description = $('#Description' + i).val();
        let reward = parseInt($('#Reward' + i).val());


        let data = {
            Description: description,
            Reward: reward,
            ProjectId: ProjectId
             }
        $.ajax({
            type: 'Post',
            url: '/api/package',
            contentType: 'application/json',
            data: JSON.stringify(data),
            processData: false,


            success: function (data) {
                window.open("/home/dashboard", "_self")

            },
            error: function (jqXhr, textStatus, errorThrown) {
                alert("Error from server:" + errorThrown);
            }

            });
        }

    });


//btn = $('.js-submit-package-create').on('click', () => {
//    debugger;
//    var actionUrl = '/api/package/'
    
//    var formData = new FormData();

//    for (var i = 1; i <= 3; i++) {


//            formData.append('Description', $('#Description' + 1).val());
//            formData.append('Reward', $('#Reward' + 1).val());
//            formData.append('Categories', $('#Categories' + 1).val());
//            formData.append('Amount', $('#Amount' + 1).val());
//            formData.append('ProjectId', $('#js-ProjectId-package').val());


//            $.ajax({
//                url: actionUrl,
//                data: JSON.stringify(formData),
//                processData: false,
//                contentType: 'application/json',
//                type: 'POST',

//                success: function (data) {

//                    $('#success-alert-project');
//                    window.open('/home/packages', '_self')

//                },
//                error: function (jqXhr, textStatus, errorThrown) {
//                    console.log('Error from server:' + errorThrown);
//                    $('#danger-alert-project').fadeIn(2000);
//                }

//            });
//        }
//    })









































function updatePackage() {
    id = $('#Id').val()

    actionUrl = '/api/package/' + id
    actiontype = 'PUT'
    actionDataType = 'json'
    var input = document.getElementById('Picture');
    var files = input.files;
    var formData = new FormData();

    for (var i = 0; i != files.length; i++) {
        formData.append('Picture', files[i]);
    }

    formData.append('amount', $('#Amount').val());
    formData.append('description', $('#Description').val());
    formData.append('reward', $('#Reward').val());

    $.ajax({
        url: actionUrl,
        data: formData,
        processData: false,
        contentType: false,
        type: 'PUT',

        success: function (data) {
            window.open('/home/packages', '_self')
        },
        error: function (jqXhr, textStatus, errorThrown) {
            alert('Error from server:' + errorThrown);
        }

    });
}

function deletePackage() {

    id = $('#Id').val()

    actionUrl = '/api/package/' + id
    actiontype = 'DELETE'
    actionDataType = 'json'

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
    id = $('#Id').val()
    actionUrl = '/Home/UpdatePackageWithDetails/' + id

    window.open(actionUrl, '_self');

    $.ajax({
        url: actionUrl,
        dataType: actionDataType,
        type: actiontype,
        data: JSON.stringify(sendData),
        contentType: 'application/json',
        processData: false,

        success: function (data, textStatus, jQxhr) {

            alert(JSON.stringify(data))

            window.open('/home/projects', '_self')
        },
        error: function (jqXhr, textStatus, errorThrown) {
            alert(errorThrown);
        }

    });
}

function findToUpdateProject() {

    id = $('#Id').val()
    actionUrl = '/Home/UpdateProject/' + id

    window.open(actionUrl, '_self');

}

ProjectDetails = $('.js-project-details').on('click', () => {
    id = $('.js-ProjectId').val()
    actionUrl = '/Home/ProjectDetails/' + id
    window.open(actionUrl, '_self');
})




searchBtn = $('.searchProject').on('click', () => {


        searchText = $('#searchText').val()
        actionUrl = '/Home/SearchProjectDisplay?text=' + searchText

        window.open(actionUrl, '_self');
})

searchEnter = $('.handleEnter').on('keypress', function (e) {

    if (e.keyCode == 13) {
        // Cancel the default action on keypress event
        e.preventDefault();

        searchText = $('#searchText').val()
        actionUrl = '/Home/SearchProjectDisplay?text=' + searchText

        window.open(actionUrl, '_self');
    }
}
);

//let $successAlert = $('#create-profile-success')
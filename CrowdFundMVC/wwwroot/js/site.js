﻿// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.



                /* User Id */



function getUserId() {
    return localStorage.getItem('userId');
}

if (getUserId()) {
    $('#logout-btn').show();
    $('#updateProjectbtn').show();
    $('#deleteProjectbtn').show();
    $('#login-btn').hide();
    $('#SignupBtn').hide();

}

$('#login-btn1').on('click', function () {
    debugger;

    let Email = $('#userEmail').val();
    let Password = $('#userPassword').val();

    let loginOptions = {
        email: Email,
        password: Password
    };

    $.ajax({
        url: "/home/login",
        contentType: 'application/json',
        type: 'POST',
        data: JSON.stringify(loginOptions),
        success: function (data) {
            localStorage.setItem('userId', data.userId);
            window.open('/Home/dashboard/',"_self") //+ localStorage.getItem('userId')
            $('#logout-btn').show();
            $('#updateProjectbtn').show();
            $('#deleteProjectbtn').show();
            $('#SignupBtn').hide();
        },
        error: function () {
            alert('Login denied');
        }
    });
});

$('#logout-btn').on('click', function () {
    localStorage.removeItem('userId');
    $('#logout-btn').hide();
    $('#updateProjectbtn').hide();
    $('#deleteProjectbtn').hide();
    $('#SignupBtn').show();
    $('#login-btn').show();


});

/* View my projects */

$('#js-myprojects').on('click', () => {
    debugger;
    actionUrl = '/Home/myprojects/' + localStorage.getItem('userId')
    window.open(actionUrl, '_self');
})
/* View my fundings */

$('#js-myfunds').on('click', () => {
    debugger;
    actionUrl = '/Home/myfunds/' + localStorage.getItem('userId')
    window.open(actionUrl, '_self');
})




                /* Add User*/

addUser = $('.addUser').on('click', () => {
    actionUrl = '/api/user/'
    actiontype = 'POST'
    actionDataType = 'json'
    debugger
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
            $('#success-alert-project').fadeIn(800);
            setTimeout(function () {
                window.open("/home/dashboard", "_self");
            }, 4000);
        },
        error: function (jqXhr, textStatus, errorThrown) {
            $('#danger-alert-project').fadeIn(800);
            console.log(errorThrown);
        }

    });
});


                    /* Update User */

updateUser = $('.updateUser').on('click', () => {
    debugger;
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
            $('#success-alert-project').fadeIn(500);
            setTimeout(function () {
                window.open("/home/dashboard", "_self");
            }, 3000);
        },
        error: function (jqXhr, textStatus, errorThrown) {

            console.log('Error from server:' + errorThrown);
            $('#danger-alert-project').fadeIn(1000);
        }

    });
});

                       /* Delete User */

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



// --------------------PROJECT----------------------------//


btn = $('#addProject').on('click', () => {
    debugger;
    let actionUrl = '/api/project/'
    let input = document.getElementById('Picture');
    let files = input.files;
    let formData = new FormData();


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
            debugger;
            $('#success-alert-project').fadeIn(1000);
            window.open('/home/addpackage/' + data.id, '_self')

        },
        error: function (jqXhr, textStatus, errorThrown) {
            console.log('Error from server:' + errorThrown);
            $('#danger-alert-project').fadeIn(2000);
        }

    });

})







//    formData.append('Title', $('#Title').val());
//    formData.append('Description', $('#Description').val());
//    formData.append('Categories', $('#Categories').val());
//    formData.append('Amount', $('#Amount').val());
//    formData.append('UserId', $('#UserId').val());


//    $.ajax({
//        url: actionUrl,
//        data: formData,
//        processData: false,
//        contentType: false,
//        type: 'PUT',

//        success: function (data) {

//            $('#success-alert-project').fadeIn(1000);

//        },
//        error: function (jqXhr, textStatus, errorThrown) {
//            console.log('Error from server:' + errorThrown);
//            $('#danger-alert-project').fadeIn(2000);
//        }

//    });

//})

btnUpdate= $('#updateProject').on('click', () => {
    debugger;
    id = $('#ProjectId').val()

    actionUrl = '/api/project/' + id
    actiontype = 'PUT'
    actionDataType = 'json'

    sendData = {
        'Title': $('#Title').val(),
        'Description': $('#Description').val(),
        'Categories': $('#Categories').val(),
        'Update': $('#Update').val(),
        'Amount': $('#Amount').val(),
        // 'Photo': $('#Photo').val(),
    }

    $.ajax({
        url: actionUrl,
        data: JSON.stringify(sendData),
        processData: false,
        contentType: 'application/json',
        type: actiontype,

        success: function (data) {

            window.open('/home/projects', '_self');

        },
        error: function (jqXhr, textStatus, errorThrown) {
            console.log('Error from server:' + errorThrown);
            $('#danger-alert-project').fadeIn(2000);
        }

    });
});

//------------------------------- PACKAGE ----------------------------------------//

                        /* Add Packages */

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
                $('#success-alert-project').fadeIn(1000);
                setTimeout(function () {
                    window.open("/home/dashboard", "_self");
                }, 5000);

            },
            error: function (jqXhr, textStatus, errorThrown) {
                $('#danger-alert-project').fadeIn(2000);
                console.log("Error from server:" + errorThrown);
            }
        });
    }

});

                /* Update Package */

Updatepackage = $('#js-update-Package').on('click', () => {
    debugger;
    let id = $('#Id').val()

    actionUrl = '/api/package/' + id
    actiontype = 'PUT'
    actionDataType = 'json'

    sendData = {
        'Description': $('#Description').val(),
        'Reward': parseFloat($('#Reward').val()),
    }

    $.ajax({
        url: actionUrl,
        dataType: actionDataType,
        type: actiontype,
        data: (JSON.stringify(sendData)),
        contentType: 'application/json',
        processData: false,

        success: function (data, textStatus, jQxhr) {
            $('#success-alert-project').fadeIn(1000);
            setTimeout(function () {
                window.open("/home/dashboard", "_self");
            }, 5000);
        },
        error: function (jqXhr, textStatus, errorThrown) {
            $('#danger-alert-project').fadeIn(2000);
            console.log("Error from server:" + errorThrown);
        }

    });
})

$('#findtoupdatePackage').on('click', () => {
    debugger;
    id = $('#Id').val()
    actionUrl = '/Home/UpdatePackageWithDetails/' + id

    window.open(actionUrl, '_self');

})


                /* Delete Package */

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

var successAlert = $('#success-alert-project').hide();
var dangerAlert = $('#danger-alert-project').hide();



function findToUpdateProject() {

    id = $('#Id').val()
    actionUrl = '/Home/UpdateProject/' + id

    window.open(actionUrl, '_self');

}









                /* Search In Navbar */

searchBtn = $('.searchProject').on('click', () => {

    searchText = $('#searchText').val()
    actionUrl = '/Home/SearchProjectDisplay?text=' + searchText

    window.open(actionUrl, '_self');
})

searchEnter = $('.handleEnter').on('keypress', function (e) {

    if (e.keyCode == 13) {
        e.preventDefault();

        searchText = $('#searchText').val()
        actionUrl = '/Home/SearchProjectDisplay?text=' + searchText

        window.open(actionUrl, '_self');
    }
}
);


                    /*Search In filters*/

searchBtnFilter = $('.searchProjectFilter').on('click', () => {

    searchTextFilter = $('#searchTextFilter').val()
    actionUrl = '/Home/SearchProjectDisplay?text=' + searchTextFilter

    window.open(actionUrl, '_self');
})

searchEnterFilter = $('.handleEnterFilter').on('keypress', function (e) {

    if (e.keyCode == 13) {
        // Cancel the default action on keypress event
        e.preventDefault();

        searchTextFilter = $('#searchTextFilter').val()
        actionUrl = '/Home/SearchProjectDisplay?text=' + searchTextFilter

        window.open(actionUrl, '_self');
    }
}
);

$('#searchControlSelectCategory').on('change', () => {
    const id = parseInt($('#searchControlSelectCategory option:selected').val());
    actionUrl = '/home/category?id=' + id
    window.open(actionUrl, '_self');
})
                    




                /*Show Picture Name when adding it */

$('#Picture').on('change', function () {
    //get the file name
    let fileName = $(this).val();
    //replace the "Choose a file" label
    $(this).next('.custom-file-label').html(fileName);
})


                        /* Fund Project */


fundProject = $('#packages').on('click', (e) => {
    debugger;
    const target = e.target.id;
    if (target.includes('fundProject-')){
        const packageId = parseInt(target.split('-')[1]);
        const reward = parseFloat(e.target.parentElement.querySelector('#js-reward-fund').value);
        actionUrl = '/home/fundproject'
        actiontype = 'PUT'
        actionDataType = 'json'
        fundUserId = parseInt(localStorage.getItem('userId'))
        ProjectFundId = parseInt($('#js-projectId-fund').val())

        sendData = {
            'Projectid': ProjectFundId,
            'Packageid': packageId,
            'Userid': fundUserId,
            'Reward': reward
        }

        $.ajax({
            url: actionUrl,
            dataType: actionDataType,
            type: actiontype,
            data: (JSON.stringify(sendData)),
            contentType: 'application/json',
            processData: false,

            success: function (data, textStatus, jQxhr) {

                window.open('/home/projects/', '_self');
            },
            error: function (jqXhr, textStatus, errorThrown) {
                $('#success-alert-project').fadeIn(500);
                setTimeout(function () {
                    window.open('/home/projectdetails/' + ProjectFundId, '_self');
                }, 3000);
            }
        });
    }
})
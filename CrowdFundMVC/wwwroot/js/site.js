﻿// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.


//function store() {
//    var firstName = document.getElementById('FirstName');
//    var lastName = document.getElementById('LastName');
//    var email = document.getElementById('Email');
//    var pw = document.getElementById('Password');
    //var lowerCaseLetters = /[a-z]/g;
    //var upperCaseLetters = /[A-Z]/g;
    //var numbers = /[0-9]/g;

    //if (name.value.length == 0) {
    //    alert('Please fill in email');

    //} else if (pw.value.length == 0) {
    //    alert('Please fill in password');

    //} else if (name.value.length == 0 && pw.value.length == 0) {
    //    alert('Please fill in email and password');

    //} else if (pw.value.length > 8) {
    //    alert('Max of 8');

    //} else if (!pw.value.match(numbers)) {
    //    alert('please add 1 number');

    //} else if (!pw.value.match(upperCaseLetters)) {
    //    alert('please add 1 uppercase letter');

    //} else if (!pw.value.match(lowerCaseLetters)) {
    //    alert('please add 1 lovercase letter');

    //} else {
    //debugger;
    //localStorage.setItem('firstName', firstName.value);
    //localStorage.setItem('lastName', lastName.value);
    //localStorage.setItem('email', email.value);
    //localStorage.setItem('pw', pw.value);
    //    alert('Your account has been created');
    //}


//// Events


//function check() {
//    var storedName = localStorage.getItem('email');
//    var storedPw = localStorage.getItem('password');

//    var userName = document.getElementById('userName');
//    var userPw = document.getElementById('userPw');
//    var userRemember = document.getElementById("rememberMe");
//    debugger;
//    if (userName.value == storedName && userPw.value == storedPw) {
//        alert('You are logged in.');
//    } else {
//        alert('Error on login');
//    }
//}

//--------------------------LOGIN ----------------------------------------
function getUserId() {
    return localStorage.getItem('userId');
}

if (getUserId()) {
    $('#logout-btn').show();
    $('#login-btn').hide();
}


                   /* Login */
//$('#login-btn').on('click', function () {
//    debugger;

//    var Email = $('#userEmail').val();
//    var Password = $('#userPassword').val();

//    var loginOptions = {
//        email: Email,
//        password: Password
//    };

//    $.ajax({
//        url: "/home/login",
//        contentType: 'application/json',
//        type: 'POST',
//        data: JSON.stringify(loginOptions),
//        success: function (data) {
//            debugger;
//            localStorage.setItem('userId', data.Userid);
//            window.open('/Home/Dashboard', "_self")
//            //$('#login-btn').hide();
//            $('#logout-btn').show();
           

//        },
//        error: function () {
//            alert('Login denied');
//        }
//    });
//});

//$('#logout-btn').on('click', function () {
//    localStorage.removeItem('userId');
//    $('#logout-btn').hide();
//    $('#login-btn').show();

//});

function getUserId() {
    return localStorage.getItem('userId');
}

if (getUserId()) {
    $('#logout-btn').show();
    $('#login-btn1').hide();
}


$('#login-btn1').on('click', function () {
    debugger;

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
            localStorage.setItem('userId', data.userId);
            window.open('/Home/MyProjects/' + localStorage.getItem('userId'), "_self")
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
    $('#login-btn1').show();

});




let successAlert = $('#success-alert-project').hide();
let dangerAlert = $('#danger-alert-project').hide();





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
    //localStorage.setItem('firstName', sendData.firstName);
    //localStorage.setItem('lastName', sendData.lastName);
    //localStorage.setItem('email', sendData.email);
    //localStorage.setItem('password', sendData.password);
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
})




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
                debugger;
                $('#success-alert-project').fadeIn(1000);
                window.open('/home/addpackage/' + data.id , '_self')

            },
            error: function (jqXhr, textStatus, errorThrown) {
                console.log('Error from server:' + errorThrown);
                $('#danger-alert-project').fadeIn(2000);
            }

        });

    })




    //btn = $('#updateProject').on('click', () => {
    //    debugger;

    //    let ProjectId = $('#ProjectId').val();
    //    let actionUrl = '/api/project/' + ProjectId
    //    let input = document.getElementById('Picture');
    //    let files = input.files;
    //    let formData = new FormData();

    //    for (var i = 0; i != files.length; i++) {
    //        formData.append('Picture', files[i]);
    //    }

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

btn = $('#updateProject').on('click', () => {
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

    //------------------------------- PACKAGE ----------------------------------------

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

    //------------------------Update Package--------------------//
    
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

                alert(JSON.stringify(data))

                window.open('/home/users', '_self')
            },
            error: function (jqXhr, textStatus, errorThrown) {
                alert(errorThrown);
            }

        });

    })

function findToUpdatePackage() {

    id = $('#Id').val()
    actionUrl = '/Home/UpdatePackage/' + id

    window.open(actionUrl, '_self');

}


    //function updatePackage() {
    //    id = $('#Id').val()

    //    actionUrl = '/api/package/' + id
    //    actiontype = 'PUT'
    //    actionDataType = 'json'
     
    //    formData.append('amount', $('#Amount').val());
    //    formData.append('description', $('#Description').val());
    //    formData.append('reward', $('#Reward').val());

    //    $.ajax({
    //        url: actionUrl,
    //        data: formData,
    //        processData: false,
    //        contentType: 'application/json',
    //        type: 'PUT',

    //        success: function (data) {
    //            window.open('/home/packages', '_self')
    //        },
    //        error: function (jqXhr, textStatus, errorThrown) {
    //            alert('Error from server:' + errorThrown);
    //        }

    //    });
    //}

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



    //function findToUpdatePackage() {
    //    //ProjectId = $('#ProjectId').val()
    //    ProjectId =parseInt($('#projectId-updatepackage').val())
    //    actionUrl = '/Home/UpdatePackagesofProject/' + ProjectId

    //    window.open(actionUrl, '_self');

    //    $.ajax({
    //        url: actionUrl,
    //        dataType: actionDataType,
    //        type: actiontype,
    //        data: JSON.stringify(sendData),
    //        contentType: 'application/json',
    //        processData: false,

    //        success: function (data, textStatus, jQxhr) {

    //            alert(JSON.stringify(data))

    //            window.open('/home/projects', '_self')
    //        },
    //        error: function (jqXhr, textStatus, errorThrown) {
    //            alert(errorThrown);
    //        }

    //    });
    //}

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


                /* Search In Navbar */

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


// --------------- Search In filters  ------------------------

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
//--------------------------------------------------------------------




let btn5 = $('#searchControlSelectCategory').on('keypress', (e) => {
    let title = $('#inputSearchTitle');
    let description = $('#inputSearchDescription');
    let category = parseInt($('#searchControlSelectCategory').val());

    if (e.keyCode == 13) {
        window.location.assign('SearchProjectDisplay?text=' + category);
    }
})









    /*Show Picture Name when adding it */

    $('#Picture').on('change', function () {
        //get the file name
        var fileName = $(this).val();
        //replace the "Choose a file" label
        $(this).next('.custom-file-label').html(fileName);
    })




    //--------------------- Fund Project ---------------


fundProject = $('#fundProject').on('click', () => {
    debugger;
    actionUrl = '/home/fundproject'
    actiontype = 'PUT'
    actionDataType = 'json'
    fundUserId = parseInt(localStorage.getItem('userId'))
    ProjectFundId = parseInt($('#js-projectId-fund').val())

    sendData = {
        'Projectid': ProjectFundId,  //parseInt($('#js-projectId-fund').val()),
        'Packageid': parseInt($('#js-packageId-fund').val()),
        'Userid': fundUserId, //parseInt($('#js-userId-fund').val()),
        'Reward': parseFloat($('#js-reward-fund').val())
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
})
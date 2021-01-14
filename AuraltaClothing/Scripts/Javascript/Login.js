
// Invisible transition to the url wanted (we didn't put this in a function because, we don't want the transition effect)
if (window.location.pathname == "/Account/Register") {
    register();

} else if (window.location.pathname == "/Account/ForgotPassword") {
    forgotPassword();

} else {
    login();

}


$(document).ready(function () {

    // Initialize event listeners for the transitions
    // Login section
    //document.getElementById('loginToForgot').addEventListener('click', function () { forgotPassword() })
    document.getElementById('loginToRegister').addEventListener('click', function () { adjustRegisterFormHeight(); register(); })

    // Register section
    document.getElementById('registerToLogin').addEventListener('click', function () { $('.form-box').addClass('transition'); login(); loginHeightToNormal(); })

    // Forgot Password section
    document.getElementById('forgotPasswordToLogin').addEventListener('click', function () { login(); })


    // If the form is not valid, we need to give the section more height
    $('#registerButton').click(adjustRegisterFormHeight);

    $('#registerForm input').on('focusout keyup', function () {
        $('.form-box').removeClass('transition');
        $('#registerForm').valid()
        adjustRegisterFormHeight();

    });

});


// On the register section, with the validation errors, the window becomes to small, so we must resize
function adjustRegisterFormHeight() {

    var heightToAdd = 0;

    $('#registerForm').find('.field-validation-error').each(function () {
        heightToAdd += $(this).height();

    })

    console.log(heightToAdd);

    $('.form-box').css('height', 646 + heightToAdd + "px");

}

// Coming from the register section, if there was any validations errors. The window is too big and we want to remove the extra height.
function loginHeightToNormal() {
    // 646px is the default height in all conditions for the form-box
    $('.form-box').css('height', "646px");

}



function login() {
    // On phone screens, padding right and left 15px will be applied, instead of left
    if (screen.width <= 414) {
        $('#loginSection').css('left', 0 + 'px');
    } else {
        $('#loginSection').css('left', 50 + 'px');
    }

    $('#registerSection').css('left', 793 + 'px');
    $('#forgotPasswordSection').css('left', -793 + 'px');

    // Change url to /Account/Login
    window.history.pushState("", "", '/Account/Login');
    document.title = "Auralta Clothing - Log in";
}

function forgotPassword() {
    // On phone screens, padding right and left 15px will be applied, instead of left
    if (screen.width <= 414) {
        $('#forgotPasswordSection').css('left', 0 + 'px');
    } else {
        $('#forgotPasswordSection').css('left', 50 + 'px');
    }


    $('#loginSection').css('left', 793 + 'px');

    // Change url to /Account/ForgotPassword
    window.history.pushState("", "", '/Account/ForgotPassword');
    document.title = "Auralta Clothing - Forgot Password";

}

function register() {
    // On phone screens, padding right and left 15px will be applied, instead of left
    if (screen.width <= 414) {
        $('#registerSection').css('left', 0 + 'px');
    } else {
        $('#registerSection').css('left', 50 + 'px');
    }


    $('#loginSection').css('left', -793 + 'px');

    // Change url to /Account/Register
    window.history.pushState("", "", '/Account/Register');
    document.title = "Auralta Clothing - Register";

}
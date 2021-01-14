
/*
 *  Script for the Currency Selector
 */

$(document).ready(function () {
    addModalListeners();

    // Update the flag with the currency
    if (getCookie('currency') != undefined && getCookie('currency') != "") {
        $('.country-holder a').attr('class', 'country ' + getCookie('currency'));
        $('.country-holder a').attr('currencyCode', getCookie('currency'));


        var li = $('.currency-dropdown [currencyCode=' + getCookie('currency') + ']').parent();
        var inputoption = $("div.currency-dropdown .option")
        var selectedItem = $('div.currency-dropdown .selected-item')

        var livalue = li.data('value');
        var lihtml = li.html();

        selectedItem.html(lihtml);
        inputoption.val(livalue);

    }

    $(function () {
        // Set
        var selectedItem = $('div.currency-dropdown .selected-item')
        var li = $('div.currency-dropdown > ul > li.input-option')
        var inputoption = $("div.currency-dropdown .option")

        // Animation
        selectedItem.click(function () {
            li.toggle('fast');
        });

        // Insert Data
        li.click(function () {
            // hide
            li.toggle('fast');
            var livalue = $(this).data('value');
            var lihtml = $(this).html();
            selectedItem.html(lihtml);
            inputoption.val(livalue);

        });
    });
})

function addModalListeners() {
    $('.country-holder .country').click(function () {
        $('#exampleModal').modal('toggle');
    })

    $('.btn-save').click(function () {
        var country = $('.country-holder');
        var html = $('.selected-item .country');

        var flag = document.createElement('a');

        $(flag).attr('class', html.attr('class'));
        $(flag).attr('href', 'javascript:void(0);');
        country.html(flag);

        $.ajax({
            url: '../Home/ChangeCurrency',
            type: 'POST',
            data: {
                // Get the currency code
                currencyCode: html.attr('currencyCode'),
                countryCode: html.attr('countryCode'),

            }
        })
            .done(function (o) {
                // change all prices on page use a class or somthin (price)
                location.reload();

            })
            .fail(function () {
                alert('An error has occured');
            });



        $('.country-holder .country').click(function () {
            $('#exampleModal').modal('toggle');
        })

    })
}

function getCookie(name) {
    var value = "; " + document.cookie;
    var parts = value.split("; " + name + "=");
    if (parts.length == 2) return parts.pop().split(";").shift();
}
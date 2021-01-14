/* 
 *  Javascript Slider 
 */


$(document).ready(function () {

    /* If we are on a mobile device */
    if ($('a.control_prev').css('display') != 'none' && $('a.control_next').css('display') != 'none') {

        /* By default automaticly slide */ 
        var interval = null;
        autoplay();

        var slideCount = $('#new-releases .new-release-product-row .new-release-product').length;
        var slideWidth = $('#new-releases .new-release-product-row .new-release-product').width();
        var slideHeight = $('#new-releases .new-release-product-row .new-release-product').height();
        var sliderUlWidth = slideCount * slideWidth;

        slideHeight += $('#new-releases .row:first').height();

        $('#new-releases').css({ /*width: slideWidth,*/ height: slideHeight });
        $('#new-releases .new-release-product-row').css({ width: sliderUlWidth, marginLeft: - slideWidth  });
        $('.new-release-product').attr("style", "width: 25% !important"); /* We must do this in js, because the original width is used to calculate the slideWidth */
        $('#new-releases .new-release-product-row .new-release-product:last-child').prependTo('#new-releases .new-release-product-row');

        /* Move the slider to the left */ 
        function moveLeft() {
            $('#new-releases .new-release-product-row').animate({
                left: + slideWidth
            }, 500, function () {

                clearInterval(interval);
                autoplay();

                $('#new-releases .new-release-product-row .new-release-product:last-child').prependTo('#new-releases .new-release-product-row');
                $('#new-releases .new-release-product-row').css('left', '');
            });
        };

        /* Move the slider to the right */
        function moveRight() {
            $('#new-releases .new-release-product-row').animate({
                left: - slideWidth
            }, 500, function () {

                clearInterval(interval);
                autoplay();

                $('#new-releases .new-release-product-row .new-release-product:first-child').appendTo('#new-releases .new-release-product-row');
                $('#new-releases .new-release-product-row').css('left', '');
            });
        };

        /* Auto play the slider */
        function autoplay() {
            interval = setInterval(function () {
                moveRight();
            }, 6000);
        }

        $('.control_prev').click(function () {
            moveLeft();
        });

        $('.control_next').click(function () {
            moveRight();
        });

    }

});
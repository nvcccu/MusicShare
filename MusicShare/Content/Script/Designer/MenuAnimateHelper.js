getMenuAnimateHelper = function (data) {
    var helper = {};
    var globalParameterBlock = $('#GlobalParameters');

    var animateSubparameterListBlock = function (afterAnimation) {
        return function () {
            $('#Subparameters').css('display', 'block');
            $('.details__subparameters').css('width', '0');
            $('.details__subparameters').animate(
                { width: '223px' },
                1000,
                afterAnimation
            );
        }
    }
    var animateVerticalBlock = function(afterAnimation) {
        return function() {
           globalParameterBlock.animate(
               { height: '100%' },
               1000,
               animateSubparameterListBlock(afterAnimation)
           );
        }
    };
    helper.onGlobalParameterChange = function (afterAnimation) {
        globalParameterBlock.animate(
            {
                width: '33px',
                'padding-left': '33px',
                'padding-right': '0'
            },
            1000,
            animateVerticalBlock(afterAnimation)
        );
    };

    return helper;
};
UIDropDown = function (context, config) {
    this.context = $(context);
    this.cssUiDropDown = config.cssUiDropDown;
    this.cssDdTitle = config.cssDdTitle;
    this.cssDdElemBlock = config.cssDdElemBlock;
    this.cssDdElem = config.cssDdElem;
    this.defaultText = config.defaultText;
    this.elements = config.elements;
    this.UiDropDown = context.find('.ui__drop-down');
    this.DdTitle = context.find('.dd__title');
    this.DdElemBlock = context.find('.dd__elem-block');
    this.DdElem = context.find('.dd__elem');
    var that = this;

    this.AddClasses = function() {
        if (that.cssUiDropDown) {
            that.UiDropDown.addClass();
        }
        if (that.cssDdTitle) {
            that.DdTitle.addClass();
        }
        if (that.cssDdElemBlock) {
            that.DdElemBlock.addClass();
        }
        if (that.cssDdElem) {
            that.DdElem.addClass();
        }
    };

    this.InitValues = function() {
        var template = context.find('.dd__elem .tmpl');
        var elem = template.clone();
        elem.removeClass('tmpl');
        elem.text(that.defaultText);
        that.DdElemBlock.append(elem);
        that.elements.forEach(function(e) {
            elem = template.clone();
            elem.text(e);
            elem.removeClass('tmpl');
            that.DdElemBlock.append(elem);
        });
    };

    this.BindEvents = function() {

    };

    this.Init = function () {
        that.AddClasses();
        that.InitValues();
        that.BindEvents();
    };

    that.Init();
};
UIDropDown = function (context, config) {
    this.context = $(context);
    this.cssUiDropDown = config.cssUiDropDown;
    this.cssDdTitle = config.cssDdTitle;
    this.cssDdElemBlock = config.cssDdElemBlock;
    this.cssDdElem = config.cssDdElem;
    this.defaultText = config.defaultText;
    this.elementsText = config.elementsText;
    this.uiDropDown = context.find('.ui__drop-down');
    this.ddTitle = context.find('.dd__title');
    this.ddElemBlock = context.find('.dd__elem-block');
    this.ddElem = context.find('.dd__elem');
    var that = this;

    this.AddClasses = function() {
        if (that.cssUiDropDown) {
            that.uiDropDown.addClass();
        }
        if (that.cssDdTitle) {
            that.ddTitle.addClass();
        }
        if (that.cssDdElemBlock) {
            that.ddElemBlock.addClass();
        }
        if (that.cssDdElem) {
            that.ddElem.addClass();
        }
    };

    this.InitValues = function() {
        var template = context.find('.dd__elem .ui-tmpl');
        var elem = template.clone();
        elem.removeClass('ui-tmpl');
        elem.text(that.defaultText);
        that.ddElemBlock.append(elem);
        that.elementsText.forEach(function(e) {
            elem = template.clone();
            elem.text(e);
            elem.removeClass('ui-tmpl');
            that.ddElemBlock.append(elem);
        });
        that.ddElem = context.find('.dd__elem');
    };

    this.Toggle = function() {
        that.ddElem.toggleClass('ui-hide');
    };

    this.BindEvents = function() {
        that.ddTitle.on('click', function() {
            that.Toggle();
        });
    };

    this.Init = function () {
        that.AddClasses();
        that.InitValues();
        that.BindEvents();
    };

    that.Init();
};
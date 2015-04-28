getMusGround = function (options) {
    var self = this;
    self.const = {};
    self.submitWithoutReload = function(target) {
        $(target).ajaxSubmit();
        return false;
    };
    self.logger = getLogger(options.logUrl);

    return self;
};
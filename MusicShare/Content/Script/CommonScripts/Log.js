getLogger = function (logUrl) {
    var self = this;
    self.logUrl = logUrl;
    
    $('[data-action-id]').on('click', function() {
        $.ajax({
            url: self.logUrl,
            type: 'POST',
            data: {
                actionId: $(this).data('action-id')
            }
        });
    });
    self.logAction = function (actionId, target) {
        $.ajax({
            url: self.logUrl,
            type: 'POST',
            data: {
                actionId: actionId,
                target: target
            }
        });
    };

    return self;
};
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
    self.logAction = function (actinId, target) {
        $.ajax({
            url: self.logUrl,
            type: 'POST',
            data: {
                actionId: actinId,
                target: target
            }
        });
    };

    return self;
};
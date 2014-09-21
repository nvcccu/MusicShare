Log = function (logUrl) {
    this.logUrl = logUrl;
    var that = this;

    $('[data-action-id]').on('click', function() {
        $.ajax({
            url: that.logUrl,
            type: 'POST',
            data: {
                actionId: $(this).data('action-id')
            }
        });
    });

    this.LogAction = function(actioId, target) {
        $.ajax({
            url: that.logUrl,
            type: 'POST',
            data: {
                actionId: actioId,
                target: target
            }
        });
    };
};
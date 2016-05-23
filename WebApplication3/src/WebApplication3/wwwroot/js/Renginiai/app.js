(function() {
    if ($.fn.rating) {
        $("#input-id").rating(
            {
                displayOnly: true,
                step: 0.5,
                size: 'xs'
            }
        );
    }
})();
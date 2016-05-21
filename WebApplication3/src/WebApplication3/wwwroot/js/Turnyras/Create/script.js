(function () {
    var createTourneyForm = $('#create_tourney_form');
    $('#announceTourney').on('click', function () {
        if (createTourneyForm.valid()) {
            $('#loader').addClass('loading');
        }
    });
}());
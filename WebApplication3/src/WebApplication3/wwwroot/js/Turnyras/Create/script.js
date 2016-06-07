(function () {
    var makeID = function () {
        var text = "";
        var possible = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";

        for (var i = 0; i < 20; i++)
            text += possible.charAt(Math.floor(Math.random() * possible.length));

        return text;
    }

    var createTourneyChallonge = function () {
        var deferred = $.Deferred();
        $.post("https://api.challonge.com/v1/tournaments.json",
        {
            api_key: "LQaugevNzjBY1EoU7lfpvbyeyWFeUI6vWGP4tgWo",
            tournament: {
                'name': $('#create_tourney_form #Pavadinimas').val(),
                'signup_cap': $('#create_tourney_form #KomanduKiekis').val(),
                'hide_forum': true,
                'private': true,
                'url': makeID()
            }

        }
        ).done(function (data) {
            console.log(data);
            deferred.resolve(data);
        });

        return deferred.promise();
    }

    var submitTourney = function (challongeAddress) {
        $('#create_tourney_form #ChallongeAddress').val(challongeAddress);
        $('#create_tourney_form').submit();
    }

    var createTourneyForm = $('#create_tourney_form');

    $('#announceTourney').on('click', function (event) {
        if (createTourneyForm.valid()) {
            event.preventDefault();
            $('#loader').addClass('loading');
            createTourneyChallonge().then(function (data) {
                console.log('submitinam');
                submitTourney(data.tournament.url);
            });
        }
    });
}());
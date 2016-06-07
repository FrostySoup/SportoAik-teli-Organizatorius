(function () {
    var allMatches;
    var opponentID;
    var match;
    var turnyroDalyvisID;
    var turnyrasID;
    var turnyroVarzybuID;

    function isTourneyOver(data) {
        for (var i = 0; i < data.length; i++) {
            if (data[i].match.state == "pending") {
                return false;
            }
        }
        return true;
    }

    function teamNeedsToPlay(data) {
        for (var i = 0; i < data.length; i++) {
            if (data[i].match.player1_id && data[i].match.player1_id && (data[i].match.player1_id === turnyroDalyvisID || data[i].match.player2_id === turnyroDalyvisID) && data[i].match.state == "open") {
                match = data[i].match;
                console.log('match', match);
                return true;
            }
        }
        return false;
    }

    function findOpponentID(data) {
        for (var i = 0; i < data.length; i++) {
            if (data[i].match.player1_id && data[i].match.player1_id && data[i].match.state == "open") {
                if (data[i].match.player1_id === turnyroDalyvisID) {
                    return data[i].match.player2_id;
                }
                if (data[i].match.player2_id === turnyroDalyvisID) {
                    return data[i].match.player1_id;
                }
            }
        }
    }

    function getAllMatches(scoreA, scoreB) {
        $.get("https://api.challonge.com/v1/tournaments/" + turnyrasID + "/matches.json?api_key=LQaugevNzjBY1EoU7lfpvbyeyWFeUI6vWGP4tgWo", function (data) {
            allMatches = data;
            if (teamNeedsToPlay(allMatches)) {
                opponentID = findOpponentID(allMatches);
            }

            confirmScore(scoreA, scoreB);
        });
    }

    function confirmScore(p1ScoreField, p2ScoreField) {
        var p1Score;
        var p2Score;
        var winner;

        if (match.player1_id === turnyroDalyvisID) {
            p1Score = p1ScoreField;
            p2Score = p2ScoreField;
            if (p1Score > p2Score) {
                winner = turnyroDalyvisID;
            }
            else {
                winner = opponentID;
            }
        }
        else {
            p1Score = p1ScoreField;
            p2Score = p2ScoreField;
            if (p1Score > p2Score) {
                winner = opponentID;
            }
            else {
                winner = turnyroDalyvisID;
            }
        }

        var matchObject = {};
        matchObject['scores_csv'] = p1Score + "-" + p2Score;
        matchObject['winner_id'] = winner;


        $.post("https://api.challonge.com/v1/tournaments/" + turnyrasID + "/matches/" + match.id + ".json",
            {
                _method: "put",
                api_key: "LQaugevNzjBY1EoU7lfpvbyeyWFeUI6vWGP4tgWo",
                match: matchObject

            }
        ).done(function (data) {
            $.get("/TurnyroVarzybos/ConfirmScore?varzybuID=" + turnyroVarzybuID + "&scoreA=" + p1ScoreField + "&scoreB=" + p2ScoreField, function (data) {
                if (isTourneyOver(allMatches)) {
                    $.get("/Turnyras/End?turnyroID=" + turnyrasID, function (data) {
                        location.reload();
                    });
                }
                else {
                    location.reload();
                }
                console.log(data);
            });
        });


    }

    $('[name=confirmScore]').on('click', function (e) {
        var form = $(this).parents('[name=confirm_score_form]');
        var teamA = form.find('#Komanda_1');
        var teamB = form.find('#Komanda_2');
        turnyroDalyvisID = form.data('challonge');
        turnyrasID = form.data('turnyras');
        turnyroVarzybuID = form.data('varzybos');

        getAllMatches(teamA.val(), teamB.val());
    });

    
}());
(function () {
    var $,
      __bind = function (fn, me) { return function () { return fn.apply(me, arguments); }; };

    $ = jQuery;

    $.fn.challonge = function (tournamentUrl, options) {
        var Challonge;
        Challonge = (function () {

            function Challonge($this, tournamentUrl, options) {
                this._$iframe = __bind(this._$iframe, this);
                this._sourceWithOptions = __bind(this._sourceWithOptions, this); this.tournamentUrl = tournamentUrl || '';
                this.options = $.extend({}, $.fn.challonge.defaults, options || {});
                this.subdomain = this.options.subdomain;
                this.height = $this.height();
                $this.html(this._$iframe);
            }

            Challonge.prototype._sourceWithOptions = function () {
                var subdomain;
                subdomain = this.subdomain ? "" + this.subdomain + "." : '';
                return "http://" + subdomain + "challonge.com/" + this.tournamentUrl + "/module?" + ($.param(this.options));
            };

            Challonge.prototype._$iframe = function () {
                return $("<iframe src='" + (this._sourceWithOptions()) + "' width='100%' height='" + this.height + "' frameborder='0' scrolling='auto' allowtransparency='true' />");
            };

            return Challonge;

        })();
        new Challonge($(this), tournamentUrl, options);
        return this;
    };

    $.fn.challonge.defaults = {
        multiplier: 1.0,
        match_width_multiplier: 1.0,
        show_final_results: 0,
        show_standings: 0,
        theme: 2,
        subdomain: null
    };

}).call(this);

(function () {
    var match;

    function isTourneyOver(data) {
        for (var i = 0; i < data.length; i++) {
            if (data[i].match.state == "open") {
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

    function addScore(opponentID, allMatches) {
        var p1Score;
        var p2Score;
        var winner;

        if (match.player1_id === turnyroDalyvisID) {
            p1Score = $('#Komanda_1').val();
            p2Score = $('#Komanda_2').val();
            if (p1Score > p2Score) {
                winner = turnyroDalyvisID;
            }
            else {
                winner = opponentID;
            }
        }
        else {
            p1Score = $('#Komanda_2').val();
            p2Score = $('#Komanda_1').val();
            if (p1Score > p2Score) {
                winner = opponentID;
            }
            else {
                winner = turnyroDalyvisID;
            }
        }

        var address = 'http://localhost:58519/TurnyroVarzybos/SuggestScore?varzybuID=' + turnyroVarzybuID + '&scoreA=' + p1Score + '&scoreB=' + p2Score;
        $.get(address, function (data) {
            location.reload();
        });
    }

    $(function () {
        var opponentID;
        var allMatches;

        $('#addScore').on('click', function () {
            addScore(opponentID, allMatches);
        });


        $('#AiksteleID').val($('#Aiksteles').val());
        $('#Aiksteles').change(function () {
            $('#AiksteleID').val((this).val());
        });

        $('#datetimepicker1').datetimepicker();
        var tournament = $("#tournament");
        if (tournament.data("status") !== 'Naujas') {
            $('#challonge_brackets').show().challonge(tournament.data("challonge"));
        }

        $.get("https://api.challonge.com/v1/tournaments/" + turnyrasID + "/matches.json?api_key=LQaugevNzjBY1EoU7lfpvbyeyWFeUI6vWGP4tgWo", function (data) {
            console.log('matches', data);
            allMatches = data;
            if (teamNeedsToPlay(data)) {
                opponentID = findOpponentID(data);
                $.get("https://api.challonge.com/v1/tournaments/" + turnyrasID + "/participants/" + opponentID + ".json?api_key=LQaugevNzjBY1EoU7lfpvbyeyWFeUI6vWGP4tgWo", function (data) {
                    console.log('CIA VA ZIUREK', data);
                    $('#KomandaB_ID').val(data.participant.id);
                    $('#KomandaB_ID_DB').val(+data.participant.misc);
                    $('#tourney_management').find('#opponent_name').text(data.participant.display_name);
                    $('#Komanda_2_label').text(data.participant.display_name);
                    $.get("https://api.challonge.com/v1/tournaments/" + turnyrasID + "/participants/" + turnyroDalyvisID + ".json?api_key=LQaugevNzjBY1EoU7lfpvbyeyWFeUI6vWGP4tgWo", function (data) {
                        $('#Komanda_1_label').text(data.participant.display_name);
                        $('#tourney_management').show();
                    });
                });
            }
        });
    });

    //Join tourney
    var joinTourneyChallonge = function () {
        var deferred = $.Deferred();
        var address = "https://api.challonge.com/v1/tournaments/" + turnyrasID + "/participants.json";

        $.post(address,
        {
            api_key: "LQaugevNzjBY1EoU7lfpvbyeyWFeUI6vWGP4tgWo",
            participant: {
                'name': komanda['name'],
                'misc': komanda['id']
            }

        }
        ).done(function (data) {
            console.log(data);
            deferred.resolve(data);
        });

        return deferred.promise();
    }

    var startTourney = function () {
        var deferred = $.Deferred();
        var address = "https://api.challonge.com/v1/tournaments/" + turnyrasID + "/start.json";

        $.post(address,
        {
            api_key: "LQaugevNzjBY1EoU7lfpvbyeyWFeUI6vWGP4tgWo",

        }
        ).done(function (data) {
            console.log(data);
            deferred.resolve(data);
        });

        return deferred.promise();
    }

    var saveTourneyParticipant = function (participantID) {
        $(location).attr('href', "/Turnyras/Join?id=" + turnyrasTikrasID + "&participantID=" + participantID);
    }


    $('#joinTourney').on('click', function () {
        $('#loader').addClass('loading');
        event.preventDefault();
        joinTourneyChallonge().then(function (participantData) {
            if (turnyroDydis === turnyroDalyviuKiekis + 1) {
                startTourney().then(function (data) {
                    saveTourneyParticipant(participantData.participant.id);
                });
            }
            else {
                saveTourneyParticipant(participantData.participant.id);
            }
        });

    });
}());
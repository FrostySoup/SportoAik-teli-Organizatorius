window.onload = function () {
    var position = new google.maps.LatLng(parseFloat($('body').data('lat')), parseFloat($('body').data('long')));
    var mapOptions = {
        center: position,        
        zoom: 14,
        mapTypeId: google.maps.MapTypeId.ROADMAP
    };
    var infoWindow = new google.maps.InfoWindow();
    var latlngbounds = new google.maps.LatLngBounds();
    var map = new google.maps.Map(document.getElementById("dvMap"), mapOptions);
    var name = $('body').data('Name');
    var marker = new google.maps.Marker({
        position: position,
        map: map,
        title: name
    });


    google.maps.event.addListener(map, 'click', function (e) {
        alert("Latitude: " + e.latLng.lat() + "\r\nLongitude: " + e.latLng.lng());
    });
}
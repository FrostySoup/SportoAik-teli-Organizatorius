window.onload = function () {
    var position = new google.maps.LatLng(54.8963, 23.911);
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
    marker.setMap(null);
    google.maps.event.addListener(map, 'click', function (e) {
        marker.setMap(null);
        var markerPos = new google.maps.LatLng(e.latLng.lat(), e.latLng.lng());
        $('#form_lat').val(e.latLng.lat());
        $('#form_long').val(e.latLng.lng());
        marker = new google.maps.Marker({
            position: markerPos,
            map: map,
            title: name
        });
    });
}
function initMap() {
    var map = new google.maps.Map(document.getElementById('map'), {
        center: { lat: 16.4023, lng: 120.5960 },
        zoom: 17
    });
    var infowindow = new google.maps.InfoWindow();
    var marker = new google.maps.Marker({
        map: map,
        anchorPoint: new google.maps.Point(0, -29)
    });
    var geocoder = new google.maps.Geocoder();

    map.addListener('click', function (e) {
        marker.setVisible(false);
        marker.setPosition(e.latLng);

        geocoder.geocode({
            'latLng': e.latLng
            }, function (results, status) {
                if (status == google.maps.GeocoderStatus.OK) {
                    if (results[0]) {
                        document.getElementById("Location").value = results[0].formatted_address;
                    }
                }
            });

        marker.setVisible(true);

        document.getElementById("Latitude").value = e.latLng.lat();
        document.getElementById("Longitude").value = e.latLng.lng();
    });

    var input = (document.getElementById('pac-input'));
    map.controls[google.maps.ControlPosition.TOP_LEFT].push(input);

    var autocomplete = new google.maps.places.Autocomplete(input);
    autocomplete.bindTo('bounds', map);

    autocomplete.addListener('place_changed', function () {
        infowindow.close();
        marker.setVisible(false);
        var place = autocomplete.getPlace();
        if (!place.geometry) {
            window.alert("We didn't find what your are looking");
            return;
        }

        // If the place has a geometry, then present it on a map.
        if (place.geometry.viewport) {
            map.fitBounds(place.geometry.viewport);
        } else {
            map.setCenter(place.geometry.location);
            map.setZoom(17);
        }

        marker.setPosition(place.geometry.location);
        marker.setVisible(true);

        document.getElementById("Location").value = place.name;
        document.getElementById("Latitude").value = place.geometry.location.lat();
        document.getElementById("Longitude").value = place.geometry.location.lng();
    });
}
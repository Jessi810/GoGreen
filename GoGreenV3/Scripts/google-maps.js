// For searching areas
function initAutocomplete() {
    var input = document.getElementById('pac-input');

    var autocomplete = new google.maps.places.Autocomplete(input);
    var center = new google.maps.LatLng(16.4023, 120.5960);
    var circle = new google.maps.Circle({
        center: center,
        radius: 5000
    });
    autocomplete.setBounds(circle.getBounds());

    autocomplete.addListener('place_changed', function () {
        console.log('place_changed');
        var place = autocomplete.getPlace();

        if (!place.geometry) {
            window.alert("Didn't find what your looking");
            return;
        }

        if (place.name.toLowerCase().includes('hospital'))
            document.getElementById("Type").value = 'Hospital';
        else if (place.name.toLowerCase().includes('police'))
            document.getElementById("Type").value = 'Police Department';
        else if (place.name.toLowerCase().includes('fire'))
            document.getElementById("Type").value = 'Fire Station';

        document.getElementById("Name").value = place.name;
        document.getElementById("Address").value = place.formatted_address;
        document.getElementById("Contact").value = place.international_phone_number;
        document.getElementById("Latitude").value = place.geometry.location.lat();
        document.getElementById("Longitude").value = place.geometry.location.lng();
        document.getElementById("WebsiteUrl").value = place.website;
    });
}
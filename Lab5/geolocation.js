function getGeolocation() {
    const geolocationDisplay = document.getElementById("geolocation");

    if (navigator.geolocation) {
        navigator.geolocation.getCurrentPosition(showGeolocation, handleError);
    } else {
        geolocationDisplay.innerHTML = "Geolocation is not supported by this browser.";
    }
}

function showGeolocation(position) {
    const geolocationDisplay = document.getElementById("geolocation");
    geolocationDisplay.innerHTML = "Latitude: " + position.coords.latitude + 
                                   "<br>Longitude: " + position.coords.longitude;
}

function handleError(error) {
    const geolocationDisplay = document.getElementById("geolocation");
    switch(error.code) {
        case error.PERMISSION_DENIED:
            geolocationDisplay.innerHTML = "User denied the request for Geolocation.";
            break;
        case error.POSITION_UNAVAILABLE:
            geolocationDisplay.innerHTML = "Location information is unavailable.";
            break;
        case error.TIMEOUT:
            geolocationDisplay.innerHTML = "The request to get user location timed out.";
            break;
        case error.UNKNOWN_ERROR:
            geolocationDisplay.innerHTML = "An unknown error occurred.";
            break;
    }
}

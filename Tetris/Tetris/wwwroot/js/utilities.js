window.setTitle = (title) => {
    document.title = title;
}

window.SetFocusToElement = (element) => {
    element.focus();
}

window.PlayAudio = (elementName) => {
    document.getElementById(elementName).play();
}

window.PauseAudio = (elementName) => {
    document.getElementById(elementName).pause();
}

window.WriteCookie = (name, value, days) => {
    var expires;
    if (days) {
        var date = new Date();
        date.setTime(date.getTime() + (days * 24 * 60 * 60 * 1000)); // set a time however many days from now (in ms)
        expires = "; expires=" + date.toUTCString();
    }
    else expires = "";
    document.cookie = name + "=" + value + expires + "; path=/";
}

window.ReadCookie = (cname) => {  // getting variable value out of cookie where variable name is cname
    var name = cname + "=";
    var decodedCookie = decodeURIComponent(document.cookie);
    var ca = decodedCookie.split(';');
    for (var i = 0; i < ca.length; i++) {  // look through substrings created from split until find one for cname
        var c = ca[i];
        while (c.charAt(0) === ' ') {    // check for leading blank (as occurs after ; in cookie statement)
            c = c.substring(1);         // reform substring from position after blank
        }
        if (c.indexOf(name) === 0) {      // if passed cname matches the start of the first substring...
            return c.substring(name.length, c.length);  // return the value after the 'cname=' ie rest of substring
                                                        // ie value associated with passed name
        }
    }
    return "0";   // if nothing found
}
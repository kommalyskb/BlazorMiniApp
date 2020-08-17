function setLocalizationToStorage(key, value) {
    localStorage[key] = value;
}
function getLocalizationFromStorage(key) {
    return localStorage[key];
}
function writeLog(message) {
    console.log(message);
}
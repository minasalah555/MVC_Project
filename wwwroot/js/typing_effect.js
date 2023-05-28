var text = document.getElementById('greet-guest');
var greeting = ['Welcome to Our Platform',
                '"UnivX Platform"'];
text.innerHTML = '<i>▮</i>';

(function greet() {
    if (greeting.length > 0 && greeting.length < 3) {
        text.insertBefore(document.createElement('br'), text.lastChild);
    }
    var line = greeting.shift();
    if (!line) {
        return;
    }
    line = line.split('');
    (function type() {
        var character = line.shift();
        if (!character) {
            return setTimeout(greet, 2000);
        }

        text.insertBefore(document.createTextNode(character), text.lastChild);
        setTimeout(type, 100);
    }());
}());

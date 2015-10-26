var russianWords = []; // Все русские слова
var englishWords = []; // Все английские слова
var selectedIndex = -1;

// Блокировка отправки формы после ввода тега по нажатию Enter
$(document).ready(function () {
    $("#word").keydown(function (event) {
        if (event.keyCode == 13) {
            event.preventDefault();
            return false;
        }
    });
});

document.getElementById("word").onkeyup = function (event) {
    var enteredWord = document.getElementById("word").value;

    if (russianWords.length == 0) {
        russianWords = GetRussianWords();
        englishWords = GetEnglishWords();
    }

    var containedWords = [];   // Слова, я вляющиеся подсказками.
    for (var i = 0; i < russianWords.length; i++) {
        if (russianWords[i].indexOf(enteredWord) != -1) {
            containedWords[containedWords.length] = russianWords[i];
        }

        // Ввыводим не более 5 подсказок на экран.
        if (containedWords.length == 5) {
            break;
        }
    }
    if (containedWords.length == 0) {
        for (var i = 0; i < englishWords.length; i++) {
            if (englishWords[i].indexOf(enteredWord) != -1) {
                containedWords[containedWords.length] = englishWords[i];
            }

            // Ввыводим не более 5 подсказок на экран.
            if (containedWords.length == 5) {
                break;
            }
        }
    }
    if (event.keyCode == 38) {
        if (selectedIndex < containedWords.length)
            document.getElementById(selectedIndex + "li").style.backgroundColor = "white";
        if (selectedIndex > 0)
            selectedIndex--;
        document.getElementById(selectedIndex + "li").style.backgroundColor = "#F0F8FF";
    }
        // Стрелка вниз
    else if (event.keyCode == 40) {
        if (selectedIndex != -1)
            document.getElementById(selectedIndex + "li").style.backgroundColor = "white";
        if (selectedIndex < containedWords.length - 1)
            selectedIndex++;
        document.getElementById(selectedIndex + "li").style.backgroundColor = "#F0F8FF";
    }
    else if (event.keyCode == 13) {
        if (selectedIndex != -1)
            document.getElementById("word").value = containedWords[selectedIndex];
        document.getElementById("submit").click();
    }
    else {
        selectedIndex = -1;

        // Удаляем уже существующий список.
        RemoveList();

        var ul = document.createElement("ul");
        ul.className = "dropdown-menu";
        ul.id = "wordList";

        // Добавляем новые подсказки.
        for (var i = 0; i < containedWords.length; i++) {
            var li = document.createElement("li");
            li.id = i + "li"
            li.className = "list-group-item";
            li.innerHTML = containedWords[i];

            li.onmouseenter = function (e) {
                for (var i = 0; i < containedWords.length; i++)
                    document.getElementById(i + "li").style.backgroundColor = "white";
                e.srcElement.style.backgroundColor = "#F0F8FF";
                selectedIndex = i;
            }

            li.onmouseleave = function (e) {
                e.fromElement.style.backgroundColor = "white";
                selectedIndex = -1;
            }

            li.onclick = function (e) {
                document.getElementById("word").value = e.currentTarget.innerHTML;
                document.getElementById("submit").click();
                RemoveList();
            }

            ul.appendChild(li);
        }

        if (containedWords.length > 0) {
            document.getElementById("list").appendChild(ul);

        }
    }
}

function GetRussianWords() {
    var russianWords = [];
    for (var i = 0; document.getElementById(i + " russianWord") != null; ++i) {
        russianWords[i] = document.getElementById(i + " russianWord").value;
    }
    return russianWords;
}

function GetEnglishWords() {
    var englishWords = [];
    for (var i = 0; document.getElementById(i + " englishWord") != null; ++i) {
        englishWords[i] = document.getElementById(i + " englishWord").value;
    }
    return englishWords;
}

function RemoveList() {
    if (document.getElementById("wordList") != null)
        document.getElementById("list").removeChild(document.getElementById("wordList"));
}
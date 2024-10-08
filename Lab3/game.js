let randomNumber = Math.floor(Math.random() * 100) + 1;
let guesses = [];
let maxTurns = 10;
let currentTurn = 0;

function guessNumber(playerGuess) {
    currentTurn++;
    guesses.push(playerGuess);

    if (currentTurn > maxTurns) {
        return "You've got no chance. Game over.";
    }

    if (playerGuess > randomNumber) {
        return `Bigger, already guessed numbers : ${guesses.join(", ")}`;
    } else if (playerGuess < randomNumber) {
        return `Smaller, already guessed numbers: ${guesses.join(", ")}`;
    } else {
        return `Congratulations, you guessed correctly! The correct number is ${randomNumber}. You used ${currentTurn}  chances.`;
    }
}

function resetGame() {
    randomNumber = Math.floor(Math.random() * 100) + 1;
    guesses = [];
    currentTurn = 0;
    return "The game has been reset, please start guessing again.";
}

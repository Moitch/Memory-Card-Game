# Memory-Card-Game

Assignment 2 in Unity.
Mitchell Foley
COMP-4478
**Unity Version 2021.3.21f1**

![image](https://user-images.githubusercontent.com/55286115/226473110-4852dbd3-5d7c-4746-b7bf-23f8ced49fa3.png)


**CardScript.cs**

Initializes many variables including references to LogicScript.cs with the variable logic and the SpriteRenderer for the card.

Withing Start(), it is just getting the proper references for the variables logic and spriteRenderer.

OnMouseDown() is an onClick function that first checks to see if the first card being clicked is already matched, if not then it
checks to see if the card matches with another card flipped. 

It then checks to see if the card is flipped by checking if the sprite is the card back sprite, if it is flipped and can be flipped
back over then it will flip back over. 

Lastly it uses the TwoCardsFlipped() function to check if there are already two cards flipped, if not then it flips the card, checks
which card was flipped with WhichCardFlipped(), and then checks to see if the cards are matching cards wwith CheckMatchingCards().

![image](https://user-images.githubusercontent.com/55286115/226473189-01a6c85d-410a-4e91-bee5-01bdf78e9ef9.png)


**-------------------------------------------------------------------------------------------------------**

**LogicScript.cs**

Initializes two GameObjects card & gameOverScreen, card is for the cards in the memory game, and gameOverScreen is hidden until the player
has completed the game.

The floats xPosition and yPosition are used to space the cards out evenly when generating the game.

There are two integer Lists, cardId which is used to store the 8 card ids, and matchedCards which is used to store the cards that have been matched.

listLength is used when generating the game size, randomNumber is used to generate the cards randomly, matchCount is used to count the number of matches
for the games win condition.

The integer Array cardsFlipped[] is used to check if there are cards flipped by checking the two positions values.

Within the Start() function, the card object is initialized, listLength is initialized, and the xPosition and yPosition are initialized.

It then uses a for loop to generate the cards, each iteration of the for loop will first generate the randomNumber to use for the cardId List.
Then using Instantiate() it will generate a new card GameObject, assign the randomNumber to the cardFront value of the card GameObject, then
remove the random number from the cardId list. At the bottom of the start function, it assigns the original card GameObject the last value in the
cardId list.

The Update() function just checks to see if the match count is equal to or greater than 4.

TwoCardsFlipped() checks to see if there are two cards flipped by using the cardsFlipped array. If both the cardsFlipped value are greater than or
equal to 0 then there are two cards flipped.

WhichCardFlipped(int cardNum) takes in the cardFront value of the card to pass into the cardsFlipped array. If cardsFlipped[0] is used then
it will place it into cardsFlipped[1].

UnflipCards(int cardNum) does the opposite of WhichCardFlipped() and unflips the cards using the cardsFlipped array.

CheckMatchingCards() initializes a boolean matching to return when the function is finished. Checks if the cardsFlipped[0] is equal to 
cardsFlipped[1], if it is then add the two cards to the matchedCards list, reset the cardsFlipped array, set matching to true, and increase matchCount by 1.
After the function has ran, return if matching is true or false.

RestartGame() reinitializes the game when the Play Again button is clicked after the player has activated the GameWon() function.

GameWon() sets the gameOverScreen to active, it congratulates the player and asks if they want to play again.

![image](https://user-images.githubusercontent.com/55286115/226473211-6063d58e-4fae-4a35-b50e-2736c9fa2ef1.png)



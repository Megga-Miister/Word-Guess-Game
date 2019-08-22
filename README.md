# Word Guess Game
#### Lord of the Rings Character Guessing Game
##### *Author: Meggan Triplett*

------------------------------

## Description
C# console application that will allow users to play a word guessing game similar to hangman.
Upon start user can pick from five options: 1, 2, 3, 4, or 5.

**1) Start Game**
User will be shown a blank character to guess by entering one letter at a time.
Letters previously guessed will be displayed and the blank character will update if user guesses any letters correctly.
Once the character is completely filled out user will receive a congrats message.
They will then be prompted to pick to return to the main menu or exiting the progrm by entering menu or exit.

**2) View Characters**
User will be shown the list of characters that could be used for the guessing game.
They will then be prompted to pick to return to the main menu or exiting the progrm by entering menu or exit.

**3) Add Character**
User will be prompted to enter a new character.
A message telling the user that their character has been added will appear.
They will then be prompted to pick to return to the main menu or exiting the progrm by entering menu or exit.

**4) Remove Character**
User will be prompted to enter a character they would like to remove from the character list.
A message telling the user that their character has been removed will appear.
Or the message will say the character did not exist on the character list.
They will then be prompted to pick to return to the main menu or exiting the progrm by entering menu or exit.

**5) Exit Game**
Console application will proceed to close.

------------------------------

## Getting Started
Clone this repository to your local machine.
```
$ git clone [https://github.com/Megga-Miister/Word-Guess-Game.git]
```
#### To run the program from Visual Studio:
Select ```File``` -> ```Open``` -> ```Project/Solution```

Next navigate to the location you cloned the Repository.

Double click on the ```Word-Guess-Game``` directory.

Then select and open ```Word Guess Game.sln```

------------------------------

## Visuals

##### Application Start
![Screenshot of Main Menu Prompt Upon App Start](\assets\ApplicationStart.JPG)

##### Using the Application
![Screenshot of initial View Characters selection](\assets\ViewCharacters.JPG)


![Screenshot of Add Character selection](https://raw.githubusercontent.com/Meggan-Triplett/Word-Guess-Game/master/assets/AddCharacter.JPG)


![Screenshot of Remove Character selection](\assets\RemoveCharacter.JPG)


------------------------------

## Change Log
1.1 Fixed error and bugs, added comments, wrote missing tests. Known bug: persisting the updatedBlankArray with user 
	answers, which breaks game. 6/25/19 - Triplett

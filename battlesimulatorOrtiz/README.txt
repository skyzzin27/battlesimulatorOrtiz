Battle Simulator by  [ Christian Ortiz ]

Description of Characters:

- Bulbasaur: A grass type character known for using Vine Whip and Razor Leaf. Balance Defense and Attack
- Ortiz: A lighting type character known for using Lighting Gun and Lighting Pulse. Higher Defense and lower Attack
- Christian: A Fire type character known for using Fire Spin and Fireball. Lower Defense And Higher Attack


Applied OOP principles

Encasulation - The character attributes (name, type, hp, attack, defense) are grouped inside a character class, hiding internal details from the rest of the program.
Inheritance  - While not directly using inheritance in this version, the structure allows future extension with subclasses ( Fire Character, Grass Character)
Polymorphism - The takedamage() method can be modified or overriden depending on character type logic, which shows flexibility in object behavior
Abstraction  - The combat logic is separated from ui logic using classes like charactrer, hiding complex calculations from the form


Features

- Animated battle effects like bounc, shake, flash
- Critical hit and effectiveness system
- Defense/Blocking sytem
- Health bar color changes depending on remaining HP
- Victory and Game over forms with play again and exit option


Challenges Faced

- Implementing animated damage effect without freezing the ui
- Synchronizing enemy turn after player attacks using timers
- Managing form trasitions (Start - Select - Battle - Victory/GameOver)
- Handling different types and effectiveness calculatins
- Debugging interactions

Instructions

- Choose your character.
- Battle with attacks and defend options.
- Win by reducing enemy HP to zero.
- Enjoy smooth animation and OOP structure



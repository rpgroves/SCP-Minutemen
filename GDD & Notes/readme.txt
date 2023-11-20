SCP: Minutemen

Controls:
    WASD - move
    shift - run
    tab - inventory
    LMB - shoot
    r - reload

Important Notes for this version:
    - no sounds yet, but this is something that will be changing soon!
    - while the computers you can interact with may seem important, they do not yet
    have any effect on gameplay, if you would like to see what one looks like however,
    the password to the ones in the security stations is "1111"
    - currently, using the interact key multiple times on an object, or the inventory key,
    will likely result in the same menu opening many instances instead of one, (ie. you might
    spawn a bunch of inventory boxes and have to close a bunch of them), so be careful
    not to spam the f or tab keys
    - The player cannot currently recover health, but they can recover shields by staying out of
    combat / not being injured for long enough.
    - Some enemies may get stuck on objects, this is something i can fix later but it will take some time
    as i have to manually do a lot of the editing for the enemy pathfinding

Gameplay Guide:
    Currently, the game is split into a few main sections:
    - Main menu
    - Opening cutscene / dialogue
    - SCP Site 08 Entrance Zone / Welcome Center
    - SCP 106 boss fight
    - Ending cutscene

    Here is a guide for each area:
    
    Main Menu:
    - clicking the door will move it to reveal buttons to start the game
    - clicking the door on the right will close the game

    Opening cutscene / dialogue
    - walking to the left will start the dialogue
    - walking to the right will start the game / move you to the SCP Site

    SCP Site 08
    - Opening:
        - you start behind a set of heavy doors and near a security station
        - the sector you start in is currently on lockdown, so your main objective
        becomes lifting that lockdown to advance to further sectors
        - walking to the right you will find a small office space with buttons inside
        - pressing the right buttons to open all doors in the hallway to the right 
        will allow you to get to the security station
        - once inside the security station, you can collect your first weapon, and use a save 
        station located in the bottom of the guard station
        - you are then faced with puzzle two, you need to find
        each number written on the ground and input them into the keypad in the correct order
        - once you enter the number, you can enter the welcome center above the security station

    - Welcome Center:
        - once inside the welcome center, you have to fight your first wave of enemies, once they
        are defeated you should head inside the small booth at the center of the welcome area
        - to get inside that booth, find the keycard hidden in the room.
        - inside the booth is a button which will open the door located to the left side of the 
        welcome area
        - opening this door does not lift the lockdown on the sector, but does allow you to move to a new area
        within it

    - Main Halls
        - there is a lot to go through in this area, but the main things are as follows:
            - immediately heading north and into the office space there, you will find an engineers keycard
            - you can bring that card to the south, then to the west where there is a symbol of lighting
            on the ground to enter the power station
            - inside the power station there is a puzzle involving colored symbols on the ground
            inputting the correct color combinations, then flipping the lever in each room of generators
            will turn the power on, allowing you to return to the welcome center to lift the lockdown
        - Some smaller things to note:
            - in the south of this area there is a guard station, it contains a suppressed pistol (no stealth 
            implemented yet D:) and a save station.
            - in the northwest of this area, there is a Mobile Task Force locker room with a rifle
            - in the far west, there is a cafeteria, bathrooms, and a room with files and servers, in the
            bathroom there is an administrator keycard that can get you into the server room, but there is nothing
            there for the moment.
            - in the southeast, there is an office with a small encounter that plays upon entering, but there is nothing
            to gain from this area yet.

        - Return to the welcome center
            - returning to the welcome center to lift the lockdown, you will now want to try hitting
            a button inside the booth at the center of the room
            - SCP 106 spawns just before you can reach the booth, triggering a boss battle
            - SCP 106 has three moves during this phase of the fight, shooting multiple projectiles in a circle, 
            shooting a singular (but fast) projectile at the player, and shooting an arc of 3 projectiles at the player
            - SCP 106 will be damaged by bullets, but during this phase of the fight you cannot kill him.
            - Upon either A: making contact with 106, or B: getting 106 to half health, he will pull you into
            a pocket dimension, changing scenes.

        - SCP 106's pocket dimension
            - The player spawns in a small inlet of a very large room, finding a special elecrified weapon on the ground they can fight 106 with
            - During this phase of the boss fight, 106 has the same moves, but also has shields surrounding him that the player must break
            - from here it is a basic bullet hell bossfight, with SCP 106 sinking into the ground at the end of the fight (still need to get
            death animations working with the nav mesh pro pathfinding i added).
            - After defeating 106, the player can walk to an exit located in the north.
            - Exiting, the player is brought to a placeholder credits scene (but more on my ending later!).

Bugs:
    - No death animations yet
    - Enemies can currently shoot each other, and the player can currently shoot themselves when running fast enough
    - Minigames and popup menus can accidentally be opened many times instead of once.
    - The player can leave the area while interacting with an object
    - No health recovery options yet, but saving the game and dying/respawning should bring you to full health.

Note to the professor:
    Hi professor! As you may have noticed, my beta is a bit late again, as well as a bit behind. I've had an extremely hectic couple weeks with two other 
    class's projects and applying to / interviewing for internships, and have been a little behind in general. But! I plan on doing a whole lot of work over 
    break as the programming side of the game is quickly closing in on 100% completion (One thing i will definitely be dropping from my plans for now is the 
    computer popup menu, as it has a lot of functionality planned and would be something i should do after completing the game), which means I can spend the 
    rest of that time improving the story and other gameplay elements that I have been using more as placeholders thusfar. I hope you can excuse my lateness 
    on this assignment though, as I spent quite a bit of time improving the game and didnt want to turn it in until it was much closer to completion than it
    was last week. I have made great strides in connecting the scenes and adding important / core elements so far so I am quite close to finishing the game 
    once I clean and polish it. I plan on including many of the things you have mentioned for the game as well! Such as having a menu that shows a uniformed
    superior giving commands to the player instead of a dialogue box. This is something i specifically plan to implement over thanksgiving break as it shouldnt
    be too difficult to make, I just havent had the time to implement it as i worked on some other areas of the game to get the core gameplay up and running.

    Thank you for reading this!
    - Ryan Groves
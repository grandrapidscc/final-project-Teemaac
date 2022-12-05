
// See https://aka.ms/new-console-template for more information
using System;

//array that represents the dungeon, 0 is walls
int [,] dungeon = { {0, 0, 0, 0, 0, 0, 0}, {0, 1, 2, 3, 4, 5, 0}, {0, 6, 7, 8, 9, 10, 0}, {0, 11, 12, 13, 14, 15, 0}, {0, 16, 17, 18, 19, 20, 0}, {0, 21, 22, 23, 24, 25, 0}, {0, 0, 0, 0, 0, 0, 0}};

//team of monsters
Orc orc1 = new Orc();
Orc orc2 = new Orc();
Orc orc3 = new Orc();
Orc orc4 = new Orc();
Banshee b1 = new Banshee();
Banshee b2 = new Banshee();
Banshee b3 = new Banshee();
Banshee b4 = new Banshee();
Goblin g1 = new Goblin();
Goblin g2 = new Goblin();
Goblin g3 = new Goblin();
Goblin g4 = new Goblin();
Goblin g5 = new Goblin();

Health h1 = new Health();
Health h2 = new Health();
Health h3 = new Health();
Magika m1 = new Magika();
Magika m2 = new Magika();
Magika m3 = new Magika();

//instantiate Wizert
Wizert wiz = new Wizert();

//generate random number
Random rand = new Random();

//get random coordinates in set vals for start and exit
int exitX = rand.Next(1,5);
int exitY = rand.Next(1,5);

//player location and exit
int location = dungeon[wiz.playerX, wiz.playerY];

//intro
Console.WriteLine("WIZERT 1: RETRO REMASTERED");
Console.WriteLine("You are in a damp dungeon illuminated by torches.");


//var so the wizert can flee backward
int prevLocation = rand.Next(1,25);
//movement

//north
void goNorth(){
    prevLocation = location;
    wiz.playerY = wiz.playerY + 1;
    location = dungeon[wiz.playerX, wiz.playerY];
    if (location == 0){
        wiz.playerY = wiz.playerY - 1;
        Console.WriteLine("The Wizert has bumped into a wall.");
    }
    location = dungeon[wiz.playerX, wiz.playerY];
}
//south
void goSouth(){
    wiz.playerY = wiz.playerY - 1;
    location = dungeon[wiz.playerX, wiz.playerY];
    if (location == 0){
        wiz.playerY = wiz.playerY + 1;
        Console.WriteLine("The Wizert has bumped into a wall.");
    }
    prevLocation = location;
    location = dungeon[wiz.playerX, wiz.playerY];
}

//east
void goEast(){
    wiz.playerX = wiz.playerX + 1;
    location = dungeon[wiz.playerX, wiz.playerY];
    if (location == 0){
        wiz.playerX = wiz.playerX - 1;
        Console.WriteLine("The Wizert has bumped into a wall.");
    }
    prevLocation = location;
    location = dungeon[wiz.playerX, wiz.playerY];
}

void goWest(){
    wiz.playerX = wiz.playerX - 1;
    location = dungeon[wiz.playerX, wiz.playerY];
    if (location == 0){
        wiz.playerX = wiz.playerX + 1;
        Console.WriteLine("The Wizert has bumped into a wall.");
    }
    prevLocation = location;
    location = dungeon[wiz.playerX, wiz.playerY];
}

//check to see if a player wins each time they move
void checkWin(){
    if(dungeon[wiz.playerX,wiz.playerY] == dungeon[exitX,exitY]){
        Console.WriteLine("You've found the exit! Congradulations!");
        exitScreen();
    }
}

void exitScreen(){
        Console.WriteLine("Would you like to play again?");
        Console.WriteLine("1.	To Play Again!");
        Console.WriteLine("2.	To Quit");
        int end = Convert.ToInt32(Console.ReadLine());
        if(end == 1){
           Console.WriteLine("Restarting Game");
           playAgain();
        }else if (end == 2){
            Console.WriteLine("Thanks for playing!");
            Environment. Exit(0);
        }else{
            Console.WriteLine("Error. Please enter 1 or 2.");
        }
}

//attempt to flea
void rollDice(){
    int luckyNum = rand.Next(1,10);
    if(luckyNum / 2 == 0){
        Console.WriteLine("The Wizert has escaped!");
        location = prevLocation;
        }else{
            Console.WriteLine("The Wizert failed to escape.");
        }
}

//mothod to only use potions once
void potion(powerups power){
    if(power.used == false){
        power.used = true;
        Console.WriteLine("You've found a " + power.name);
        Console.WriteLine("It is " + power.description);
        if(power.name == "Magika Potion"){
            wiz.mp = wiz.mp + 20;
        }else{
            wiz.hp = wiz.hp + 10; 
        }
    }
}

//method to reset game
void playAgain(){
    //team of monsters
    orc1.ressurect();
    orc2.ressurect();
    orc3.ressurect();
    orc4.ressurect();
    b1.ressurect();
    b2.ressurect();
    b3.ressurect();
    b4.ressurect();
    g1.ressurect();
    g2.ressurect();
    g3.ressurect();
    g4.ressurect();
    g5.ressurect();

    h1.used = false;
    h2.used = false;
    h3.used = false;
    m1.used = false;
    m2.used = false;
    m3.used = false;

    wiz.reset();

    int exitX = rand.Next(1,5);
    int exitY = rand.Next(1,5);
}

//fight methods
void fight(Enemy badGuy){
        Console.WriteLine("The " + badGuy.name + " " + badGuy.moves + "s the Wizert!");
        if (wiz.hp < 1){
            Console.WriteLine("You've been defeated by the " + badGuy.name);
            exitScreen();
        }
        wiz.hp = wiz.hp - badGuy.damage;
        Console.WriteLine("The Wizert's Health: " + wiz.hp);
        wiz.fireball();
        badGuy.hp = badGuy.hp - 3;
        if(badGuy.hp > 0){
            Console.WriteLine("This " + badGuy.name + "'s Health: " + badGuy.hp);
        }
}


void encounter(Enemy badGuy){
        //encounter loop
        if(badGuy.hp > 0){
            Console.WriteLine("You've encountered a/an" + badGuy.name);
            while(badGuy.hp > 0){
                Console.WriteLine("Enemy HP: " + badGuy.hp);
                Console.WriteLine("Press... ");
                Console.WriteLine("1.	To Attack");
                Console.WriteLine("2.	To Heal");
                Console.WriteLine("3.	To Attempt to Flee");

                //takes user input to determine move
                int move = Convert.ToInt32(Console.ReadLine());
                //check for null
                //if(move){}
                //switch based on move choice
                switch(move){
                    //fight with the orc
                    case 1:
                        fight(badGuy);
                        break;
                    //heal
                    case 2:
                        wiz.heal();
                        break;
                    //attempt to flee
                    case 3:
                        rollDice();
                        break;
                    default:
                        Console.WriteLine("Error. Please enter 1, 2, or 3");
                        break;
                    }

            }
            Console.WriteLine("The " + badGuy + " couldn't handle the heat.");
        
        }else{
            Console.WriteLine("This place feels familiar...");
        }
};

//text for empty locations
void empty(){
    Console.WriteLine("You can't see much here.");
}

//travel

void travel(){
    Console.WriteLine("Which direction would you like to go?");
    Console.WriteLine("Press... ");
    Console.WriteLine("1.   Go North");
    Console.WriteLine("2.   Go South");
    Console.WriteLine("3.   Go East");
    Console.WriteLine("4.   Go West");

    int direct = Convert.ToInt32(Console.ReadLine());

        switch(direct){
        case 1:
            goNorth();
            break;
        case 2:
            goSouth();
            break;
        case 3:
            goEast();
            break;
        case 4:
            goWest();
            break;
        default:
            Console.WriteLine("Error. Please enter 1, 2, 3, or 4.");
            break;
    }
}


//switch to find enemies, powerup, exit
while(location != 0){
    switch(location){
    case 1:
        checkWin();
        //enemy encounter
        encounter(orc1);
        travel();
        break;
    case 2:
        checkWin();
        potion(h1);
        travel();
        break;
    case 3:
        checkWin();
        potion(m1);
        encounter(orc2);
        travel();
        break;
    case 4:
        checkWin();
        empty();
        travel();
        break;
    case 5:
        checkWin();
        encounter(g1);
        travel();
        break;
    case 6:
        checkWin();
        empty();
        travel();
        break;
    case 7:
        checkWin();
        potion(h2);
        encounter(g2);
        travel();
        break;
    case 8:
        checkWin();
        encounter(orc4);
        travel();
        break;
    case 10:
        checkWin();
        empty();
        travel();
        break;
    case 11:
        checkWin();
        potion(h3);
        travel();
        break;
    case 12:
        checkWin();
        encounter(b3);
        travel();
        break;
    case 13:
        checkWin();
        potion(m3);
        travel();
        break;
    case 14:
        checkWin();
        encounter(b2);
        travel();
        break;
    case 15:
        checkWin();
        empty();
        travel();
        break;
    case 16:
        checkWin();
        encounter(g3);
        travel();
        break;
    case 17:
        checkWin();
        empty();
        travel();
        break;
    case 18:
        checkWin();
        encounter(b1);
        travel();
        break;
    case 19:
        checkWin();
        empty();
        travel();
        break;
    case 20:
        checkWin();
        encounter(g5);
        travel();
        break;
    case 21:
        checkWin();
        encounter(b4);
        travel();
        break;
    case 22:
        checkWin();
        empty();
        travel();
        break;
    case 23:
        checkWin();
        encounter(orc4);
        travel();
        break;
    case 24:
        checkWin();
        empty();
        travel();
        break;
    case 25:
        checkWin();
        encounter(orc3);
        travel();
        break;

};
};





// See https://aka.ms/new-console-template for more information

/* todo:
win screen + play again
fix input issue
*/
using System.Windows;


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

//instantiate Wizert
Wizert wiz = new Wizert();

//generate random number
Random rand = new Random();

//get random coordinates in set vals for start and exit
int exitX = rand.Next(1,5);
int exitY = rand.Next(1,5);

//player locatiom
int location = dungeon[wiz.playerX, wiz.playerY];
//movement
//north
void goNorth(){
    Console.WriteLine("Player moved north");
    wiz.playerY = wiz.playerY + 1;
    if (location == 0){
        wiz.playerY = wiz.playerY - 1;
        Console.WriteLine("The Wizert has bumped into a wall.");
    }
    location = dungeon[wiz.playerX, wiz.playerY];
    Console.WriteLine(location);
}
//south
void goSouth(){
    wiz.playerY = wiz.playerY - 1;
    if (location == 0){
        wiz.playerY = wiz.playerY + 1;
        Console.WriteLine("The Wizert has bumped into a wall.");
    }
}
//east
void goEast(){
    wiz.playerX = wiz.playerX + 1;
    if (location == 0){
        wiz.playerY = wiz.playerY - 1;
        Console.WriteLine("The Wizert has bumped into a wall.");
    }
}

void goWest(){
    wiz.playerX = wiz.playerX - 1;
    if (location == 0){
        wiz.playerY = wiz.playerY + 1;
        Console.WriteLine("The Wizert has bumped into a wall.");
    }
}


//magika potion encounter
void magickaPotion(){
    Console.WriteLine("You've found a Magika potion");
    Console.WriteLine("This will restore 20 Magika Points");
    wiz.mp = wiz.mp + 20;
};

//health potion encounter
void healthPotion(){
    Console.WriteLine("You've found a Health potion");
    Console.WriteLine("This will restore 10 Health Points");
    wiz.hp = wiz.hp + 10;
}

//fight methods
void fight(Enemy badGuy){
        wiz.fireball();
        badGuy.hp = badGuy.hp - 3;
        Console.WriteLine("This " + badGuy.name + "'s Health: " + badGuy.hp);
        Console.WriteLine("The " + badGuy.name + " " + badGuy.moves + "'s the Wizert!");
        wiz.hp = wiz.hp - 2;
        Console.WriteLine("The Wizert's Health: " + wiz.hp);
}


void encounter(Enemy badGuy){
        Console.WriteLine("You've encountered a/an " + badGuy.name);
        Console.WriteLine("It's current hp is " + badGuy.hp);
        //encounter loop
        while(badGuy.hp > 0){
            Console.WriteLine("Press... ");
            Console.WriteLine("1.	To Attack");
            Console.WriteLine("2.	To Heal");
            Console.WriteLine("3.	To Attempt to Flee");
            //takes user input to determine move
            int move = Convert.ToInt32(Console.ReadLine());
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
                    wiz.rollDice();
                    break;
                default:
                    Console.WriteLine("Error. Please enter 1, 2, or 3");
                    break;
        }
        }
};

//travel

void travel(){
    Console.WriteLine("Which direction would you like to go?");
    Console.WriteLine("Press... ");
    Console.WriteLine("1.   Go North");
    Console.WriteLine("2.   Go South");
    Console.WriteLine("3.   Go East");
    Console.WriteLine("4.   Go West");

    int direct = 1;

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
while(location != dungeon[exitX,exitY]){
    switch(location){
    case 1:

        //enemy encounter
        encounter(orc1);
        travel();
        break;
    case 2:

        magickaPotion();
        travel();
        break;
    case 3:

        healthPotion();
        encounter(orc2);
        travel();
        break;
    case 4:
     
        travel();
        break;
    case 5:

        magickaPotion();
        encounter(g1);
        travel();
        break;
    case 6:

        travel();
        break;
    case 7:

        healthPotion();
        encounter(g2);
        travel();
        break;
    case 8:

        encounter(orc4);
        travel();
        break;
    case 10:
   
        break;
    case 11:

        magickaPotion();
        travel();
        break;
    case 12:

        encounter(b3);
        travel();
        break;
    case 13:

        healthPotion();
        travel();
        break;
    case 14:

        encounter(b2);
        travel();
        break;
    case 15:
  
        travel();
        break;
    case 16:
        magickaPotion();
        encounter(g3);
        travel();
        break;
    case 17:
   
        healthPotion();
        travel();
        break;
    case 18:

        encounter(b1);
        travel();
        break;
    case 19:

        travel();
        break;
    case 20:

        healthPotion();
        encounter(g5);
        travel();
        break;
    case 21:
  
        encounter(b4);
        travel();
        break;
    case 22:

        travel();
        break;
    case 23:

        encounter(orc4);
        travel();
        break;
    case 24:

        healthPotion();
        travel();
        break;
    case 25:

        encounter(orc3);
        travel();
        break;

};
};

Console.WriteLine("You've found the exit! Congradulations!");
        Console.WriteLine("Would you like to play again?");
        Console.WriteLine("1.	To Play Again!");
        Console.WriteLine("2.	To Quit");
        int end = Convert.ToInt32(Console.ReadLine());
        if(end == 1){
           Console.WriteLine("Restarting Game");
        }else if (end == 2){
            Console.WriteLine("Thanks for playing!");
            Environment. Exit(0);
        }else{
            Console.WriteLine("Error. Please enter 1 or 2.");
        }




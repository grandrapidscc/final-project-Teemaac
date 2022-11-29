// See https://aka.ms/new-console-template for more information
//array that represents the dungeon, 0 is walls
int [,] dungeon = { {0, 0, 0, 0, 0, 0, 0}, {0, 1, 2, 3, 4, 5, 0}, {0, 6, 7, 8, 9, 10, 0}, {0, 11, 12, 13, 14, 15, 0}, {0, 16, 17, 18, 19, 20, 0}, {0, 21, 22, 23, 24, 25, 0}, {0, 0, 0, 0, 0, 0, 0}};

//generate random number
Random rand = new Random();

//get random coordinates in set vals for start and exit
int playerX = rand.Next(1,5);
int playerY = rand.Next(1,5);
int exitX = rand.Next(1,5);
int exitY = rand.Next(1,5);

//method to check if exit is found
void checkWin(){
    if(dungeon[playerX,playerY] == dungeon[exitX,exitY]){
        Console.WriteLine("You've found the exit! Congradulations!");
        //add code to end game here
    }
}

//player locatiom
int location = dungeon[playerX,playerY];

//orc encounter
void orcEncounter(Orc){
    Console.WriteLine("You've encountered an Orc.");
    //need to create different instances of the Orc to keep track of their seprate hps
    Console.WriteLine("It's current hp is ");
    Console.WriteLine("Press... ");
    Console.WriteLine("1.	To Attack");
    Console.WriteLine("2.	To Heal");
    Console.WriteLine("3.	To Attempt to Flee");
    //read line to choose move
};

//magika potion encounter
void magickaPotion(){
    Console.WriteLine("You've found a Magika potion");
    Console.WriteLine("This will restore 20 Magika Points");
    //add 20 mp to wizert
};

//health potion encounter
void healthPotion(){
    Console.WriteLine("You've found a Health potion");
    Console.WriteLine("This will restore 10 Health Points");
    //add 10 hp to wizert
}

//TODO create wizert moves. Do this in Wizert class? Should other related methods be in their own classes?

//switch to find enemies, powerup, exit
switch(location){
    case 1:
        checkWin();
        break;
    case 2:
        checkWin();
        break;
    case 3:
        checkWin();
        break;
    case 4:
        checkWin();
        break;
    case 5:
        checkWin();
        break;
    case 6:
        checkWin();
        break;
    case 7:
        checkWin();
        break;
    case 8:
        checkWin();
        break;
    case 10:
        checkWin();
        break;
    case 11:
        checkWin();
        break;
    case 12:
        checkWin();
        break;
    case 13:
        checkWin();
        break;
    case 14:
        checkWin();
        break;
    case 15:
        checkWin();
        break;
    case 16:
        checkWin();
        break;
    case 17:
        checkWin();
        break;
    case 18:
        checkWin();
        break;
    case 19:
        checkWin();
        break;
    case 20:
        checkWin();
        break;
    case 21:
        checkWin();
        break;
    case 22:
        checkWin();
        break;
    case 23:
        checkWin();
        break;
    case 24:
        checkWin();
        break;
    case 25:
        checkWin();
        break;

};




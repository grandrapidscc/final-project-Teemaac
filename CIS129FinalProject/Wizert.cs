using System;
class Wizert : being{

    //random
    static Random roll = new Random();
    //declare magika points
    public int mp;
    //randomize player start location
    public int playerX = roll.Next(1,5);
    public int playerY = roll.Next(1,5);

    //initialize mp and hp
   public Wizert(){
    mp = 100;
    hp = 200;
   }
   //heal method
   public void heal(){
        Console.WriteLine("The Wizert casts a spell to heal his wounds.");
        Console.WriteLine("The spell used 5 Magika Points.");
        mp = mp - 5;
        hp = hp + 3;
        Console.WriteLine("The Wizert's Health: " + hp);
   }

    //give the wizert a chance to escape the enemy
   public void rollDice(){
        int luckyNum = roll.Next(1,10);
            if(luckyNum / 2 == 0){
                    Console.WriteLine("The Wizert has escaped!");
                }else{
                    Console.WriteLine("The Wizert failed to escape.");
                }
   }

   public void fireball(){
        Console.WriteLine("The Wizert casts a fireball that burns the enemy!");
        Console.WriteLine("Fireball used 3 Magika Points");
        mp = mp = -3;
        
   }

   public void reset(){
        playerX = roll.Next(1,5);
        playerY = roll.Next(1,5);
        mp = 100;
        hp = 200;
   }

}
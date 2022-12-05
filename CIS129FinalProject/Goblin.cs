class Goblin : Enemy{
    public Goblin(){
        name = "Goblin";
        damage = 2;
        hp = 3;
        moves = "Body Slam";
    }

    public void ressurect(){
        hp = 3;
    }
}
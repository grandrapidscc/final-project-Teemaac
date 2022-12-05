class Orc : Enemy{

    public Orc(){
        name = "Orc";
        damage = 3;
        hp = 5;
        moves = "Cleave";

    }

    public void ressurect(){
        hp = 5;
    }

}
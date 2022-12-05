class Banshee : Enemy{

    public Banshee(){
        name = "Banshee";
        damage = 5;
        hp = 8;
        moves = "Screeche";
    }

    public void ressurect(){
        hp = 8;
    }
}
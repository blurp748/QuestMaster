using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDatabase : MonoBehaviour
{
    private List<Item> items = new List<Item>();

    public void Awake()
    {
        BuildDatabase();
    }

    public Item getItem(int id)
    {
        return items.Find(item => item.id == id);
    }

    public Item getItemByName(string name)
    {
        return items.Find(item => item.name == name);
    }

    void BuildDatabase()
    {
        // Id - Rarete - Name - Icon - Description - Nombre d'ennemis
        items = new List<Item>(){
            //Slime
            new Item(0,"F","Bague du Slime","Slimei","Invoque un slime",1),
            new Item(1,"F","Bague du Slime de vent","Slime Windi","Invoque un slime de vent",1),
            new Item(2,"F","Bague du Slime du tonnerre","Slime Thunderi","Invoque un slime de tonnerre",1),
            new Item(3,"F","Bague du Slime de feu","Slime Firei","Invoque un slime de feu",1),
            new Item(4,"F","Bague du Slime sacre","Slime Holyi","Invoque un slime sacre",1),
            new Item(5,"F","Bague du Slime de terre","Slime Earthi","Invoque un slime de terre",1),
            new Item(6,"F","Bague du Slime sombre","Slime Darki","Invoque un slime sombre",1),
            new Item(7,"E","Bague du double Slime","Slimei","Invoque deux slime",2),

            //Toxic
            new Item(8,"F","Bague du Cactus","Toxic Cactus C","Invoque un cactus",1),
            new Item(9,"F","Bague de la Grenouille Noire","Toxic FRog A2","Invoque une grenouille noire",1),
            new Item(10,"F","Bague de la Grenouille Blanche","Toxic Frog B2","Invoque une grenouille blanche",1),
            new Item(11,"F","Bague de la Grenouille Verte","Toxic Frog C2","Invoque une grenouille verte",1),
            new Item(12,"E","Bague de la Plante Carnivore","Toxic Maneater Plant B","Invoque une plante carnivore",1),
            new Item(13,"E","Bague de la Racine Toxique","Toxic Root B","Invoque une racine toxique",1),
            new Item(14,"E","Bague du Champignon","Toxic Shroom C","Invoque un champignon",1),

            //Skeleton
            new Item(15,"E","Bague du Chevalier Squelette","Skeleton Knight Alstreim","Invoque un chevalier squelette",1),
            new Item(16,"D","Bague du Baron Squelette","Skeleton Knight Baron","Invoque un baron squelette",1),
            new Item(17,"E","Bague du Soldat Squelette","Skeleton Knight Debon","Invoque un soldat squelette",1),
            new Item(18,"D","Bague du Squelette Enflamme","Skeleton Knight Debons","Invoque un squelette enflamme",1),
            new Item(19,"E","Bague du Mage Squelette","Skeleton Mage","Invoque un mage squelette",1),
            new Item(20,"E","Bague du Necromancien Squelette","Skeleton Mage Mabon","Invoque un squelette necromancien",1),

            //Beach
            new Item(21,"D","Bague du Bigorneau","Sea Beach Dark Shell","Invoque un bigorneau",1),
            new Item(22,"D","Bague de l'Etoile de Mer","Sea Beach Dark Star","Invoque une etoile de mer",1),
            new Item(23,"D","Bague du Crabe Bleu","Sea Beach Emperor Crab A","Invoque un crabe bleu",1),
            new Item(24,"D","Bague du Crabe Rouge","Sea Beach Emperor Crab B","Invoque un crabe rouge",1),
            new Item(25,"D","Bague du Pelican","Sea Beach Pelican","Invoque un pelican",1),
            new Item(26,"D","Bague du Goelan","Sea Beach Seagull","Invoque un goelan",1),
            new Item(27,"D","Bague du Homard Bleu","Sea Beach War Lobster A","Invoque un homard bleu",1),
            new Item(28,"D","Bague du Homard Rouge","Sea Beach War Lobster B","Invoque un homard rouge",1),

            //Orc
            new Item(29,"D","Bague de l'Orc Archer","Orc Archer","Invoque un crabe rouge",1),
            new Item(30,"C","Bague de l'Orc Hache","Orc Axe Warrior","Invoque un pelican",1),
            new Item(31,"D","Bague de l'Orc Guerrier","Orc Sword Warrior","Invoque un goelan",1),
            new Item(32,"D","Bague de l'Orc Monte","Orc War Drummer","Invoque un homard bleu",1),
            new Item(33,"C","Bague de l'Orc Demoniste","Orc Warlock","Invoque un homard rouge",1),

            //Eldritch
            new Item(34,"D","Bague du Chien Eldritch","Eldritch Abomination Hound","Invoque un crabe bleu",1),
            new Item(35,"C","Bague de l'Abomination Eldritch","Eldritch Abomination Gazer","Invoque un crabe rouge",1),
            new Item(36,"C","Bague du Tyrant Eldritch","Eldritch Abomination Tyrant","Invoque un pelican",1),
            new Item(37,"C","Bague du Monstre des Abysses Eldritch","Eldritch Abominations Abyss Denizen","Invoque un goelan",1),
            new Item(38,"D","Bague de l'Eclaireur Eldritch","Eldritch Abominations Scout","Invoque un homard bleu",1),
            new Item(39,"B","Bague du Seigneur Eldritch","Eldritch Abominations Ultimate","Invoque un homard rouge",1),

            //Fusion
            new Item(40,"D","Bague de Flynn","Boss Flynn The Original Slime","",1),
            new Item(41,"D","Bague du Golem Slime","Boss Slime Golem","",1),
            new Item(42,"A","Bague du Slime Esprit Eldritch","Boss Eldritch Slime Overmind","",1),
            new Item(43,"A","Bague du Slime Demon","Boss Doppelganger Slime","",1),
            new Item(44,"S","Bague du Slime Mangeur d'Hommes","Blood Manipulation Slime","",1),
            new Item(45,"B","Bague du Slime Eldritch Sentinelle","Eldritch Slime Spawn D","",1),
            new Item(46,"B","Bague du Slime Eldritch Assaillant","Eldritch Slime Spawn E","",1),
            new Item(47,"B","Bague du Grand Chef Orc","Boss Orc Chief Grunt","",1),
            new Item(48,"SS","Bague de la Grand Sorciere Duessa","Boss Grand Sorceress Duessa","",1),
            new Item(49,"B","Bague de la Tortue de Guerre","Sea Beach Turtle","",1),
            new Item(50,"SS","Bague de Shaccad'Yoggoth","Boss Eldritch God Shaccad'Yoggoth","",1),
            new Item(51,"SSS","Bague Ultime de Shaccad'Yoggoth","Eldritch God Shaccad'Yoggoth","",1),
            new Item(52,"A","Bague de l'Ombre Eldritch","Eldritch Slime Spawn A","",1),
            new Item(53,"S","Bague du Crane","Gazers Skull","",1),
            new Item(54,"S","Bague du Mage","Blood Manipulation Mage","",1),
            new Item(54,"A","Bague de l'Ogre de feu","Fire Ogre","",1)
        };
    }
}

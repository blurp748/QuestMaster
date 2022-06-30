using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterDatabase : MonoBehaviour
{
    private List<Monster> monsters = new List<Monster>();

    public void Awake()
    {
        BuildDatabase();
    }

    public Monster getItem(string familyName)
    {
        return monsters.Find(monsterList => monsterList.familyName == familyName);
    }

    public Monster getItem(int id)
    {
        return monsters[id];
    }

    void BuildDatabase()
    {
        monsters = new List<Monster>(){
            new Monster("Dummy",1,new List<string>(){"Arcane Crystal"},new List<string>()),
            new Monster("Slime",1,new List<string>(){"Slime Darki","Slime Earthi","Slime Holyi","Slime Firei","Slime Thunderi","Slime Windi","Slimei"},new List<string>(){"Bague du Slime","Bague du Slime de vent","Bague du Slime du tonnerre","Bague du Slime de feu","Bague du Slime sacre","Bague du Slime de terre","Bague du Slime sombre","Bague du double Slime"}),
            new Monster("Toxic",1,new List<string>(){"Toxic Cactus C","Toxic FRog A2","Toxic Frog B2","Toxic Frog C2","Toxic Maneater Plant B","Toxic Root B","Toxic Shroom C"},new List<string>(){"Bague du Cactus","Bague de la Grenouille Noire","Bague de la Grenouille Blanche","Bague de la Grenouille Verte","Bague de la Plante Carnivore","Bague de la Racine Toxique","Bague du Champignon"}),
            new Monster("Skeleton",1,new List<string>(){"Skeleton Knight Alstreim","Skeleton Knight Baron","Skeleton Knight Debon","Skeleton Knight Debons","Skeleton Mage","Skeleton Mage Mabon"},new List<string>(){"Bague du Chevalier Squelette","Bague du Baron Squelette","Bague du Soldat Squelette","Bague du Squelette Enflamme","Bague du Mage Squelette","Bague du Necromancien Squelette"}),
            new Monster("Beach",1,new List<string>(){"Sea Beach Dark Shell","Sea Beach Dark Star","Sea Beach Emperor Crab A","Sea Beach Emperor Crab B","Sea Beach Pelican","Sea Beach Seagull","Sea Beach War Lobster A","Sea Beach War Lobster B"},new List<string>(){"Bague du Bigorneau","Bague de l'Etoile de Mer","Bague du Crabe Bleu","Bague du Crabe Rouge","Bague du Pelican","Bague du Goelan","Bague du Homard Bleu","Bague du Homard Rouge"}),
            new Monster("Orc",1,new List<string>(){"Orc Archer","Orc Axe Warrior","Orc Sword Warrior","Orc War Drummer","Orc Warlock"},new List<string>(){"Bague de l'Orc Archer","Bague de l'Orc Hache","Bague de l'Orc Guerrier","Bague de l'Orc Monte","Bague de l'Orc Demoniste"}),
            new Monster("Eldritch",1,new List<string>(){"Eldritch Abomination Hound","Eldritch Abomination Gazer","Eldritch Abomination Tyrant","Eldritch Abominations Abyss Denizen","Eldritch Abominations Scout","Eldritch Abominations Ultimate"},new List<string>(){"Bague du Chien Eldritch","Bague de l'Abomination Eldritch","Bague du Tyrant Eldritch","Bague du Monstre des Abysses Eldritch","Bague de l'Eclaireur Eldritch","Bague du Seigneur Eldritch"})
        };
    }

}

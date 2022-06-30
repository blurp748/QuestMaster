using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MergeDatabase : MonoBehaviour
{
    private IDictionary<string, string> mergeDatabase = new Dictionary<string, string>();

    public void Awake()
    {
        BuildDatabase();
    }

    public string findItem(string item1, string item2)
    {
        string res = "";
        if(mergeDatabase.ContainsKey(item1+item2)){  
            res = mergeDatabase[item1+item2];
        } else if(mergeDatabase.ContainsKey(item2+item1))
        {
            res = mergeDatabase[item2+item1];
        }
        return res;
    }

    void BuildDatabase()
    {
        string slime = "Bague du Slime";
        string windSlime = "Bague du Slime de vent";
        string thunderSlime = "Bague du Slime du tonnerre";
        string fireSlime = "Bague du Slime de feu";
        string holySlime = "Bague du Slime sacre";
        string earthSlime = "Bague du Slime de terre";
        string darkSlime = "Bague du Slime sombre";
        string doubleSlime = "Bague du double Slime";

        string cactus = "Bague du Cactus";
        string blackFrog = "Bague de la Grenouille Noire";
        string whiteFrog = "Bague de la Grenouille Blanche";
        string greenFrog = "Bague de la Grenouille Verte";
        string carnivorousPlant = "Bague de la Plante Carnivore";
        string toxicRoot = "Bague de la Racine Toxique";
        string mushroom = "Bague du Champignon";

        string chevalierSquelette = "Bague du Chevalier Squelette";
        string baronSquelette = "Bague du Baron Squelette";
        string enflammeSquelette = "Bague du Squelette Enflamme";
        string soldatSquelette = "Bague du Soldat Squelette";
        string mageSquelette = "Bague du Mage Squelette";
        string necromancienSquelette = "Bague du Necromancien Squelette";

        string bigorneau = "Bague du Bigorneau";
        string etoileDeMer = "Bague de l'Etoile de Mer";
        string crabeBleu = "Bague du Crabe Bleu";
        string crabeRouge = "Bague du Crabe Rouge";
        string pelican = "Bague du Pelican";
        string goelan = "Bague du Goelan";
        string homardBleu = "Bague du Homard Bleu";
        string homardRouge = "Bague du Homard Rouge"; 

        string archerOrc = "Bague de l'Orc Archer";
        string hacheOrc = "Bague de l'Orc Hache";
        string guerrierOrc = "Bague de l'Orc Guerrier";
        string monteOrc = "Bague de l'Orc Monte";
        string demonisteOrc = "Bague de l'Orc Demoniste"; 

        string chienEldritch = "Bague du Chien Eldritch";
        string abominationEldritch = "Bague de l'Abomination Eldritch";
        string tyrantEldritch = "Bague du Tyrant Eldritch";
        string abyssEldritch = "Bague du Monstre des Abysses Eldritch";
        string scoutEldritch = "Bague de l'Eclaireur Eldritch";
        string seigneurEldritch = "Bague du Seigneur Eldritch"; 

        string flynn = "Bague de Flynn";
        string golemSlime = "Bague du Golem Slime";
        string espritEldritch = "Bague du Slime Esprit Eldritch";
        string demonEldritch = "Bague du Slime Demon";
        string manEater = "Bague du Slime Mangeur d'Hommes";
        string sentinelleEldritch = "Bague du Slime Eldritch Sentinelle";
        string assaillantEldritch = "Bague du Slime Eldritch Assaillant";
        string grandChefOrc = "Bague du Grand Chef Orc";
        string grandSorciereDuessa = "Bague de la Grand Sorciere Duessa";
        string warTurtle = "Bague de la Tortue de Guerre";
        string shaccad = "Bague de Shaccad'Yoggoth";
        string ultimeShaccad = "Bague Ultime de Shaccad'Yoggoth";
        string ombreEldritch = "Bague de l'Ombre Eldritch";
        string crane = "Bague du Crane";
        string mage = "Bague du Mage";
        string fireOgre = "Bague de l'Ogre de feu";

        mergeDatabase.Add(slime+slime,doubleSlime);
        mergeDatabase.Add(doubleSlime+mageSquelette,flynn);
        mergeDatabase.Add(earthSlime+chevalierSquelette,golemSlime);
        mergeDatabase.Add(golemSlime+seigneurEldritch,demonEldritch);
        mergeDatabase.Add(sentinelleEldritch+assaillantEldritch,espritEldritch);
        mergeDatabase.Add(espritEldritch+demonEldritch,manEater);
        mergeDatabase.Add(abominationEldritch+crabeBleu,sentinelleEldritch);
        mergeDatabase.Add(tyrantEldritch+cactus,assaillantEldritch);
        mergeDatabase.Add(hacheOrc+guerrierOrc,grandChefOrc);
        mergeDatabase.Add(bigorneau+demonisteOrc,warTurtle);
        mergeDatabase.Add(shaccad+grandSorciereDuessa,ultimeShaccad);
        mergeDatabase.Add(crane+grandChefOrc,grandSorciereDuessa);
        mergeDatabase.Add(assaillantEldritch+necromancienSquelette,ombreEldritch);
        mergeDatabase.Add(ombreEldritch+enflammeSquelette,crane);
        mergeDatabase.Add(blackFrog+fireOgre,mage);
        mergeDatabase.Add(warTurtle+fireSlime,fireOgre);
        mergeDatabase.Add(mage+toxicRoot,shaccad);


    }
}

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

    public string findItem(string key)
    {
        string res = "";
        if(mergeDatabase.ContainsKey(key)){  
            res = mergeDatabase[key];
        }
        return res;
    }

    void BuildDatabase()
    {
        string slime = "Bague du Slime";
        string windSlime = "Bague du Slime de vent";
        string thunderSlime = "Bague du Slime du tonnerre";
        string fireSlime = "Bague du Slime de feu";
        string holySlime = "Bague du Slime sacré";
        string earthSlime = "Bague du Slime de terre";
        string darkSlime = "Bague du Slime sombre";
        string doubleSlime = "Bague du double Slime";

        mergeDatabase.Add(slime+slime,doubleSlime);
    }
}

using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System;

public class Wizard
{
    public int Id { get; private set; }
    public string Name { get; private set; }
    public string PosessiveName
    {
        get
        {
            if (Name.Last() == 's')
                return Name + "'";
            else
                return Name + "'s";
        }
    }

    public Wizard(int id, string name)
    {
        this.Id = id;
        this.Name = name;
    }
}

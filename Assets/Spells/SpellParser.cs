using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System;
using System.IO;

public static class SpellParser
{
    static string descriptorsPath = "Assets\\Spells\\spell_descriptors.txt";
    static string objectsPath = "Assets\\Spells\\spell_objects.txt";

    public static IEnumerable<SpellDescriptor> FetchDescriptors()
    {
        var descriptors = new List<SpellDescriptor>();

        StreamReader reader = File.OpenText(descriptorsPath);
        string line = reader.ReadLine();

        var regions = line.Split('\t').Skip(1);

        while ((line = reader.ReadLine()) != null)
        {
            var columns = line.Split('\t');
            string descriptor = columns[0];
            descriptors.Add(new SpellDescriptor(columns[0], GetOpinions(regions, columns.Skip(1).Select(u => float.Parse(u)))));
        }

        return descriptors;
    }

    public static IEnumerable<SpellObject> FetchObjects()
    {
        var objects = new List<SpellObject>();

        StreamReader reader = File.OpenText(objectsPath);
        string line = reader.ReadLine();

        var regions = line.Split('\t').Skip(1);

        while ((line = reader.ReadLine()) != null)
        {
            var columns = line.Split('\t');
            string descriptor = columns[0];
            objects.Add(new SpellObject(columns[0], GetOpinions(regions, columns.Skip(1).Select(u => float.Parse(u)))));
        }

        return objects;
    }

    public static Dictionary<string, float> GetOpinions(IEnumerable<string> regions, IEnumerable<float> opinions)
    {
        var opinionDictionary = new Dictionary<string, float>();

        int numRegions = regions.Count();
        int numopinions = opinions.Count();

        if (numRegions != numopinions)
            throw new Exception("regions != opinions " + numRegions + " vs " + numopinions);

        for (int i = 0; i < numRegions; i += 1)
        {
            string region = regions.ElementAt(i);
            float opinion = opinions.ElementAt(i);
            opinionDictionary.Add(region, opinion);
        }
        return opinionDictionary;
    }
}

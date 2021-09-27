using System;
using System.Threading;
using System.Collections.Generic;

namespace Darkness_Adventure
{
    public class FonctionsUtiles
    {
        // Demande une int, teste si c'en est une puis la retourne ou redemande jusqu'a ce que soit bon
        static public int TestInt(string demande)
        {
            int intAttendu = 0;
            bool intIsOK = false;
            while (!intIsOK)
            {
                Console.WriteLine(demande);
                // Récup' de l'input
                string caracString = Console.ReadLine();
                // Tentative de Parse
                try
                {
                    intAttendu = int.Parse(caracString);
                    intIsOK = true;
                }
                catch (Exception exception)
                {
                    Console.WriteLine($"{caracString} n'est pas valide ! Erreur : {exception.GetType()}");
                }
            }
            return intAttendu;
        }

        // Afficher du texte de façon stylée (caractère par caractère)
        static public void DisplayString(string texteFull)
        {
            Console.Clear();
            string texte = null;

            for (int i = 0; i < texteFull.Length; i++)
            {
                texte = texteFull[i].ToString();
                Console.Write(texte);
                switch (texte)
                {
                    case ".":
                        Thread.Sleep(500);
                        break;
                    case ",":
                        Thread.Sleep(300);
                        break;
                    case " ":
                        Thread.Sleep(50);
                        break;
                    default:
                        Thread.Sleep(20);
                        break;
                }
            }
        }

        // Pose une question et retourne true ou false selon si on écris oui/yes ou non/no
        static public bool DetectYesNo(string demande)
        {
            bool reponseIsOK = false;
            while (!reponseIsOK)
            {
                Console.WriteLine(demande);
                string string1 = Console.ReadLine();
                string string2 = ConversionString(string1);
                if (string2 == "yes" | string2 == "oui")
                {
                    return true;
                }
                else if (string2 == "non" | string2 == "no")
                {
                    return false;
                }
                else
                {
                    Console.WriteLine($"{string1} n'est pas reconnu. Veuillez entrer \"oui\" ou \"non\"");
                }
            }
            return true;
        }

        // Prend une string, détruit les accents, espaces, majuscules et caractères spéciaux puis la retourne
        static public string ConversionString(string mot)
        {
            mot = mot.ToLower();
            mot = mot.Replace('é', 'e');
            mot = mot.Replace('è', 'e');
            mot = mot.Replace('ê', 'e');
            mot = mot.Replace('à', 'a');
            mot = mot.Replace('ô', 'o');
            mot = mot.Replace('û', 'u');
            mot = mot.Replace(" ", "");
            mot = mot.Replace("\'", "");
            return mot;
        }
    }
}
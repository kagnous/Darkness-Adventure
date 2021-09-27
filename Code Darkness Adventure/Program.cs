using System;

namespace Darkness_Adventure
{
    class Program
    {
        static void Main(string[] args)
        {
            Player player = new Player();
            Game game = new Game(player);

            //BeginGame(player);

            bool end = false;
            while (!end)
            {
                switch (FonctionsUtiles.TestInt("Que voulez vous faire ?\n1-Lancer une partie \t 2-Stats \t 3-Inventaire \t 4-Forgeron \t 5-Médecin \t 6-Quitter"))
                {
                    case 1:
                        Console.WriteLine("Vous pénétrez dans le donjon...");
                        game.Donjon();
                        if(player.life <= 0)
                        {
                            end = true;
                        }
                        break;
                    case 2:
                        Console.WriteLine(player);
                        break;
                    case 3:
                        Console.WriteLine(player.DisplayInventaire());
                        break;
                    case 4:
                        if (FonctionsUtiles.DetectYesNo("Bienvenue !\tAméliorer l'épée pour 100 PO ?"))
                        {
                            if (player.gold >= 100)
                            {
                                player.weaponDamage++;
                                player.gold -= 100;
                                Console.WriteLine("Epée améliorée");
                            }
                            else
                            {
                                Console.WriteLine("Pas assez d'argent, sale pauvre");
                            }
                        }
                        break;
                    case 5:
                        if (FonctionsUtiles.DetectYesNo("Bienvenue !\tSoigner ses blessures pour  10 PO ?"))
                        {
                            if (player.gold >= 10)
                            {
                                player.life = player.lifeMax;
                                player.gold -= 10;
                                Console.WriteLine("Santé restaurée");
                            }
                            else
                            {
                                Console.WriteLine("Pas assez d'argent, sale pauvre");
                            }
                        }
                        break;

                    case 6:
                        end = true;
                        Console.WriteLine("Merci d'avoir joué !");
                        break;
                    default:
                        Console.WriteLine("Entrée non valide");
                        break;
                }
            }
        }

        static public void BeginGame(Player player)
        {
            Console.WriteLine("Hello user\nBienvenue dans DARKNESS ADVENTURE by KagnousGame");
            Console.WriteLine("Entrez votre nom :");
            player.name = Console.ReadLine();
            if (FonctionsUtiles.DetectYesNo("Voulez vous lire le lore du jeu ?"))
            {
                FonctionsUtiles.DisplayString($"Il y a bien longtemps, le terrible Seigneur Brutus le Sanguinaire enleva la princesse Lumina et plongea le royaume de Solaris dans les ténèbres les plus absolus. Seul un héros courageux osera partir à l'aventure pour ramener la lumière sur Solaris et défaire Brutus. Va {player.name}, trouve les 3 fragments de lumière et sauve la princesse.\n");
            }
        }
    }
}
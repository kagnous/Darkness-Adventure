using System;
using System.Collections.Generic;

namespace Darkness_Adventure
{
    public class Game
    {
        Random rand = new Random();

        public enum item
        {
            gold,
            cape,
            health_potion
        }

        public enum room
        {
            emptyRoom,
            lootRoom,
            fightRoom
        }

        Player player;

        public Game(Player player)
        {
            this.player = player;
        }

        public void Fight(Mobs mob)
        {
            int valeur = rand.Next(1, 8 + 1);
            int[] loot = new int[5];

            // Boucle de combat
            while (true)
            {
                int entree = FonctionsUtiles.TestInt("Frappez a une coordonnée entre 1 et 8");
                if (entree > valeur)
                {
                    Console.WriteLine("C'est moins");
                    if (player.Damaged(mob.attaque))
                    {
                        return;
                    }
                }
                else if (entree < valeur)
                {
                    Console.WriteLine("C'est plus");
                    if (player.Damaged(mob.attaque))
                    {
                        return;
                    }
                }
                else if (entree == valeur)
                {
                    if (mob.Hit(player.weaponDamage))
                    {
                        Console.WriteLine($"Monstre vaincu !\nVous gagnez {mob.exp} points d'expérience");
                        player.GetExp(mob.exp);

                        mob = null;
                        break;
                    }
                    else
                    {
                        Console.WriteLine($"Vous infligez {player.weaponDamage} dégâts\nLe monstre pousse un cri de douleur");
                        if (player.Damaged(mob.attaque))
                        {
                            return;
                        }
                    }
                }
                else
                {
                    Console.WriteLine("Erreur système");
                }
            }
        }

        public void Donjon()
        {
            int exploredRoom = 0;
            while (exploredRoom < 20)
            {
                switch (FonctionsUtiles.TestInt("Vous avancez au travers des couloirs. Que voulez-vous faire :\n1-Continuer    2-Utiliser un objet    3-Quitter le donjon"))
                {
                    case 1:
                        room roomValue = (room)rand.Next(0, 3);
                        switch (roomValue)
                        {
                            case room.emptyRoom:
                                Console.WriteLine("Vous ne trouvez rien ici. Vous continuez votre exploration");
                                exploredRoom++;
                                break;
                            case room.fightRoom:
                                Console.WriteLine("Vous entendez un bruit étrange et percevz du mouvement...\nVous dégainez votre arme !");
                                Fight(new Mobs("Monstre", 3, 1, 60));
                                if (player.life <= 0)
                                {
                                    return;
                                }
                                exploredRoom++;
                                break;
                            case room.lootRoom:
                                item item = (item)rand.Next(0, 3);

                                if (item == item.gold)
                                {
                                    int numberCoin = rand.Next(2, 35);
                                    player.gold += numberCoin;
                                    Console.WriteLine($"Vous entendez un tintement au sol.\nVous trouvez {numberCoin} pièces d'or");
                                }
                                else
                                {
                                    player.inventaire.Add(item);
                                    Console.WriteLine($"Vous trébuchez sur quelque chose...\nVous trouvez un(e) {item} !");
                                }

                                exploredRoom++;
                                break;
                            default:
                                Console.WriteLine($"Entrée non valide");
                                break;
                        }
                        break;

                    case 2:
                        switch (FonctionsUtiles.TestInt(player.DisplayInventaire() + "\n1-Potion   2-Cape de furtivité   3-Annuler"))
                        {
                            case 1:
                                for (int i = 0; i < player.inventaire.Count; i++)
                                {
                                    if (player.inventaire[i] == item.health_potion)
                                    {
                                        player.inventaire.RemoveAt(i);
                                        player.life += 10;
                                        if (player.life > player.lifeMax)
                                        {
                                            player.life = player.lifeMax;
                                            Console.WriteLine("Vous vous sentez mieux...");
                                            break;
                                        }
                                    }
                                }
                                break;

                            case 2:
                                for (int i = 0; i < player.inventaire.Count; i++)
                                {
                                    if (player.inventaire[i] == item.cape)
                                    {
                                        player.inventaire.RemoveAt(i);
                                        Console.WriteLine("Vous avancez en silence a travers les salles du donjon...");
                                        exploredRoom += 3;
                                        break;
                                    }
                                }
                                break;
                        }
                        break;

                    case 3:
                        return;

                    default:
                        Console.WriteLine($"Entrée non valide");
                        break;
                }
            }
            Console.WriteLine("Vous arrivez dans ce qu'il vous semble être une immence pièce. Vous entendez le rire maléfique du seigneur du donjon");
            Fight(new Mobs("Boss", 10, 3, 150));
            Console.WriteLine("Vous avez vaincu le terrible seigneur du donjon et récupéré son fragment solaire !!!");

            if (player.fragments < 3)
            {
                player.fragments += 1;
                Console.WriteLine("Vous avez obtenu le dernier fragment ! Préparez vous a libérer la princesse et affronter Brutus\n(Dans une future version du jeu ptdr)");
            }
        }
    }
}
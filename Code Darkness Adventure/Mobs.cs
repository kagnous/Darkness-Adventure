namespace Darkness_Adventure
{
    public class Mobs
    {
        public string name;
        public int life;
        public int attaque;
        public int exp;

        public Mobs(string name, int life, int attaque, int exp)
        {
            this.name = name;
            this.life = life;
            this.attaque = attaque;
            this.exp = exp;
        }

        public bool Hit(int degat)
        {
            life -= degat;
            if(life <= 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
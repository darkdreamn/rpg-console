using System;
namespace rpg_console
{
    public class Wizard : Character
    {
        public Wizard(bool active, string name, int level, int healthPoints, int magicalPoints, int magicalDefense, int magicalAttack, int physicalDefense, int physicalAttack) :
        base(active, name, level, healthPoints, magicalPoints, magicalDefense, magicalAttack, physicalDefense, physicalAttack)
        { }
        public override int UsePhysicalAttack()
        {
            Console.WriteLine("Golpe de Cajado");
            return PhysicalAttack;
        }
        public override int UseMagicalPower()
        {
            Console.WriteLine("Raio Poderoso");
            return MagicalAttack;
        }
        public void UseMagicalCure(string target)
        {
            Console.WriteLine("Cura Mágica +4 para " + target);
            MagicalPoints = 0;
        }
    }
}
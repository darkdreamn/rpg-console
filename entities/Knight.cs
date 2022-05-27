using System;
namespace rpg_console
{
    public class Knight : Characters
    {
        public Knight(bool active, string name, int level, int healthPoints, int magicalPoints, int magicalDefense, int magicalAttack, int physicalDefense, int physicalAttack) :
        base(active, name, level, healthPoints, magicalPoints, magicalDefense, magicalAttack, physicalDefense, physicalAttack)
        { }
        public override int UsePhysicalAttack()
        {
            Console.WriteLine("Ataque de Lança");
            return PhysicalAttack;
        }
        public int UseSpecialAttack()
        {
            Console.WriteLine("Contra ataque. O Último Avanço! +2");
            return PhysicalAttack + 2;
        }
        public override int UseMagicalPower()
        {
            return MagicalAttack;
        }
    }
}
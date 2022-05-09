using System;

namespace rpg_console
{
    public class Hero : Character
    {
        public Hero(bool active, int level, int healthPoints, int magicalPoints, int magicalDefense, int magicalAttack, int physicalDefense, int physicalAttack) :
        base(active, level, healthPoints, magicalPoints, magicalDefense, magicalAttack, physicalDefense, physicalAttack)
        { }
        public override int UsePhysicalAttack()
        {
            if (HealthPoints < 7)
            {
                Console.WriteLine("Ataque de Espada +1");
                return PhysicalAttack + 1;
            }
            else
            {
                Console.WriteLine("Ataque de Espada");
                return PhysicalAttack;
            }
        }
        public override int UseMagicalPower()
        {
            MagicalPoints = 0;
            Random randon = new Random();
            int power = randon.Next(2);
            Console.WriteLine("Espada da Aurora! +" + power);
            return MagicalAttack + power;
        }
    }
}
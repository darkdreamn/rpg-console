using System;
namespace rpg_console
{
    public class Boss : Character
    {
        int special = 1;
        public Boss(bool active, int level, int healthPoints, int magicalPoints, int magicalDefense, int magicalAttack, int physicalDefense, int physicalAttack) :
        base(active, level, healthPoints, magicalPoints, magicalDefense, magicalAttack, physicalDefense, physicalAttack)
        { }
        public int ChooseAction()
        {
            if (special % 5 == 0)
                return 2;
            else if (MagicalPoints > 1)
            {
                Random randomAction = new Random();
                int action = randomAction.Next(2);
                if (action == 1) MagicalPoints -= 2;
                return action;
            }
            else
                return 0;
        }
        public int ChooseTarget(Hero hero, Knight knight, Wizard wizard)
        {
            int actives = 0;
            int only = 0;
            if (hero.Active)
            {
                only = 0;
                actives++;
            }
            if (knight.Active)
            {
                only = 1;
                actives++;
            }
            if (wizard.Active)
            {
                only = 2;
                actives++;
            }
            if (actives == 1)
                return only;

            else
            {
                do
                {
                    Random random = new Random();
                    int target = random.Next(3);
                    if (hero.Active && target == 0)
                        return 0;
                    else if (knight.Active && target == 1)
                        return 1;
                    else if (wizard.Active && target == 2)
                        return 2;
                } while (true);
            }
        }
        public override int UsePhysicalAttack()
        {
            special++;
            Console.WriteLine("Garras afiadas ///");
            return PhysicalAttack;
        }
        public override int UseMagicalPower()
        {
            Console.WriteLine("Bola de fogo");
            return MagicalAttack;
        }
        public void UseSpecialAttack()
        {
            special++;
            Console.WriteLine("Ataque especial! Grande destruição!");
        }
    }
}
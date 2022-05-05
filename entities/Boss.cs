namespace rpg_console
{
    public class Boss : Character
    {
        public Boss(int level, int healthPoints, int magicalPoints, int magicalDefense, int magicalAttack, int physicalDefense, int physicalAttack) :
        base(level, healthPoints, magicalPoints, magicalDefense, magicalAttack, physicalDefense, physicalAttack)
        { }
    }
}
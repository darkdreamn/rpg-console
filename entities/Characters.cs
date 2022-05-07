namespace rpg_console
{
    public abstract class Character
    {
        public bool Active { get; set; }
        public int Level { get; set; }
        public int HealthPoints { get; set; }
        public int MagicalPoints { get; set; }
        public int MagicalDefense { get; set; }
        public int MagicalAttack { get; set; }
        public int PhysicalDefense { get; set; }
        public int PhysicalAttack { get; set; }

        public Character(bool active, int level, int healthPoints, int magicalPoints, int magicalDefense, int magicalAttack, int physicalDefense, int physicalAttack)
        {
            Active = active;
            Level = level;
            HealthPoints = healthPoints;
            MagicalPoints = magicalPoints;
            MagicalAttack = magicalAttack;
            MagicalDefense = magicalDefense;
            PhysicalAttack = physicalAttack;
            PhysicalDefense = physicalDefense;
        }
    }


}
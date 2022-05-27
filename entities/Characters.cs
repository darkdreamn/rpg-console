namespace rpg_console
{
    public abstract class Characters
    {
        public bool Active { get; set; }
        public string Name { get; set; }
        public int Level { get; set; }
        public int HealthPoints { get; set; }
        public int MagicalPoints { get; set; }
        public int MagicalDefense { get; set; }
        public int MagicalAttack { get; set; }
        public int PhysicalDefense { get; set; }
        public int PhysicalAttack { get; set; }

        public Characters(bool active, string name, int level, int healthPoints, int magicalPoints, int magicalDefense, int magicalAttack, int physicalDefense, int physicalAttack)
        {
            Active = active;
            Name = name;
            Level = level;
            HealthPoints = healthPoints;
            MagicalPoints = magicalPoints;
            MagicalAttack = magicalAttack;
            MagicalDefense = magicalDefense;
            PhysicalAttack = physicalAttack;
            PhysicalDefense = physicalDefense;
        }
        public abstract int UsePhysicalAttack();
        public abstract int UseMagicalPower();
    }
}
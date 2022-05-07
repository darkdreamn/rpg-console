using static System.Console;
using System;

namespace rpg_console
{
    public class Game
    {
        Hero hero = new Hero(false, 9, 17, 2, 3, 3, 3, 4);
        Knight knight = new Knight(false, 11, 19, 1, 1, 1, 3, 5);
        Wizard wizard = new Wizard(false, 10, 20, 3, 3, 5, 1, 1);
        Boss boss = new Boss(false, 40, 30, 5, 2, 4, 3, 5);
        public void Start()
        {
            int playerA = 0;
            int playerB = 0;

            ChooseCharacter(ref playerA, ref playerB);
            Clear();


        }
        public void ChooseCharacter(ref int playerA, ref int playerB)
        {
            int selected = 0;
            do
            {
                Clear();
                WriteLine("ESCOLHA DE PERSONAGENS");
                WriteLine(selected == 0 ? "Escolha o primeiro personagem: " : "Escolha o segundo personagem: ");

                WriteLine(playerA == 1 ? "[X] HERÓI" : "[1] HERÓI");
                Write($"    HP:{hero.HealthPoints}  MP:{hero.MagicalPoints}");
                Write($"  | AT.M:{hero.MagicalAttack}  AT.F:{hero.PhysicalAttack}");
                WriteLine($"  | DEF.M:{hero.MagicalDefense}  DEF.F:{hero.PhysicalDefense}");

                //TODO: CORRIGIR SET
                WriteLine("\n[2] CAVALEIRO");
                Write($"    HP:{knight.HealthPoints}  MP:{knight.MagicalPoints}");
                Write($"  | AT.M:{knight.MagicalAttack}  AT.F:{knight.PhysicalAttack}");
                WriteLine($"  | DEF.M:{knight.MagicalDefense}  DEF.F:{knight.PhysicalDefense}");

                //TODO: CORRIGIR 
                WriteLine("\n[3] MAGO");
                Write($"    HP:{wizard.HealthPoints}  MP:{wizard.MagicalPoints}");
                Write($"  | AT.M:{wizard.MagicalAttack}  AT.F:{wizard.PhysicalAttack}");
                WriteLine($"  | DEF.M:{wizard.MagicalDefense}  DEF.F:{wizard.PhysicalDefense}");
                try
                {
                    int value = int.Parse(ReadLine());
                    if (value > 0 && value < 4)
                    {
                        if (playerA == 0)
                        {
                            SetCharacter(value);
                            playerA = value;
                            selected++;
                        }
                        else if (playerA != value)
                        {
                            SetCharacter(value);
                            playerB = value;
                            selected++;
                        }
                        else
                            WriteLine("Escolha um personagem diferente");
                    }
                    else
                    {
                        WriteLine("\nDigite um valor entre 1 e 3 \nEnter para continuar");
                        ReadKey();
                    }
                }
                catch
                {
                    WriteLine("\nDigite uma opção válida \nEnter para continuar");
                    ReadKey();
                }
            } while (selected < 2);
        }
        public void SetCharacter(int value)
        {
            switch (value)
            {
                case 1: hero.Active = true; break;
                case 2: knight.Active = true; break;
                case 3: wizard.Active = true; break;
            }
        }
        static void Combat()
        {

        }
    }
}
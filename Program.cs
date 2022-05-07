using System;
using static System.Console;

namespace rpg_console
{
    class Program
    {
        static void Main(string[] args)
        {
            Hero hero = new Hero(9, 17, 2, 3, 3, 3, 4);
            Knight knight = new Knight(11, 19, 1, 1, 1, 3, 5);
            Wizard wizard = new Wizard(10, 20, 3, 3, 5, 1, 1);
            Boss boss = new Boss(40, 50, 5, 2, 4, 3, 5);
            int playerA = 0;
            int playerB = 0;
            int selected = 0;

            ChooseCharacter(ref playerA, ref playerB, selected, hero, knight, wizard);

        }
        static void ChooseCharacter(ref int playerA, ref int playerB, int selected, Hero hero, Knight knight, Wizard wizard)
        {
            do
            {
                Clear();
                WriteLine("ESCOLHA DE PERSONAGENS");
                WriteLine(selected == 0 ? "Escolha o primeiro personagem: " : "Escolha o segundo personagem: ");

                WriteLine("\n[1] HERÓI");
                Write($"    HP:{hero.HealthPoints}  MP:{hero.MagicalPoints}");
                Write($"  | AT.M:{hero.MagicalAttack}  AT.F:{hero.PhysicalAttack}");
                WriteLine($"  | DEF.M:{hero.MagicalDefense}  DEF.F:{hero.PhysicalDefense}");

                WriteLine("\n[2] CAVALEIRO");
                Write($"    HP:{knight.HealthPoints}  MP:{knight.MagicalPoints}");
                Write($"  | AT.M:{knight.MagicalAttack}  AT.F:{knight.PhysicalAttack}");
                WriteLine($"  | DEF.M:{knight.MagicalDefense}  DEF.F:{knight.PhysicalDefense}");

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
                            playerA = value;
                        else
                            playerB = value;
                        selected++;
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
    }
}

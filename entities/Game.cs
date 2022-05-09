using static System.Console;
using System;

namespace rpg_console
{
    public class Game
    {
        Hero hero = new Hero(false, 9, 17, 2, 2, 3, 3, 4);
        Knight knight = new Knight(false, 11, 19, 1, 1, 1, 3, 5);
        Wizard wizard = new Wizard(false, 10, 20, 3, 3, 5, 1, 1);
        Boss boss = new Boss(true, 40, 20, 5, 2, 4, 3, 5);
        public void Start()
        {
            int playerA = 0;
            int playerB = 0;

            ChooseCharacter(ref playerA, ref playerB);
            Clear();
            Combat();
        }
        public void ChooseCharacter(ref int playerA, ref int playerB)
        {
            int selected = 0;
            do
            {
                Clear();
                WriteLine("ESCOLHA DE PERSONAGENS");
                WriteLine(selected == 0 ? "Escolha o primeiro personagem: " : "Escolha o segundo personagem: ");

                WriteLine(playerA == 1 ? "\n[X] HERÓI" : "\n[1] HERÓI");
                Write($"    HP:{hero.HealthPoints}  MP:{hero.MagicalPoints}");
                Write($"  | AT.M:{hero.MagicalAttack}  AT.F:{hero.PhysicalAttack}");
                WriteLine($"  | DEF.M:{hero.MagicalDefense}  DEF.F:{hero.PhysicalDefense}");

                WriteLine(playerA == 2 ? "\n[X] CAVALEIRO" : "\n[2] CAVALEIRO");
                Write($"    HP:{knight.HealthPoints}  MP:{knight.MagicalPoints}");
                Write($"  | AT.M:{knight.MagicalAttack}  AT.F:{knight.PhysicalAttack}");
                WriteLine($"  | DEF.M:{knight.MagicalDefense}  DEF.F:{knight.PhysicalDefense}");

                WriteLine(playerA == 3 ? "\n[X] MAGO" : "\n[3] MAGO");
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
                        {
                            WriteLine("Escolha um personagem diferente \nEnter para continuar");
                            ReadKey();
                        }
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
        public void Combat()
        {
            bool endGame = false;
            string value = "";

            do
            {
                if (hero.Active)
                {
                    hero.MagicalDefense = 2;
                    hero.PhysicalDefense = 3;
                    if (hero.MagicalPoints < 2) hero.MagicalPoints++;
                    do
                    {
                        WriteLine("COMBATE");
                        Write($" HERÓI > HP:{hero.HealthPoints}  MP:{hero.MagicalPoints}");
                        Write($"  | AT.M:{hero.MagicalAttack}  AT.F:{hero.PhysicalAttack}");
                        WriteLine($"  | DEF.M:{hero.MagicalDefense}  DEF.F:{hero.PhysicalDefense}");
                        WriteLine("\n[1] Ataque Físico");
                        WriteLine(hero.MagicalPoints == 2 ? "[2] Ataque Mágico - Espada da Aurora" : "[X] Mana insuficiente");
                        WriteLine("[3] Defesa");
                        value = ReadLine();
                        if (value == "1")
                        {                            
                            boss.HealthPoints += boss.PhysicalDefense - hero.UsePhysicalAttack();
                            break;
                        }
                        else if (value == "2" && hero.MagicalPoints == 2)
                        {                                                     
                            boss.HealthPoints += (boss.MagicalDefense - hero.UseMagicalPower());
                            WriteLine(boss.HealthPoints);
                            ReadKey();
                            break;
                        }
                        else if (value == "3")
                        {
                            if (hero.HealthPoints < 11)
                            {
                                WriteLine("Pontos de vida +1");
                                hero.HealthPoints++;
                            }
                            hero.MagicalDefense = 4;
                            hero.PhysicalDefense = 4;                   
                            break;
                        }
                        else
                        {
                            WriteLine("\nDigite 1, 2 ou 3 \nEnter para continuar");
                            ReadKey();
                            Clear();
                        }
                    } while (true);

                    Clear();
                    if (hero.HealthPoints <= 0) hero.Active = false;
                }
                if (knight.Active)
                {
                    WriteLine("COMBATE");

                    Write($"    HP:{knight.HealthPoints}  MP:{knight.MagicalPoints}");
                    Write($"  | AT.M:{knight.MagicalAttack}  AT.F:{knight.PhysicalAttack}");
                    WriteLine($"  | DEF.M:{knight.MagicalDefense}  DEF.F:{knight.PhysicalDefense}");

                    Clear();
                    if (knight.HealthPoints <= 0) knight.Active = false;
                }
                if (wizard.Active)
                {
                    WriteLine("COMBATE");

                    Write($"    HP:{wizard.HealthPoints}  MP:{wizard.MagicalPoints}");
                    Write($"  | AT.M:{wizard.MagicalAttack}  AT.F:{wizard.PhysicalAttack}");
                    WriteLine($"  | DEF.M:{wizard.MagicalDefense}  DEF.F:{wizard.PhysicalDefense}");

                    Clear();
                    if (wizard.HealthPoints <= 0) wizard.Active = false;
                }
                if (boss.Active)
                {
                    WriteLine("COMBATE");

                    Write($"    HP:{boss.HealthPoints}  MP:{boss.MagicalPoints}");
                    Write($"  | AT.M:{boss.MagicalAttack}  AT.F:{boss.PhysicalAttack}");
                    WriteLine($"  | DEF.M:{boss.MagicalDefense}  DEF.F:{boss.PhysicalDefense}");

                    Clear();
                    if (boss.HealthPoints <= 0) boss.Active = false;
                }
                if (!hero.Active && !knight.Active && !wizard.Active)
                {
                    endGame = true;
                    WriteLine("VOCÊ PERDEU! =(");
                }
                if (!boss.Active)
                {
                    endGame = true;
                    WriteLine("VOCÊ VENCEU!!! =)");
                }
            } while (!endGame);
        }
    }
}
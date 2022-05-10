using static System.Console;
using System;

namespace rpg_console
{
    public class Game
    {
        Hero hero = new Hero(false, 9, 15, 2, 2, 3, 3, 4);
        Knight knight = new Knight(false, 11, 19, 0, 0, 0, 4, 5);
        Wizard wizard = new Wizard(false, 10, 24, 3, 3, 4, 1, 1);
        Boss boss = new Boss(true, 18, 60, 4, 2, 4, 3, 5);
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
        public void PrintStatusBoss()
        {
            Write($"CPU = BOSS > HP:{boss.HealthPoints}  MP:{boss.MagicalPoints}");
            Write($"  | AT.M:{boss.MagicalAttack}  AT.F:{boss.PhysicalAttack}");
            WriteLine($"  | DEF.M:{boss.MagicalDefense}  DEF.F:{boss.PhysicalDefense}");
            WriteLine();
        }
        public void Combat()
        {
            bool endGame = false;
            string value = "";
            int damage = 0;

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
                        PrintStatusBoss();
                        Write($"Jogador = HERÓI > HP:{hero.HealthPoints}  MP:{hero.MagicalPoints}");
                        Write($"  | AT.M:{hero.MagicalAttack}  AT.F:{hero.PhysicalAttack}");
                        WriteLine($"  | DEF.M:{hero.MagicalDefense}  DEF.F:{hero.PhysicalDefense}");
                        WriteLine("\n[1] Ataque Físico");
                        WriteLine(hero.MagicalPoints == 2 ? "[2] Ataque Mágico - Espada da Aurora" : "[X] Mana insuficiente");
                        WriteLine("[3] Defesa");
                        value = ReadLine();
                        if (value == "1")
                        {
                            damage = hero.UsePhysicalAttack();
                            if (damage > boss.PhysicalDefense)
                            {
                                damage = boss.PhysicalDefense - damage;
                                WriteLine(" Dano causado: " + damage);
                                boss.HealthPoints += damage;
                                if (boss.HealthPoints <= 0)
                                    boss.Active = false;
                            }
                            else
                                WriteLine("Sem dano");
                            break;
                        }
                        else if (value == "2" && hero.MagicalPoints == 2)
                        {
                            damage = hero.UseMagicalPower();
                            if (damage > boss.MagicalDefense)
                            {
                                damage = boss.MagicalDefense - damage;
                                WriteLine(" Dano causado: " + damage);
                                boss.HealthPoints += damage;
                                if (boss.HealthPoints <= 0)
                                    boss.Active = false;
                            }
                            else
                                WriteLine("Sem dano");
                            break;
                        }
                        else if (value == "3")
                        {
                            if (hero.HealthPoints < 11)
                            {
                                WriteLine("Defesa! Pontos de vida +1");
                                hero.HealthPoints++;
                            }
                            else
                                WriteLine("Posição Defensiva!");

                            hero.MagicalDefense = 4;
                            hero.PhysicalDefense = 4;
                            WriteLine("Defesa física: " + hero.PhysicalDefense);
                            WriteLine("Defesa mágica: " + hero.MagicalDefense);
                            break;
                        }
                        else
                        {
                            WriteLine("\nDigite 1, 2 ou 3 \nEnter para continuar");
                            ReadKey();
                            Clear();
                        }
                    } while (true);

                    WriteLine("\n[Enter] para continuar");
                    ReadLine();
                    Clear();
                    if (hero.HealthPoints <= 0) hero.Active = false;
                }
                if (knight.Active)
                {
                    knight.MagicalDefense = 0;
                    knight.PhysicalDefense = 4;
                    do
                    {
                        WriteLine("COMBATE");
                        PrintStatusBoss();
                        Write($"Jogador = CAVALEIRO > HP:{knight.HealthPoints}  MP:{knight.MagicalPoints}");
                        Write($"  | AT.M:{knight.MagicalAttack}  AT.F:{knight.PhysicalAttack}");
                        WriteLine($"  | DEF.M:{knight.MagicalDefense}  DEF.F:{knight.PhysicalDefense}");
                        WriteLine("\n[1] Ataque Físico");
                        WriteLine("[2] Defesa");
                        value = ReadLine();
                        if (value == "1")
                        {
                            damage = knight.UsePhysicalAttack();
                            if (damage > boss.PhysicalDefense)
                            {
                                damage = boss.PhysicalDefense - damage;
                                WriteLine(" Dano causado: " + damage);
                                boss.HealthPoints += damage;
                                if (boss.HealthPoints <= 0)
                                    boss.Active = false;
                            }
                            else
                                WriteLine("Sem dano");
                            break;
                        }
                        else if (value == "2")
                        {
                            WriteLine("Posição Defensiva!");
                            knight.MagicalDefense = 3;
                            knight.PhysicalDefense = 5;
                            WriteLine("Defesa física: " + knight.PhysicalDefense);
                            WriteLine("Defesa mágica: " + knight.MagicalDefense);
                            break;
                        }
                        else
                        {
                            WriteLine("\nDigite 1 ou 2 \nEnter para continuar");
                            ReadKey();
                            Clear();
                        }
                    } while (true);
                    WriteLine("\n[Enter] para continuar");
                    ReadLine();
                    Clear();
                    if (knight.HealthPoints <= 0) knight.Active = false;
                }
                if (wizard.Active)
                {
                    wizard.MagicalDefense = 3;
                    wizard.PhysicalDefense = 1;

                    if (wizard.MagicalPoints < 3) wizard.MagicalPoints++;
                    do
                    {
                        WriteLine("COMBATE");
                        PrintStatusBoss();
                        Write($"Jogador = MAGO > HP:{wizard.HealthPoints}  MP:{wizard.MagicalPoints}");
                        Write($"  | AT.M:{wizard.MagicalAttack}  AT.F:{wizard.PhysicalAttack}");
                        WriteLine($"  | DEF.M:{wizard.MagicalDefense}  DEF.F:{wizard.PhysicalDefense}");
                        WriteLine("\n[1] Ataque Físico");
                        WriteLine("[2] Ataque Mágico");
                        WriteLine(wizard.MagicalPoints == 3 ? "[3] Cura Mágica" : "[X] Mana insuficiente");
                        WriteLine("[4] Defesa");
                        value = ReadLine();
                        if (value == "1")
                        {
                            damage = wizard.UsePhysicalAttack();
                            if (wizard.PhysicalAttack > boss.PhysicalDefense)
                            {
                                damage = boss.PhysicalDefense - damage;
                                WriteLine(" Dano causado: " + damage);
                                boss.HealthPoints += damage;
                                if (boss.HealthPoints <= 0)
                                    boss.Active = false;
                            }
                            else
                                WriteLine("Sem dano");
                            break;
                        }
                        else if (value == "2")
                        {
                            damage = wizard.UseMagicalPower();
                            if (wizard.MagicalAttack > boss.MagicalDefense)
                            {
                                damage = boss.MagicalDefense - damage;
                                WriteLine(" Dano causado: " + damage);
                                boss.HealthPoints += damage;
                                if (boss.HealthPoints <= 0)
                                    boss.Active = false;
                            }
                            else
                                WriteLine("Sem dano");
                            break;
                        }
                        else if (value == "3" && wizard.MagicalPoints == 3)
                        {
                            do
                            {
                                WriteLine("Escolha o alvo");
                                WriteLine("[1] Mago");
                                if (hero.Active)
                                    WriteLine("[2] Herói");
                                else if (knight.Active)
                                    WriteLine("[2] Cavaleiro");
                                value = ReadLine();

                                if (value == "1")
                                {
                                    wizard.UseMagicalCure("Mago");
                                    wizard.HealthPoints += 4;
                                    break;
                                }
                                else if (value == "2")
                                    if (hero.Active)
                                    {
                                        wizard.UseMagicalCure("Herói");
                                        hero.HealthPoints += 4;
                                        break;
                                    }
                                    else if (knight.Active)
                                    {
                                        wizard.UseMagicalCure("Cavaleiro");
                                        knight.HealthPoints += 4;
                                        break;
                                    }
                                    else
                                        WriteLine("Digite um valor válido");
                                else
                                    WriteLine("Digite um valor válido");
                            } while (true);
                            break;
                        }
                        else if (value == "4")
                        {
                            WriteLine("Posição Defensiva!");
                            wizard.MagicalDefense = 5;
                            wizard.PhysicalDefense = 4;
                            WriteLine("Defesa física: " + wizard.PhysicalDefense);
                            WriteLine("Defesa mágica: " + wizard.MagicalDefense);
                            break;
                        }
                        else
                        {
                            WriteLine("\nDigite 1, 2, 3 ou 4 \nEnter para continuar");
                            ReadLine();
                            Clear();
                        }
                    } while (true);
                    WriteLine("\n[Enter] para continuar");
                    ReadLine();
                    Clear();
                    Clear();
                    if (wizard.HealthPoints <= 0) wizard.Active = false;
                }
                if (boss.Active)
                {
                    if (boss.MagicalPoints < 4) boss.MagicalPoints++;

                    WriteLine("COMBATE");
                    PrintStatusBoss();

                    switch (boss.ChooseAction())
                    {
                        case 0:
                            switch (boss.ChooseTarget(hero, knight, wizard))
                            {
                                case 0:
                                    Write("Herói recebe ");
                                    damage = boss.UsePhysicalAttack();
                                    if (damage > hero.PhysicalDefense)
                                    {
                                        damage = hero.PhysicalDefense - damage;
                                        WriteLine(" Dano causado: " + damage);
                                        hero.HealthPoints += damage;
                                        if (hero.HealthPoints <= 0)
                                            hero.Active = false;
                                    }
                                    else
                                        WriteLine("Sem dano");
                                    break;
                                case 1:
                                    Write("Cavaleiro recebe ");
                                    damage = boss.UsePhysicalAttack();
                                    if (damage > knight.PhysicalDefense)
                                    {
                                        damage = knight.PhysicalDefense - damage;
                                        WriteLine(" Dano causado: " + damage);
                                        knight.HealthPoints += damage;
                                        if (knight.HealthPoints <= 0)
                                        {
                                            damage = boss.PhysicalDefense - knight.UseSpecialAttack();
                                            WriteLine(" Dano causado: " + damage);
                                            boss.HealthPoints += damage;
                                            if (boss.HealthPoints <= 0)
                                                boss.Active = false;
                                            knight.Active = false;
                                        }
                                    }
                                    else
                                        WriteLine("Sem dano");
                                    break;
                                case 2:
                                    Write("Mago recebe ");
                                    damage = boss.UsePhysicalAttack();
                                    if (damage > wizard.PhysicalDefense)
                                    {
                                        damage = wizard.PhysicalDefense - damage;
                                        WriteLine(" Dano causado: " + damage);
                                        wizard.HealthPoints += damage;
                                        if (wizard.HealthPoints <= 0)
                                            wizard.Active = false;
                                    }
                                    else
                                        WriteLine("Sem dano");
                                    break;
                            }
                            break;
                        case 1:
                            switch (boss.ChooseTarget(hero, knight, wizard))
                            {
                                case 0:
                                    Write("Herói recebe ");
                                    damage = boss.UseMagicalPower();
                                    if (damage > hero.MagicalDefense)
                                    {
                                        damage = hero.MagicalDefense - damage;
                                        WriteLine(" Dano causado: " + damage);
                                        hero.HealthPoints += damage;
                                        if (hero.HealthPoints <= 0)
                                            hero.Active = false;
                                    }
                                    else
                                        WriteLine("Sem dano");
                                    break;
                                case 1:
                                    Write("Cavaleiro recebe ");
                                    damage = boss.UseMagicalPower();
                                    if (damage > knight.MagicalDefense)
                                    {
                                        damage = knight.MagicalDefense - damage;
                                        WriteLine(" Dano causado: " + damage);
                                        knight.HealthPoints += damage;
                                        if (knight.HealthPoints <= 0)
                                        {
                                            damage = boss.PhysicalDefense - knight.UseSpecialAttack();
                                            WriteLine(" Dano causado: " + damage);
                                            boss.HealthPoints += damage;
                                            if (boss.HealthPoints <= 0)
                                                boss.Active = false;
                                            knight.Active = false;
                                        }
                                    }
                                    else
                                        WriteLine("Sem dano");
                                    break;
                                case 2:
                                    Write("Mago recebe ");
                                    damage = boss.UseMagicalPower();
                                    if (damage > wizard.MagicalDefense)
                                    {
                                        damage = wizard.MagicalDefense - damage;
                                        WriteLine(" Dano causado: " + damage);
                                        wizard.HealthPoints += damage;
                                        if (wizard.HealthPoints <= 0)
                                            wizard.Active = false;
                                    }
                                    else
                                        WriteLine("Sem dano");
                                    break;
                            }
                            break;
                        case 2:
                            boss.UseSpecialAttack();
                            if (hero.Active)
                            {
                                damage = hero.MagicalDefense - 7;
                                hero.HealthPoints += damage;
                                WriteLine(" Dano causado ao herói: " + damage);
                                if (hero.HealthPoints <= 0)
                                    hero.Active = false;
                            }
                            if (knight.Active)
                            {
                                damage = knight.MagicalDefense - 7;
                                knight.HealthPoints += damage;
                                WriteLine(" Dano causado ao cavaleiro: " + damage);
                                if (knight.HealthPoints <= 0)
                                {
                                    damage = boss.PhysicalDefense - knight.UseSpecialAttack();
                                    WriteLine(" Dano causado: " + damage);
                                    boss.HealthPoints += damage;
                                    if (boss.HealthPoints <= 0)
                                        boss.Active = false;
                                    knight.Active = false;
                                }
                            }
                            if (wizard.Active)
                            {
                                damage = wizard.MagicalDefense - 7;
                                wizard.HealthPoints += damage;
                                WriteLine(" Dano causado ao mago: " + damage);
                                if (wizard.HealthPoints <= 0)
                                    wizard.Active = false;
                            }
                            break;
                    }
                    WriteLine("\n[Enter] para continuar");
                    ReadLine();
                    Clear();
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
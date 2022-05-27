using static System.Console;
using System;

namespace rpg_console
{
    public class Game
    {
        Hero hero = new Hero(false, "hero", 9, 15, 2, 2, 3, 3, 4);
        Knight knight = new Knight(false, "knight", 11, 19, 0, 0, 0, 4, 5);
        Wizard wizard = new Wizard(false, "wizard", 10, 24, 3, 3, 4, 1, 1);
        Boss boss = new Boss(true, "boss", 18, 60, 4, 2, 4, 3, 5);
        Characters[] Characters = new Characters[4];
        public void Start()
        {
            Characters[0] = hero;
            Characters[1] = knight;
            Characters[2] = wizard;
            Characters[3] = boss;
            int playerA = 0;
            int playerB = 0;

            ChooseCharacters(ref playerA, ref playerB);
            Clear();
            Combat();
        }
        public void PrintCharacters<T>(T Characters, int i) where T : Characters
        {
            i++;
            switch (i)
            {
                case 1: WriteLine(Characters.Active ? "\n[X] HERÓI" : "\n[1] HERÓI"); break;
                case 2: WriteLine(Characters.Active ? "\n[X] CAVALEIRO" : "\n[2] CAVALEIRO"); break;
                case 3: WriteLine(Characters.Active ? "\n[X] MAGO" : "\n[3] MAGO"); break;
            }
            Write($"    HP:{Characters.HealthPoints}  MP:{Characters.MagicalPoints}");
            Write($"  | AT.M:{Characters.MagicalAttack}  AT.F:{Characters.PhysicalAttack}");
            WriteLine($"  | DEF.M:{Characters.MagicalDefense}  DEF.F:{Characters.PhysicalDefense}");
        }
        public void ChooseCharacters(ref int playerA, ref int playerB)
        {
            const string UNDERLINE = "\x1B[4m";
            const string RESET = "\x1B[0m";
            int selected = 0;
            do
            {
                Clear();
                WriteLine($"{UNDERLINE}Personagens{RESET}\n");
                WriteLine(selected == 0 ? "Escolha o primeiro personagem: " : "Escolha o segundo personagem: ");
                for (int i = 0; i < 3; i++)
                    PrintCharacters(Characters[i], i);

                try
                {
                    int value = int.Parse(ReadLine());
                    if (value > 0 && value < 4)
                    {
                        if (playerA == 0)
                        {
                            SetCharacters(value);
                            playerA = value;
                            selected++;
                        }
                        else if (playerA != value)
                        {
                            SetCharacters(value);
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
            Clear();
            WriteLine($"{UNDERLINE}Personagens{RESET}\n");
            WriteLine("Personagens confirmados!");
            for (int i = 0; i < 3; i++)
                PrintCharacters(Characters[i], i);
            WriteLine("\n[Enter] para continuar");
            ReadKey();
        }
        public void SetCharacters(int value)
        {
            switch (value)
            {
                case 1: hero.Active = true; break;
                case 2: knight.Active = true; break;
                case 3: wizard.Active = true; break;
            }
        }
        public void PrintStatusBoss(bool turn)
        {
            ForegroundColor = ConsoleColor.DarkYellow;
            Write(turn ? "[*] " : "[ ] ");
            ResetColor();
            ForegroundColor = ConsoleColor.DarkRed;
            Write($"BOSS >\t\t");
            ResetColor();
            ForegroundColor = ConsoleColor.Green;
            Write($"HP:{boss.HealthPoints}");
            ResetColor();
            Write($"  MP:{boss.MagicalPoints}");
            Write($"  | AT.M:{boss.MagicalAttack}  AT.F:{boss.PhysicalAttack}");
            WriteLine($"  | DEF.M:{boss.MagicalDefense}  DEF.F:{boss.PhysicalDefense}");
            ForegroundColor = ConsoleColor.DarkRed;
            WriteLine("    ¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨");
            ResetColor();
            WriteLine();
        }
        public void PrintStatusPlayer<T>(T Characters, bool turn) where T : Characters
        {
            string name = "";

            ForegroundColor = ConsoleColor.DarkYellow;
            Write(turn ? "[*] " : "[ ] ");
            ResetColor();
            ForegroundColor = ConsoleColor.Blue;

            switch (Characters.Name)
            {
                case "hero": name = "HERÓI"; break;
                case "knight": name = "CAVALEIRO"; break;
                case "wizard": name = "MAGO"; break;
            }
            Write($"{name} >\t\t");
            ResetColor();
            ForegroundColor = ConsoleColor.Green;
            Write($"HP:{Characters.HealthPoints}");
            ResetColor();
            Write($"  MP:{Characters.MagicalPoints}");
            Write($"  | AT.M:{Characters.MagicalAttack}  AT.F:{Characters.PhysicalAttack}");
            WriteLine($"  | DEF.M:{Characters.MagicalDefense}  DEF.F:{Characters.PhysicalDefense}");
            ForegroundColor = ConsoleColor.Blue;
            WriteLine("    ¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨");
            ResetColor();
        }
        public void TitleCombat(bool turn)
        {
            const string UNDERLINE = "\x1B[4m";
            const string RESET = "\x1B[0m";
            WriteLine($"{UNDERLINE}Combate{RESET}\n");
            PrintStatusBoss(turn);
        }
        public void HeroPrintStatusGroup()
        {
            if (knight.Active)
                PrintStatusPlayer(knight, false);
            else if (wizard.Active)
                PrintStatusPlayer(wizard, false);
        }
        public void KnightPrintStatusGroup()
        {
            if (hero.Active)
                PrintStatusPlayer(hero, false);
            else if (wizard.Active)
                PrintStatusPlayer(wizard, false);
        }
        public void WizardPrintStatusGroup()
        {
            if (hero.Active)
                PrintStatusPlayer(hero, false);
            else if (knight.Active)
                PrintStatusPlayer(knight, false);
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
                        TitleCombat(false);
                        PrintStatusPlayer(hero, true);
                        HeroPrintStatusGroup();
                        WriteLine("Escolha a ação:");

                        WriteLine("\n[1] Ataque Físico");
                        WriteLine(hero.MagicalPoints == 2 ? "[2] Ataque Mágico - Espada da Aurora" : "[X] Mana insuficiente");
                        WriteLine("[3] Defesa");
                        value = ReadLine();

                        Clear();
                        TitleCombat(false);
                        PrintStatusPlayer(hero, true);
                        HeroPrintStatusGroup();

                        if (value == "1")
                        {
                            damage = hero.UsePhysicalAttack();
                            if (damage > boss.PhysicalDefense)
                            {
                                damage = boss.PhysicalDefense - damage;
                                WriteLine("Dano causado: " + damage);
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
                                WriteLine("Dano causado: " + damage);
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
                        TitleCombat(false);
                        PrintStatusPlayer(knight, true);
                        KnightPrintStatusGroup();

                        WriteLine("Escolha a ação:");
                        WriteLine("\n[1] Ataque Físico");
                        WriteLine("[2] Defesa");
                        value = ReadLine();

                        Clear();
                        TitleCombat(false);
                        PrintStatusPlayer(knight, true);
                        KnightPrintStatusGroup();
                        if (value == "1")
                        {
                            damage = knight.UsePhysicalAttack();
                            if (damage > boss.PhysicalDefense)
                            {
                                damage = boss.PhysicalDefense - damage;
                                WriteLine("Dano causado: " + damage);
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
                        TitleCombat(false);
                        PrintStatusPlayer(wizard, true);
                        WizardPrintStatusGroup();
                        WriteLine("Escolha a ação:");

                        WriteLine("\n[1] Ataque Físico");
                        WriteLine("[2] Ataque Mágico");
                        WriteLine(wizard.MagicalPoints == 3 ? "[3] Cura Mágica" : "[X] Mana insuficiente");
                        WriteLine("[4] Defesa");
                        value = ReadLine();

                        Clear();
                        TitleCombat(false);
                        PrintStatusPlayer(wizard, true);
                        WizardPrintStatusGroup();

                        if (value == "1")
                        {
                            damage = wizard.UsePhysicalAttack();
                            if (wizard.PhysicalAttack > boss.PhysicalDefense)
                            {
                                damage = boss.PhysicalDefense - damage;
                                WriteLine("Dano causado: " + damage);
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
                                WriteLine("Dano causado: " + damage);
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
                                WriteLine("Escolha o alvo: \n");
                                WriteLine("[1] Mago");
                                if (hero.Active)
                                    WriteLine("[2] Herói");
                                else if (knight.Active)
                                    WriteLine("[2] Cavaleiro");
                                value = ReadLine();

                                if (value == "1")
                                {
                                    wizard.UseMagicalCure("Mago");
                                    if (wizard.HealthPoints + 4 > 24)
                                        wizard.HealthPoints = 24;
                                    else
                                        wizard.HealthPoints += 4;
                                    break;
                                }
                                else if (value == "2")
                                    if (hero.Active)
                                    {
                                        wizard.UseMagicalCure("Herói");
                                        if (hero.HealthPoints + 4 > 15)
                                            hero.HealthPoints = 15;
                                        else
                                            hero.HealthPoints += 4;
                                        break;
                                    }
                                    else if (knight.Active)
                                    {
                                        wizard.UseMagicalCure("Cavaleiro");
                                        if (knight.HealthPoints + 4 > 19)
                                            knight.HealthPoints = 19;
                                        else
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
                    TitleCombat(true);

                    switch (boss.ChooseAction())
                    {
                        case 0:
                            switch (boss.ChooseTarget(hero, knight, wizard))
                            {
                                case 0:
                                    PrintStatusPlayer(hero, false);
                                    if (knight.Active)
                                        PrintStatusPlayer(knight, false);
                                    if (wizard.Active)
                                        PrintStatusPlayer(wizard, false);

                                    Write("Herói recebe: ");
                                    damage = boss.UsePhysicalAttack();
                                    if (damage > hero.PhysicalDefense)
                                    {
                                        damage = hero.PhysicalDefense - damage;
                                        WriteLine("Dano causado: " + damage);
                                        hero.HealthPoints += damage;
                                        if (hero.HealthPoints <= 0)
                                            hero.Active = false;
                                    }
                                    else
                                        WriteLine("Sem dano");
                                    break;
                                case 1:
                                    PrintStatusPlayer(knight, false);
                                    if (hero.Active)
                                        PrintStatusPlayer(hero, false);
                                    if (wizard.Active)
                                        PrintStatusPlayer(wizard, false);

                                    Write("Cavaleiro recebe: ");
                                    damage = boss.UsePhysicalAttack();
                                    if (damage > knight.PhysicalDefense)
                                    {
                                        damage = knight.PhysicalDefense - damage;
                                        WriteLine("Dano causado: " + damage);
                                        knight.HealthPoints += damage;
                                        if (knight.HealthPoints <= 0)
                                        {
                                            damage = boss.PhysicalDefense - knight.UseSpecialAttack();
                                            WriteLine("Dano causado: " + damage);
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
                                    PrintStatusPlayer(wizard, false);
                                    if (hero.Active)
                                        PrintStatusPlayer(hero, false);
                                    if (knight.Active)
                                        PrintStatusPlayer(knight, false);

                                    Write("Mago recebe: ");
                                    damage = boss.UsePhysicalAttack();
                                    if (damage > wizard.PhysicalDefense)
                                    {
                                        damage = wizard.PhysicalDefense - damage;
                                        WriteLine("Dano causado: " + damage);
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
                                    PrintStatusPlayer(hero, false);
                                    if (knight.Active)
                                        PrintStatusPlayer(knight, false);
                                    if (wizard.Active)
                                        PrintStatusPlayer(wizard, false);

                                    Write("Herói recebe: ");
                                    damage = boss.UseMagicalPower();
                                    if (damage > hero.MagicalDefense)
                                    {
                                        damage = hero.MagicalDefense - damage;
                                        WriteLine("Dano causado: " + damage);
                                        hero.HealthPoints += damage;
                                        if (hero.HealthPoints <= 0)
                                            hero.Active = false;
                                    }
                                    else
                                        WriteLine("Sem dano");
                                    break;
                                case 1:
                                    PrintStatusPlayer(knight, false);
                                    if (hero.Active)
                                        PrintStatusPlayer(hero, false);
                                    if (wizard.Active)
                                        PrintStatusPlayer(wizard, false);

                                    Write("Cavaleiro recebe: ");
                                    damage = boss.UseMagicalPower();
                                    if (damage > knight.MagicalDefense)
                                    {
                                        damage = knight.MagicalDefense - damage;
                                        WriteLine("Dano causado: " + damage);
                                        knight.HealthPoints += damage;
                                        if (knight.HealthPoints <= 0)
                                        {
                                            damage = boss.PhysicalDefense - knight.UseSpecialAttack();
                                            WriteLine("Dano causado: " + damage);
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
                                    PrintStatusPlayer(wizard, false);
                                    if (hero.Active)
                                        PrintStatusPlayer(hero, false);
                                    if (knight.Active)
                                        PrintStatusPlayer(knight, false);

                                    Write("Mago recebe: ");
                                    damage = boss.UseMagicalPower();
                                    if (damage > wizard.MagicalDefense)
                                    {
                                        damage = wizard.MagicalDefense - damage;
                                        WriteLine("Dano causado: " + damage);
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
                            if (hero.Active)
                                PrintStatusPlayer(hero, false);
                            if (knight.Active)
                                PrintStatusPlayer(knight, false);
                            if (wizard.Active)
                                PrintStatusPlayer(wizard, false);

                            boss.UseSpecialAttack();
                            if (hero.Active)
                            {
                                damage = hero.MagicalDefense - 7;
                                hero.HealthPoints += damage;
                                WriteLine("Dano causado ao herói: " + damage);
                                if (hero.HealthPoints <= 0)
                                    hero.Active = false;
                            }
                            if (knight.Active)
                            {
                                damage = knight.MagicalDefense - 7;
                                knight.HealthPoints += damage;
                                WriteLine("Dano causado ao cavaleiro: " + damage);
                                if (knight.HealthPoints <= 0)
                                {
                                    damage = boss.PhysicalDefense - knight.UseSpecialAttack();
                                    WriteLine("Dano causado: " + damage);
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
                                WriteLine("Dano causado ao mago: " + damage);
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
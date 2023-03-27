using System;

// Setting Up Variables
int? distance;
int? aim;
int round = 1;
int damage = 1;
string blastType = "Normal Blast";
double manticoreHealth = 10.0;
double cityHealth = 15.0;

// Breaking Down Steps into Methods
void Player1() // Player 1's move, sets the Manticore's position
{
    Console.Write("Manticore Pilot, set your position of the Manticore (0-100)... ");
    distance = Convert.ToInt32(Console.ReadLine());
    Console.Clear();
}

void Player2() // Player 2's move, aims for the Manticore
{
    DisplayStatus();
    AimAndFire();
}

void DisplayStatus() // Displays all stats
{
    // Round Status Display
    Console.ForegroundColor = ConsoleColor.White;
    Console.WriteLine("----------------------------------------------------------------");
    Console.Write("STATUS: Round ");
    Console.ForegroundColor = ConsoleColor.DarkGray;
    Console.Write(round);
    Console.ForegroundColor = ConsoleColor.White;
    Console.Write("  City Health: ");
    Console.ForegroundColor = HealthColor(cityHealth / 15);
    Console.Write(cityHealth);
    Console.ForegroundColor = ConsoleColor.DarkGray;
    Console.Write("/15");
    Console.ForegroundColor = ConsoleColor.White;
    Console.Write("  Manticore Health: ");
    Console.ForegroundColor = HealthColor(manticoreHealth / 10);
    Console.Write(manticoreHealth);
    Console.ForegroundColor = ConsoleColor.DarkGray;
    Console.WriteLine("/10");


    // Blast Type Display
    Console.ForegroundColor = ConsoleColor.White;
    Console.Write("Cannon is charged with a(n) ");
    CalculateDamage();
    Console.Write(blastType);
    Console.ForegroundColor = ConsoleColor.White;
    Console.Write(" dealing ");
    Console.ForegroundColor = ConsoleColor.Magenta;
    Console.Write(damage);
    Console.ForegroundColor = ConsoleColor.White;
    Console.WriteLine(" damage on hit...");
    
}

void CalculateDamage()
{
    if (round % 3 == 0 && round % 5 == 0)
    {
        blastType = "Explosive Blast";
        damage = 10;
        Console.ForegroundColor = ConsoleColor.Blue;
    } else if (round % 3 == 0) 
    {
        blastType = "Fire Blast";
        damage = 3;
        Console.ForegroundColor = ConsoleColor.Red;
    } else if (round % 5 == 0) 
    {
        blastType = "Electric Blast";
        damage = 3;
        Console.ForegroundColor = ConsoleColor.Yellow;
    } else
    {
        blastType = "Normal Blast";
        damage = 1;
        Console.ForegroundColor = ConsoleColor.DarkGray;
    }
}

ConsoleColor HealthColor(double fraction)
{
    if (fraction < 0.33)
    {
        return ConsoleColor.DarkRed;
    } else if (fraction < 0.66)
    {
        return ConsoleColor.DarkYellow;
    } else
    {
        return ConsoleColor.DarkGreen;
    }
}

void AimAndFire()
{
    Console.Write("Cannon Operator, set the aim for the Magic Cannon (0-100)... ");
    aim = Convert.ToInt32(Console.ReadLine());

    Console.Write("The blast ");
    if (aim != distance)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        if (aim > distance) 
        {
            Console.Write("OVERHOT");
        } else 
        {
            Console.Write("FELL SHORT of");
        }
        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine(" the target...");
        return;
    }
    Console.ForegroundColor = ConsoleColor.Green;
    Console.Write("HITS ");
    Console.ForegroundColor = ConsoleColor.White;
    Console.WriteLine("the target!!!");
    manticoreHealth -= damage;

}

// LOOP
Player1();

Console.WriteLine("It is the defense's turn...");

while (manticoreHealth > 0 && cityHealth > 0)
{
    Player2();
    cityHealth--;
    round++;
}

if (manticoreHealth < 1)
{
    Console.ForegroundColor = ConsoleColor.Green;
    Console.WriteLine("The Manticore has been destroyed!!! The city of Consolas has been saved!!!");
} else {
    Console.ForegroundColor = ConsoleColor.Red;
    Console.WriteLine("Our city has been destroyed... We failed...");
}
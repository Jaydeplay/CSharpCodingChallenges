// Setting Up Variables
int? distance;
int? aim;
int round = 1;
int damage = 1;
string blastType = "Normal Blast";
double manticoreHealth = 10.0;
double cityHealth = 15.0;

void FragWrite(string msg, ConsoleColor? textColor = null, bool end = false) // Writes in fragmented messages to customize certain fragments
{
    if (textColor != null) {Console.ForegroundColor = (ConsoleColor)textColor;}
    Console.Write(msg + " ");
    if (end) {Console.WriteLine(" ");}
}

// Breaking Down Steps into Methods
void Player1() // Player 1's move, sets the Manticore's position
{
    FragWrite("Manticore Pilot, set your position of the Manticore (0-100)...", ConsoleColor.White);
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
    FragWrite("----------------------------------------------------------------", ConsoleColor.White, true);
    FragWrite("STATUS: Round");
    FragWrite(Convert.ToString(round), ConsoleColor.DarkGray);
    FragWrite(" City Health:", ConsoleColor.White);
    FragWrite(Convert.ToString(cityHealth), HealthColor(cityHealth / 15));
    FragWrite("/ 15", ConsoleColor.DarkGray);
    FragWrite(" Manticore Health:", ConsoleColor.White);
    FragWrite(Convert.ToString(manticoreHealth), HealthColor(manticoreHealth / 10));
    FragWrite("/ 10", ConsoleColor.DarkGray, true);


    // Blast Type Display
    FragWrite("Cannon is charged with a(n)", ConsoleColor.DarkGray);
    ConsoleColor blastColor = CalculateDamage();
    FragWrite(Convert.ToString(blastType), blastColor);
    FragWrite("dealing", ConsoleColor.DarkGray);
    FragWrite(Convert.ToString(damage), ConsoleColor.Magenta);
    FragWrite("damage on hit...", ConsoleColor.DarkGray);
}

ConsoleColor CalculateDamage() // Calculates the damage and blast type from round number
{
    if (round % 3 == 0 && round % 5 == 0)
    {
        blastType = "Explosive Blast";
        damage = 10;
        return ConsoleColor.Blue;
    } else if (round % 3 == 0) 
    {
        blastType = "Fire Blast";
        damage = 3;
        return ConsoleColor.Red;
    } else if (round % 5 == 0) 
    {
        blastType = "Electric Blast";
        damage = 3;
        return ConsoleColor.Yellow;
    } else
    {
        blastType = "Normal Blast";
        damage = 1;
        return ConsoleColor.White;
    }
}

ConsoleColor HealthColor(double fraction) // Outputs color determined by health
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

void AimAndFire() // Guessing the Distance
{
    FragWrite("Cannon Operator, set the aim for the Magic Cannon (0-100)... ");
    aim = Convert.ToInt32(Console.ReadLine());

    FragWrite("The blast", ConsoleColor.White);
    if (aim != distance)
    {
        string missReason;
        if (aim > distance) 
        {
            missReason = "OVERHOT";
        } else 
        {
            missReason = "FELL SHORT of";
        }
        FragWrite(missReason, ConsoleColor.Red);
        FragWrite("the target...", ConsoleColor.White, true);
        return;
    }
    FragWrite("HITS", ConsoleColor.Green);
    FragWrite("the target!!!", ConsoleColor.White, true);
    manticoreHealth -= damage;

}

// LOOP
Player1();

FragWrite("It is the defense's turn...");

while (manticoreHealth > 0 && cityHealth > 0)
{
    Player2();
    cityHealth--;
    round++;
}

if (manticoreHealth < 1)
{
    FragWrite("The Manticore has been destroyed!!! The city of Consolas has been saved!!!", ConsoleColor.Green, true);
} else {
    FragWrite("Our city has been destroyed... We failed...", ConsoleColor.Red, true);
}

using PasswordGenerator;

void ClearCurrentConsoleLine()
{
    
    Console.SetCursorPosition(0, Console.CursorTop - 1);
    Console.Write(new string(' ', Console.WindowWidth));
    Console.SetCursorPosition(0, Console.CursorTop);
}

Console.WriteLine("Enter password length:");
var passlengthInput = Console.ReadLine();
int passlength;
while (!int.TryParse(passlengthInput, out passlength))
{
    ClearCurrentConsoleLine();
    Console.Write("Invalid input. Please enter a valid number for password length: ");
    passlengthInput = Console.ReadLine();
}

Console.Write("Do you want to include complexity (uppercase, lowercase, special characters)? (yes/no): ");
string complexityInput = Console.ReadLine()?.Trim().ToLower();
while (complexityInput != "yes" && complexityInput != "no")
{
    ClearCurrentConsoleLine();
    Console.Write("Invalid input. Please enter 'yes' or 'no': ");
    complexityInput = Console.ReadLine()?.Trim().ToLower();
}

IPassword pwd;
if (complexityInput == "yes")
{
    pwd = new Password(passlength).IncludeLowercase().IncludeUppercase().IncludeSpecial();
}
else
{
    pwd = new Password(passlength);
}

var password = pwd.Next();
Console.WriteLine($"Now we will generate a password {passlength} characters long");
Console.WriteLine(password);

Console.WriteLine($"{Environment.NewLine}Press any key to exit...");
Console.ReadKey(true);
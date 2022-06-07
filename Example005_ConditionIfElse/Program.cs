Console.Write("Enter user name: ");
string username = Console.ReadLine();

if(username.ToLower() == "mary")
{
    Console.WriteLine("Yey, It's Mary!");
}
else
{
    Console.Write("Hello, ");
    Console.WriteLine(username);
}
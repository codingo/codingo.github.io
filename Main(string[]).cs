// ctf.sectalks_bne.crackme.Program
// Token: 0x06000006 RID: 6
private static void Main(string[] args)
{
	Program.PrintBanner();
	Console.WriteLine(string.Format("Success! Flag: {0}!", Crypto.DecryptStringAES("EAAAAB+ljfnegBraKanx/SJLBfrGhIDfffz8MOc922hrm0aK44KwgXmu9GHrIU+LjyBwmQ==")));
}

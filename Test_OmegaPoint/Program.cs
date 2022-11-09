using Test_OmegaPoint;

//Skapa klasserna med format som är specifikt för de olika numren,
PNumValidityChecker check = new PNumValidityChecker();
SamNumChecker samCheck = new SamNumChecker();
OrgNumChecker orgCheck = new OrgNumChecker();


//Skapa ett verifierings objekt för de olika numren.
Verifier pNumVerifier = new Verifier(check, new LuhnCheck(), new StringFormat(), new Converter());
Verifier samNumVerifier = new Verifier(samCheck, new LuhnCheck(), new StringFormat(), new Converter());
Verifier orgNumVerifier = new Verifier(orgCheck, new LuhnCheck(), new StringFormat(), new Converter());

Console.WriteLine(pNumVerifier.Verify("141206-2380"));
Console.WriteLine(orgNumVerifier.Verify("556614-3185"));
Console.WriteLine(samNumVerifier.Verify("190910799824"));


Console.ReadKey();
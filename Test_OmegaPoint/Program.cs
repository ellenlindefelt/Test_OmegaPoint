using System.Globalization;
using Test_OmegaPoint;

//Instantiate validitychecks.
IValidityChecker SSNFormChecker = new SSNFormatChecker();
IValidityChecker samNumFormChecker = new SamNumFormatChecker();
IValidityChecker orgNumFormChecker = new OrgNumFormatChecker();
NullorEmptyChecker nullorEmptyChecker = new NullorEmptyChecker();
StringPatternChecker patternChecker = new StringPatternChecker();
LuhnChecker luhnChecker = new LuhnChecker();

//Instantiate verifiers.
Verifier SSNVerifier = new Verifier(SSNFormChecker, nullorEmptyChecker, patternChecker, luhnChecker);
Verifier samNumVerifier = new Verifier(samNumFormChecker, nullorEmptyChecker, patternChecker, luhnChecker);
Verifier orgNumVerifier = new Verifier(orgNumFormChecker, nullorEmptyChecker, patternChecker, luhnChecker);


/* Simple code for asking and validating arbitrary strings as specified
SSN/Samordningsnummer/Organisationsnummer.*/
Console.WriteLine("Enter Social Security Number for validation:");
string? SSN = Console.ReadLine();
bool validSSN = SSNVerifier.Verify(SSN);

if (validSSN)
{
    Console.WriteLine($"Input: {SSN} is valid");
}
Console.WriteLine();

Console.WriteLine("Enter Co-ordnination Number for validation:");
string? SamNum = Console.ReadLine(); Console.ReadLine();
bool validSamNum = samNumVerifier.Verify(SamNum);
if (validSamNum)
{
    Console.WriteLine($"Input: {SamNum} is valid");
}
Console.WriteLine();


Console.WriteLine("Enter Organization Number for validation:");
string? OrgNum = Console.ReadLine(); Console.ReadLine();

bool validOrgNum = orgNumVerifier.Verify(OrgNum);
if (validOrgNum)
{
    Console.WriteLine($"Input: {OrgNum} is valid");
}

Console.ReadKey();



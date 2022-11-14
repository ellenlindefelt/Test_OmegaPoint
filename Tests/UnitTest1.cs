using Test_OmegaPoint;
namespace Tests;

public class Tests
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void TestNullorEmptyCheck()
    {
        IValidityChecker nullorEmptyChecker = new NullorEmptyChecker();
        Assert.True(nullorEmptyChecker.validityCheck("141206-2380"));
        Assert.True(nullorEmptyChecker.validityCheck("1"));

        Assert.False(nullorEmptyChecker.validityCheck(""));
        Assert.False(nullorEmptyChecker.validityCheck(null));

    }
    [Test]
    public void TestValidStringPattern()
    {
        IValidityChecker stringPatternChecker = new StringPatternChecker();
        Assert.True(stringPatternChecker.validityCheck("141206-2380"));
        Assert.True(stringPatternChecker.validityCheck("19141206-2380"));
        Assert.True(stringPatternChecker.validityCheck("141206+2380"));
        Assert.True(stringPatternChecker.validityCheck("191412062380"));
        Assert.True(stringPatternChecker.validityCheck("1412062380"));
        Assert.True(stringPatternChecker.validityCheck("556614-3185"));
        Assert.True(stringPatternChecker.validityCheck("16556601-6399"));
        Assert.True(stringPatternChecker.validityCheck("262000-1111"));
        Assert.True(stringPatternChecker.validityCheck("857202-7566"));
        Assert.True(stringPatternChecker.validityCheck("190910799824"));

        Assert.False(stringPatternChecker.validityCheck("119141206-2380"));
        Assert.False(stringPatternChecker.validityCheck("1"));
        Assert.False(stringPatternChecker.validityCheck("19141206x2380"));
        Assert.False(stringPatternChecker.validityCheck(""));
    }

    [Test]
    public void TestValidSSNFormat()
    {
        IValidityChecker SSNChecker = new SSNFormatChecker();
        Assert.True(SSNChecker.validityCheck("201701102384"));
        Assert.True(SSNChecker.validityCheck("141206-2380"));
        Assert.True(SSNChecker.validityCheck("20080903-2386"));
        Assert.True(SSNChecker.validityCheck("7101169295"));
        Assert.True(SSNChecker.validityCheck("198107249289"));
        Assert.True(SSNChecker.validityCheck("19021214-9819"));
        Assert.True(SSNChecker.validityCheck("190910199827"));
        Assert.True(SSNChecker.validityCheck("191006089807"));
        Assert.True(SSNChecker.validityCheck("192109099180"));
        Assert.True(SSNChecker.validityCheck("4607137454"));
        Assert.True(SSNChecker.validityCheck("194510168885"));
        Assert.True(SSNChecker.validityCheck("900118+9811"));
        Assert.True(SSNChecker.validityCheck("189102279800"));
        Assert.True(SSNChecker.validityCheck("201701102384"));
        Assert.True(SSNChecker.validityCheck("189912299816"));

        Assert.False(SSNChecker.validityCheck("179912299816"));
        Assert.False(SSNChecker.validityCheck("189912809816"));
        Assert.False(SSNChecker.validityCheck("190302299813"));
        Assert.False(SSNChecker.validityCheck("030229+9813"));
    }

    [Test]
    public void TestValidSamNumFormat()
    {
        IValidityChecker samNumChecker = new SamNumFormatChecker();
        Assert.True(samNumChecker.validityCheck("190910799824"));
        Assert.True(samNumChecker.validityCheck("0910799824"));
        Assert.True(samNumChecker.validityCheck("091079+9824"));


        Assert.False(samNumChecker.validityCheck("170910799824"));
        Assert.False(samNumChecker.validityCheck("190910599824"));
        Assert.False(samNumChecker.validityCheck("190910999824"));
        Assert.False(samNumChecker.validityCheck("190900799824"));
        Assert.False(samNumChecker.validityCheck("190913799824"));
    }

    [Test]
    public void TestValidOrgNumFormat()
    {
        IValidityChecker orgNumChecker = new OrgNumFormatChecker();
        Assert.True(orgNumChecker.validityCheck("556614-3185"));
        Assert.True(orgNumChecker.validityCheck("16556601-6399"));
        Assert.True(orgNumChecker.validityCheck("262000-1111"));
        Assert.True(orgNumChecker.validityCheck("857202-7566"));

        Assert.False(orgNumChecker.validityCheck("18556614-3185"));
        Assert.False(orgNumChecker.validityCheck("16551914-3185"));
        Assert.False(orgNumChecker.validityCheck("551914-3185"));
    }

    [Test]
    public void TestLuhnCheck()
    {
        IValidityChecker luhnChecker = new LuhnChecker();
        Assert.True(luhnChecker.validityCheck("556614-3185"));
        Assert.True(luhnChecker.validityCheck("16556601-6399"));
        Assert.True(luhnChecker.validityCheck("262000-1111"));
        Assert.True(luhnChecker.validityCheck("857202-7566"));
        Assert.True(luhnChecker.validityCheck("190910799824"));
        Assert.True(luhnChecker.validityCheck("201701102384"));
        Assert.True(luhnChecker.validityCheck("141206-2380"));
        Assert.True(luhnChecker.validityCheck("20080903-2386"));
        Assert.True(luhnChecker.validityCheck("7101169295"));
        Assert.True(luhnChecker.validityCheck("198107249289"));
        Assert.True(luhnChecker.validityCheck("19021214-9819"));
        Assert.True(luhnChecker.validityCheck("190910199827"));
        Assert.True(luhnChecker.validityCheck("191006089807"));
        Assert.True(luhnChecker.validityCheck("192109099180"));
        Assert.True(luhnChecker.validityCheck("4607137454"));
        Assert.True(luhnChecker.validityCheck("194510168885"));
        Assert.True(luhnChecker.validityCheck("900118+9811"));
        Assert.True(luhnChecker.validityCheck("189102279800"));
        Assert.True(luhnChecker.validityCheck("201701102384"));
        Assert.True(luhnChecker.validityCheck("189912299816"));

        Assert.False(luhnChecker.validityCheck("556614-3187"));
        Assert.False(luhnChecker.validityCheck("190910799826"));
        Assert.False(luhnChecker.validityCheck("201701272394"));
    }

    [Test]
    public void TestSSNVerifier()
    {
        Verifier SSNVerifier = new Verifier(new SSNFormatChecker(), new NullorEmptyChecker(), new StringPatternChecker(), new LuhnChecker());
        Assert.True(SSNVerifier.Verify("201701102384"));
        Assert.True(SSNVerifier.Verify("141206-2380"));
        Assert.True(SSNVerifier.Verify("20080903-2386"));
        Assert.True(SSNVerifier.Verify("7101169295"));
        Assert.True(SSNVerifier.Verify("198107249289"));
        Assert.True(SSNVerifier.Verify("19021214-9819"));
        Assert.True(SSNVerifier.Verify("190910199827"));
        Assert.True(SSNVerifier.Verify("191006089807"));
        Assert.True(SSNVerifier.Verify("192109099180"));
        Assert.True(SSNVerifier.Verify("4607137454"));
        Assert.True(SSNVerifier.Verify("194510168885"));
        Assert.True(SSNVerifier.Verify("900118+9811"));
        Assert.True(SSNVerifier.Verify("189102279800"));
        Assert.True(SSNVerifier.Verify("201701102384"));
        Assert.True(SSNVerifier.Verify("189912299816"));

        Assert.False(SSNVerifier.Verify("201701272394"));
        Assert.False(SSNVerifier.Verify("190302299813"));
        Assert.False(SSNVerifier.Verify(""));
        Assert.False(SSNVerifier.Verify("171701102384"));
        Assert.False(SSNVerifier.Verify("20170110x2384"));
        Assert.False(SSNVerifier.Verify("201702384"));
        Assert.False(SSNVerifier.Verify("20171310-2384"));
        
    }

    [Test]
    public void TestSamNumVerifier()
    {
        Verifier SamNumVerifier = new Verifier(new SamNumFormatChecker(), new NullorEmptyChecker(), new StringPatternChecker(), new LuhnChecker());
        Assert.True(SamNumVerifier.Verify("190910799824"));
        Assert.True(SamNumVerifier.Verify("19091079-9824"));
        Assert.True(SamNumVerifier.Verify("091079-9824"));
        Assert.True(SamNumVerifier.Verify("0910799824"));
        Assert.True(SamNumVerifier.Verify("091079+9824"));

        Assert.False(SamNumVerifier.Verify(""));
        Assert.False(SamNumVerifier.Verify(null));
        Assert.False(SamNumVerifier.Verify("170910799824"));
        Assert.False(SamNumVerifier.Verify("190910599824"));
        Assert.False(SamNumVerifier.Verify("190910999824"));
        Assert.False(SamNumVerifier.Verify("190900799824"));
        Assert.False(SamNumVerifier.Verify("190913799824"));
        Assert.False(SamNumVerifier.Verify("190910799827"));
        Assert.False(SamNumVerifier.Verify("19091799824"));
        Assert.False(SamNumVerifier.Verify("19091379x9824"));
    }

    [Test]
    public void TestOrgNumVerifier()
    {
        Verifier OrgNumVerifier = new Verifier(new OrgNumFormatChecker(), new NullorEmptyChecker(), new StringPatternChecker(), new LuhnChecker());
        Assert.True(OrgNumVerifier.Verify("556614-3185"));
        Assert.True(OrgNumVerifier.Verify("16556601-6399"));
        Assert.True(OrgNumVerifier.Verify("262000-1111"));
        Assert.True(OrgNumVerifier.Verify("857202-7566"));

        Assert.False(OrgNumVerifier.Verify("857202-7567"));
        Assert.False(OrgNumVerifier.Verify(""));
        Assert.False(OrgNumVerifier.Verify(null));
        Assert.False(OrgNumVerifier.Verify("857202x7566"));
        Assert.False(OrgNumVerifier.Verify("857202-7"));
        Assert.False(OrgNumVerifier.Verify("19857202-7566"));
        Assert.False(OrgNumVerifier.Verify("850202-7566"));


    }

}
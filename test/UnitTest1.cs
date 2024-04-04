using ISO8601DurationClassLib;

namespace ISO8601Duration_UnitTests;

[TestClass]
public class UnitTest1
{
    [TestMethod]
    public void TestMethod1()
    {
        var duration = new ISO8601Duration("PT2S");
        var now = DateTime.Now;
        Assert.AreEqual(now.Add(TimeSpan.FromSeconds(2)), now.Add(duration));
    }

    [TestMethod]
    public void TestMethod2()
    {
        var duration = new ISO8601Duration("PT2M");
        var now = DateTime.Now;
        Assert.AreEqual(now.Add(TimeSpan.FromMinutes(2)), now.Add(duration));
    }

    [TestMethod]
    public void TestMethod3()
    {
        var duration = new ISO8601Duration("P1W");
        var now = DateTime.Now;
        Assert.AreEqual(now.Add(TimeSpan.FromDays(7)), now.Add(duration));
    }

    [TestMethod]
    public void TestMethod4()
    {
        var duration = new ISO8601Duration("P5D");
        var now = DateTime.Now;
        Assert.AreEqual(now.Add(TimeSpan.FromDays(5)), now.Add(duration));
    }

    [DataTestMethod]
    [DataRow("P1M", "2024/01/01", "2024/02/01")]
    [DataRow("P2M", "2024/01/01", "2024/03/01")]
    [DataRow("P12M", "2024/01/01", "2025/01/01")]
    [DataRow("P1Y2M3DT4H5M6S", "2024/01/01", "3/4/2025 4:05:06 AM")]
    public void TestMethod5(string duration, string startDate, string endDate)
    {
        new ISO8601Duration(duration);
        Assert.AreEqual(DateTime.Parse(startDate).Add(new ISO8601Duration(duration)), DateTime.Parse(endDate));
    }
}
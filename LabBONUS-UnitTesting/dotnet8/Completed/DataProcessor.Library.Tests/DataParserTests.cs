namespace DataProcessor.Library.Tests;

public class DataParserTests
{
    //private DataParser GetParserWithFakeLogger()
    //{
    //    var logger = new FakeLogger();
    //    return new DataParser(logger);
    //}

    private DataParser GetParserWithFakeLogger() => new DataParser(new FakeLogger());

    [Test]
    public async Task ParseData_WithMixedData_ReturnsGoodRecords()
    {
        // Arrange
        var parser = GetParserWithFakeLogger();

        // Act
        var records = await parser.ParseData(TestData.Data);

        // Assert
        Assert.That(records.Count, Is.EqualTo(9));
    }

    [Test]
    public async Task ParseData_WithGoodRecord_ReturnsOneRecord()
    {
        var parser = GetParserWithFakeLogger();

        var records = await parser.ParseData(TestData.GoodRecord);

        Assert.That(records.Count, Is.EqualTo(1));
    }

    [Test]
    public async Task ParseData_WithBadRecord_ReturnsZeroRecords()
    {
        var parser = GetParserWithFakeLogger();

        var records = await parser.ParseData(TestData.BadRecord);

        Assert.That(records.Count, Is.EqualTo(0));
    }

    [Test]
    public async Task ParseData_WithBadStartDate_ReturnsZeroRecords()
    {
        var parser = GetParserWithFakeLogger();

        var records = await parser.ParseData(TestData.BadStartDate);

        Assert.That(records.Count, Is.EqualTo(0));
    }

    [Test]
    public async Task ParseData_WithBadRating_ReturnsZeroRecords()
    {
        var parser = GetParserWithFakeLogger();

        var records = await parser.ParseData(TestData.BadRating);

        Assert.That(records.Count, Is.EqualTo(0));
    }
}
using NUnit.Framework;
using QMAPP.src;

namespace QMAPP.Tests;

public class WeightTests
{
    [Test]
    public void Given0KgAnd0Kg_WhenCompared_ShouldReturnEqual()
    {
        var kg1 = new Quantity<WeightUnit>(0.0, WeightUnit.KILOGRAM);
        var kg2 = new Quantity<WeightUnit>(0.0, WeightUnit.KILOGRAM);
        Assert.That(kg1, Is.EqualTo(kg2));
    }

    [Test]
    public void Given1KgAnd1000Gram_WhenCompared_ShouldReturnEqual()
    {
        var kg = new Quantity<WeightUnit>(1.0, WeightUnit.KILOGRAM);
        var gram = new Quantity<WeightUnit>(1000.0, WeightUnit.GRAM);
        Assert.That(kg, Is.EqualTo(gram));
    }

    [Test]
    public void Given1PoundAnd0_453592Kg_WhenCompared_ShouldReturnEqual()
    {
        var pound = new Quantity<WeightUnit>(1.0, WeightUnit.POUND);
        var kg = new Quantity<WeightUnit>(0.453592, WeightUnit.KILOGRAM);
        Assert.That(pound, Is.EqualTo(kg));
    }

    [Test]
    public void Given1KgAnd1Kg_WhenAdded_ShouldReturn2Kg()
    {
        var kg1 = new Quantity<WeightUnit>(1.0, WeightUnit.KILOGRAM);
        var kg2 = new Quantity<WeightUnit>(1.0, WeightUnit.KILOGRAM);
        var result = kg1.Add(kg2);
        Assert.That(result, Is.EqualTo(new Quantity<WeightUnit>(2.0, WeightUnit.KILOGRAM)));
    }

    [Test]
    public void Given1PoundAnd0_453592Kg_WhenAdded_ShouldReturn0_907184Kg()
    {
        var pound = new Quantity<WeightUnit>(1.0, WeightUnit.POUND);
        var kg = new Quantity<WeightUnit>(0.453592, WeightUnit.KILOGRAM);
        var result = pound.Add(kg, WeightUnit.KILOGRAM);
        Assert.That(result, Is.EqualTo(new Quantity<WeightUnit>(0.907184, WeightUnit.KILOGRAM)));
    }

    [Test]
    public void Given2KgAnd1Kg_WhenSubtracted_ShouldReturn1Kg()
    {
        var kg1 = new Quantity<WeightUnit>(2.0, WeightUnit.KILOGRAM);
        var kg2 = new Quantity<WeightUnit>(1.0, WeightUnit.KILOGRAM);
        var result = kg1.Sub(kg2);
        Assert.That(result, Is.EqualTo(new Quantity<WeightUnit>(1.0, WeightUnit.KILOGRAM)));
    }

    [Test]
    public void Given4KgAnd2Kg_WhenDivided_ShouldReturn2Kg()
    {
        var kg1 = new Quantity<WeightUnit>(4.0, WeightUnit.KILOGRAM);
        var kg2 = new Quantity<WeightUnit>(2.0, WeightUnit.KILOGRAM);
        var result = kg1.Div(kg2);
        Assert.That(result, Is.EqualTo(new Quantity<WeightUnit>(2.0, WeightUnit.KILOGRAM)));
    }
}

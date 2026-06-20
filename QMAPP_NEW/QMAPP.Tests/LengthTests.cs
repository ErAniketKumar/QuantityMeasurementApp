using NUnit.Framework;
using QMAPP.src;

namespace QMAPP.Tests;

public class LengthTests
{
    [Test]
    public void Given0FeetAnd0Feet_WhenCompared_ShouldReturnEqual()
    {
        var feet1 = new Quantity<LengthUnit>(0.0, LengthUnit.FEET);
        var feet2 = new Quantity<LengthUnit>(0.0, LengthUnit.FEET);
        Assert.That(feet1, Is.EqualTo(feet2));
    }

    [Test]
    public void Given0FeetAnd0Inch_WhenCompared_ShouldReturnEqual()
    {
        var feet = new Quantity<LengthUnit>(0.0, LengthUnit.FEET);
        var inch = new Quantity<LengthUnit>(0.0, LengthUnit.INCH);
        Assert.That(feet, Is.EqualTo(inch));
    }

    [Test]
    public void Given1FeetAnd1Inch_WhenCompared_ShouldNotReturnEqual()
    {
        var feet = new Quantity<LengthUnit>(1.0, LengthUnit.FEET);
        var inch = new Quantity<LengthUnit>(1.0, LengthUnit.INCH);
        Assert.That(feet, Is.Not.EqualTo(inch));
    }

    [Test]
    public void Given1InchAnd1Feet_WhenCompared_ShouldNotReturnEqual()
    {
        var inch = new Quantity<LengthUnit>(1.0, LengthUnit.INCH);
        var feet = new Quantity<LengthUnit>(1.0, LengthUnit.FEET);
        Assert.That(inch, Is.Not.EqualTo(feet));
    }

    [Test]
    public void Given1FeetAnd12Inch_WhenCompared_ShouldReturnEqual()
    {
        var feet = new Quantity<LengthUnit>(1.0, LengthUnit.FEET);
        var inch = new Quantity<LengthUnit>(12.0, LengthUnit.INCH);
        Assert.That(feet, Is.EqualTo(inch));
    }

    [Test]
    public void Given12InchAnd1Feet_WhenCompared_ShouldReturnEqual()
    {
        var inch = new Quantity<LengthUnit>(12.0, LengthUnit.INCH);
        var feet = new Quantity<LengthUnit>(1.0, LengthUnit.FEET);
        Assert.That(inch, Is.EqualTo(feet));
    }

    [Test]
    public void Given3FeetAnd1Yard_WhenCompared_ShouldReturnEqual()
    {
        var feet = new Quantity<LengthUnit>(3.0, LengthUnit.FEET);
        var yard = new Quantity<LengthUnit>(1.0, LengthUnit.YARDS);
        Assert.That(feet, Is.EqualTo(yard));
    }

    [Test]
    public void Given1YardAnd3Feet_WhenCompared_ShouldReturnEqual()
    {
        var yard = new Quantity<LengthUnit>(1.0, LengthUnit.YARDS);
        var feet = new Quantity<LengthUnit>(3.0, LengthUnit.FEET);
        Assert.That(yard, Is.EqualTo(feet));
    }

    [Test]
    public void Given1YardAnd36Inch_WhenCompared_ShouldReturnEqual()
    {
        var yard = new Quantity<LengthUnit>(1.0, LengthUnit.YARDS);
        var inch = new Quantity<LengthUnit>(36.0, LengthUnit.INCH);
        Assert.That(yard, Is.EqualTo(inch));
    }

    [Test]
    public void Given36InchAnd1Yard_WhenCompared_ShouldReturnEqual()
    {
        var inch = new Quantity<LengthUnit>(36.0, LengthUnit.INCH);
        var yard = new Quantity<LengthUnit>(1.0, LengthUnit.YARDS);
        Assert.That(inch, Is.EqualTo(yard));
    }

    [Test]
    public void Given1YardAnd1Yard_WhenCompared_ShouldReturnEqual()
    {
        var yard1 = new Quantity<LengthUnit>(1.0, LengthUnit.YARDS);
        var yard2 = new Quantity<LengthUnit>(1.0, LengthUnit.YARDS);
        Assert.That(yard1, Is.EqualTo(yard2));
    }

    [Test]
    public void Given2InchAnd5_08Centimeter_WhenCompared_ShouldReturnEqual()
    {
        var inch = new Quantity<LengthUnit>(2.0, LengthUnit.INCH);
        var cm = new Quantity<LengthUnit>(5.08, LengthUnit.CENTIMETER);
        Assert.That(inch, Is.EqualTo(cm));
    }

    [Test]
    public void Given2InchAnd2Inch_WhenAdded_ShouldReturn4Inch()
    {
        var inch1 = new Quantity<LengthUnit>(2.0, LengthUnit.INCH);
        var inch2 = new Quantity<LengthUnit>(2.0, LengthUnit.INCH);
        var result = inch1.Add(inch2);
        Assert.That(result, Is.EqualTo(new Quantity<LengthUnit>(4.0, LengthUnit.INCH)));
    }

    [Test]
    public void Given1FeetAnd2Inch_WhenAdded_ShouldReturn14Inch()
    {
        var feet = new Quantity<LengthUnit>(1.0, LengthUnit.FEET);
        var inch = new Quantity<LengthUnit>(2.0, LengthUnit.INCH);
        var result = feet.Add(inch, LengthUnit.INCH);
        Assert.That(result, Is.EqualTo(new Quantity<LengthUnit>(14.0, LengthUnit.INCH)));
    }

    [Test]
    public void Given1FeetAnd1Feet_WhenAdded_ShouldReturn24Inch()
    {
        var feet1 = new Quantity<LengthUnit>(1.0, LengthUnit.FEET);
        var feet2 = new Quantity<LengthUnit>(1.0, LengthUnit.FEET);
        var result = feet1.Add(feet2, LengthUnit.INCH);
        Assert.That(result, Is.EqualTo(new Quantity<LengthUnit>(24.0, LengthUnit.INCH)));
    }

    [Test]
    public void Given2InchAnd2_54Centimeter_WhenAdded_ShouldReturn3Inch()
    {
        var inch = new Quantity<LengthUnit>(2.0, LengthUnit.INCH);
        var cm = new Quantity<LengthUnit>(2.54, LengthUnit.CENTIMETER);
        var result = inch.Add(cm, LengthUnit.INCH);
        Assert.That(result, Is.EqualTo(new Quantity<LengthUnit>(3.0, LengthUnit.INCH)));
    }

    [Test]
    public void Given2FeetAnd1Feet_WhenSubtracted_ShouldReturn1Feet()
    {
        var feet1 = new Quantity<LengthUnit>(2.0, LengthUnit.FEET);
        var feet2 = new Quantity<LengthUnit>(1.0, LengthUnit.FEET);
        var result = feet1.Sub(feet2);
        Assert.That(result, Is.EqualTo(new Quantity<LengthUnit>(1.0, LengthUnit.FEET)));
    }

    [Test]
    public void Given2FeetAnd1Feet_WhenDivided_ShouldReturn2Feet()
    {
        var feet1 = new Quantity<LengthUnit>(2.0, LengthUnit.FEET);
        var feet2 = new Quantity<LengthUnit>(1.0, LengthUnit.FEET);
        var result = feet1.Div(feet2);
        Assert.That(result, Is.EqualTo(new Quantity<LengthUnit>(2.0, LengthUnit.FEET)));
    }
}

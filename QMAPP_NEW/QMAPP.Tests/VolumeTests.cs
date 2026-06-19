using NUnit.Framework;
using QMAPP.src;

namespace QMAPP.Tests;

public class VolumeTests
{
    [Test]
    public void Given0LitreAnd0Litre_WhenCompared_ShouldReturnEqual()
    {
        var l1 = new Quantity<VolumeUnit>(0.0, VolumeUnit.LITRES);
        var l2 = new Quantity<VolumeUnit>(0.0, VolumeUnit.LITRES);
        Assert.That(l1, Is.EqualTo(l2));
    }

    [Test]
    public void Given1LitreAnd1000MilliLitre_WhenCompared_ShouldReturnEqual()
    {
        var l1 = new Quantity<VolumeUnit>(1.0, VolumeUnit.LITRES);
        var ml1 = new Quantity<VolumeUnit>(1000.0, VolumeUnit.MILLILITRES);
        Assert.That(l1, Is.EqualTo(ml1));
    }

    [Test]
    public void Given1GallonAnd3_78541Litres_WhenCompared_ShouldReturnEqual()
    {
        var gallon = new Quantity<VolumeUnit>(1.0, VolumeUnit.GALLON);
        var litre = new Quantity<VolumeUnit>(3.78541, VolumeUnit.LITRES);
        Assert.That(gallon, Is.EqualTo(litre));
    }

    [Test]
    public void Given1LitreAnd1Litre_WhenAdded_ShouldReturn2Litre()
    {
        var l1 = new Quantity<VolumeUnit>(1.0, VolumeUnit.LITRES);
        var l2 = new Quantity<VolumeUnit>(1.0, VolumeUnit.LITRES);
        var result = l1.Add(l2);
        Assert.That(result, Is.EqualTo(new Quantity<VolumeUnit>(2.0, VolumeUnit.LITRES)));
    }

    [Test]
    public void Given1GallonAnd3_78541Litres_WhenAdded_ShouldReturn7_57082Litres()
    {
        var gallon = new Quantity<VolumeUnit>(1.0, VolumeUnit.GALLON);
        var litre = new Quantity<VolumeUnit>(3.78541, VolumeUnit.LITRES);
        var result = gallon.Add(litre, VolumeUnit.LITRES);
        Assert.That(result, Is.EqualTo(new Quantity<VolumeUnit>(7.57082, VolumeUnit.LITRES)));
    }

    [Test]
    public void Given2LitreAnd1Litre_WhenSubtracted_ShouldReturn1Litre()
    {
        var l1 = new Quantity<VolumeUnit>(2.0, VolumeUnit.LITRES);
        var l2 = new Quantity<VolumeUnit>(1.0, VolumeUnit.LITRES);
        var result = l1.Sub(l2);
        Assert.That(result, Is.EqualTo(new Quantity<VolumeUnit>(1.0, VolumeUnit.LITRES)));
    }

    [Test]
    public void Given4LitreAnd2Litre_WhenDivided_ShouldReturn2Litre()
    {
        var l1 = new Quantity<VolumeUnit>(4.0, VolumeUnit.LITRES);
        var l2 = new Quantity<VolumeUnit>(2.0, VolumeUnit.LITRES);
        var result = l1.Div(l2);
        Assert.That(result, Is.EqualTo(new Quantity<VolumeUnit>(2.0, VolumeUnit.LITRES)));
    }
}

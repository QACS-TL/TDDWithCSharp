using QL2CarAgeIdentifier;

namespace QL2CarAgeIdentifierTests
{
    public class AgeIdentifierTests
    {
        [Fact]
        public void March2005_ReturnsSeptember2005()
        {
            Assert.Equal("55", AgeIdentifier.GetNext("05"));
        }

        [Fact]
        public void September2005_ReturnsMarch2006()
        {
            Assert.Equal("06", AgeIdentifier.GetNext("55"));
        }

        [Fact]
        public void September2027_ReturnsMarch2028()
        {
            Assert.Equal("28", AgeIdentifier.GetNext("77"));
        }

        [Fact]
        public void March2028_ReturnsSeptember2028()
        {
            Assert.Equal("78", AgeIdentifier.GetNext("28"));
        }

        [Fact]
        public void InvalidInput_ThrowsFormatException()
        {
            Assert.Throws<FormatException>( () => AgeIdentifier.GetNext("XYZ"));
        }
    }
}
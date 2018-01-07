using FluentAssertions;
using microObjectPizzaShop.Library;

namespace MicroObjectPizzaShop {
    public class TestWriteString : IWriteString
    {
        private string _value;

        public void Write(string value) => _value = value;

        public void AssertValueIs(string expected) => _value.Should().Be(expected);
    }
}
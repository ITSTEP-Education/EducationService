using AspNetWeb_NLayer.DAL.Entities;
using System.Collections;

namespace AspNetWeb_NLayer.DAL.Tests.Entities
{
    public class ProductItemTestData : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[] { "c++",
                new ProductItem() {
                    id = 1,
                    name = "c++",
                    description = "low-level language",
                    typeEngeeniring = "back-end",
                    durationMonth = 12,
                    price = 2000 } };

            yield return new object[] { "css",
                new ProductItem() {
                    id = 7,
                    name = "css",
                    description = "none",
                    typeEngeeniring = "front-end",
                    durationMonth = 4,
                    price = 500 } };
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}

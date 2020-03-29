using System;
using System.Collections.Generic;

namespace Infrastructure
{
    public interface IHasProducts<T>
        where T:GeneralProduct
    {
        List<T> Products { get; }
        T GetProductBy(Uri uri);
    }
}
